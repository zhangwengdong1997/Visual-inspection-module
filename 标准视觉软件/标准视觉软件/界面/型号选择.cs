using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 标准视觉软件
{
    public partial class 型号选择 : UserControl
    {
        Panel panelMain;
        public 型号选择(Panel panelMain)
        {
            InitializeComponent();
            this.panelMain = panelMain;
        }

        private void bnt新建模板_Click(object sender, EventArgs e)
        {
            新建模板 createModeFrom = new 新建模板();
            createModeFrom.ShowDialog();
        }

        private void 型号选择_Load(object sender, EventArgs e)
        {

            //初始化界面
            //列表中显示之前创建的所有型号
            //读取存储的json文件
            //List<String> list = FileOperation.GetAllDirectoryName(Application.StartupPath + "\\model");
            

        }
    }
}
