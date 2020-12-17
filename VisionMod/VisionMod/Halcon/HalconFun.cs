using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LS_VisionMod
{
    class HalconFun
    {
        public HObject m_hoRegion;
        public HObject m_hoImage;
        public HTuple m_hvWindowHandle;
        public List<HObject> m_historyRegions;

        public void InitHistoryRegions()
        {
            m_historyRegions = new List<HObject>();
        }
        public void AddHistoryRegions()
        {
            m_historyRegions.Add(m_hoRegion);
        }
        public void BreakHistoryRegion()
        {
            if (m_historyRegions.Count > 0)
            {
                HObjectEmpty(ref m_hoRegion);
                m_hoRegion = m_historyRegions.Last();
                m_historyRegions.RemoveAt(m_historyRegions.Count - 1);

            }
            else
            {
                m_hoRegion = null;
            }
        }
        public void SetWindowHandle(PictureBox pictureBox)
        {
            HTuple FatherWindow = pictureBox.Handle;
            HOperatorSet.OpenWindow(0, 0, pictureBox.Width, pictureBox.Height, FatherWindow, "visible", "", out m_hvWindowHandle);
            HSystem.SetSystem("clip_region", "false");
        }
        public void ColseWindow()
        {
            HOperatorSet.CloseWindow(m_hvWindowHandle);
        }
        public static Bitmap Honject2Bitmap(HObject hObject)
        {
            //获取图像尺寸
            HOperatorSet.GetImageSize(hObject, out HTuple width0, out _);
            //创建交错格式图像
            HOperatorSet.InterleaveChannels(hObject, out HObject InterImage, "rgb", 4 * width0, 0);
            //获取交错格式图像指针
            HOperatorSet.GetImagePointer1(InterImage, out HTuple Pointer, out _, out HTuple width, out HTuple height);
            IntPtr ptr = Pointer;
            InterImage.Dispose();
            //构建新Bitmap图像
            return new Bitmap(width / 4, height, width, PixelFormat.Format24bppRgb, ptr); ;
        }

        public void WriteImage(string path, string fileName)
        {
            if (m_hoImage != null)
            {
                HOperatorSet.WriteImage(m_hoImage, "jpg", 0, path + "\\" + fileName);
            }

        }

        public void ReadImage(string path)
        {
            HObjectEmpty(ref m_hoImage);
            HOperatorSet.ReadImage(out m_hoImage, path);
        }
        public void ShowImage()
        {
            if (m_hoImage == null)
            {
                return;
            }

            HOperatorSet.GetImagePointer1(m_hoImage, out _, out _, out HTuple Width, out HTuple Height);
            HOperatorSet.SetPart(m_hvWindowHandle, 0, 0, Height - 1, Width - 1);
            HOperatorSet.DispObj(m_hoImage, m_hvWindowHandle);
        }
        public void ShowImage(HObject ho_Image)
        {
            HObjectEmpty(ref m_hoImage);
            HOperatorSet.CopyImage(ho_Image, out m_hoImage);
            ShowImage();
        }
        public static void ShowImage(HObject ho_Image, HTuple hvWindowHandle)
        {
            HOperatorSet.GetImagePointer1(ho_Image, out _, out _, out HTuple Width, out HTuple Height);
            HOperatorSet.SetPart(hvWindowHandle, 0, 0, Height - 1, Width - 1);
            HOperatorSet.DispObj(ho_Image, hvWindowHandle);
        }
        public static void OpenWindow(PictureBox pictureBox, out HTuple hvWindowHandle)
        {
            HTuple FatherWindow = pictureBox.Handle;
            HOperatorSet.OpenWindow(0, 0, pictureBox.Width, pictureBox.Height, FatherWindow, "visible", "", out hvWindowHandle);
        }
        public static void ColseWindow(HTuple hvWindowHandle)
        {
            HOperatorSet.CloseWindow(hvWindowHandle);
        }
        #region 画区域

        public delegate void DrawRegionModel();

        public void DrawRegion(DrawRegionModel drawRegionModel, Operation operation)
        {
            HObject originalRegion = null;
            HObject resultRegion = null;
            switch (operation)
            {
                case Operation.New:
                    drawRegionModel();
                    originalRegion = new HObject(m_hoRegion);
                    break;
                case Operation.Add:
                    if(m_hoRegion == null)
                    {
                        goto case Operation.New;
                    }
                    originalRegion = new HObject(m_hoRegion);
                    drawRegionModel();
                    HOperatorSet.Union2(originalRegion, m_hoRegion, out resultRegion);
                    HObjectEmpty(ref m_hoRegion);
                    m_hoRegion = resultRegion;
                    break;
                case Operation.Cut:
                    if (m_hoRegion == null)
                    {
                        goto case Operation.New;
                    }
                    originalRegion = new HObject(m_hoRegion);
                    drawRegionModel();
                    HOperatorSet.Difference(originalRegion, m_hoRegion, out resultRegion);
                    HObjectEmpty(ref m_hoRegion);
                    m_hoRegion = resultRegion;
                    break;
                case Operation.Int:
                    if (m_hoRegion == null)
                    {
                        goto case Operation.New;
                    }
                    originalRegion = new HObject(m_hoRegion);
                    drawRegionModel();
                    HOperatorSet.Intersection(originalRegion, m_hoRegion, out resultRegion);
                    HObjectEmpty(ref m_hoRegion);
                    m_hoRegion = new HObject(resultRegion);
                    break;
            }
            originalRegion.Dispose();

        }

        public void DrawRectangle1()
        {
            HOperatorSet.DrawRectangle1(m_hvWindowHandle, out HTuple hv_row1, out HTuple hv_column1, out HTuple hv_row2, out HTuple hv_column2);
            HObjectEmpty(ref m_hoRegion);
            HOperatorSet.GenRectangle1(out m_hoRegion, hv_row1, hv_column1, hv_row2, hv_column2);
        }

        public void DrawRectangle2()
        {
            HOperatorSet.DrawRectangle2(m_hvWindowHandle, out HTuple hv_row, out HTuple hv_column, out HTuple hv_phi, out HTuple hv_length1, out HTuple hv_length2);
            HObjectEmpty(ref m_hoRegion);
            HOperatorSet.GenRectangle2(out m_hoRegion, hv_row, hv_column, hv_phi, hv_length1, hv_length2);
        }

        public void DrawCircle()
        {
            HOperatorSet.DrawCircle(m_hvWindowHandle, out HTuple hv_row, out HTuple hv_column, out HTuple hv_radius);
            HObjectEmpty(ref m_hoRegion);
            HOperatorSet.GenCircle(out m_hoRegion, hv_row, hv_column, hv_radius);
        }

        public void DrawPolygon()
        {
            HOperatorSet.DrawPolygon(out HObject ho_PolygonRegion, m_hvWindowHandle);
            HObjectEmpty(ref m_hoRegion);
            HOperatorSet.ShapeTrans(ho_PolygonRegion, out m_hoRegion, "convex");
        }

        public enum Operation
        {
            /// <summary>
            /// 新建一个区域，原有区域会被覆盖
            /// </summary>
            New = 1,
            /// <summary>
            /// 在原有区域的基础上增加区域
            /// </summary>
            Add = 2,
            /// <summary>
            /// 在原有区域的基础上减少区域
            /// </summary>
            Cut = 3,
            /// <summary>
            /// 在原有区域的基础上求交集
            /// </summary>
            Int = 4
        }

        #endregion

        public void DrawRectangle1(out HObject ho_region)
        {
            HOperatorSet.DrawRectangle1(m_hvWindowHandle, out HTuple hv_row1, out HTuple hv_column1, out HTuple hv_row2, out HTuple hv_column2);
            HOperatorSet.GenRectangle1(out ho_region, hv_row1, hv_column1, hv_row2, hv_column2);
        }
        private static void HObjectEmpty(ref HObject hObject)
        {
            if (hObject != null)
            {
                hObject.Dispose();
            }
        }

        public void HWindowRefresh(Color color, RegionFillMode fillMode)
        {
            HOperatorSet.ClearWindow(m_hvWindowHandle);
            SetRegionColor(color);
            SetRegionFillMode(fillMode);
            ShowImage();
            ShowRegion();
        }

        public enum RegionFillMode
        {
            Fill = 1,
            Margin = 2
        }

        public void SetRegionColor(Color color)
        {
            string argb = color.ToArgb().ToString("x");
            string rgba = argb.Substring(2) + argb.Substring(0, 2);
            string colorH = "#" + rgba;
            HOperatorSet.SetColor(m_hvWindowHandle, colorH);
        }
        public void SetRegionFillMode(RegionFillMode fillMode)
        {
            switch (fillMode)
            {
                case RegionFillMode.Fill:
                    HOperatorSet.SetDraw(m_hvWindowHandle, "fill");
                    break;
                case RegionFillMode.Margin:
                    HOperatorSet.SetDraw(m_hvWindowHandle, "margin");
                    break;
            }
        }
        public void ShowRegion()
        {
            if (m_hoRegion == null)
            {
                return;
            }
            HOperatorSet.DispObj(m_hoRegion, m_hvWindowHandle);
        }
        public void ShowRegion(Color color)
        {

            SetRegionColor(color);
            ShowRegion();
        }
        public void ShowRegion(HObject ho_Region, Color color)
        {
            if (ho_Region == null)
            {
                return;
            }
            SetRegionColor(color);
            HOperatorSet.DispObj(ho_Region, m_hvWindowHandle);
        }
    }
}
