using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS_VisionMod
{
    public abstract class MatchingFun
    {
        /// <summary>
        /// 定位功能类型名称
        /// </summary>
        public string type;
        /// <summary>
        /// 输出的定位轮廓
        /// </summary>
        public HObject outContour;
        /// <summary>
        /// 输出的定位模板的ID
        /// </summary>
        public HTuple outModelID;
        /// <summary>
        /// 输入的区域
        /// </summary>
        public HObject InRegion;
        /// <summary>
        /// 输入的图片
        /// </summary>
        public HObject InImage;
        /// <summary>
        /// 完整产品的区域
        /// </summary>
        public HObject CompleteRegion;
        /// <summary>
        /// 是否检测完整性
        /// </summary>
        public bool completionTest { get; set; }
        /// <summary>
        /// 使用的模板
        /// </summary>
        public Matching matching { get; set; }
        /// <summary>
        /// 创建定位模板
        /// </summary>
        /// <param name="inImage"></param>
        /// <param name="inRegion"></param>
        public abstract void Create(HObject inImage, HObject inRegion);

        /// <summary>
        /// 匹配定位模板，矫正图片位置
        /// </summary>
        /// <param name="inImage"></param>
        /// <param name="outImage"></param>
        /// <returns></returns>
        public abstract int Find(HObject inImage, out HObject outImage);
        /// <summary>
        /// 释放定位模板
        /// </summary>
        public abstract void Release();
        /// <summary>
        /// 保存定位模板
        /// </summary>
        /// <param name="sFolderPath"></param>
        /// <param name="matchingName"></param>
        public abstract void Write(string sFolderPath, string matchingName);
        /// <summary>
        /// 读取定位模板
        /// </summary>
        /// <param name="sFolderPath"></param>
        /// <param name="mathing"></param>
        public abstract void Read(string sFolderPath, Matching mathing);
    }
}
