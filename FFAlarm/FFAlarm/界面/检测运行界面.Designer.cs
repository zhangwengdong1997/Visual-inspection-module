namespace FFAlarm.界面
{
    partial class 检测运行界面
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
            this.components = new System.ComponentModel.Container();
            this.cmbModeName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btn开始 = new CCWin.SkinControl.SkinButton();
            this.btn测试 = new CCWin.SkinControl.SkinButton();
            this.图像显示控件1 = new LS_VisionMod.界面.图像显示控件();
            this.SuspendLayout();
            // 
            // cmbModeName
            // 
            this.cmbModeName.FormattingEnabled = true;
            this.cmbModeName.Location = new System.Drawing.Point(718, 36);
            this.cmbModeName.Name = "cmbModeName";
            this.cmbModeName.Size = new System.Drawing.Size(171, 20);
            this.cmbModeName.TabIndex = 25;
            this.cmbModeName.SelectedIndexChanged += new System.EventHandler(this.cmbModeName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(718, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "检测模板选择";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(718, 62);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(171, 404);
            this.txtMessage.TabIndex = 27;
            // 
            // btn开始
            // 
            this.btn开始.BackColor = System.Drawing.Color.Transparent;
            this.btn开始.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn开始.DownBack = null;
            this.btn开始.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn开始.Location = new System.Drawing.Point(715, 609);
            this.btn开始.MouseBack = null;
            this.btn开始.Name = "btn开始";
            this.btn开始.NormlBack = null;
            this.btn开始.Size = new System.Drawing.Size(170, 92);
            this.btn开始.TabIndex = 29;
            this.btn开始.Text = "开始";
            this.btn开始.UseVisualStyleBackColor = false;
            this.btn开始.Click += new System.EventHandler(this.btn开始_Click);
            // 
            // btn测试
            // 
            this.btn测试.BackColor = System.Drawing.Color.Transparent;
            this.btn测试.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn测试.DownBack = null;
            this.btn测试.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn测试.Location = new System.Drawing.Point(715, 491);
            this.btn测试.MouseBack = null;
            this.btn测试.Name = "btn测试";
            this.btn测试.NormlBack = null;
            this.btn测试.Size = new System.Drawing.Size(170, 92);
            this.btn测试.TabIndex = 30;
            this.btn测试.Text = "测试";
            this.btn测试.UseVisualStyleBackColor = false;
            this.btn测试.Click += new System.EventHandler(this.btn测试_Click);
            // 
            // 图像显示控件1
            // 
            this.图像显示控件1.ConnectCam = null;
            this.图像显示控件1.Location = new System.Drawing.Point(21, 36);
            this.图像显示控件1.Name = "图像显示控件1";
            this.图像显示控件1.Size = new System.Drawing.Size(688, 610);
            this.图像显示控件1.TabIndex = 31;
            // 
            // 检测运行界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.图像显示控件1);
            this.Controls.Add(this.btn测试);
            this.Controls.Add(this.btn开始);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbModeName);
            this.Name = "检测运行界面";
            this.Size = new System.Drawing.Size(892, 730);
            this.Load += new System.EventHandler(this.检测运行界面_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbModeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMessage;
        private CCWin.SkinControl.SkinButton btn开始;
        private CCWin.SkinControl.SkinButton btn测试;
        private LS_VisionMod.界面.图像显示控件 图像显示控件1;
    }
}
