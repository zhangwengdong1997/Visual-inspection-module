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

namespace LS_VisionMod.模板创建步骤
{
    public partial class 检测项添加 : UserControl, I模板创建步骤
    {
        Model model;
        MatchingFun matchingfun;
        I检测参数设置 检测项设置;

        Form fatherForm;
        string[] ImagesPath;
        int count = 0;
        HalconFun halconFun = new HalconFun();
        public 检测项添加(ref Model model, Form fatherForm)
        {
            InitializeComponent();
            this.model = model;
            this.fatherForm = fatherForm;
            this.Dock = DockStyle.Fill;
        }

        public void Add()
        {
            //List<Parameter> parameters = 检测项设置.initParameterList();
            //检测项设置.Save(ref parameters);
            //TestItem testItem = new TestItem
            //{
            //    name = 检测项设置.GetName() + model.testItems.Count,
            //    CamName = model.nowCam.name,
            //    MatchName = model.nowMatching.name,
            //    type = 检测项设置.GetName(),
            //    parameters = parameters
            //};
            //model.testItems.Add(testItem);
            model.nowStep++;
        }

        public void Revise()
        {
            List<Parameter> parameters = 检测项设置.initParameterList();
            检测项设置.Save(ref parameters);
            model.nowTestItem.CamName = model.nowCam.name;
            model.nowTestItem.MatchName = model.nowMatching.name;
            model.nowTestItem.type = 检测项设置.GetName();
            model.nowTestItem.parameters = parameters;
        }

        private void 检测项添加_Load(object sender, EventArgs e)
        {

            //获取可用的检测功能
            cmb选择检测项.DataSource = MyRun.GetTestItemList();
            //设置默认值
            //Hashtable testItemSettings = (Hashtable)ConfigurationManager.GetSection("testItemSettings");
            //MyRun.GetTestItemList().FindIndex(x => x.Equals(testItemSettings["type"]));
            //cmb选择检测项.SelectedIndex = MyRun.GetTestItemList().FindIndex(x => x.Equals(testItemSettings["type"]));

        }

        private void MyRun_SoftwareOnceEvent(object sender, TriggerIamge e)
        {
            halconFun.ShowImage(e.ho_Image);
            if (model.nowMatching.type != "无")
            {
                matchingfun = MyRun.GetMatchingFun(model.nowMatching.type);
                matchingfun.Read(MyRun.appPath + "\\model\\" + model.modelName, model.nowMatching);
                matchingfun.Find(halconFun.m_hoImage, out halconFun.m_hoImage);
                halconFun.ShowImage();
            }
            检测项设置.SetHalconImage(halconFun.m_hoImage);
        }

        private void cmb选择检测项_SelectedIndexChanged(object sender, EventArgs e)
        {
            检测项设置 = MyRun.GetParameterSettingControl(cmb选择检测项.Text);
            

            pnl参数设置.Controls.Clear();
            pnl参数设置.Controls.Add((Control)检测项设置);
        }

        private void btn获取图片_Click(object sender, EventArgs e)
        {
            if (rdo相机模式.Checked)
            {
                MyRun.TriggerCamera(model.nowCam.name);
            }
            else if (rdo本地模式.Checked && ImagesPath.Length != 0)
            {
                string ImagePath = ImagesPath[count++];
                halconFun.ReadImage(ImagePath);
                if (model.nowMatching.type != "无")
                {
                    matchingfun = MyRun.GetMatchingFun(model.nowMatching.type);
                    matchingfun.Read(Application.StartupPath + "\\model\\" + model.modelName, model.nowMatching);
                    matchingfun.Find(halconFun.m_hoImage, out halconFun.m_hoImage);
                }
                halconFun.ShowImage();
                检测项设置.SetHalconImage(halconFun.m_hoImage);
                count %= ImagesPath.Length;
            }
        }

        private void 检测项添加_Enter(object sender, EventArgs e)
        {
            
            //关联Halcon窗口
            halconFun.SetWindowHandle(pictureBox1);
            检测项设置.SetHalconWindow(halconFun.m_hvWindowHandle);
            
            ImagesPath = FileOperation.GetImagesPath(MyRun.appPath + "\\model\\" + model.modelName + "\\" + model.nowCam.name);
            lab本地图片数量.Text = "本地图片数量：" + ImagesPath.Length;

            //拍照事件
            MyRun.SoftwareOnceEvent += MyRun_SoftwareOnceEvent;

            if (model.nowTestItem.type != "无")
            {
                检测项设置 = MyRun.GetParameterSettingControl(model.nowTestItem.type);
                检测项设置.SetHalconWindow(halconFun.m_hvWindowHandle);
                检测项设置.Create(model.nowTestItem);
            }
            //如果当前定位模板非空
            if (model.nowMatching.type != "无")
            {
                matchingfun = MyRun.GetMatchingFun(model.nowMatching.type);
                matchingfun.Read(MyRun.appPath + "\\model\\" + model.modelName, model.nowMatching);
                halconFun.m_hoImage = matchingfun.InImage;
                halconFun.ShowImage();
                检测项设置.SetHalconImage(halconFun.m_hoImage);
            }
        }

        private void 检测项添加_Leave(object sender, EventArgs e)
        {

            //拍照事件
            MyRun.SoftwareOnceEvent -= MyRun_SoftwareOnceEvent;
            //关闭Halcon窗口
            halconFun.ColseWindow();
        }

        private void btn测试_Click(object sender, EventArgs e)
        {
            string outMessage;
            List<Parameter> parameters = 检测项设置.initParameterList();
            检测项设置.Save(ref parameters);
            if(halconFun.m_hoImage == null)
            {
                MessageBox.Show("请先获取图片");
                return;
            }
            检测项设置.Find(halconFun.m_hoImage, parameters, out outMessage);
            txt检测结果.Text = outMessage;
        }

        private void btn保存_Click(object sender, EventArgs e)
        {
            List<Parameter> parameters = 检测项设置.initParameterList();
            检测项设置.Save(ref parameters);
            TestItem testItem = new TestItem
            {
                name = 检测项设置.GetName() + model.testItems.Count,
                CamName = model.nowCam.name,
                MatchName = model.nowMatching.name,
                type = 检测项设置.GetName(),
                parameters = parameters
            };
            model.testItems.Add(testItem);
            model.nowTestItem = testItem;
            if(fatherForm is 编辑模板窗口)
            {
                (fatherForm as 编辑模板窗口).ShowModelStatus();
            }
            if (fatherForm is 新建模板窗口)
            {
                (fatherForm as 新建模板窗口).ShowModelStatus();
            }
        }
    }
}
