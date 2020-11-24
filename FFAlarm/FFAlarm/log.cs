using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LS_CLASS
{
    public class LogHelper
    {
        public static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");
        public static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");
        public static void WriteLog(string info)
        {
            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(info);
            }
        }

        public static void WriteLog(string info, Exception ex)
        {
            if (logerror.IsErrorEnabled)
            {
                logerror.Error(info, ex);
            }
        }

        /// <summary>
        /// 自动清理大于参数nDays时间的过期日志
        /// </summary>
        /// <param name="nDays">天数，删除指定天数前的日志</param>
        /// <returns></returns>
        public static bool AutoClearLog(int nDays)
        {
            string strErrorPath = Application.StartupPath + "\\Log\\LogError";
            string strInfoPath = Application.StartupPath + "\\Log\\LogInfo";

            
            if (System.IO.Directory.Exists(strErrorPath) == true)
            {
                FileInfo[] infos = new DirectoryInfo(strErrorPath).GetFiles();
                try
                {
                    foreach (FileInfo d in infos)
                    {
                        try
                        {
                            string strFileName = System.Text.RegularExpressions.Regex.Replace(Path.GetFileNameWithoutExtension(d.Name), @"\D", "/");
                            if ((DateTime.Now - Convert.ToDateTime(strFileName)).TotalDays > nDays)
                            {
                                File.Delete(d.FullName);
                                //Directory.Delete(d.FullName, true);
                            }
                        }
                        catch (Exception err)
                        {
                            WriteLog("文件删除异常", err);
                        }

                    }
                }
                catch (Exception err)
                {
                    WriteLog("文件删除循环异常", err);
                    return false;
                }
            }

            if (System.IO.Directory.Exists(strInfoPath) == true)
            {
                FileInfo[] infos = new DirectoryInfo(strInfoPath).GetFiles();
                try
                {
                    foreach (FileInfo d in infos)
                    {
                        try
                        {
                            string strFileName = System.Text.RegularExpressions.Regex.Replace(Path.GetFileNameWithoutExtension(d.Name), @"\D", "/");
                            if ((DateTime.Now - Convert.ToDateTime(strFileName)).TotalDays > nDays)
                            {
                                File.Delete(d.FullName);
                                //Directory.Delete(d.FullName, true);
                            }
                        }
                        catch (Exception err)
                        {
                            WriteLog("文件删除异常", err);
                        }

                    }
                }
                catch (Exception err)
                {
                    WriteLog("文件删除循环异常", err);
                    return false;
                }
            }


            return true;
        }
    }
}
