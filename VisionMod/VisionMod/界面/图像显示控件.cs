using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace LS_VisionMod.界面
{
    public partial class 图像显示控件 : UserControl
    {
        string connectCam;
        public 图像显示控件()
        {
            InitializeComponent();
            //拍照事件
            VisinoMod.SoftwareOnceEvent += MyRun_SoftwareOnceEvent;
            VisinoMod.DetectionOnceEvent += VisinoMod_DetectionOnceEvent;
        }

        private void VisinoMod_DetectionOnceEvent(object sender, DetectionResult e)
        {
            if (connectCam == null || e.camName == connectCam)
            {
                this.Invoke(new Action(() => {
                    HalconFun.ShowImage(e.ho_resultImage, hWindowControl1.HalconWindow);
                }
                ));
            }

        }

        public string ConnectCam { get => connectCam; set => connectCam = value; }

        private void MyRun_SoftwareOnceEvent(object sender, TriggerIamge e)
        {
            if(connectCam == null || e.camName == connectCam)
            {
                this.Invoke(new Action(() =>HalconFun.ShowImage(e.ho_Image, hWindowControl1.HalconWindow)));
            }
            
        }
    }
}
