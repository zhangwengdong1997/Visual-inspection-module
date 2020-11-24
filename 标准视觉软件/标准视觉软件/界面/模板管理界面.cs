using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace 标准视觉软件
{
    public partial class 模板管理界面 : UserControl
    {
        public 模板管理界面()
        {
            InitializeComponent();
        }

        private void 模板管理界面_Load(object sender, EventArgs e)
        {
            型号选择 ModelNameSelectWindow = new 型号选择(panelMain);
            panelMain.Controls.Add(ModelNameSelectWindow);
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            string a = ConfigurationManager.AppSettings["userName"];
        }
    }
}
