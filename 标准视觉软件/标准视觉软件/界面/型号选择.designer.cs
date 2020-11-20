namespace 标准视觉软件
{
    partial class 型号选择
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bnt新建模板 = new System.Windows.Forms.Button();
            this.bnt编辑模板 = new System.Windows.Forms.Button();
            this.bnt删除模板 = new System.Windows.Forms.Button();
            this.bnt复制模板 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.pnlModelList = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(87, 72);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(289, 21);
            this.textBox1.TabIndex = 0;
            // 
            // bnt新建模板
            // 
            this.bnt新建模板.Location = new System.Drawing.Point(644, 118);
            this.bnt新建模板.Name = "bnt新建模板";
            this.bnt新建模板.Size = new System.Drawing.Size(276, 83);
            this.bnt新建模板.TabIndex = 2;
            this.bnt新建模板.Text = "新建模板";
            this.bnt新建模板.UseVisualStyleBackColor = true;
            this.bnt新建模板.Click += new System.EventHandler(this.bnt新建模板_Click);
            // 
            // bnt编辑模板
            // 
            this.bnt编辑模板.Location = new System.Drawing.Point(644, 256);
            this.bnt编辑模板.Name = "bnt编辑模板";
            this.bnt编辑模板.Size = new System.Drawing.Size(276, 83);
            this.bnt编辑模板.TabIndex = 3;
            this.bnt编辑模板.Text = "编辑模板";
            this.bnt编辑模板.UseVisualStyleBackColor = true;
            // 
            // bnt删除模板
            // 
            this.bnt删除模板.Location = new System.Drawing.Point(644, 532);
            this.bnt删除模板.Name = "bnt删除模板";
            this.bnt删除模板.Size = new System.Drawing.Size(276, 83);
            this.bnt删除模板.TabIndex = 4;
            this.bnt删除模板.Text = "删除模板";
            this.bnt删除模板.UseVisualStyleBackColor = true;
            // 
            // bnt复制模板
            // 
            this.bnt复制模板.Location = new System.Drawing.Point(644, 394);
            this.bnt复制模板.Name = "bnt复制模板";
            this.bnt复制模板.Size = new System.Drawing.Size(276, 83);
            this.bnt复制模板.TabIndex = 5;
            this.bnt复制模板.Text = "复制模板";
            this.bnt复制模板.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(392, 64);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(70, 34);
            this.button5.TabIndex = 6;
            this.button5.Text = "搜索";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // pnlModelList
            // 
            this.pnlModelList.Location = new System.Drawing.Point(84, 134);
            this.pnlModelList.Name = "pnlModelList";
            this.pnlModelList.Size = new System.Drawing.Size(475, 497);
            this.pnlModelList.TabIndex = 7;
            // 
            // 型号选择
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlModelList);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.bnt复制模板);
            this.Controls.Add(this.bnt删除模板);
            this.Controls.Add(this.bnt编辑模板);
            this.Controls.Add(this.bnt新建模板);
            this.Controls.Add(this.textBox1);
            this.Name = "型号选择";
            this.Size = new System.Drawing.Size(1007, 730);
            this.Load += new System.EventHandler(this.型号选择_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bnt新建模板;
        private System.Windows.Forms.Button bnt编辑模板;
        private System.Windows.Forms.Button bnt删除模板;
        private System.Windows.Forms.Button bnt复制模板;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel pnlModelList;
    }
}
