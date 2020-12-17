using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LS_VisionMod.界面;
using HalconDotNet;

namespace LS_VisionMod.模板创建步骤
{
    public partial class 匹配定位 : UserControl, I模板创建步骤
    {
        Model model;
        MatchingFun matchingfun;
        string matchingName;
        新建模板窗口 fatherForm;
        string[] ImagesPath;
        int count = -1;
        bool havWrite = false;

        HalconFun halconFun;
        public 匹配定位(ref Model model, Form fatherForm)
        {
            InitializeComponent();
            this.model = model;
            this.fatherForm = fatherForm as 新建模板窗口;
            this.Dock = DockStyle.Fill;
            halconFun = new HalconFun();
        }
        public void Add()
        {
            if (matchingfun != null)
            {
                if (!havWrite)
                {
                    DialogResult dialogResult = MessageBox.Show("定位模板保存", "是否保存当前的定位模板", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        matchingName = matchingfun.type + model.matchings.Count;
                        matchingfun.Write(MyRun.appPath + "\\model\\" + model.modelName, matchingName);
                    }
                    else
                    {
                        model.nowMatching = new Matching("无", "无");
                        model.nowStep++;
                        return;
                    }
                    matchingName = matchingfun.type + model.matchings.Count;
                    Matching matching = new Matching(matchingName, matchingfun.type);
                    matching.completionTest = matchingfun.completionTest;
                    matching.camName = model.nowCam.name;
                    model.matchings.Add(matching);
                    model.nowMatching = matching;
                }

                matchingfun = null;
            }
            else
            {
                model.nowMatching = new Matching("无", "无");
            }
            model.nowStep++;
        }

        public void Revise()
        {
            matchingName = model.nowMatching.name;
            matchingfun.InImage = halconFun.m_hoImage;
            matchingfun.Write(MyRun.appPath + "\\model\\" + model.modelName, matchingName);
            Matching matching = new Matching(matchingName, matchingfun.type);
            matching.completionTest = matchingfun.completionTest;
            matching.camName = model.nowCam.name;
            model.matchings.Add(matching);
            model.nowMatching = matching;
            model.nowTestItem.MatchName = matchingName;
        }
        private void 匹配定位_Load(object sender, EventArgs e)
        {
            //获取可用的匹配功能
            cmb定位模板类型.DataSource = MyRun.GetMatchingList();

            //设置默认值
            //Hashtable matchingSettings = (Hashtable)ConfigurationManager.GetSection("matchingSettings");
            //cmb定位模板类型.Text = (string)matchingSettings["type"];
        }

        private void MyRun_SoftwareOnceEvent(object sender, TriggerIamge e)
        {
            halconFun.ShowImage(e.ho_Image);
            if (chb测试定位模板.Checked)
            {
                if (matchingfun != null)
                    matchingfun.Find(halconFun.m_hoImage, out halconFun.m_hoImage);
            }
            halconFun.HWindowRefresh(Color.Red, HalconFun.RegionFillMode.Margin);
        }

        private void btn新建区域_Click(object sender, EventArgs e)
        {
            ButtonEnabled(false);
            halconFun.AddHistoryRegions();
            halconFun.SetRegionColor(Color.Green);
            this.Focus();
            if (rdo矩形区域.Checked)
                halconFun.DrawRegion(halconFun.DrawRectangle1, HalconFun.Operation.New);
            if (rdo圆形区域.Checked)
                halconFun.DrawRegion(halconFun.DrawCircle, HalconFun.Operation.New);
            if (rdo多边形区域.Checked)
                halconFun.DrawRegion(halconFun.DrawPolygon, HalconFun.Operation.New);
            halconFun.HWindowRefresh(Color.Red, HalconFun.RegionFillMode.Margin);
            ButtonEnabled(true);
        }

        private void btn添加区域_Click(object sender, EventArgs e)
        {
            ButtonEnabled(false);
            halconFun.AddHistoryRegions();
            halconFun.SetRegionColor(Color.Green);
            this.Focus();
            if (rdo矩形区域.Checked)
                halconFun.DrawRegion(halconFun.DrawRectangle1, HalconFun.Operation.Add);
            if (rdo圆形区域.Checked)
                halconFun.DrawRegion(halconFun.DrawCircle, HalconFun.Operation.Add);
            if (rdo多边形区域.Checked)
                halconFun.DrawRegion(halconFun.DrawPolygon, HalconFun.Operation.Add);
            halconFun.HWindowRefresh(Color.Red, HalconFun.RegionFillMode.Margin);
            ButtonEnabled(true);
        }

        private void btn减少区域_Click(object sender, EventArgs e)
        {
            ButtonEnabled(false);
            halconFun.AddHistoryRegions();
            halconFun.SetRegionColor(Color.Green);
            this.Focus();
            if (rdo矩形区域.Checked)
                halconFun.DrawRegion(halconFun.DrawRectangle1, HalconFun.Operation.Cut);
            if (rdo圆形区域.Checked)
                halconFun.DrawRegion(halconFun.DrawCircle, HalconFun.Operation.Cut);
            if (rdo多边形区域.Checked)
                halconFun.DrawRegion(halconFun.DrawPolygon, HalconFun.Operation.Cut);
            halconFun.HWindowRefresh(Color.Red, HalconFun.RegionFillMode.Margin);
            ButtonEnabled(true);
        }
        private void btn撤销上一步_Click(object sender, EventArgs e)
        {
            halconFun.BreakHistoryRegion();
            halconFun.HWindowRefresh(Color.Red, HalconFun.RegionFillMode.Margin);
        }

