using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HalconDotNet;


namespace 标准视觉软件
{
    public partial class 匹配定位 : UserControl, 模板创建步骤
    {
        string matchingName;
        string[] ImagesPath;
        int count = 0;
        HObject m_hoImage;
        HObject m_hoRegion;
        List<HObject> m_historyRegions;
        HWindow m_hvWindowHandle;
        Model model;
        定位功能 matchingWay;
        public 匹配定位(Model model)
        {
            InitializeComponent();
            this.model = model;
        }

        public void Save(Model model)
        {
            if (matchingWay != null)
            {
                Matching matching = new Matching(matchingName, matchingWay.type);
                model.matchings.Add(matching);
                model.nowMatching = matching;
            }
            else
            {
                model.nowMatching = null;
            }
        }

        private void 匹配定位_Load(object sender, EventArgs e)
        {
            m_hvWindowHandle = new HWindow();
            cmb定位模板类型.DataSource = MyRun.GetMatchingList();
            DisplayWindowsInitial();
            MyRun.SoftwareOnceEvent += MyRun_SoftwareOnceEvent;
            SetRegionFillMode(RegionFillMode.Margin);
            m_historyRegions = new List<HObject>();
        }

        private void MyRun_SoftwareOnceEvent(object sender, TriggerIamge e)
        {
            m_hoImage = e.ho_Image;
            if (chb测试定位模板.Checked)
            {
                if (matchingWay != null)
                    matchingWay.Find(m_hoImage, out m_hoImage);
            }
            HWindowRefresh(Color.Red, RegionFillMode.Margin);
        }

