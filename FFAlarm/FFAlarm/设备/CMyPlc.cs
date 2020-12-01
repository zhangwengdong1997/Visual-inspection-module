using LS_CLASS;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FFAlarm
{
    class CMyPlc
    {
        SerialPort serialPort = null;

        Thread workThread = null;
        public Dictionary<string, byte> InNum = new Dictionary<string, byte>();
        public Dictionary<string, byte> OutNum = new Dictionary<string, byte>();
        
        private void DictionaryInit()
        {
            InNum.Add("无", 0x00);
            InNum.Add("X0", 0x01);
            InNum.Add("X1", 0x02);
            InNum.Add("X2", 0x04);
            InNum.Add("X3", 0x08);
            InNum.Add("X4", 0x10);
            InNum.Add("X5", 0x20);
            InNum.Add("X6", 0x40);
            InNum.Add("X7", 0x80);
            OutNum.Add("无", 0x00);
            OutNum.Add("Y0", 0x01);
            OutNum.Add("Y1", 0x02);
            OutNum.Add("Y2", 0x04);
            OutNum.Add("Y3", 0x08);
            OutNum.Add("Y4", 0x10);
            OutNum.Add("Y5", 0x20);
            OutNum.Add("Y6", 0x40);
            OutNum.Add("Y7", 0x80);
        }
        
        public string strErrorMsg
        {
            get; private set;
        } = "";

        /// <summary>
        /// -1未运行，0停止，1运行
        /// </summary>
        int nState = -1;


        /// <summary>
        /// 消息队列,由外部写入
        /// </summary>
        private Queue<byte[]> queueMsg = new Queue<byte[]>();

        private object lockQueue = new object();

        /// <summary>
        /// 往PLC里进行写入数据，适用于不需要返回值的情况（如报警）
        /// </summary>
        /// <param name="Msg"></param>
        public void AddMsg(byte[] Msg)
        {
            lock (lockQueue)
            {
                queueMsg.Enqueue(Msg);
            }
        }

        /// <summary>
        /// 开始运行
        /// </summary>
        /// <param name="strCom">COM口</param>
        /// <param name="baudRate">波特率</param>
        /// <param name="parity">奇偶校验</param>
        /// <param name="dataBits">停止位</param>
        /// <returns></returns>
        public bool Start(string strCom, int baudRate, Parity parity, int dataBits)
        {
            if (nState != -1)
            {
                if (nState == 0)
                    nState = 1;
                strErrorMsg = "";
                return false;
            }
            DictionaryInit();
            try
            {
                serialPort = new SerialPort(strCom, baudRate, parity, dataBits);
                serialPort.Open();
            }
            catch (Exception err)
            {
                strErrorMsg = err.Message;
                return false;
            }
            nState = 1;
            workThread = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        if (nState == 0)
                        {
                            Thread.Sleep(50);
                            continue;
                        }
                        
                        if (queueMsg.Count > 0)//写入外部输入的数据，并清空缓冲区（不需要接收回复）
                        {
                            lock (lockQueue)
                            {
                                foreach (byte[] buf in queueMsg)
                                {
                                    serialPort.Write(buf, 0, buf.Length);
                                    Thread.Sleep(80);
                                }
                                queueMsg.Clear();
                            }
                        }

                        serialPort.DiscardOutBuffer();
                        if (serialPort.BytesToRead == 0)
                        {
                            Thread.Sleep(50);
                            continue;
                        }
                        Thread.Sleep(50);//方便起见，隔50MS直接全读完

                        byte[] buff = new byte[serialPort.BytesToRead];
                        serialPort.Read(buff, 0, buff.Length);

                        LogHelper.WriteLog(string.Format("收到串口消息:{0},长度{1}", Encoding.ASCII.GetString(buff),
                            Encoding.ASCII.GetString(buff).Length));
                        bool bStart = false;
                        bool bEnd = false;
                        string strData = "";
                        byte[] data = new byte[buff.Length];
                        int nDataIndex = 0;
                        for (int i = 0; i < buff.Length; i++)
                        {
                            if (buff[i] == 0x55 && !bStart)
                            {
                                data[nDataIndex] = buff[i];
                                nDataIndex++;
                                bStart = true;
                                continue;
                            }
                            if (buff[i] == 0xaa && bStart)
                            {
                                data[nDataIndex] = buff[i];
                                nDataIndex++;
                                bEnd = true;
                                break;
                            }

                            if (bStart)
                            {
                                data[nDataIndex] = buff[i];
                                nDataIndex++;
                            }
                        }
                        if (bStart && bEnd)
                        {
                            RecvData?.Invoke(null, data[1]);

                        }
                    }
                    catch (Exception err)
                    {
                        LogHelper.WriteLog("串口读写异常", err);
                    }

                }

            })
            { IsBackground = true };

            workThread.Start();
            return true;

        }

        public void Stop()
        {
            nState = 0;
        }
        /// <summary>
        /// 当PLC接收到指定数据时触发
        /// </summary>
        public event EventHandler<byte> RecvData;


    }
}
