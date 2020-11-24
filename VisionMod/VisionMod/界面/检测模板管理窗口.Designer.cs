namespace VisionMod.界面
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
            this.pnlModelList = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bnt复制模板 = new System.Windows.Forms.Button();
            this.bnt删除模板 = new System.Windows.Forms.Button();
            this.bnt编辑模板 = new System.Windows.Forms.Button();
            this.bnt新建模板 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlModelList
            // 
            this.pnlModelList.Location = new System.Drawing.Point(94, 147);
            this.pnlModelList.Name = "pnlModelList";
            this.pnlModelList.Size = new System.Drawing.Size(422, 497);
            this.pnlModelList.TabIndex = 10;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(402, 77);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(70, 34);
            this.button5.TabIndex = 9;
            this.button5.Text = "搜索";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(97, 85);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(289, 21);
            this.textBox1.TabIndex = 8;
            // 
            // bnt复制模板
            // 
            this.bnt复制模板.Location = new System.Drawing.Point(615, 413);
            this.bnt复制模板.Name = "bnt复制模板";
            this.bnt复制模板.Size = new System.Drawing.Size(276, 83);
            this.bnt复制模板.TabIndex = 14;
            this.bnt复制模板.Text = "复制模板";
            this.bnt复制模板.UseVisualStyleBackColor = true;
            // 
            // bnt删除模板
            // 
            this.bnt删除模板.Location = new System.Drawing.Point(615, 551);
            this.bnt删除模板.Name = "bnt删除模板";
            this.bnt删除模板.Size = new System.Drawing.Size(276, 83);
            this.bnt删除模板.TabIndex = 13;
            this.bnt删除模板.Text = "删除模板";
            this.bnt删除模板.UseVisualStyleBackColor = true;
            // 
            // bnt编辑模板
            // 
            this.bnt编辑模板.Location = new System.Drawing.Point(615, 275);
            this.bnt编辑模板.Name = "bnt编辑模板";
            this.bnt编辑模板.Size = new System.Drawing.Size(276, 83);
            this.bnt编辑模板.TabIndex = 12;
            this.bnt编辑模板.Text = "编辑模板";
            this.bnt编辑模板.UseVisualStyleBackColor = true;
            // 
            // bnt新建模板
            // 
            this.bnt新建模板.Location = new System.Drawing.Point(615, 137);
            this.bnt新建模板.Name = "bnt新建模板";
            this.bnt新建模板.Size = new System.Drawing.Size(276, 83);
            this.bnt新建模板.TabIndex = 11;
            this.bnt新建模板.Text = "新建模板";
            this.bnt新建模板.UseVisualStyleBackColor = true;
            this.bnt新建模板.Click += new System.EventHandler(this.bnt新建模板_Click);
            // 
            // 检测模板管理窗口
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bnt复制模板);
            this.Controls.Add(this.bnt删除模板);
            this.Controls.Add(this.bnt编辑模板);
            this.Controls.Add(this.bnt新建模板);
            this.Controls.Add(this.pnlModelList);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox1);
            this.Name = "检测模板管理窗口";
            this.Size = new System.Drawing.Size(1024, 768);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlModelList;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bnt复制模板;
        private System.Windows.Forms.Button bnt删除模板;
        private System.Windows.Forms.Button bnt编辑模板;
        private System.Windows.Forms.Button bnt新建模板;
    }
}
