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
            this.cmbPLC连接串口 = new System.Windows.Forms.ComboBox();
            this.btn保存设置 = new CCWin.SkinControl.SkinButton();
            this.skinLabel7 = new CCWin.SkinControl.SkinLabel();
            this.txtNGSave = new CCWin.SkinControl.SkinTextBox();
            this.skinLabel6 = new CCWin.SkinControl.SkinLabel();
            this.txtOKSave = new CCWin.SkinControl.SkinTextBox();
            this.cmb检测触发信号口 = new System.Windows.Forms.ComboBox();
            this.cmbOK输出信号口 = new System.Windows.Forms.ComboBox();
            this.cmbNG输出信号口 = new System.Windows.Forms.ComboBox();
            this.txtDuration = new CCWin.SkinControl.SkinTextBox();
            this.skinLabel9 = new CCWin.SkinControl.SkinLabel();
            this.labPLC连接串口 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.txtDelay = new CCWin.SkinControl.SkinTextBox();
            this.skinGroupBox1 = new CCWin.SkinControl.SkinGroupBox();
            this.skinGroupBox2 = new CCWin.SkinControl.SkinGroupBox();
            this.skinGroupBox1.SuspendLayout();
            this.skinGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbPLC连接串口
            // 
            this.cmbPLC连接串口.FormattingEnabled = true;
            this.cmbPLC连接串口.Location = new System.Drawing.Point(122, 27);
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
            this.skinLabel7.Location = new System.Drawing.Point(190, 137);
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
            this.txtNGSave.Location = new System.Drawing.Point(133, 130);
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
            // skinLabel6
            // 
            this.skinLabel6.AutoSize = true;
            this.skinLabel6.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel6.BorderColor = System.Drawing.Color.White;
            this.skinLabel6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel6.Location = new System.Drawing.Point(190, 95);
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
            this.txtOKSave.Location = new System.Drawing.Point(133, 88);
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
            this.cmb检测触发信号口.Location = new System.Drawing.Point(122, 74);
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
            this.cmbOK输出信号口.Location = new System.Drawing.Point(122, 121);
            this.cmbOK输出信号口.Name = "cmbOK输出信号口";
            this.cmbOK输出信号口.Size = new System.Drawing.Size(121, 20);
            this.cmbOK输出信号口.TabIndex = 27;
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
            this.cmbNG输出信号口.Location = new System.Drawing.Point(122, 168);
            this.cmbNG输出信号口.Name = "cmbNG输出信号口";
            this.cmbNG输出信号口.Size = new System.Drawing.Size(121, 20);
            this.cmbNG输出信号口.TabIndex = 29;
            // 
            // txtDuration
            // 
            this.txtDuration.BackColor = System.Drawing.Color.Transparent;
            this.txtDuration.DownBack = null;
            this.txtDuration.Icon = null;
            this.txtDuration.IconIsButton = false;
            this.txtDuration.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtDuration.IsPasswordChat = '\0';
            this.txtDuration.IsSystemPasswordChar = false;
            this.txtDuration.Lines = new string[0];
            this.txtDuration.Location = new System.Drawing.Point(122, 206);
            this.txtDuration.Margin = new System.Windows.Forms.Padding(0);
            this.txtDuration.MaxLength = 32767;
            this.txtDuration.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtDuration.MouseBack = null;
            this.txtDuration.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtDuration.Multiline = true;
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.NormlBack = null;
            this.txtDuration.Padding = new System.Windows.Forms.Padding(5);
            this.txtDuration.ReadOnly = false;
            this.txtDuration.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDuration.Size = new System.Drawing.Size(87, 29);
            // 
            // 
            // 
            this.txtDuration.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDuration.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDuration.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtDuration.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtDuration.SkinTxt.Multiline = true;
            this.txtDuration.SkinTxt.Name = "BaseText";
            this.txtDuration.SkinTxt.Size = new System.Drawing.Size(77, 19);
            this.txtDuration.SkinTxt.TabIndex = 0;
            this.txtDuration.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtDuration.SkinTxt.WaterText = "";
            this.txtDuration.TabIndex = 19;
            this.txtDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDuration.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtDuration.WaterText = "";
            this.txtDuration.WordWrap = true;
            // 
            // skinLabel9
            // 
            this.skinLabel9.AutoSize = true;
            this.skinLabel9.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel9.BorderColor = System.Drawing.Color.White;
            this.skinLabel9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel9.Location = new System.Drawing.Point(218, 218);
            this.skinLabel9.Name = "skinLabel9";
            this.skinLabel9.Size = new System.Drawing.Size(25, 17);
            this.skinLabel9.TabIndex = 31;
            this.skinLabel9.Text = "ms";
            // 
            // labPLC连接串口
            // 
            this.labPLC连接串口.AutoSize = true;
            this.labPLC连接串口.Location = new System.Drawing.Point(23, 35);
            this.labPLC连接串口.Name = "labPLC连接串口";
            this.labPLC连接串口.Size = new System.Drawing.Size(71, 12);
            this.labPLC连接串口.TabIndex = 32;
            this.labPLC连接串口.Text = "PLC连接串口";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 33;
            this.label1.Text = "检测触发信号口";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 34;
            this.label2.Text = "OK输出信号口";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 35;
            this.label3.Text = "NG输出信号口";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 36;
            this.label4.Text = "信号延迟时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 37;
            this.label5.Text = "OK图片保存时间";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 38;
            this.label6.Text = "NG图片保存时间";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 39;
            this.label7.Text = "拍照延迟时间";
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(219, 48);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(25, 17);
            this.skinLabel1.TabIndex = 41;
            this.skinLabel1.Text = "ms";
            // 
            // txtDelay
            // 
            this.txtDelay.BackColor = System.Drawing.Color.Transparent;
            this.txtDelay.DownBack = null;
            this.txtDelay.Icon = null;
            this.txtDelay.IconIsButton = false;
            this.txtDelay.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtDelay.IsPasswordChat = '\0';
            this.txtDelay.IsSystemPasswordChar = false;
            this.txtDelay.Lines = new string[0];
            this.txtDelay.Location = new System.Drawing.Point(123, 36);
            this.txtDelay.Margin = new System.Windows.Forms.Padding(0);
            this.txtDelay.MaxLength = 32767;
            this.txtDelay.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtDelay.MouseBack = null;
            this.txtDelay.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtDelay.Multiline = true;
            this.txtDelay.Name = "txtDelay";
            this.txtDelay.NormlBack = null;
            this.txtDelay.Padding = new System.Windows.Forms.Padding(5);
            this.txtDelay.ReadOnly = false;
            this.txtDelay.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDelay.Size = new System.Drawing.Size(87, 29);
            // 
            // 
            // 
            this.txtDelay.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDelay.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDelay.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtDelay.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtDelay.SkinTxt.Multiline = true;
            this.txtDelay.SkinTxt.Name = "BaseText";
            this.txtDelay.SkinTxt.Size = new System.Drawing.Size(77, 19);
            this.txtDelay.SkinTxt.TabIndex = 0;
            this.txtDelay.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtDelay.SkinTxt.WaterText = "";
            this.txtDelay.TabIndex = 40;
            this.txtDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDelay.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtDelay.WaterText = "";
            this.txtDelay.WordWrap = true;
            // 
            // skinGroupBox1
            // 
            this.skinGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.BorderColor = System.Drawing.Color.Aqua;
            this.skinGroupBox1.Controls.Add(this.label2);
            this.skinGroupBox1.Controls.Add(this.label1);
            this.skinGroupBox1.Controls.Add(this.labPLC连接串口);
            this.skinGroupBox1.Controls.Add(this.label3);
            this.skinGroupBox1.Controls.Add(this.cmbPLC连接串口);
            this.skinGroupBox1.Controls.Add(this.skinLabel9);
            this.skinGroupBox1.Controls.Add(this.label4);
            this.skinGroupBox1.Controls.Add(this.cmb检测触发信号口);
            this.skinGroupBox1.Controls.Add(this.txtDuration);
            this.skinGroupBox1.Controls.Add(this.cmbNG输出信号口);
            this.skinGroupBox1.Controls.Add(this.cmbOK输出信号口);
            this.skinGroupBox1.ForeColor = System.Drawing.Color.Black;
            this.skinGroupBox1.Location = new System.Drawing.Point(136, 33);
            this.skinGroupBox1.Name = "skinGroupBox1";
            this.skinGroupBox1.RectBackColor = System.Drawing.Color.White;
            this.skinGroupBox1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox1.Size = new System.Drawing.Size(282, 271);
            this.skinGroupBox1.TabIndex = 42;
            this.skinGroupBox1.TabStop = false;
            this.skinGroupBox1.Text = "PLC设置";
            this.skinGroupBox1.TitleBorderColor = System.Drawing.Color.Aqua;
            this.skinGroupBox1.TitleRectBackColor = System.Drawing.Color.White;
            this.skinGroupBox1.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // skinGroupBox2
            // 
            this.skinGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox2.BorderColor = System.Drawing.Color.Aqua;
            this.skinGroupBox2.Controls.Add(this.label7);
            this.skinGroupBox2.Controls.Add(this.txtOKSave);
            this.skinGroupBox2.Controls.Add(this.skinLabel1);
            this.skinGroupBox2.Controls.Add(this.skinLabel6);
            this.skinGroupBox2.Controls.Add(this.txtDelay);
            this.skinGroupBox2.Controls.Add(this.txtNGSave);
            this.skinGroupBox2.Controls.Add(this.skinLabel7);
            this.skinGroupBox2.Controls.Add(this.label6);
            this.skinGroupBox2.Controls.Add(this.label5);
            this.skinGroupBox2.ForeColor = System.Drawing.Color.Black;
            this.skinGroupBox2.Location = new System.Drawing.Point(136, 331);
            this.skinGroupBox2.Name = "skinGroupBox2";
            this.skinGroupBox2.RectBackColor = System.Drawing.Color.White;
            this.skinGroupBox2.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox2.Size = new System.Drawing.Size(282, 271);
            this.skinGroupBox2.TabIndex = 43;
            this.skinGroupBox2.TabStop = false;
            this.skinGroupBox2.Text = "相机设置";
            this.skinGroupBox2.TitleBorderColor = System.Drawing.Color.Aqua;
            this.skinGroupBox2.TitleRectBackColor = System.Drawing.Color.White;
            this.skinGroupBox2.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // 设置界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skinGroupBox2);
            this.Controls.Add(this.skinGroupBox1);
            this.Controls.Add(this.btn保存设置);
            this.Name = "设置界面";
            this.Size = new System.Drawing.Size(848, 730);
            this.Load += new System.EventHandler(this.设置界面_Load);
            this.skinGroupBox1.ResumeLayout(false);
            this.skinGroupBox1.PerformLayout();
            this.skinGroupBox2.ResumeLayout(false);
            this.skinGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbPLC连接串口;
        private CCWin.SkinControl.SkinButton btn保存设置;
        private CCWin.SkinControl.SkinLabel skinLabel7;
        private CCWin.SkinControl.SkinTextBox txtNGSave;
        private CCWin.SkinControl.SkinLabel skinLabel6;
        private CCWin.SkinControl.SkinTextBox txtOKSave;
        private System.Windows.Forms.ComboBox cmb检测触发信号口;
        private System.Windows.Forms.ComboBox cmbOK输出信号口;
        private System.Windows.Forms.ComboBox cmbNG输出信号口;
        private CCWin.SkinControl.SkinTextBox txtDuration;
        private CCWin.SkinControl.SkinLabel skinLabel9;
        private System.Windows.Forms.Label labPLC连接串口;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinTextBox txtDelay;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox1;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox2;
    }
}
