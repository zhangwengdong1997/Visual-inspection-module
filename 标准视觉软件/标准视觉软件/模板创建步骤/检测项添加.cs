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
    public partial class 检测项添加 : UserControl, 模板创建步骤
    {
        检测参数设置 检测项设置;
        string[] ImagesPath;
        int count = 0;
        HObject m_hoImage;
        HWindow m_hvWindowHandle;
        Model model;
        定位功能  matchingWay;
        public 检测项添加(Model model)
        {
            InitializeComponent();
            this.model = model;
        }

        public void Save(Model model)
        {
            TestItem testItem = new TestItem();
            testItem.name = 检测项设置.GetName();
            testItem.CamName = model.nowCam;
            testItem.Match = model.nowMatching;
            testItem.type = 检测项设置.GetName();
            List<Parameter> parameters = 检测项设置.initParameterList();
            检测项设置.Save(ref parameters);
            testItem.parameters = parameters;
            model.testItems.Add(testItem);
        }

        private void 检测项添加_Load(object sender, EventArgs e)
        {
            m_hvWindowHandle = new HWindow();
            cmb选择检测项.DataSource = MyRun.GetTestItemList();
            DisplayWindowsInitial();
            MyRun.SoftwareOnceEvent += MyRun_SoftwareOnceEvent;
        }

        private void MyRun_SoftwareOnceEvent(object sender, TriggerIamge e)
        {
            m_hoImage = e.ho_Image;
            if (model.nowMatching != null)
            {
                matchingWay = MyRun.GetMatchingFun(model.nowMatching.type);
                matchingWay.Read(Application.StartupPath + "\\model\\" + model.modelName, model.nowMatching.name);
                matchingWay.Find(m_hoImage, out m_hoImage);
            }
            HalconDisplay(m_hvWindowHandle, m_hoImage);

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

        public void HalconDisplay(HTuple hWindow, HObject Hobj)
        {
            // ch: 显示 || display
            try
            {
                HTuple Width = null, Height = null;
                HOperatorSet.GetImagePointer1(Hobj, out _, out _, out Width, out Height);
                HOperatorSet.SetPart(hWindow, 0, 0, Height, Width);
                HOperatorSet.SetPart(hWindow, 0, 0, Height - 1, Width - 1);// ch: 使图像显示适应窗口大小 || en: Make the image adapt the window size
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            if (hWindow == null)
            {
                return;
            }
            try
            {
                HOperatorSet.DispObj(Hobj, hWindow);// ch 显示 || en: display
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            return;
        }

        private void cmb选择检测项_SelectedIndexChanged(object sender, EventArgs e)
        {
            检测项设置 = MyRun.GetParameterSettingControl(cmb选择检测项.Text);
            检测项设置.SetHalconWindow(m_hvWindowHandle);
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
                HOperatorSet.ReadImage(out m_hoImage, ImagesPath[count++]);

                if (model.nowMatching != null)
                {
                    matchingWay = MyRun.GetMatchingFun(model.nowMatching.type);
                    matchingWay.Read(Application.StartupPath + "\\model\\" + model.modelName, model.nowMatching.name);
                    matchingWay.Find(m_hoImage, out m_hoImage);
                }
                HalconDisplay(m_hvWindowHandle, m_hoImage);
                count %= ImagesPath.Length;
            }
        }

        private void btn测试_Click(object sender, EventArgs e)
        {

            string outMessage;
            List<Parameter> parameters = 检测项设置.initParameterList();
            检测项设置.Save(ref parameters);

            检测项设置.Find(m_hoImage, parameters, out outMessage);
            txt检测结果.Text = outMessage;

        }

        private void 检测项添加_Enter(object sender, EventArgs e)
        {
            lab当前相机.Text = "当前相机：" + model.nowCam;
            ImagesPath = FileOperation.GetFiles(Application.StartupPath + "\\model\\" + model.modelName + "\\" + model.nowCam);
            lab本地图片数量.Text = "本地图片数量：" + ImagesPath.Length;
        }
    }
}
