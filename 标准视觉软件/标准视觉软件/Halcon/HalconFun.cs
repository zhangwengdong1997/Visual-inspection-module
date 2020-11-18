using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 标准视觉软件.Halcon
{
    class HalconFun
    {
        public static Bitmap Honject2Bitmap(HObject hObject)
        {
            //获取图像尺寸
            HOperatorSet.GetImageSize(hObject, out HTuple width0, out HTuple height0);
            //获取图像大小
            HOperatorSet.GetImageSize(hObject, out width0, out height0);
            //创建交错格式图像
            HOperatorSet.InterleaveChannels(hObject, out HObject InterImage, "rgb", 4 * width0, 0);
            //获取交错格式图像指针
            HOperatorSet.GetImagePointer1(InterImage, out HTuple Pointer, out HTuple type, out HTuple width, out HTuple height);
            IntPtr ptr = Pointer;
            //构建新Bitmap图像
            return new Bitmap(width / 4, height, width, PixelFormat.Format24bppRgb, ptr); ;
        }
    }
}
