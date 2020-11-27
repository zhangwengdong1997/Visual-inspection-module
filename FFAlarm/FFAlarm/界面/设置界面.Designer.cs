namespace FFAlarm.界面
{
    partial class 设置界面
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
            this.labPLC连接串口 = new CCWin.SkinControl.SkinLabel();
            this.cmbPLC连接串口 = new System.Windows.Forms.ComboBox();
            this.btn保存设置 = new CCWin.SkinControl.SkinButton();
            this.skinLabel7 = new CCWin.SkinControl.SkinLabel();
            this.txtNGSave = new CCWin.SkinControl.SkinTextBox();
            this.skinLabel8 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel6 = new CCWin.SkinControl.SkinLabel();
            this.txtOKSave = new CCWin.SkinControl.SkinTextBox();
            this.skinLabel5 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.cmb检测触发信号口 = new System.Windows.Forms.ComboBox();
            this.cmbOK输出信号口 = new System.Windows.Forms.ComboBox();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.cmbNG输出信号口 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labPLC连接串口
            // 
            this.labPLC连接串口.AutoSize = true;
            this.labPLC连接串口.BackColor = System.Drawing.Color.Transparent;
            this.labPLC连接串口.BorderColor = System.Drawing.Color.White;
            this.labPLC连接串口.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPLC连接串口.Location = new System.Drawing.Point(158, 106);
            this.labPLC连接串口.Name = "labPLC连接串口";
            this.labPLC连接串口.Size = new System.Drawing.Size(77, 17);
            this.labPLC连接串口.TabIndex = 16;
            this.labPLC连接串口.Text = "PLC连接串口";
            // 
            // cmbPLC连接串口
            // 
            this.cmbPLC连接串口.FormattingEnabled = true;
            this.cmbPLC连接串口.Location = new System.Drawing.Point(258, 103);
            this.cmbPLC连接串口.Name = "cmbPLC连接串口";
            this.cmbPLC连接串口.Size = new System.Drawing.Size(121, 20);
            this.cmbPLC连接串口.TabIndex = 15;
            // 
            // btn保存设置
            // 
            this.btn保存设置.BackColor = System.Drawing.Color.Transparent;
            this.btn保存设置.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn保存设置.DownBack = null;
            this.btn保存设置.Location = new System.Drawing.Point(627, 610);
            this.btn保存设置.MouseBack = null;
            this.btn保存设置.Name = "btn保存设置";
            this.btn保存设置.NormlBack = null;
            this.btn保存设置.Size = new System.Drawing.Size(106, 32);
            this.btn保存设置.TabIndex = 17;
            this.btn保存设置.Text = "保存设置";
            this.btn保存设置.UseVisualStyleBackColor = false;
            this.btn保存设置.Click += new System.EventHandler(this.btn保存设置_Click);
            // 
            // skinLabel7
            // 
            this.skinLabel7.AutoSize = true;
            this.skinLabel7.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel7.BorderColor = System.Drawing.Color.White;
            this.skinLabel7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel7.Location = new System.Drawing.Point(325, 419);
            this.skinLabel7.Name = "skinLabel7";
            this.skinLabel7.Size = new System.Drawing.Size(20, 17);
            this.skinLabel7.TabIndex = 23;
            this.skinLabel7.Text = "天";
            // 
            // txtNGSave
            // 
            this.txtNGSave.BackColor = System.Drawing.Color.Transparent;
            this.txtNGSave.DownBack = null;
            this.txtNGSave.Icon = null;
            this.txtNGSave.IconIsButton = false;
            this.txtNGSave.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtNGSave.IsPasswordChat = '\0';
            this.txtNGSave.IsSystemPasswordChar = false;
            this.txtNGSave.Lines = new string[0];
            this.txtNGSave.Location = new System.Drawing.Point(268, 412);
            this.txtNGSave.Margin = new System.Windows.Forms.Padding(0);
            this.txtNGSave.MaxLength = 32767;
            this.txtNGSave.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtNGSave.MouseBack = null;
            this.txtNGSave.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtNGSave.Multiline = true;
            this.txtNGSave.Name = "txtNGSave";
            this.txtNGSave.NormlBack = null;
            this.txtNGSave.Padding = new System.Windows.Forms.Padding(5);
            this.txtNGSave.ReadOnly = false;
            this.txtNGSave.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNGSave.Size = new System.Drawing.Size(41, 29);
            // 
            // 
            // 
            this.txtNGSave.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNGSave.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNGSave.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtNGSave.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtNGSave.SkinTxt.Multiline = true;
            this.txtNGSave.SkinTxt.Name = "BaseText";
            this.txtNGSave.SkinTxt.Size = new System.Drawing.Size(31, 19);
            this.txtNGSave.SkinTxt.TabIndex = 0;
            this.txtNGSave.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtNGSave.SkinTxt.WaterText = "";
            this.txtNGSave.TabIndex = 21;
            this.txtNGSave.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNGSave.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtNGSave.WaterText = "";
            this.txtNGSave.WordWrap = true;
            // 
            // skinLabel8
            // 
            this.skinLabel8.AutoSize = true;
            this.skinLabel8.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel8.BorderColor = System.Drawing.Color.White;
            this.skinLabel8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel8.Location = new System.Drawing.Point(158, 419);
            this.skinLabel8.Name = "skinLabel8";
            this.skinLabel8.Size = new System.Drawing.Size(99, 17);
            this.skinLabel8.TabIndex = 22;
            this.skinLabel8.Text = "NG图片保存时间";
            // 
            // skinLabel6
            // 
            this.skinLabel6.AutoSize = true;
            this.skinLabel6.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel6.BorderColor = System.Drawing.Color.White;
            this.skinLabel6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel6.Location = new System.Drawing.Point(325, 377);
            this.skinLabel6.Name = "skinLabel6";
            this.skinLabel6.Size = new System.Drawing.Size(20, 17);
            this.skinLabel6.TabIndex = 20;
            this.skinLabel6.Text = "天";
            // 
            // txtOKSave
            // 
            this.txtOKSave.BackColor = System.Drawing.Color.Transparent;
            this.txtOKSave.DownBack = null;
            this.txtOKSave.Icon = null;
            this.txtOKSave.IconIsButton = false;
            this.txtOKSave.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtOKSave.IsPasswordChat = '\0';
            this.txtOKSave.IsSystemPasswordChar = false;
            this.txtOKSave.Lines = new string[0];
            this.txtOKSave.Location = new System.Drawing.Point(268, 370);
            this.txtOKSave.Margin = new System.Windows.Forms.Padding(0);
            this.txtOKSave.MaxLength = 32767;
            this.txtOKSave.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtOKSave.MouseBack = null;
            this.txtOKSave.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtOKSave.Multiline = true;
            this.txtOKSave.Name = "txtOKSave";
            this.txtOKSave.NormlBack = null;
            this.txtOKSave.Padding = new System.Windows.Forms.Padding(5);
            this.txtOKSave.ReadOnly = false;
            this.txtOKSave.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtOKSave.Size = new System.Drawing.Size(41, 29);
            // 
            // 
            // 
            this.txtOKSave.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOKSave.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOKSave.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtOKSave.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtOKSave.SkinTxt.Multiline = true;
            this.txtOKSave.SkinTxt.Name = "BaseText";
            this.txtOKSave.SkinTxt.Size = new System.Drawing.Size(31, 19);
            this.txtOKSave.SkinTxt.TabIndex = 0;
            this.txtOKSave.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtOKSave.SkinTxt.WaterText = "";
            this.txtOKSave.TabIndex = 18;
            this.txtOKSave.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtOKSave.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtOKSave.WaterText = "";
            this.txtOKSave.WordWrap = true;
            // 
            // skinLabel5
            // 
            this.skinLabel5.AutoSize = true;
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.White;
            this.skinLabel5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel5.Location = new System.Drawing.Point(158, 377);
            this.skinLabel5.Name = "skinLabel5";
            this.skinLabel5.Size = new System.Drawing.Size(98, 17);
            this.skinLabel5.TabIndex = 19;
            this.skinLabel5.Text = "OK图片保存时间";
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(158, 158);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(92, 17);
            this.skinLabel1.TabIndex = 24;
            this.skinLabel1.Text = "检测触发信号口";
            // 
            // cmb检测触发信号口
            // 
            this.cmb检测触发信号口.FormattingEnabled = true;
            this.cmb检测触发信号口.Items.AddRange(new object[] {
            "X0",
            "X1",
            "X2",
            "X3",
            "X4",
            "X5",
            "X6",
            "X7"});
            this.cmb检测触发信号口.Location = new System.Drawing.Point(258, 158);
            this.cmb检测触发信号口.Name = "cmb检测触发信号口";
            this.cmb检测触发信号口.Size = new System.Drawing.Size(121, 20);
            this.cmb检测触发信号口.TabIndex = 25;
            // 
            // cmbOK输出信号口
            // 
            this.cmbOK输出信号口.FormattingEnabled = true;
            this.cmbOK输出信号口.Items.AddRange(new object[] {
            "Y0",
            "Y1",
            "Y2",
            "Y3",
            "Y4",
            "Y5",
            "Y6",
            "Y7"});
            this.cmbOK输出信号口.Location = new System.Drawing.Point(258, 201);
            this.cmbOK输出信号口.Name = "cmbOK输出信号口";
            this.cmbOK输出信号口.Size = new System.Drawing.Size(121, 20);
            this.cmbOK输出信号口.TabIndex = 27;
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(158, 201);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(86, 17);
            this.skinLabel2.TabIndex = 26;
            this.skinLabel2.Text = "OK输出信号口";
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(158, 249);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(87, 17);
            this.skinLabel3.TabIndex = 28;
            this.skinLabel3.Text = "NG输出信号口";
            // 
            // cmbNG输出信号口
            // 
            this.cmbNG输出信号口.FormattingEnabled = true;
            this.cmbNG输出信号口.Items.AddRange(new object[] {
            "Y0",
            "Y1",
            "Y2",
            "Y3",
            "Y4",
            "Y5",
            "Y6",
            "Y7"});
            this.cmbNG输出信号口.Location = new System.Drawing.Point(258, 246);
            this.cmbNG输出信号口.Name = "cmbNG输出信号口";
            this.cmbNG输出信号口.Size = new System.Drawing.Size(121, 20);
            this.cmbNG输出信号口.TabIndex = 29;
            // 
            // 设置界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbNG输出信号口);
            this.Controls.Add(this.skinLabel3);
            this.Controls.Add(this.cmbOK输出信号口);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.cmb检测触发信号口);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.skinLabel7);
            this.Controls.Add(this.txtNGSave);
            this.Controls.Add(this.skinLabel8);
            this.Controls.Add(this.skinLabel6);
            this.Controls.Add(this.txtOKSave);
            this.Controls.Add(this.skinLabel5);
            this.Controls.Add(this.btn保存设置);
            this.Controls.Add(this.labPLC连接串口);
            this.Controls.Add(this.cmbPLC连接串口);
            this.Name = "设置界面";
            this.Size = new System.Drawing.Size(848, 730);
            this.Load += new System.EventHandler(this.设置界面_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinLabel labPLC连接串口;
        private System.Windows.Forms.ComboBox cmbPLC连接串口;
        private CCWin.SkinControl.SkinButton btn保存设置;
        private CCWin.SkinControl.SkinLabel skinLabel7;
        private CCWin.SkinControl.SkinTextBox txtNGSave;
        private CCWin.SkinControl.SkinLabel skinLabel8;
        private CCWin.SkinControl.SkinLabel skinLabel6;
        private CCWin.SkinControl.SkinTextBox txtOKSave;
        private CCWin.SkinControl.SkinLabel skinLabel5;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private System.Windows.Forms.ComboBox cmb检测触发信号口;
        private System.Windows.Forms.ComboBox cmbOK输出信号口;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private System.Windows.Forms.ComboBox cmbNG输出信号口;
    }
}
