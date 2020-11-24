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



        private void btn下一步_Click(object sender, EventArgs e)
        {
            (panelMain.Controls[0] as I模板创建步骤).Save(model);
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
            ShowNowModel();
        }

        public void ShowNowModel()
        {
            
            txt当前型号.Text = model.modelName;
            cmb当前相机.Text = model.nowCam;
            List<string> imagePreprocessesName = new List<string>();
            foreach (var item in model.imagePreprocesses)
            {
                imagePreprocessesName.Add(item.name);
            }
            cmb当前图像预处理.DataSource = imagePreprocessesName;
            if (model.nowImagePreprocess == null)
            {
                cmb当前图像预处理.Text = "无";
            }
            else
            {
                cmb当前图像预处理.Text = model.nowImagePreprocess.name;
            }
            List<string> matchingsName = new List<string>();
            foreach (var item in model.matchings)
            {
                matchingsName.Add(item.name);
            }
            cmb当前定位.DataSource = matchingsName;
            if(model.nowMatching == null)
            {
                cmb当前定位.Text = "无";
            }
            else
            {
                cmb当前定位.Text = model.nowMatching.name;
            }
            List<string> testItemsName = new List<string>();
            foreach (var item in model.testItems)
            {
                testItemsName.Add(item.name);
            }

            cmb当前检测项.DataSource = testItemsName;
            if (model.testItems == null)
            {
                cmb当前检测项.Text = "无";
            }
            else
            {
                cmb当前检测项.Text = "";
                model.nowTestItem = null;
            }
            palNow.Visible = true;
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
            ShowNowModel();
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

        private void cmb当前相机_SelectedIndexChanged(object sender, EventArgs e)
        {
            model.nowCam = cmb当前相机.Text;
        }

        private void cmb当前图像预处理_SelectedIndexChanged(object sender, EventArgs e)
        {
            model.nowImagePreprocess = model.imagePreprocesses[cmb当前图像预处理.SelectedIndex];
        }

        private void cmb当前定位_SelectedIndexChanged(object sender, EventArgs e)
        {
            model.nowMatching = model.matchings[cmb当前定位.SelectedIndex];
        }

        private void cmb当前检测项_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb当前检测项_DropDownClosed(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("修改检测项", "是否要修改之前添加的检测项", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                model.nowTestItem = model.testItems[cmb当前检测项.SelectedIndex];
                btn下一步.Text = "下一步";
            }
        }
    }
}
