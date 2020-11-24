using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFAlarm.界面
{
    public partial class 检测运行界面 : UserControl
    {
        public 检测运行界面()
        {
            InitializeComponent();
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
                MyRun.StartRun();
                btn开始.Text = "检测中";
                btn开始.BaseColor = Color.FromArgb(80, 134, 254);
            }
            else
            {
                MyRun.StartRun();
                btn开始.Text = "检测中";
                btn开始.BaseColor = Color.FromArgb(80, 134, 254);
            }
        }

        private void btn测试_Click(object sender, EventArgs e)
        {
            MyRun.check();
        }
    }
}
