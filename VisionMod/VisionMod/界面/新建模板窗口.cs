using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionMod.界面
{
    public partial class 新建模板窗口 : Form
    {
        选择模板类型 chooseModelTypeWindow;
        相机配置 camSetWindow;
        图像预处理 imagePretreatWindow;
        匹配定位 matchingWindow;
        检测项添加 testItemsAddWindow;

        Model model;
        public 新建模板窗口()
        {
            InitializeComponent();
        }

        private void 新建模板窗口_Load(object sender, EventArgs e)
        {
            //新建模板窗口新建一个Model对象
            model = new Model();

            chooseModelTypeWindow = new 选择模板类型();
            camSetWindow = new 相机配置(model);
            imagePretreatWindow = new 图像预处理();
            matchingWindow = new 匹配定位(model);
            testItemsAddWindow = new 检测项添加(model);
            //进入模板类型选择界面
            panelMain.Controls.Add(chooseModelTypeWindow);
            btn上一步.Visible = false;

            cmb当前相机.DataSource = HkCameraCltr.GetListUserDefinedName();
            cmb当前相机.Text = "";
        }
    }
}
