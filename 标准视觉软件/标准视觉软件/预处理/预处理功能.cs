using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 标准视觉软件
{
    public abstract class 预处理功能
    {
        public string type;
        public HObject outContour;
        public HTuple outModelID;
        public HObject InRegion;
        public HObject InImage;
        public abstract void Create(HObject inImage, HObject inRegion);
        public abstract int Find(HObject inImage, out HObject outImage);
        public abstract void Release();
        public abstract void Write(string sFolderPath, string matchingName);

        public abstract void Read(string sFolderPath, string mathingName);
    }
}
