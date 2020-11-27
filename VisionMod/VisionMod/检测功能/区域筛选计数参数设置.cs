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

namespace LS_VisionMod
{
    public partial class 区域筛选计数参数设置 : UserControl, I检测参数设置
    {
        HTuple hWindow;
        HObject hImage;
        HObject hRegionIn;
        HObject hRegionGray;
        HObject hRegionArea;
        public 区域筛选计数参数设置()
        {
            InitializeComponent();
        }

        public void Find(HObject inImage, List<Parameter> inParameters, out string outMessage)
        {
            float row, column, phi, length1, length2;
            row = (inParameters[0].value as float[])[0];
            column = (inParameters[0].value as float[])[1];
            phi = (inParameters[0].value as float[])[2];
            length1 = (inParameters[0].value as float[])[3];
            length2 = (inParameters[0].value as float[])[4];
            int minGray, maxGray;
            minGray = (inParameters[1].value as int[])[0];
            maxGray = (inParameters[1].value as int[])[1];
            int minArea, maxArea;
            minArea = (inParameters[2].value as int[])[0];
            maxArea = (inParameters[2].value as int[])[1];
            int num = (int)inParameters[3].value;
            HOperatorSet.GenRectangle2(out HObject ho_inRegion, row, column, phi, length1, length2);
            HOperatorSet.ReduceDomain(inImage, ho_inRegion, out HObject ho_imageReduced);
            HOperatorSet.Threshold(ho_imageReduced, out HObject ho_ThresholdRegion, minGray, maxGray);
            HOperatorSet.Connection(ho_ThresholdRegion, out HObject ho_connectedRegions);
            HOperatorSet.SelectShape(ho_connectedRegions, out HObject ho_selectedRegion, "area", "and", minArea, maxArea);
            HOperatorSet.CountObj(ho_selectedRegion, out HTuple hv_number);
            if(hv_number.I == num)
            {
                outMessage = "OK\n筛选区域个数为" + hv_number.I.ToString();
            }
            else
            {
                outMessage = "NG\n筛选区域个数为" + hv_number.I.ToString();
            }
            
        }

        public string GetName()
        {
            return "区域筛选计数";
        }

        public List<Parameter> initParameterList()
        {
            List<Parameter> parameterList = new List<Parameter>();
            Parameter region = new Parameter("感兴趣区域", ParameterType.区域);
            Parameter gray = new Parameter("灰度", ParameterType.阈值);
            Parameter area = new Parameter("面积", ParameterType.阈值);
            Parameter number = new Parameter("计数", ParameterType.数字);
            parameterList.Add(region);
            parameterList.Add(gray);
            parameterList.Add(area);
            parameterList.Add(number);
            return parameterList;
        }


        public void Save(ref List<Parameter> parameterList)
        {
            float row, column, phi, length1, length2;
            row = float.Parse(txtRow.Text);
            column = float.Parse(txtColumn.Text);
            phi = float.Parse(txtPhi.Text);
            length1 = float.Parse(txtLength1.Text);
            length2 = float.Parse(txtLength2.Text);
            parameterList[0].value = new float[5] { row, column, phi, length1, length2 };
            int minGray, maxGray;
            minGray = (int)nudMinGray.Value;
            maxGray = (int)nudMaxGray.Value;
            parameterList[1].value = new int[2] { minGray, maxGray };
            int minArea, maxArea;
            minArea = (int)nudMinArea.Value;
            maxArea = (int)nudMaxArea.Value;
            parameterList[2].value = new int[2] { minArea, maxArea };
            parameterList[3].value = (int)nud期望区域个数.Value;
        }

        public void SetHalconWindow(HTuple hWindow)
        {
            this.hWindow = hWindow;
        }

