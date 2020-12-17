namespace LS_VisionMod.模板创建步骤
{ 
    partial class 检测项编辑
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
            this.dgv检测项 = new System.Windows.Forms.DataGridView();
            this.btn修改匹配定位模板 = new System.Windows.Forms.Button();
            this.btn修改检测项功能 = new System.Windows.Forms.Button();
            this.btn修改使用相机 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv检测项)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv检测项
            // 
            this.dgv检测项.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv检测项.Location = new System.Drawing.Point(68, 73);
            this.dgv检测项.Name = "dgv检测项";
            this.dgv检测项.RowTemplate.Height = 23;
            this.dgv检测项.Size = new System.Drawing.Size(287, 455);
            this.dgv检测项.TabIndex = 2;
            // 
            // btn修改匹配定位模板
            // 
            this.btn修改匹配定位模板.Location = new System.Drawing.Point(549, 181);
            this.btn修改匹配定位模板.Name = "btn修改匹配定位模板";
            this.btn修改匹配定位模板.Size = new System.Drawing.Size(156, 68);
            this.btn修改匹配定位模板.TabIndex = 3;
            this.btn修改匹配定位模板.Text = "修改匹配定位模板";
            this.btn修改匹配定位模板.UseVisualStyleBackColor = true;
            this.btn修改匹配定位模板.Click += new System.EventHandler(this.btn修改匹配定位模板_Click);
            // 
            // btn修改检测项功能
            // 
            this.btn修改检测项功能.Location = new System.Drawing.Point(549, 303);
            this.btn修改检测项功能.Name = "btn修改检测项功能";
            this.btn修改检测项功能.Size = new System.Drawing.Size(156, 68);
            this.btn修改检测项功能.TabIndex = 4;
            this.btn修改检测项功能.Text = "修改检测项功能";
            this.btn修改检测项功能.UseVisualStyleBackColor = true;
            this.btn修改检测项功能.Click += new System.EventHandler(this.btn修改检测项功能_Click);
            // 
            // btn修改使用相机
            // 
            this.btn修改使用相机.Location = new System.Drawing.Point(549, 73);
            this.btn修改使用相机.Name = "btn修改使用相机";
            this.btn修改使用相机.Size = new System.Drawing.Size(156, 68);
            this.btn修改使用相机.TabIndex = 1;
            this.btn修改使用相机.Text = "修改使用相机";
            this.btn修改使用相机.UseVisualStyleBackColor = true;
            this.btn修改使用相机.Click += new System.EventHandler(this.btn修改使用相机_Click);
            // 
            // 检测项编辑
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn修改检测项功能);
            this.Controls.Add(this.btn修改匹配定位模板);
            this.Controls.Add(this.dgv检测项);
            this.Controls.Add(this.btn修改使用相机);
            this.Name = "检测项编辑";
            this.Size = new System.Drawing.Size(993, 634);
            this.Load += new System.EventHandler(this.检测项编辑_Load);
            this.Enter += new System.EventHandler(this.检测项编辑_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.dgv检测项)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv检测项;
        private System.Windows.Forms.Button btn修改匹配定位模板;
        private System.Windows.Forms.Button btn修改检测项功能;
        private System.Windows.Forms.Button btn修改使用相机;
    }
}
