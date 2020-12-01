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
    public partial class 检测项添加 : UserControl, I模板创建步骤
    {
        Model model;
        MatchingFun matchingfun;
        I检测参数设置 检测项设置;

        string[] ImagesPath;
        int count = 0;
        public 检测项添加(ref Model model)
        {
            InitializeComponent();
            this.model = model;
            this.Dock = DockStyle.Fill;
        }

        public void Save()
        {
            if (model.testItems.RemoveAll(x => x == model.nowTestItem) > 0)
            {
                model.nowStep--;
            }

            model.nowTestItem = null;
            List<Parameter> parameters = 检测项设置.initParameterList();
            检测项设置.Save(ref parameters);
            TestItem testItem = new TestItem
            {
                name = 检测项设置.GetName() + model.testItems.Count,
                CamName = model.nowCam,
                Match = model.nowMatching,
                type = 检测项设置.GetName(),
                parameters = parameters
            };
            model.testItems.Add(testItem);
            model.nowStep++;
        }

        private void 检测项添加_Load(object sender, EventArgs e)
        {
            //获取可用的检测功能
            cmb选择检测项.DataSource = MyRun.GetTestItemList();
            //拍照事件
            MyRun.SoftwareOnceEvent += MyRun_SoftwareOnceEvent;
            //设置默认值
            //Hashtable testItemSettings = (Hashtable)ConfigurationManager.GetSection("testItemSettings");
            //MyRun.GetTestItemList().FindIndex(x => x.Equals(testItemSettings["type"]));
            //cmb选择检测项.SelectedIndex = MyRun.GetTestItemList().FindIndex(x => x.Equals(testItemSettings["type"]));
            
        }

        private void MyRun_SoftwareOnceEvent(object sender, TriggerIamge e)
        {
            HalconFun.ShowImage(e.ho_Image);
            if (model.nowMatching != null)
            {
                matchingfun = MyRun.GetMatchingFun(model.nowMatching.type);
                matchingfun.Read(MyRun.appPath + "\\model\\" + model.modelName, model.nowMatching.name);
                matchingfun.Find(HalconFun.m_hoImage, out HalconFun.m_hoImage);
                HalconFun.ShowImage();
            }
            检测项设置.SetHalconImage(HalconFun.m_hoImage);
        }

        private void cmb选择检测项_SelectedIndexChanged(object sender, EventArgs e)
        {
            检测项设置 = MyRun.GetParameterSettingControl(cmb选择检测项.Text);
            检测项设置.SetHalconWindow(HalconFun.m_hvWindowHandle);

            pnl参数设置.Controls.Clear();
            pnl参数设置.Controls.Add((Control)检测项设置);
        }

        private void btn获取图片_Click(object sender, EventArgs e)
        {
            if (rdo相机模式.Checked)
            {
                MyRun.TriggerCamera(model.nowCam);
            }
            else if (rdo本地模式.Checked && ImagesPath.Length != 0)
            {
                string ImagePath = ImagesPath[count++];
                HalconFun.ReadImage(ImagePath);
                if (model.nowMatching != null)
                {
                    matchingfun = MyRun.GetMatchingFun(model.nowMatching.type);
                    matchingfun.Read(Application.StartupPath + "\\model\\" + model.modelName, model.nowMatching.name);
                    matchingfun.Find(HalconFun.m_hoImage, out HalconFun.m_hoImage);
                }
                HalconFun.ShowImage();
                检测项设置.SetHalconImage(HalconFun.m_hoImage);
                count %= ImagesPath.Length;
            }
        }

        private void 检测项添加_Enter(object sender, EventArgs e)
        {
            //关联Halcon窗口
            HalconFun.SetWindowHandle(pictureBox1);
            //显示上一步的图片
            HalconFun.ShowImage();
            ImagesPath = FileOperation.GetImagesPath(MyRun.appPath + "\\model\\" + model.modelName + "\\" + model.nowCam);
            lab本地图片数量.Text = "本地图片数量：" + ImagesPath.Length;
            检测项设置.SetHalconImage(HalconFun.m_hoImage);
        }

        private void 检测项添加_Leave(object sender, EventArgs e)
        {
            //关闭Halcon窗口
            HalconFun.ColseWindow();
        }

        private void btn测试_Click(object sender, EventArgs e)
        {
            string outMessage;
            List<Parameter> parameters = 检测项设置.initParameterList();
            检测项设置.Save(ref parameters);

            检测项设置.Find(HalconFun.m_hoImage, parameters, out outMessage);
            txt检测结果.Text = outMessage;
        }

    }
}
