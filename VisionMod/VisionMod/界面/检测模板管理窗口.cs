﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LS_VisionMod.界面
{
    public partial class 检测模板管理窗口 : UserControl
    {
        public 检测模板管理窗口()
        {
            InitializeComponent();
            
        }
        private void 检测模板管理窗口_Load(object sender, EventArgs e)
        {
            //显示已建模板列表
        }

        private void bnt新建模板_Click(object sender, EventArgs e)
        {
            //打开新建模板界面
            新建模板窗口 createModeFrom = new 新建模板窗口();
            createModeFrom.ShowDialog();
            //更新已建模板列表

        }

        private void btn搜索_Click(object sender, EventArgs e)
        {
            //已建模板列表显示与搜索关键词相关的模板
        }
    }
}
