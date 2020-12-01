﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LS_VisionMod
{
    static class FileOperation
    {

        public static void CreateDirectory(params string[] names)
        {
            string strPath = MyRun.appPath;
            foreach (var item in names)
            {
                strPath = strPath + "\\" + item;
                if (Directory.Exists(strPath) == false)
                {
                    Directory.CreateDirectory(strPath);
                }
            }
        }

        public static string [] GetImagesPath(string path)
        {
            Directory.CreateDirectory(path);
            string[] jpgPaths = Directory.GetFiles(path, "*.jpg");
            string[] bmpPaths = Directory.GetFiles(path, "*.bmp");
            string[] imagePaths = new string[jpgPaths.Length + bmpPaths.Length];

            jpgPaths.CopyTo(imagePaths, 0);
            bmpPaths.CopyTo(imagePaths, jpgPaths.Length);
            return imagePaths;
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
            Directory.CreateDirectory(path);
            List<String> list = new List<string>();

            //遍历文件夹
            DirectoryInfo theFolder = new DirectoryInfo(path);
            DirectoryInfo[] thedirectoryInfo = theFolder.GetDirectories();

            foreach (DirectoryInfo NextFile in thedirectoryInfo)  //遍历文件
                list.Add(NextFile.Name);
            return list;
        }

        public static void DelectDir(string srcPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(i.FullName);      //删除指定文件
                    }
                }
                dir.Delete();
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
