﻿namespace FFAlarm.界面
{
    partial class 模板创建界面
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.检测模板管理窗口1 = new LS_VisionMod.界面.检测模板管理窗口();
            this.SuspendLayout();
            // 
            // 检测模板管理窗口1
            // 
            this.检测模板管理窗口1.Location = new System.Drawing.Point(-33, 0);
            this.检测模板管理窗口1.Name = "检测模板管理窗口1";
            this.检测模板管理窗口1.Size = new System.Drawing.Size(1037, 745);
            this.检测模板管理窗口1.TabIndex = 0;
            // 
            // 模板创建界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.检测模板管理窗口1);
            this.Name = "模板创建界面";
            this.Size = new System.Drawing.Size(983, 748);
            this.Load += new System.EventHandler(this.模板创建界面_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private LS_VisionMod.界面.检测模板管理窗口 检测模板管理窗口1;
    }
}
