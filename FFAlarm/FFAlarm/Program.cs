using LS_CLASS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFAlarm
{
    static class Program
    {
        private static EventWaitHandle OpenSignal = null;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            OpenSignal = new EventWaitHandle(false, EventResetMode.ManualReset, "__软件打开信号__", out bool bResult);
            if (bResult == false)
            {
                MessageBox.Show("已有一个程序在运行");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogHelper.WriteLog(e.ToString(), e.ExceptionObject as Exception);
            bool b = e.IsTerminating;
            if (b)
            {
                MessageBox.Show("未处理的异常信息，应用程序即将退出!"
                    + (e.ExceptionObject as Exception)?.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("未处理的异常信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            LogHelper.WriteLog("未经处理的异常！", e.Exception);
            MessageBox.Show("未经处理的异常信息:" + e.Exception.Message);
        }
    }
}
