using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LS_VisionMod.模板创建步骤
{
    public partial class 匹配定位 : UserControl, I模板创建步骤
    {
        Model model;
        MatchingFun matchingfun;
        string matchingName;

        string[] ImagesPath;
        int count = 0;
        bool havWrite = false;
        public 匹配定位(ref Model model)
        {
            InitializeComponent();
            this.model = model;
            this.Dock = DockStyle.Fill;
        }
        public void Save()
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
                        model.nowMatching = null;
                        model.nowStep++;
                        return;
                    }
                }
                matchingName = matchingfun.type + model.matchings.Count;
                Matching matching = new Matching(matchingName, matchingfun.type);
                model.matchings.Add(matching);
                model.nowMatching = matching;
                matchingfun = null;
            }
            else
            {
                model.nowMatching = null;
            }
            model.nowStep++;
        }
        private void 匹配定位_Load(object sender, EventArgs e)
        {
            //获取可用的匹配功能
            cmb定位模板类型.DataSource = MyRun.GetMatchingList();
            //拍照事件
            MyRun.SoftwareOnceEvent += MyRun_SoftwareOnceEvent;
            //设置默认值
            //Hashtable matchingSettings = (Hashtable)ConfigurationManager.GetSection("matchingSettings");
            //cmb定位模板类型.Text = (string)matchingSettings["type"];
        }

        

        
        private void MyRun_SoftwareOnceEvent(object sender, TriggerIamge e)
        {
            HalconFun.ShowImage(e.ho_Image);
            if (chb测试定位模板.Checked)
            {
                if (matchingfun != null)
                    matchingfun.Find(HalconFun.m_hoImage, out HalconFun.m_hoImage);
                HalconFun.HWindowRefresh(Color.Red, HalconFun.RegionFillMode.Margin);
            }
            
        }

        private void btn新建区域_Click(object sender, EventArgs e)
        {
            HalconFun.AddHistoryRegions();
            HalconFun.SetRegionColor(Color.Red);
            this.Focus();
            if (rdo矩形区域.Checked)
                HalconFun.DrawRegion(HalconFun.DrawRectangle1, HalconFun.Operation.New);
            if (rdo圆形区域.Checked)
                HalconFun.DrawRegion(HalconFun.DrawCircle, HalconFun.Operation.New);
            if (rdo多边形区域.Checked)
                HalconFun.DrawRegion(HalconFun.DrawPolygon, HalconFun.Operation.New);
            HalconFun.HWindowRefresh(Color.Red, HalconFun.RegionFillMode.Margin);
        }

        private void btn添加区域_Click(object sender, EventArgs e)
        {
            HalconFun.AddHistoryRegions();
            HalconFun.SetRegionColor(Color.Red);
            this.Focus();
            if (rdo矩形区域.Checked)
                HalconFun.DrawRegion(HalconFun.DrawRectangle1, HalconFun.Operation.Add);
            if (rdo圆形区域.Checked)
                HalconFun.DrawRegion(HalconFun.DrawCircle, HalconFun.Operation.Add);
            if (rdo多边形区域.Checked)
                HalconFun.DrawRegion(HalconFun.DrawPolygon, HalconFun.Operation.Add);
            HalconFun.HWindowRefresh(Color.Red, HalconFun.RegionFillMode.Margin);

        }

        private void btn减少区域_Click(object sender, EventArgs e)
        {
            HalconFun.AddHistoryRegions();
            HalconFun.SetRegionColor(Color.Red);
            this.Focus();
            if (rdo矩形区域.Checked)
                HalconFun.DrawRegion(HalconFun.DrawRectangle1, HalconFun.Operation.Cut);
            if (rdo圆形区域.Checked)
                HalconFun.DrawRegion(HalconFun.DrawCircle, HalconFun.Operation.Cut);
            if (rdo多边形区域.Checked)
                HalconFun.DrawRegion(HalconFun.DrawPolygon, HalconFun.Operation.Cut);
            HalconFun.HWindowRefresh(Color.Red, HalconFun.RegionFillMode.Margin);

        }
        private void btn撤销上一步_Click(object sender, EventArgs e)
        {
            HalconFun.BreakHistoryRegion();
            HalconFun.HWindowRefresh(Color.Red, HalconFun.RegionFillMode.Margin);
        }

        private void btn创建模板_Click(object sender, EventArgs e)
        {
            matchingfun = MyRun.GetMatchingFun(cmb定位模板类型.Text);
            matchingfun.Create(HalconFun.m_hoImage, HalconFun.m_hoRegion);
            HalconFun.ShowRegion(matchingfun.outContour, Color.Green);
            havWrite = false;
        }

        private void btn保存模板_Click(object sender, EventArgs e)
        {
            if (matchingfun == null)
                return;
            havWrite = true;
            matchingName = matchingfun.type + model.matchings.Count;
            matchingfun.Write(MyRun.appPath + "\\model\\" + model.modelName, matchingName);

        }

        private void 匹配定位_Enter(object sender, EventArgs e)
        {
            //关联Halcon窗口
            HalconFun.SetWindowHandle(pictureBox1);
            //初始化历史区域
            HalconFun.InitHistoryRegions();
            //显示上一步的图片
            HalconFun.ShowImage();
            ImagesPath = FileOperation.GetImagesPath(MyRun.appPath + "\\model\\" + model.modelName + "\\" + model.nowCam);
            lab本地图片数量.Text = "本地图片数量：" + ImagesPath.Length;

        }

        private void 匹配定位_Leave(object sender, EventArgs e)
        {
            //关闭Halcon窗口
            HalconFun.ColseWindow();
        }

        private void btn获取图片_Click(object sender, EventArgs e)
        {
            if (rdo相机模式.Checked)
            {
                MyRun.TriggerCamera(model.nowCam);
            }
            else if (rdo本地模式.Checked && ImagesPath.Length != 0)
            {
                count %= ImagesPath.Length;
                string ImagePath = ImagesPath[count++];
                HalconFun.ReadImage(ImagePath);
                if (chb测试定位模板.Checked)
                {
                    if (matchingfun != null)
                        matchingfun.Find(HalconFun.m_hoImage, out HalconFun.m_hoImage);
                }
                HalconFun.HWindowRefresh(Color.Red, HalconFun.RegionFillMode.Margin);
                count %= ImagesPath.Length;
            }
        }
    }
}
