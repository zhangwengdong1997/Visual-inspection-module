using FFAlarm.Properties;
using LS_CLASS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FFAlarm
{
    class MyRun
    {
        static CMyPlc myPlc;

        static Thread runThread;
        /// <summary>
        /// 发送运行中的一些信息
        /// </summary>
        public static event EventHandler<string> SendMsg;
        /// <summary>
        /// 检测信号
        /// </summary>
        static EventWaitHandle CheckSignal = null;
        /// <summary>
        /// 运行状态 -1：未初始化，0：暂停，1：运行
        /// </summary>
        static int nState = -1;

        /// <summary>
        /// 发送设备连接的信息
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="state"></param>
        public delegate void OnConnectState(int nId, string state);
        public static event OnConnectState ConnectState;
        public static void Init()
        {
            if (nState != -1)
                return;
            if (CheckSignal != null)
                return;
            CheckSignal = new EventWaitHandle(false, EventResetMode.ManualReset, "__检测信号__");
            if (EventWaitHandle.TryOpenExisting("__检测信号__", out CheckSignal) == false)
            {
                LogHelper.WriteLog("_检测信号__内核异常");
                SendMsg?.Invoke(null, "内核异常");
            }

            //连接PLC
            myPlc = new CMyPlc();
            string com = Settings.Default.COM;
            if (myPlc.Start(com, 9600, System.IO.Ports.Parity.None, 8))
            {
                ConnectState?.Invoke(1, "PLC连接成功");
            }
            else
            {
                ConnectState?.Invoke(2, "PLC连接失败");
            }
            //连接视觉模块


            myPlc.RecvData += MyPlc_RecvData;

            runThread = new Thread(WorkFun)
            {
                IsBackground = true
            };
            runThread.Start();

        }

        private static void MyPlc_RecvData(object sender, byte e)
        {
            Dictionary<string, byte> InNum = new Dictionary<string, byte>();
            InNum.Add("X0", 0x01);
            InNum.Add("X1", 0x02);
            InNum.Add("X2", 0x04);
            InNum.Add("X3", 0x08);
            InNum.Add("X4", 0x10);
            InNum.Add("X5", 0x20);
            InNum.Add("X6", 0x40);
            InNum.Add("X7", 0x80);
            string IN= Settings.Default.CheckIN;
            if (e.Equals(InNum[IN]))
            {
                CheckSignal.Set();
            }
        }

        public static void WorkFun()
        {
            DateTime t = DateTime.Now;
            while (true)
            {
                if (DateTime.Now - t >= new TimeSpan(1, 0, 0, 0))
                {
                    t = DateTime.Now;
                    //删除图片
                    ClearImage("OK", Settings.Default.OKSaveTime);
                    ClearImage("NG", Settings.Default.NGSaveTime);

                }
                if (CheckSignal.WaitOne(100) == false)
                    continue;
                if (nState != 1)
                {
                    CheckSignal.Reset();
                    continue;
                }
                Test();
                CheckSignal.Reset();
            }
        }
        public static void StopRun()
        {
            nState = 0;
            SendMsg?.Invoke(null, "停止检测");
        }
        public static void StartRun()
        {
            nState = 1;
            SendMsg?.Invoke(null, "开始检测");
        }
        public static void check()
        {
            CheckSignal.Set();
            SendMsg?.Invoke(null, "手动检测");
        }
        public static void Test() { }
        public static void WritePLC(byte message)
        {
            byte[] Data = { 0x8F, message, 0x7f };
            myPlc.AddMsg(Data);
        }

        public static void ClearImage(string path, int day)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            DirectoryInfo[] directories = dir.GetDirectories();

            foreach (var item in directories)
            {
                string[] a = item.Name.Split('-');
                if (a.Length == 3)
                {
                    DateTime dateTime = new DateTime(
                        int.Parse(item.Name.Split('-')[0]), 
                        int.Parse(item.Name.Split('-')[1]), 
                        int.Parse(item.Name.Split('-')[2]));
                    if (DateTime.Now - dateTime > new TimeSpan(day, 0, 0, 0))
                    {
                        DeleteFiles(item.FullName);
                    }
                }
            }
        }

        public static bool DeleteFiles(string path)
        {
            if (Directory.Exists(path) == false)
            {
                return false;
            }
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles();
            try
            {
                foreach (var item in files)
                {
                    File.Delete(item.FullName);
                }
                if (dir.GetDirectories().Length != 0)
                {
                    foreach (var item in dir.GetDirectories())
                    {
                        if (!item.ToString().Contains("$") && (!item.ToString().Contains("Boot")))
                        {
                            DeleteFiles(dir.ToString() + "\\" + item.ToString());
                        }
                    }
                }
                Directory.Delete(path);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

}

