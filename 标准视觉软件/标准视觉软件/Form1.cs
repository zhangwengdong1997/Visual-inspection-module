using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 标准视觉软件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 创建模板按钮_Click(object sender, EventArgs e)
        {
            调用视觉模板管理的窗口 mainForm = new 调用视觉模板管理的窗口();
            mainForm.ShowDialog();
        }
    }
}
