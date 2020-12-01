using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LS_VisionMod.模板创建步骤;

namespace LS_VisionMod.界面
{
    public partial class 新建模板窗口 : Form
    {
        选择模板类型 chooseModelTypeWindow;
        相机配置 camSetWindow;
        //图像预处理 imagePretreatWindow;
        匹配定位 matchingWindow;
        检测项添加 testItemsAddWindow;

        Model model;

        AutoControlSize autoSize;
        public 新建模板窗口()
        {
            InitializeComponent();
            autoSize = new AutoControlSize();
            autoSize.InitializeControlsSize(this);
        }

        private void 新建模板窗口_Load(object sender, EventArgs e)
        {
            //新建模板窗口新建一个Model对象
            model = new Model();

            chooseModelTypeWindow = new 选择模板类型(ref model);
            camSetWindow = new 相机配置(ref model);
            //imagePretreatWindow = new 图像预处理();
            matchingWindow = new 匹配定位(ref model);
            testItemsAddWindow = new 检测项添加(ref model);
            //进入模板类型选择界面
            panelMain.Controls.Add(chooseModelTypeWindow);
            btn上一步.Visible = false;

            cmb当前相机.DataSource = MyRun.GetCameraList();
            cmb当前相机.Text = "";
        }

        private void btn下一步_Click(object sender, EventArgs e)
        {
            (panelMain.Controls[0] as I模板创建步骤).Save();
            if (model.nowStep == model.steps.Count)
            {
                MyRun.WriteModelJS(model);
                this.Close();
                return;
            }
            panelMain.Controls.Clear();
            Control stepsControl = GetStepWindow(model.steps[model.nowStep]);
            panelMain.Controls.Add(stepsControl);
            stepsControl.Focus();
            if (model.nowStep + 1 == model.steps.Count) { btn下一步.Text = "完成"; }
            if (model.nowStep != 0)
            {
                btn上一步.Visible = true;
            }
        }

        private Control GetStepWindow(StepName stepName)
        {
            switch (stepName)
            {
                case StepName.选择模板类型:
                    return chooseModelTypeWindow;
                case StepName.相机配置:
                    return camSetWindow;
                //case StepName.图像预处理:
                //    return imagePretreatWindow;
                case StepName.匹配定位:
                    return matchingWindow;
                case StepName.检测项添加:
                    return testItemsAddWindow;
                default:
                    return null;
            }
        }

        private void btn上一步_Click(object sender, EventArgs e)
        {
            if (model.nowStep == 1)
            {
                btn上一步.Visible = false;
            }
            model.nowStep--;
            panelMain.Controls.Clear();
            Control stepsControl = GetStepWindow(model.steps[model.nowStep]);
            panelMain.Controls.Add(stepsControl);
            stepsControl.Focus();
            btn下一步.Text = "下一步";
            
        }

        private void 新建模板窗口_Resize(object sender, EventArgs e)
        {
            autoSize.Resize(this);
        }
    }
}
