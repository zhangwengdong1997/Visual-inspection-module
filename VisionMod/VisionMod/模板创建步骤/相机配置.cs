using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Configuration;
using System.IO;

namespace LS_VisionMod.模板创建步骤
{
    public partial class 相机配置 : UserControl,I模板创建步骤
    {
        Model model;
        string camName;
        string localImagePath;
        string[] ImagesPath;
        float exposureTime = -1;
        /// <summary>
        /// 循环遍历本地关联图片使用
        /// </summary>
        int count = 0;
        public 相机配置(ref Model model)
        {
            InitializeComponent();
            this.model = model;
            this.Dock = DockStyle.Fill;
        }
        public void Save()
        {
            model.cams.Add(new Cam(camName, exposureTime));
            model.nowCam = camName;
            model.camNum++;
            model.nowStep++;
        }
        private void 相机配置_Load(object sender, EventArgs e)
        {
            //获取连接的相机名，供选择
            cmb相机列表.DataSource = MyRun.GetCameraList();
            if(MyRun.GetCameraList().Count == 0)
            {
                camName = "noCam";
                localImagePath = MyRun.appPath + "\\model\\" + model.modelName + "\\noCam";
                Directory.CreateDirectory(localImagePath);
                ImagesPath = FileOperation.GetImagesPath(localImagePath);
                lab关联图片数量.Text = ImagesPath.Length.ToString();
            }
            //拍照事件
            MyRun.SoftwareOnceEvent += MyRun_SoftwareOnceEvent;


        }
        

        private void MyRun_SoftwareOnceEvent(object sender, TriggerIamge e)
        {
            HalconFun.ShowImage(e.ho_Image);
        }

        

        private void cmb相机列表_SelectedIndexChanged(object sender, EventArgs e)
        {
            camName = cmb相机列表.SelectedItem.ToString();
            //获取相机当前曝光值
            txt相机曝光值.Text = MyRun.GetCamExposureTime(camName).ToString();
            //获取该相机关联图片的路径，如无此路径则创建文件夹用于保存相机关联图片
            localImagePath = MyRun.appPath + "\\model\\" + model.modelName + "\\" + camName;
            ImagesPath = FileOperation.GetImagesPath(localImagePath);
            count = 0;
            //获取关联图片数量
            lab关联图片数量.Text = ImagesPath.Length.ToString();
        }


        private void txt相机曝光值_TextChanged(object sender, EventArgs e)
        {
            if (camName.Equals("noCam"))
                return;
            //设置相机曝光值
            if (float.TryParse(txt相机曝光值.Text, out exposureTime))
            {
                float lower = MyRun.GetCamExposureTimeLower(camName);
                float upper = MyRun.GetCamExposureTimeUpper(camName);
                if (exposureTime < lower || exposureTime > upper)
                {
                    lab相机曝光值提示.Text = string.Format("相机曝光值范围{0}至{1}", lower, upper);
                }
                else
                {
                    lab相机曝光值提示.Text = "";
                    if (camName != null)
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
                ImagesPath = FileOperation.GetImagesPath(localImagePath);
                lab关联图片数量.Text = ImagesPath.Length.ToString();
            }
        }

        private void btn添加当前图片关联相机_Click(object sender, EventArgs e)
        {
            HalconFun.WriteImage(localImagePath, DateTime.Now.ToString("HH-mm-ss") + ".jpg");
            ImagesPath = FileOperation.GetImagesPath(localImagePath);
            lab关联图片数量.Text = ImagesPath.Length.ToString();
        }

        private void btn获取图片_Click(object sender, EventArgs e)
        {
            if (rdo相机模式.Checked)
            {
                MyRun.TriggerCamera(camName);
            }
            else if (rdo本地模式.Checked && ImagesPath.Length != 0)
            {
                string ImagePath = ImagesPath[count++];
                HalconFun.ReadImage(ImagePath);
                HalconFun.ShowImage();
                
                count %= ImagesPath.Length;
            }
        }

        private void 相机配置_Enter(object sender, EventArgs e)
        {
            //关联Halcon窗口
            HalconFun.SetWindowHandle(pictureBox1);
            //显示上一步的图片
            HalconFun.ShowImage();

        }

        private void 相机配置_Leave(object sender, EventArgs e)
        {
            //关闭Halcon窗口
            HalconFun.ColseWindow();
        }

    }
}
