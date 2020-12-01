namespace LS_VisionMod.界面
{
    partial class 检测模板管理窗口
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
            this.btn搜索 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bnt删除模板 = new System.Windows.Forms.Button();
            this.bnt新建模板 = new System.Windows.Forms.Button();
            this.已建模板列表控件1 = new LS_VisionMod.界面.已建模板列表控件();
            this.SuspendLayout();
            // 
            // btn搜索
            // 
            this.btn搜索.Location = new System.Drawing.Point(412, 55);
            this.btn搜索.Name = "btn搜索";
            this.btn搜索.Size = new System.Drawing.Size(70, 34);
            this.btn搜索.TabIndex = 9;
            this.btn搜索.Text = "搜索";
            this.btn搜索.UseVisualStyleBackColor = true;
            this.btn搜索.Visible = false;
            this.btn搜索.Click += new System.EventHandler(this.btn搜索_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(107, 63);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(289, 21);
            this.textBox1.TabIndex = 8;
            this.textBox1.Visible = false;
            // 
            // bnt删除模板
            // 
            this.bnt删除模板.Location = new System.Drawing.Point(579, 442);
            this.bnt删除模板.Name = "bnt删除模板";
            this.bnt删除模板.Size = new System.Drawing.Size(276, 83);
            this.bnt删除模板.TabIndex = 13;
            this.bnt删除模板.Text = "删除模板";
            this.bnt删除模板.UseVisualStyleBackColor = true;
            this.bnt删除模板.Click += new System.EventHandler(this.bnt删除模板_Click);
            // 
            // bnt新建模板
            // 
            this.bnt新建模板.Location = new System.Drawing.Point(579, 231);
            this.bnt新建模板.Name = "bnt新建模板";
            this.bnt新建模板.Size = new System.Drawing.Size(276, 83);
            this.bnt新建模板.TabIndex = 11;
            this.bnt新建模板.Text = "新建模板";
            this.bnt新建模板.UseVisualStyleBackColor = true;
            this.bnt新建模板.Click += new System.EventHandler(this.bnt新建模板_Click);
            // 
            // 已建模板列表控件1
            // 
            this.已建模板列表控件1.Location = new System.Drawing.Point(97, 137);
            this.已建模板列表控件1.Name = "已建模板列表控件1";
            this.已建模板列表控件1.Size = new System.Drawing.Size(419, 521);
            this.已建模板列表控件1.TabIndex = 15;
            // 
            // 检测模板管理窗口
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.已建模板列表控件1);
            this.Controls.Add(this.bnt删除模板);
            this.Controls.Add(this.bnt新建模板);
            this.Controls.Add(this.btn搜索);
            this.Controls.Add(this.textBox1);
            this.Name = "检测模板管理窗口";
            this.Size = new System.Drawing.Size(1024, 768);
            this.Load += new System.EventHandler(this.检测模板管理窗口_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn搜索;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bnt删除模板;
        private System.Windows.Forms.Button bnt新建模板;
        private 已建模板列表控件 已建模板列表控件1;
    }
}
