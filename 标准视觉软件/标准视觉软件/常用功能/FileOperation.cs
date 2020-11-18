using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 标准视觉软件
{
    static class FileOperation
    {

        public static void CreateDirectory(params string[] names)
        {
            string strPath = Application.StartupPath;
            foreach (var item in names)
            {
                strPath = strPath + "\\" + item;
                if (Directory.Exists(strPath) == false)
                {
                    Directory.CreateDirectory(strPath);
                }
            }
        }

        public static string [] GetFiles(string path)
        {
            return Directory.GetFiles(path, "*.jpg");
        }

        public static void BindAllFiles(string path, ComboBox comboxlist)
        {
            List<String> list = new List<string>();

            //遍历文件夹
            DirectoryInfo theFolder = new DirectoryInfo(path);
            FileInfo[] thefileInfo = theFolder.GetFiles("*.*", SearchOption.TopDirectoryOnly);

            foreach (FileInfo NextFile in thefileInfo)  //遍历文件
                list.Add(NextFile.Name);

            comboxlist.DataSource = list;//绑定
            comboxlist.SelectedIndex = -1;
        }

        public static List<string> GetAllDirectoryName(string path)
         {
            List<String> list = new List<string>();

            //遍历文件夹
            DirectoryInfo theFolder = new DirectoryInfo(path);
            DirectoryInfo[] thedirectoryInfo = theFolder.GetDirectories();

            foreach (DirectoryInfo NextFile in thedirectoryInfo)  //遍历文件
                list.Add(NextFile.Name);
            return list;
        }

    }
}