        public void SetHalconImage(HObject ho_image)
        {
            HOperatorSet.CopyImage(ho_image, out this.hImage);
        }
        private void btn选择区域_Click(object sender, EventArgs e)
        {
            btn选择区域.Enabled = false;
            this.Focus();
            HOperatorSet.DrawRectangle2(hWindow, out HTuple hv_row, out HTuple hv_column,
                out HTuple hv_phi, out HTuple hv_length1, out HTuple hv_length2);
            HOperatorSet.GenRectangle2(out hRegionIn, hv_row, hv_column, hv_phi, hv_length1, hv_length2);
            HOperatorSet.SetDraw(hWindow, "margin");
            HOperatorSet.SetColor(hWindow, "red");
            HOperatorSet.DispObj(hRegionIn, hWindow);
            txtRow.Text = hv_row.D.ToString();
            txtColumn.Text = hv_column.D.ToString();
            txtPhi.Text = hv_phi.D.ToString();
            txtLength1.Text = hv_length1.D.ToString();
            txtLength2.Text = hv_length2.D.ToString();


            btn选择区域.Enabled = true;
        }

        private void trbMinGray_Scroll(object sender, EventArgs e)
        {
            nudMinGray.Value = trbMinGray.Value;

        }

        private void trbMaxGray_Scroll(object sender, EventArgs e)
        {
            nudMaxGray.Value = trbMaxGray.Value;

        }

        private void nudMinGray_ValueChanged(object sender, EventArgs e)
        {
            trbMinGray.Value = (int)nudMinGray.Value;
            if(trbMinGray.Value > trbMaxGray.Value)
            {
                trbMaxGray.Value = trbMinGray.Value;
            }
            if (hImage == null)
            {
                MessageBox.Show("请先获取图片");
                return;
            }
            if (hRegionIn == null)
            {
                MessageBox.Show("请先选择感兴趣区域");
                return;
            }
            HTuple hv_minGray = new HTuple(trbMinGray.Value);
            HTuple hv_maxGray = new HTuple(trbMaxGray.Value);
            HOperatorSet.ReduceDomain(hImage, hRegionIn, out HObject ho_imageReduced);
            HOperatorSet.Threshold(ho_imageReduced, out hRegionGray, hv_minGray, hv_maxGray);
            HOperatorSet.SetDraw(hWindow, "fill");
            HOperatorSet.SetColor(hWindow, "green");
            HOperatorSet.DispObj(hImage, hWindow);
            HOperatorSet.DispObj(hRegionGray, hWindow);
            HOperatorSet.AreaCenter(hRegionGray, out HTuple hv_area, out _, out _);
            trbMinArea.Maximum = hv_area.I;
            trbMaxArea.Maximum = hv_area.I;
            nudMinArea.Maximum = hv_area.I;
            nudMaxArea.Maximum = hv_area.I;
        }

        private void nudMaxGray_ValueChanged(object sender, EventArgs e)
        {
            trbMaxGray.Value = (int)nudMaxGray.Value;
            if (trbMinGray.Value > trbMaxGray.Value)
            {
                trbMinGray.Value = trbMaxGray.Value;
            }
            if (hImage == null)
            {
                MessageBox.Show("请先获取图片");
                return;
            }
            if (hRegionIn == null)
            {
                MessageBox.Show("请先选择感兴趣区域");
                return;
            }
            HTuple hv_minGray = new HTuple(trbMinGray.Value);
            HTuple hv_maxGray = new HTuple(trbMaxGray.Value);
            HOperatorSet.ReduceDomain(hImage, hRegionIn, out HObject ho_imageReduced);
            HOperatorSet.Threshold(ho_imageReduced, out hRegionGray, hv_minGray, hv_maxGray);
            HOperatorSet.SetDraw(hWindow, "fill");
            HOperatorSet.SetColor(hWindow, "green");
            HOperatorSet.DispObj(hImage, hWindow);
            HOperatorSet.DispObj(hRegionGray, hWindow);
            HOperatorSet.AreaCenter(hRegionGray, out HTuple hv_area, out _, out _);
            trbMinArea.Maximum = hv_area.I;
            trbMaxArea.Maximum = hv_area.I;
            nudMinArea.Maximum = hv_area.I;
            nudMaxArea.Maximum = hv_area.I;
        }

