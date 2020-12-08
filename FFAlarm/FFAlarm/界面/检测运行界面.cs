using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LS_VisionMod;

namespace FFAlarm.界面
{
    public partial class 检测运行界面 : UserControl
    {
        public 检测运行界面()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void btn开始_Click(object sender, EventArgs e)
        {
            if (btn开始.Text == "检测中")
            {
                MyRun.StopRun();
                btn开始.Text = "暂停中";
                btn开始.BaseColor = Color.FromArgb(224, 64, 10);

            }
            else if (btn开始.Text == "暂停中")
            {
                MyRun.PrepareModel(cmbModeName.Text);
                MyRun.StartRun();
                btn开始.Text = "检测中";
                btn开始.BaseColor = Color.FromArgb(80, 134, 254);
            }
            else
            {
                MyRun.PrepareModel(cmbModeName.Text);
                MyRun.StartRun();
                
                btn开始.Text = "检测中";
                btn开始.BaseColor = Color.FromArgb(80, 134, 254);
            }
        }

        private void btn测试_Click(object sender, EventArgs e)
        {
            MyRun.PrepareModel(cmbModeName.Text);
            MyRun.check();
        }

        private void 检测运行界面_Load(object sender, EventArgs e)
        {
            cmbModeName.DataSource = MyRun.GetModeNameList();
            图像显示控件1.ConnectCam = "122";
            MyRun.ResultMsg += MyRun_ResultMsg;
        }

        private void MyRun_ResultMsg(object sender, string e)
        {
            if(e == null)
            {
                this.Invoke(new Action(() => { txtMessage.Text = ""; }));
            }
            this.Invoke(new Action(() => { txtMessage.Text += e; }));
        }

        private void cmbModeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void 检测运行界面_Enter(object sender, EventArgs e)
        {
            cmbModeName.DataSource = MyRun.GetModeNameList();
        }
    }
}
