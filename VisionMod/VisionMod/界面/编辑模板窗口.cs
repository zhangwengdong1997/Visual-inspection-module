﻿using LS_VisionMod.模板创建步骤;
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
        检测项编辑 testItemsEditWindow;
        相机配置 camSetWindow;
        //图像预处理 imagePretreatWindow;
        匹配定位 matchingWindow;
        检测项添加 testItemsAddWindow;

        Model model;

        AutoControlSize autoSize;
        public 编辑模板窗口(string modelName)
        {
            InitializeComponent();
            this.model = MyRun.ReadModelJS(modelName);
            autoSize = new AutoControlSize();
            autoSize.InitializeControlsSize(this);
        }

        private void 编辑模板窗口_Load(object sender, EventArgs e)
        {
            testItemsEditWindow = new 检测项编辑(ref model, this);
            camSetWindow = new 相机配置(ref model);
            //imagePretreatWindow = new 图像预处理();
            matchingWindow = new 匹配定位(ref model);
            testItemsAddWindow = new 检测项添加(ref model);
            panelMain.Controls.Add(testItemsEditWindow);
            btn上一步.Visible = false;
            btn下一步.Visible = false;
            cmb当前相机.DataSource = MyRun.GetCameraList();
            cmb当前相机.Text = "";
        }

        public void SwitchWindow(StepName stepName)
        {
            //以后改为工厂模式，现在先用switch
            switch (stepName)
            {
                case StepName.相机配置:
                    panelMain.Controls.Clear();
                    panelMain.Controls.Add(camSetWindow);
                    break;
                case StepName.匹配定位:
                    panelMain.Controls.Clear();
                    panelMain.Controls.Add(matchingWindow);
                    break;
                case StepName.检测项添加:
                    panelMain.Controls.Clear();
                    panelMain.Controls.Add(testItemsAddWindow);
                    break;
            }

        }

        private void btn下一步_Click(object sender, EventArgs e)
        {
            (panelMain.Controls[0] as I模板创建步骤).Save();
            panelMain.Controls.Clear();
            panelMain.Controls.Add(testItemsEditWindow);
        }
    }
}