        private void DisplayWindowsInitial()
        {
            // ch: 定义显示的起点和宽高 || en: Definition the width and height of the display window
            HTuple hWindowRow, hWindowColumn, hWindowWidth, hWindowHeight;

            // ch: 设置显示窗口的起点和宽高 || en: Set the width and height of the display window
            hWindowRow = 0;
            hWindowColumn = 0;
            hWindowWidth = pictureBox1.Width;
            hWindowHeight = pictureBox1.Height;

            try
            {
                HTuple hWindowID = (HTuple)pictureBox1.Handle;
                m_hvWindowHandle.OpenWindow(hWindowRow, hWindowColumn, hWindowWidth, hWindowHeight, hWindowID, "visible", "");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

        }



        private void btn获取图片_Click(object sender, EventArgs e)
        {
            if (rdo相机模式.Checked)
            {
                MyRun.TriggerCamera(model.nowCam);
            }
            else if (rdo本地模式.Checked && ImagesPath.Length != 0)
            {
                HOperatorSet.ReadImage(out m_hoImage, ImagesPath[count++]);
                if (chb测试定位模板.Checked)
                {
                    if (matchingWay != null)
                        matchingWay.Find(m_hoImage, out m_hoImage);
                }
                HWindowRefresh(Color.Red, RegionFillMode.Margin);
                count %= ImagesPath.Length;
            }
        }

        private void 匹配定位_Enter(object sender, EventArgs e)
        {
            lab当前相机.Text = "当前相机：" + model.nowCam;
            ImagesPath = FileOperation.GetFiles(Application.StartupPath + "\\model\\" + model.modelName + "\\" + model.nowCam);
            lab本地图片数量.Text = "本地图片数量：" + ImagesPath.Length;
        }

        private void btn新建区域_Click(object sender, EventArgs e)
        {
            this.Focus();
            if (rdo矩形区域.Checked)
                DrawRegion(DrawRectangle1, Operation.New);
            if (rdo圆形区域.Checked)
                DrawRegion(DrawCircle, Operation.New);
            if (rdo多边形区域.Checked)
                DrawRegion(DrawPolygon, Operation.New);
            HWindowRefresh(Color.Red, RegionFillMode.Margin);
        }

        private void btn添加区域_Click(object sender, EventArgs e)
        {
            m_historyRegions.Add(m_hoRegion);
            this.Focus();
            if (rdo矩形区域.Checked)
                DrawRegion(DrawRectangle1, Operation.Add);
            if (rdo圆形区域.Checked)
                DrawRegion(DrawCircle, Operation.Add);
            if (rdo多边形区域.Checked)
                DrawRegion(DrawPolygon, Operation.Add);
            HWindowRefresh(Color.Red, RegionFillMode.Margin);

        }

        private void btn减少区域_Click(object sender, EventArgs e)
        {
            m_historyRegions.Add(m_hoRegion);
            this.Focus();
            if (rdo矩形区域.Checked)
                DrawRegion(DrawRectangle1, Operation.Cut);
            if (rdo圆形区域.Checked)
                DrawRegion(DrawCircle, Operation.Cut);
            if (rdo多边形区域.Checked)
                DrawRegion(DrawPolygon, Operation.Cut);
            HWindowRefresh(Color.Red, RegionFillMode.Margin);
        }

        private void btn撤销上一步_Click(object sender, EventArgs e)
        {
            if (m_historyRegions.Count > 0)
            {
                m_hoRegion = m_historyRegions.Last();
                m_historyRegions.RemoveAt(m_historyRegions.Count - 1);

            }
            else
            {
                m_hoRegion = null;
            }
            HWindowRefresh(Color.Red, RegionFillMode.Margin);

        }
        public delegate void DrawRegionEventHandler();

        public void DrawRegion(DrawRegionEventHandler drawRegionEvent, Operation operation)
        {
            HObject originalRegion = null;
            HObject resultRegion = null;
            switch (operation)
            {
                case Operation.New:
                    drawRegionEvent();
                    originalRegion = new HObject(m_hoRegion);
                    break;
                case Operation.Add:
                    if (m_hoRegion == null)
                        goto case Operation.New;
                    originalRegion = new HObject(m_hoRegion);
                    drawRegionEvent();
                    HOperatorSet.Union2(originalRegion, m_hoRegion, out resultRegion);
                    HObjectEmpty(ref m_hoRegion);
                    m_hoRegion = resultRegion;
                    break;
                case Operation.Cut:
                    if (m_hoRegion == null)
                        goto case Operation.New;
                    originalRegion = new HObject(m_hoRegion);
                    drawRegionEvent();
                    HOperatorSet.Difference(originalRegion, m_hoRegion, out resultRegion);
                    HObjectEmpty(ref m_hoRegion);
                    m_hoRegion = resultRegion;
                    break;
                case Operation.Int:
                    if (m_hoRegion == null)
                        goto case Operation.New;
                    originalRegion = new HObject(m_hoRegion);
                    drawRegionEvent();
                    HOperatorSet.Intersection(originalRegion, m_hoRegion, out resultRegion);
                    HObjectEmpty(ref m_hoRegion);
                    m_hoRegion = new HObject(resultRegion);
                    break;
            }
            originalRegion.Dispose();
        }

        private void HObjectEmpty(ref HObject hObject)
        {
            if (hObject != null)
            {
                hObject.Dispose();
            }
            else
            {
                HOperatorSet.GenEmptyObj(out hObject);
            }
        }

        public void DrawRectangle1()
        {
            HOperatorSet.DrawRectangle1(m_hvWindowHandle, out HTuple hv_row1, out HTuple hv_column1, out HTuple hv_row2, out HTuple hv_column2);
            HOperatorSet.GenRectangle1(out m_hoRegion, hv_row1, hv_column1, hv_row2, hv_column2);
        }

        public void DrawRectangle2()
        {
            HOperatorSet.DrawRectangle2(m_hvWindowHandle, out HTuple hv_row, out HTuple hv_column, out HTuple hv_phi, out HTuple hv_length1, out HTuple hv_length2);
            HOperatorSet.GenRectangle2(out m_hoRegion, hv_row, hv_column, hv_phi, hv_length1, hv_length2);
        }

        public void DrawCircle()
        {
            HOperatorSet.DrawCircle(m_hvWindowHandle, out HTuple hv_row, out HTuple hv_column, out HTuple hv_radius);
            HOperatorSet.GenCircle(out m_hoRegion, hv_row, hv_column, hv_radius);
        }

        public void DrawPolygon()
        {
            HOperatorSet.DrawPolygon(out HObject ho_PolygonRegion, m_hvWindowHandle);
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

        public void SetRegionColor(Color color)
        {
            string argb = color.ToArgb().ToString("x");
            string rgba = argb.Substring(2) + argb.Substring(0, 2);
            string colorH = "#" + rgba;
            HOperatorSet.SetColor(m_hvWindowHandle, colorH);
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

        public void ShowMatchModel()
        {
            HOperatorSet.DispObj(matchingWay.outContour, m_hvWindowHandle);
        }

        public void ShowImage()
        {
            if (m_hoImage == null)
            {
                return;
            }
            HOperatorSet.GetImagePointer1(m_hoImage, out _, out _, out HTuple Width, out HTuple Height);
            HOperatorSet.SetPart(m_hvWindowHandle, 0, 0, Height, Width);
            HOperatorSet.DispObj(m_hoImage, m_hvWindowHandle);
        }

        public void HWindowRefresh(Color color, RegionFillMode fillMode)
        {
            HOperatorSet.ClearWindow(m_hvWindowHandle);
            SetRegionColor(color);
            SetRegionFillMode(fillMode);
            ShowImage();
            ShowRegion();
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

        public enum RegionFillMode
        {
            Fill = 1,
            Margin = 2
        }

        private void btn创建模板_Click(object sender, EventArgs e)
        {
            matchingWay = MyRun.GetMatchingFun(cmb定位模板类型.Text);
            matchingWay.Create(m_hoImage, m_hoRegion);
            ShowMatchModel();
        }

        private void btn保存模板_Click(object sender, EventArgs e)
        {
            if (matchingWay == null)
                return;
            matchingName = "abc";
            matchingWay.Write(Application.StartupPath + "\\model\\" + model.modelName, matchingName);
        }

    }
}
