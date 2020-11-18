namespace 标准视觉软件
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
            this.创建模板按钮 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // 创建模板按钮
            // 
            this.创建模板按钮.Location = new System.Drawing.Point(244, 178);
            this.创建模板按钮.Name = "创建模板按钮";
            this.创建模板按钮.Size = new System.Drawing.Size(163, 79);
            this.创建模板按钮.TabIndex = 3;
            this.创建模板按钮.Text = "创建模板";
            this.创建模板按钮.UseVisualStyleBackColor = true;
            this.创建模板按钮.Click += new System.EventHandler(this.创建模板按钮_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 435);
            this.Controls.Add(this.创建模板按钮);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button 创建模板按钮;
    }
}

