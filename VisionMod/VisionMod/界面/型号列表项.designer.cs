namespace LS_VisionMod.界面
{
    partial class 型号列表项
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
            this.labTime = new System.Windows.Forms.Label();
            this.labModelName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labTime
            // 
            this.labTime.AutoSize = true;
            this.labTime.Location = new System.Drawing.Point(246, 18);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(65, 12);
            this.labTime.TabIndex = 6;
            this.labTime.Text = "2020/11/21";
            // 
            // labModelName
            // 
            this.labModelName.AutoSize = true;
            this.labModelName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labModelName.Location = new System.Drawing.Point(19, 11);
            this.labModelName.Name = "labModelName";
            this.labModelName.Size = new System.Drawing.Size(58, 22);
            this.labModelName.TabIndex = 4;
            this.labModelName.Text = "型号名";
            // 
            // 型号列表项
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.labTime);
            this.Controls.Add(this.labModelName);
            this.Name = "型号列表项";
            this.Size = new System.Drawing.Size(370, 55);
            this.Load += new System.EventHandler(this.型号列表项_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.型号列表项_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.型号列表项_MouseDoubleClick);
            this.MouseEnter += new System.EventHandler(this.型号列表项_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.型号列表项_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labTime;
        private System.Windows.Forms.Label labModelName;
    }
}
