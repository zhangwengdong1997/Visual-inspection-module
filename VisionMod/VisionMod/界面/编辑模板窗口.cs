using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LS_VisionMod.界面
{
    public partial class 编辑模板窗口 : Form
    {
        Model model;
        public 编辑模板窗口(string modelName)
        {
            InitializeComponent();
            this.model = MyRun.ReadModelJS(modelName);
        }

        private void 编辑模板窗口_Load(object sender, EventArgs e)
        {

        }

        //public DataTable GetTestItems()
        //{
        //    DataTable dataTable = new DataTable();

        //    return 
        //}
    }
}