        private void trbMinArea_Scroll(object sender, EventArgs e)
        {
            nudMinArea.Value = trbMinArea.Value;
        }

        private void trbMaxArea_Scroll(object sender, EventArgs e)
        {
            nudMaxArea.Value = trbMaxArea.Value;
        }

        private void nudMinArea_ValueChanged(object sender, EventArgs e)
        {
            trbMinArea.Value = (int)nudMinArea.Value;
            if (trbMinArea.Value > trbMaxArea.Value)
            {
                trbMaxArea.Value = trbMinArea.Value;
            }
            if (hImage == null)
            {
                MessageBox.Show("请先获取图片");
                return;
            }
            if (hRegionIn == null)
            {
                MessageBox.Show("请先选择感兴趣区域");
                return;
            }
            HTuple hv_minArea = new HTuple(trbMinArea.Value);
            HTuple hv_maxArea = new HTuple(trbMaxArea.Value);
            HOperatorSet.Connection(hRegionGray, out HObject ho_connectedRegions);
            HOperatorSet.SelectShape(ho_connectedRegions, out hRegionArea, "area", "and", hv_minArea, hv_maxArea);
            HOperatorSet.SetDraw(hWindow, "fill");
            HOperatorSet.SetColored(hWindow, 12);
            HOperatorSet.DispObj(hImage, hWindow);
            HOperatorSet.DispObj(hRegionArea, hWindow);
            HOperatorSet.CountObj(hRegionArea, out HTuple hv_number);
            lab当前区域个数.Text = hv_number.I.ToString();
        }

        private void nudMaxArea_ValueChanged(object sender, EventArgs e)
        {
            trbMaxArea.Value = (int)nudMaxArea.Value;
            if (trbMinArea.Value > trbMaxArea.Value)
            {
                trbMinArea.Value = trbMaxArea.Value;
            }
            if (hImage == null)
            {
                MessageBox.Show("请先获取图片");
                return;
            }
            if (hRegionIn == null)
            {
                MessageBox.Show("请先选择感兴趣区域");
                return;
            }
            HTuple hv_minArea = new HTuple(trbMinArea.Value);
            HTuple hv_maxArea = new HTuple(trbMaxArea.Value);
            HOperatorSet.Connection(hRegionGray, out HObject ho_connectedRegions);
            HOperatorSet.SelectShape(ho_connectedRegions, out hRegionArea, "area", "and", hv_minArea, hv_maxArea);
            HOperatorSet.SetDraw(hWindow, "fill");
            HOperatorSet.SetColored(hWindow, 12);
            HOperatorSet.DispObj(hImage, hWindow);
            HOperatorSet.DispObj(hRegionArea, hWindow);
            HOperatorSet.CountObj(hRegionArea, out HTuple hv_number);
            lab当前区域个数.Text = hv_number.I.ToString();
        }

        private void btn放大图像_Click(object sender, EventArgs e)
        {
            if (btn放大图像.Text.Equals("放大图像"))
            {
                this.Focus();
                HOperatorSet.SetColor(hWindow, "green");
                HOperatorSet.DrawRectangle1(hWindow, out HTuple row1, out HTuple column1, out HTuple row2, out HTuple column2);
                HOperatorSet.SetPart(hWindow, row1, column1, row2, column2);
                HOperatorSet.DispObj(hImage, hWindow);
                btn放大图像.Text = "还原";
            }
            else
            {
                HOperatorSet.GetImagePointer1(hImage, out _, out _, out HTuple hv_width, out HTuple hv_height);
                HOperatorSet.SetPart(hWindow, 0, 0, hv_height - 1, hv_width - 1);
                HOperatorSet.DispObj(hImage, hWindow);
                btn放大图像.Text = "放大图像";
            }
        }
    }
}