        private void btn创建模板_Click(object sender, EventArgs e)
        {
            matchingfun = MyRun.GetMatchingFun(cmb定位模板类型.Text);
            if (halconFun.m_hoRegion == null)
            {
                MessageBox.Show("请先新建区域");
            }
            if (chb完整性判断.Checked)
            {
                MessageBox.Show("请框选区域，完整性判断将保证检测时该区域内的检测项都处于画面中");
                this.Focus();
                ButtonEnabled(false);
                halconFun.SetRegionColor(Color.Yellow);
                halconFun.DrawRectangle1(out HObject ho_matchingRegion);
                matchingfun.CompleteRegion = ho_matchingRegion;
                matchingfun.completionTest = true;
                ButtonEnabled(true);
            }
            matchingfun.Create(halconFun.m_hoImage, halconFun.m_hoRegion);
            halconFun.ShowRegion(matchingfun.outContour, Color.Red);
            havWrite = false;
            
        }

        private void btn保存模板_Click(object sender, EventArgs e)
        {
            if (matchingfun == null)
                return;
            havWrite = true;
            
            matchingName = matchingfun.type + model.matchings.Count;
            matchingfun.Write(MyRun.appPath + "\\model\\" + model.modelName, matchingName);
            Matching matching = new Matching(matchingName, matchingfun.type);
            matching.completionTest = matchingfun.completionTest;
            matching.camName = model.nowCam.name;
            model.matchings.Add(matching);
            model.nowMatching = matching;
            fatherForm.ShowModelStatus();
        }
        private void ButtonEnabled(bool enabled)
        {
            foreach (Control control in this.Controls)
            {
                if (control.GetType().Equals(typeof(Button)))
                {
                    control.Enabled = enabled;
                }
            }
            
        }
        private void 匹配定位_Enter(object sender, EventArgs e)
        {
            //拍照事件
            MyRun.SoftwareOnceEvent += MyRun_SoftwareOnceEvent;
            //关联Halcon窗口
            halconFun.SetWindowHandle(pictureBox1);
            //初始化历史区域
            halconFun.InitHistoryRegions();

            ImagesPath = FileOperation.GetImagesPath(MyRun.appPath + "\\model\\" + model.modelName + "\\" + model.nowCam.name);
            lab本地图片数量.Text = "本地图片数量：" + ImagesPath.Length;

            //如果当前定位模板非空
            if( model.nowMatching.type != "无")
            {
                matchingfun = MyRun.GetMatchingFun(model.nowMatching.type);
                matchingfun.Read(MyRun.appPath + "\\model\\" + model.modelName, model.nowMatching);
                halconFun.m_hoImage = matchingfun.InImage;
                halconFun.ShowImage();
                halconFun.m_hoRegion = matchingfun.InRegion;
            }
        }

        private void 匹配定位_Leave(object sender, EventArgs e)
        {
            //拍照事件
            MyRun.SoftwareOnceEvent -= MyRun_SoftwareOnceEvent;
            //关闭Halcon窗口
            halconFun.ColseWindow();
        }

        private void btn获取图片_Click(object sender, EventArgs e)
        {
            if (rdo相机模式.Checked)
            {
                MyRun.TriggerCamera(model.nowCam.name);
            }
            else if (rdo本地模式.Checked && ImagesPath.Length != 0)
            {
                count++;
                count %= ImagesPath.Length;
                string ImagePath = ImagesPath[count];
                halconFun.ReadImage(ImagePath);
                if (chb测试定位模板.Checked)
                {
                    if (matchingfun != null)
                        matchingfun.Find(halconFun.m_hoImage, out halconFun.m_hoImage);
                }
                halconFun.HWindowRefresh(Color.Red, HalconFun.RegionFillMode.Margin);
            }
        }

        private void btn上一张_Click(object sender, EventArgs e)
        {
            count--;
            count += ImagesPath.Length;
            count %= ImagesPath.Length;
            string ImagePath = ImagesPath[count];
            halconFun.ReadImage(ImagePath);
            if (chb测试定位模板.Checked)
            {
                if (matchingfun != null)
                    matchingfun.Find(halconFun.m_hoImage, out halconFun.m_hoImage);
            }
            halconFun.HWindowRefresh(Color.Red, HalconFun.RegionFillMode.Margin);
        }

        private void btn下一张_Click(object sender, EventArgs e)
        {
            count++;
            count %= ImagesPath.Length;
            string ImagePath = ImagesPath[count];
            halconFun.ReadImage(ImagePath);
            if (chb测试定位模板.Checked)
            {
                if (matchingfun != null)
                    matchingfun.Find(halconFun.m_hoImage, out halconFun.m_hoImage);
            }
            halconFun.HWindowRefresh(Color.Red, HalconFun.RegionFillMode.Margin);
        }

        private void rdo本地模式_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo本地模式.Checked)
            {
                btn上一张.Visible = true;
                btn下一张.Visible = true;
            }
            else
            {
                btn上一张.Visible = false;
                btn下一张.Visible = false;
            }
        }
    }
}
