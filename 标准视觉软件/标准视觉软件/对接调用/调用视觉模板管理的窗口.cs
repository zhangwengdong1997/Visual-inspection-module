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
    public partial class 调用视觉模板管理的窗口 : Form
    {
        public 调用视觉模板管理的窗口()
        {
            MyRun.Init();
            InitializeComponent();
        }

        private void 调用视觉模板管理的窗口_Load(object sender, EventArgs e)
        {
            模板管理界面 CreateModelWindow = new 模板管理界面();
            this.Controls.Add(CreateModelWindow);
        }
    }
}
