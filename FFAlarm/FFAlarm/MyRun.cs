using FFAlarm.Properties;
using LS_CLASS;
using LS_VisionMod;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public static int nState { get; private set; } = -1;

        public static event EventHandler<string> ResultMsg;

        /// <summary>
        /// 发送设备连接的信息
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="state"></param>
        public delegate void OnConnectState(int nId, string state);
        public static event OnConnectState ConnectState;

        public static string modelName;

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
            

            myPlc.RecvData += MyPlc_RecvData;

            //连接视觉模块
            if (VisinoMod.Connect())
            {
                ConnectState?.Invoke(3, "相机连接成功");
            }
            else
            {
                ConnectState?.Invoke(4, "相机连接失败");

            }

            VisinoMod.DetectionOnceEvent += VisinoMod_DetectionOnceEvent;
            runThread = new Thread(WorkFun)
            {
                IsBackground = true
            };
            runThread.Start();

        }
        static HashSet<string> item = new HashSet<string>();
        private static void VisinoMod_DetectionOnceEvent(object sender, DetectionResult e)
        {
            if (item.Count == 0)
            {
                ResultMsg.Invoke(null, null);
            }
            string[] result = e.outMessage.Split('@');
            ResultMsg.Invoke(null, "\r\n[" + result[0] + "]: " + result[1] + "\r\n");
            if (result[1].Equals("NG"))
            {
                TreatNG(e.ho_outImage.CopyObj(1, -1));
                item.Add(result[0]);
            }
            if (result[1].Equals("OK"))
            {
                item.Add(result[0]);
            }
            if(item.Count == VisinoMod.TestItemNumber())
            {
                TreatOK(e.ho_outImage.CopyObj(1, -1));
                item.Clear();
            }
        }


        public static List<string> GetModeNameList()
        {
            return VisinoMod.ModelNameList;
        }
        private static void MyPlc_RecvData(object sender, byte e)
        {
            string IN= Settings.Default.CheckIN;
            if (e.Equals(myPlc.InNum[IN]))
            {
                DateTime time = DateTime.Now;
                //VisinoMod.PrepareModel(modelName);
                while(DateTime.Now.Subtract(time).TotalMilliseconds < Settings.Default.Delay)
                {
                    Thread.Sleep(20);
                }
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
                    //删除图片
                    ClearImage(Application.StartupPath + "\\OK", Settings.Default.OKSaveTime);
                    ClearImage(Application.StartupPath + "\\NG", Settings.Default.NGSaveTime);

                }
                if(nState == 1)
                {
                    //VisinoMod.TriggerCamera();
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
            throw new Exception();
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
        public static void Test() 
        {
            item.Clear();
            VisinoMod.stopDetectionSignal.Set();
            VisinoMod.TriggerDetection2();

        }
        public static void PrepareModel(string modelName)
        {
            VisinoMod.PrepareModel(modelName);
        }
        public static void WritePLC(byte message)
        {
            byte[] Data = { 0x8F, message, 0x7f };
            myPlc.AddMsg(Data);
        }
        private static void TreatNG(object image)
        {
            new Thread(() =>
            {
                string OUT = Settings.Default.NGOut;
                Thread.Sleep(Settings.Default.Duration);
                WritePLC(myPlc.OutNum[OUT]);
                Thread.Sleep(200);
                WritePLC(myPlc.OutNum["无"]);
                string t = DateTime.Now.ToString("yyyy-MM-dd");
                string path = Application.StartupPath + "\\NG\\" + t;
                Directory.CreateDirectory(path);
                VisinoMod.SaveImage(image, path, DateTime.Now.ToString("HH-mm-ss") + ".jpg");
            })
            { IsBackground = true }.Start();

        }
        private static void TreatOK(object image)
        {
            new Thread(() =>
            {
                string OUT = Settings.Default.OKOut;
                WritePLC(myPlc.OutNum[OUT]);
                Thread.Sleep(Settings.Default.Duration);
                WritePLC(myPlc.OutNum["无"]);
                string t = DateTime.Now.ToString("yyyy-MM-dd");
                string path = Application.StartupPath + "\\OK\\" + t;
                Directory.CreateDirectory(path);
                VisinoMod.SaveImage(image,path, DateTime.Now.ToString("HH-mm-ss") + ".jpg");

            })
            { IsBackground = true }.Start();
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

