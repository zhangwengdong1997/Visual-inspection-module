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
using System.IO;

namespace 标准视觉软件
{
    public partial class 相机配置 : UserControl, 模板创建步骤
    {
        string camName;
        float exposureTime = -1;
        string localImagePath;
        string[] ImagesPath;
        int count = 0;

        HWindow m_Window;
        Model model;
        public 相机配置(Model model)
        {
            InitializeComponent();
            this.model = model;
        }

        private void 相机配置_Load(object sender, EventArgs e)
        {
            cmb相机列表.DataSource = HkCameraCltr.GetListUserDefinedName();
            m_Window = new HWindow();
            DisplayWindowsInitial();
            MyRun.SoftwareOnceEvent += MyRun_SoftwareOnceEvent;
            //导入模板默认配置（未完成）
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
                m_Window.OpenWindow(hWindowRow, hWindowColumn, hWindowWidth, hWindowHeight, hWindowID, "visible", "");
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

        private void MyRun_SoftwareOnceEvent(object sender, TriggerIamge e)
        {
            HalconDisplay(m_Window, e.ho_Image);
        }


        private void cmb相机列表_SelectedIndexChanged(object sender, EventArgs e)
        {
            camName = cmb相机列表.SelectedItem.ToString();
            FileOperation.CreateDirectory("model", model.modelName, camName);
            localImagePath = Application.StartupPath + "\\model\\" + model.modelName + "\\" + camName;
            txt关联图片路径.Text = localImagePath;
            ImagesPath = FileOperation.GetFiles(localImagePath);
            lab关联图片数量.Text = ImagesPath.Length.ToString();
        }

        private void txt相机曝光值_TextChanged(object sender, EventArgs e)
         {
            if (float.TryParse(txt相机曝光值.Text, out exposureTime))
            {
                if (exposureTime < 100 || exposureTime > 2000000)
                {
                    lab相机曝光值提示.Text = "相机曝光值范围100至2000000";
                }
                else
                {
                    lab相机曝光值提示.Text = "";
                    MyRun.SetCameraExposureTime(camName, exposureTime);
                }
            }
            else
            {
                lab相机曝光值提示.Text = "请输入相机曝光值";
                txt相机曝光值.Text = "";
            }
        }

        private void btn添加本地图片关联相机_Click(object sender, EventArgs e)
        {
            string ImagePath;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPEG文件|*.jpg*|BMP文件|*.bmp*";
            openFileDialog.RestoreDirectory = true;


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ImagePath = openFileDialog.FileName;
                File.Copy(ImagePath, localImagePath + "\\" + openFileDialog.SafeFileName, true);
                ImagesPath = FileOperation.GetFiles(localImagePath);
                lab关联图片数量.Text = ImagesPath.Length.ToString();
            }
        }

        private void btn获取图片_Click(object sender, EventArgs e)
        {

            if (rdo相机模式.Checked)
            {
                MyRun.TriggerCamera(camName);
            }
            else if (rdo本地模式.Checked && ImagesPath.Length != 0)
            {
                HObject ho_Image;
                HOperatorSet.ReadImage(out ho_Image, ImagesPath[count++]);
                HalconDisplay(m_Window, ho_Image);
                count %= ImagesPath.Length;
            }

        }
        public void Save(Model model)
        {
            model.cams.Add(new Cam(camName, exposureTime));
            model.nowCam = camName;
        }

        private void rdo相机模式_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdo本地模式_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
