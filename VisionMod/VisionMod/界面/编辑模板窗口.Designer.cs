﻿namespace LS_VisionMod.界面
{
    partial class 编辑模板窗口
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.cmb当前检测项 = new System.Windows.Forms.ComboBox();
            this.cmb当前图像预处理 = new System.Windows.Forms.ComboBox();
            this.lab当前型号 = new System.Windows.Forms.Label();
            this.lab当前图像预处理 = new System.Windows.Forms.Label();
            this.txt当前型号 = new System.Windows.Forms.TextBox();
            this.lab当前相机 = new System.Windows.Forms.Label();
            this.cmb当前定位 = new System.Windows.Forms.ComboBox();
            this.lab当前定位 = new System.Windows.Forms.Label();
            this.cmb当前相机 = new System.Windows.Forms.ComboBox();
            this.lab当前检测项 = new System.Windows.Forms.Label();
            this.palNow = new System.Windows.Forms.Panel();
            this.btn保存修改 = new System.Windows.Forms.Button();
            this.palNow.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.AutoSize = true;
            this.panelMain.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelMain.Location = new System.Drawing.Point(3, 46);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(993, 634);
            this.panelMain.TabIndex = 30;
            // 
            // cmb当前检测项
            // 
            this.cmb当前检测项.FormattingEnabled = true;
            this.cmb当前检测项.Location = new System.Drawing.Point(880, 8);
            this.cmb当前检测项.Name = "cmb当前检测项";
            this.cmb当前检测项.Size = new System.Drawing.Size(111, 20);
            this.cmb当前检测项.TabIndex = 21;
            // 
            // cmb当前图像预处理
            // 
            this.cmb当前图像预处理.FormattingEnabled = true;
            this.cmb当前图像预处理.Location = new System.Drawing.Point(492, 8);
            this.cmb当前图像预处理.Name = "cmb当前图像预处理";
            this.cmb当前图像预处理.Size = new System.Drawing.Size(111, 20);
            this.cmb当前图像预处理.TabIndex = 23;
            // 
            // lab当前型号
            // 
            this.lab当前型号.AutoSize = true;
            this.lab当前型号.Location = new System.Drawing.Point(3, 12);
            this.lab当前型号.Name = "lab当前型号";
            this.lab当前型号.Size = new System.Drawing.Size(53, 12);
            this.lab当前型号.TabIndex = 12;
            this.lab当前型号.Text = "模板型号";
            // 
            // lab当前图像预处理
            // 
            this.lab当前图像预处理.AutoSize = true;
            this.lab当前图像预处理.Location = new System.Drawing.Point(403, 12);
            this.lab当前图像预处理.Name = "lab当前图像预处理";
            this.lab当前图像预处理.Size = new System.Drawing.Size(65, 12);
            this.lab当前图像预处理.TabIndex = 22;
            this.lab当前图像预处理.Text = "图像预处理";
            // 
            // txt当前型号
            // 
            this.txt当前型号.Location = new System.Drawing.Point(80, 8);
            this.txt当前型号.Name = "txt当前型号";
            this.txt当前型号.ReadOnly = true;
            this.txt当前型号.Size = new System.Drawing.Size(111, 21);
            this.txt当前型号.TabIndex = 13;
            // 
            // lab当前相机
            // 
            this.lab当前相机.AutoSize = true;
            this.lab当前相机.Location = new System.Drawing.Point(215, 12);
            this.lab当前相机.Name = "lab当前相机";
            this.lab当前相机.Size = new System.Drawing.Size(29, 12);
            this.lab当前相机.TabIndex = 14;
            this.lab当前相机.Text = "相机";
            // 
            // cmb当前定位
            // 
            this.cmb当前定位.FormattingEnabled = true;
            this.cmb当前定位.Location = new System.Drawing.Point(680, 8);
            this.cmb当前定位.Name = "cmb当前定位";
            this.cmb当前定位.Size = new System.Drawing.Size(111, 20);
            this.cmb当前定位.TabIndex = 21;
            // 
            // lab当前定位
            // 
            this.lab当前定位.AutoSize = true;
            this.lab当前定位.Location = new System.Drawing.Point(627, 12);
            this.lab当前定位.Name = "lab当前定位";
            this.lab当前定位.Size = new System.Drawing.Size(29, 12);
            this.lab当前定位.TabIndex = 16;
            this.lab当前定位.Text = "定位";
            // 
            // cmb当前相机
            // 
            this.cmb当前相机.FormattingEnabled = true;
            this.cmb当前相机.Location = new System.Drawing.Point(268, 8);
            this.cmb当前相机.Name = "cmb当前相机";
            this.cmb当前相机.Size = new System.Drawing.Size(111, 20);
            this.cmb当前相机.TabIndex = 20;
            // 
            // lab当前检测项
            // 
            this.lab当前检测项.AutoSize = true;
            this.lab当前检测项.Location = new System.Drawing.Point(815, 12);
            this.lab当前检测项.Name = "lab当前检测项";
            this.lab当前检测项.Size = new System.Drawing.Size(41, 12);
            this.lab当前检测项.TabIndex = 18;
            this.lab当前检测项.Text = "检测项";
            // 
            // palNow
            // 
            this.palNow.Controls.Add(this.cmb当前检测项);
            this.palNow.Controls.Add(this.cmb当前图像预处理);
            this.palNow.Controls.Add(this.lab当前型号);
            this.palNow.Controls.Add(this.lab当前图像预处理);
            this.palNow.Controls.Add(this.txt当前型号);
            this.palNow.Controls.Add(this.lab当前相机);
            this.palNow.Controls.Add(this.cmb当前定位);
            this.palNow.Controls.Add(this.lab当前定位);
            this.palNow.Controls.Add(this.cmb当前相机);
            this.palNow.Controls.Add(this.lab当前检测项);
            this.palNow.Location = new System.Drawing.Point(3, 5);
            this.palNow.Name = "palNow";
            this.palNow.Size = new System.Drawing.Size(1003, 35);
            this.palNow.TabIndex = 32;
            // 
            // btn保存修改
            // 
            this.btn保存修改.Location = new System.Drawing.Point(820, 686);
            this.btn保存修改.Name = "btn保存修改";
            this.btn保存修改.Size = new System.Drawing.Size(115, 37);
            this.btn保存修改.TabIndex = 33;
            this.btn保存修改.Text = "保存修改";
            this.btn保存修改.UseVisualStyleBackColor = true;
            this.btn保存修改.Click += new System.EventHandler(this.btn保存修改_Click);
            // 
            // 编辑模板窗口
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.btn保存修改);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.palNow);
            this.Name = "编辑模板窗口";
            this.Text = "编辑模板窗口";
            this.Load += new System.EventHandler(this.编辑模板窗口_Load);
            this.palNow.ResumeLayout(false);
            this.palNow.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ComboBox cmb当前检测项;
        private System.Windows.Forms.ComboBox cmb当前图像预处理;
        private System.Windows.Forms.Label lab当前型号;
        private System.Windows.Forms.Label lab当前图像预处理;
        private System.Windows.Forms.TextBox txt当前型号;
        private System.Windows.Forms.Label lab当前相机;
        private System.Windows.Forms.ComboBox cmb当前定位;
        private System.Windows.Forms.Label lab当前定位;
        private System.Windows.Forms.ComboBox cmb当前相机;
        private System.Windows.Forms.Label lab当前检测项;
        private System.Windows.Forms.Panel palNow;
        private System.Windows.Forms.Button btn保存修改;
    }
}