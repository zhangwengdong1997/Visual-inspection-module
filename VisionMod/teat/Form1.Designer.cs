namespace teat
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.检测模板管理窗口1 = new LS_VisionMod.界面.检测模板管理窗口();
            this.图像显示控件1 = new LS_VisionMod.界面.图像显示控件();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // 检测模板管理窗口1
            // 
            this.检测模板管理窗口1.Location = new System.Drawing.Point(122, 7);
            this.检测模板管理窗口1.Name = "检测模板管理窗口1";
            this.检测模板管理窗口1.Size = new System.Drawing.Size(1024, 768);
            this.检测模板管理窗口1.TabIndex = 0;
            // 
            // 图像显示控件1
            // 
            this.图像显示控件1.Location = new System.Drawing.Point(29, 440);
            this.图像显示控件1.Name = "图像显示控件1";
            this.图像显示控件1.Size = new System.Drawing.Size(171, 128);
            this.图像显示控件1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(83, 648);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 787);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.图像显示控件1);
            this.Controls.Add(this.检测模板管理窗口1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private LS_VisionMod.界面.检测模板管理窗口 检测模板管理窗口1;
        private LS_VisionMod.界面.图像显示控件 图像显示控件1;
        private System.Windows.Forms.Button button1;
    }
}

