using LS_VisionMod;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VisinoMod.Connect();
            图像显示控件1.ConnectCam = "camCM";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VisinoMod.PrepareModel("123");
            //VisinoMod.TriggerCamera();
            VisinoMod.TriggerDetection();

        }
    }
}
