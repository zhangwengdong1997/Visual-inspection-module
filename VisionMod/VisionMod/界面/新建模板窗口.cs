﻿using System;
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
            matchingWindow = new 匹配定位(ref model, this);
            testItemsAddWindow = new 检测项添加(ref model, this);

            //进入模板类型选择界面
            panelMain.Controls.Add(chooseModelTypeWindow);
            //不显示上一步按钮
            btn上一步.Visible = false;


            ShowModelStatus();
        }

        /// <summary>
        /// 显示模板当前状态
        /// </summary>
        public void ShowModelStatus()
        {
            txt当前型号.Text = model.modelName;

            cmb当前相机.DataSource = new List<string>
                (model.cams.Select(t => t.name).ToList());
            cmb当前相机.SelectedItem = model.nowCam.name;

            cmb当前图像预处理.DataSource = new List<string>
                (model.imagePreprocesses.Select(t => t.name).ToList());
            cmb当前图像预处理.SelectedItem = model.nowImagePreprocess.name;

            cmb当前定位.DataSource = new List<string>
                (model.matchings.Select(t => t.name).ToList());
            cmb当前定位.SelectedItem = model.nowMatching.name;

            cmb当前检测项.DataSource = new List<string>
                (model.testItems.Select(t => t.name).ToList());
            cmb当前检测项.SelectedItem = model.nowTestItem.name;

        }

        private void btn下一步_Click(object sender, EventArgs e)
        {
            //调用模板创建步骤控件的保存方法，将控件中设置的参数保存至模板
            (panelMain.Controls[0] as I模板创建步骤).Add();
            //最后一步，保存模板并关闭窗口
            if (model.nowStep == model.steps.Count)
            {
                MyRun.WriteModelJS(model);
                this.Close();
                return;
            }
            //显示下一步骤的控件
            panelMain.Controls.Clear();
            Control stepsControl = GetStepWindow(model.steps[model.nowStep]);
            panelMain.Controls.Add(stepsControl);
            stepsControl.Focus();

            //下一步是最后一步，将下一步按钮的显示文本改为“完成”
            if (model.nowStep + 1 == model.steps.Count) { btn下一步.Text = "完成"; }
            //显示上一步按钮
            if (model.nowStep != 0)
            {
                btn上一步.Visible = true;
            }

            ShowModelStatus();
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

        private void cmb当前相机_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmb当前相机.Focused)
            {
                model.nowCam = model.cams[cmb当前相机.SelectedIndex];
            }
        }

        private void cmb当前图像预处理_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmb当前图像预处理.Focused)
            {
                model.nowImagePreprocess = model.imagePreprocesses[cmb当前图像预处理.SelectedIndex];
            }
            
        }

        private void cmb当前定位_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmb当前定位.Focused)
            {
                model.nowMatching = model.matchings[cmb当前定位.SelectedIndex];
            }
        }

        private void cmb当前检测项_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmb当前检测项.Focused)
            {
                model.nowTestItem = model.testItems[cmb当前检测项.SelectedIndex];
            }
        }
    }
}
