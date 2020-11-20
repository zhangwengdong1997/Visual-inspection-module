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
    public partial class 新建模板 : Form
    {
        选择模板类型 chooseModelTypeWindow;
        相机配置 camSetWindow;
        图像预处理 imagePretreatWindow;
        匹配定位 matchingWindow;
        检测项添加 testItemsAddWindow;

        Model model;

        public 新建模板()
        {
            InitializeComponent();
            
        }

        private void 新建模板_Load(object sender, EventArgs e)
        {
            
            model = new Model();
            chooseModelTypeWindow = new 选择模板类型();
            camSetWindow = new 相机配置(model);
            imagePretreatWindow = new 图像预处理();
            matchingWindow = new 匹配定位(model);
            testItemsAddWindow = new 检测项添加(model);
            panelMain.Controls.Add(chooseModelTypeWindow);
            btn上一步.Visible = false;
            model.steps.Add(StepName.选择模板类型);
        }



        private void btn下一步_Click(object sender, EventArgs e)
        {
            (panelMain.Controls[0] as 模板创建步骤).Save(model);
            if (model.nowStep == model.steps.Count)
            {
                MyRun.WriteModelJS(model);
                this.Close();
                return;
            }
            panelMain.Controls.Clear();   
            panelMain.Controls.Add(GetStepWindow(model.steps[model.nowStep]));
            if (model.nowStep + 1 == model.steps.Count) { btn下一步.Text = "完成"; }
            if (model.nowStep != 0)
            {
                btn上一步.Visible = true;
            }
        }

        public void ShowNowModel()
        {
            txt当前型号.Text = model.modelName;
            txt当前相机.Text = model.nowCam;

        }

        private void btn上一步_Click(object sender, EventArgs e)
        {
            if(model.nowStep == 1)
            {
                btn上一步.Visible = false;
            }
            model.nowStep--;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(GetStepWindow(model.steps[model.nowStep]));
            btn下一步.Text = "下一步";
        }
        private Control GetStepWindow(StepName stepName)
        {
            switch (stepName)
            {
                case StepName.选择模板类型:
                    return chooseModelTypeWindow;
                case StepName.相机配置:
                    return camSetWindow;
                case StepName.图像预处理:
                    return imagePretreatWindow;
                case StepName.匹配定位:
                    return matchingWindow;
                case StepName.检测项添加:
                    return testItemsAddWindow;
                default:
                    return null;
            }
        }

        private void 新建模板_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        
    }
}
