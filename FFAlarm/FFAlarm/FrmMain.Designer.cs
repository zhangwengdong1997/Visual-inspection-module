namespace FFAlarm
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            this.panelSwitchButton = new System.Windows.Forms.Panel();
            this.btn设置 = new CCWin.SkinControl.SkinButton();
            this.btn检测 = new CCWin.SkinControl.SkinButton();
            this.btn模板 = new CCWin.SkinControl.SkinButton();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMessage = new System.Windows.Forms.Panel();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.panelSwitchButton.SuspendLayout();
            this.panelMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSwitchButton
            // 
            this.panelSwitchButton.Controls.Add(this.btn设置);
            this.panelSwitchButton.Controls.Add(this.btn检测);
            this.panelSwitchButton.Controls.Add(this.btn模板);
            this.panelSwitchButton.Location = new System.Drawing.Point(12, 31);
            this.panelSwitchButton.Name = "panelSwitchButton";
            this.panelSwitchButton.Size = new System.Drawing.Size(107, 394);
            this.panelSwitchButton.TabIndex = 0;
            // 
            // btn设置
            // 
            this.btn设置.BackColor = System.Drawing.Color.Transparent;
            this.btn设置.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn设置.DownBack = null;
            this.btn设置.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn设置.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn设置.ImageSize = new System.Drawing.Size(60, 60);
            this.btn设置.Location = new System.Drawing.Point(3, 271);
            this.btn设置.MouseBack = null;
            this.btn设置.Name = "btn设置";
            this.btn设置.NormlBack = null;
            this.btn设置.Size = new System.Drawing.Size(95, 79);
            this.btn设置.TabIndex = 19;
            this.btn设置.Text = "设置";
            this.btn设置.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn设置.UseVisualStyleBackColor = false;
            this.btn设置.Click += new System.EventHandler(this.btn设置_Click);
            // 
            // btn检测
            // 
            this.btn检测.BackColor = System.Drawing.Color.Transparent;
            this.btn检测.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn检测.DownBack = null;
            this.btn检测.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn检测.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn检测.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn检测.ImageSize = new System.Drawing.Size(70, 70);
            this.btn检测.Location = new System.Drawing.Point(3, 4);
            this.btn检测.MouseBack = null;
            this.btn检测.Name = "btn检测";
            this.btn检测.NormlBack = null;
            this.btn检测.Size = new System.Drawing.Size(95, 79);
            this.btn检测.TabIndex = 17;
            this.btn检测.Text = "检测";
            this.btn检测.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn检测.UseVisualStyleBackColor = false;
            this.btn检测.Click += new System.EventHandler(this.btn检测_Click);
            // 
            // btn模板
            // 
            this.btn模板.BackColor = System.Drawing.Color.Transparent;
            this.btn模板.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn模板.DownBack = null;
            this.btn模板.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn模板.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn模板.ImageSize = new System.Drawing.Size(70, 70);
            this.btn模板.Location = new System.Drawing.Point(3, 104);
            this.btn模板.MouseBack = null;
            this.btn模板.Name = "btn模板";
            this.btn模板.NormlBack = null;
            this.btn模板.Size = new System.Drawing.Size(95, 79);
            this.btn模板.TabIndex = 18;
            this.btn模板.Text = "模板";
            this.btn模板.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn模板.UseVisualStyleBackColor = false;
            this.btn模板.Click += new System.EventHandler(this.btn模板_Click);
            // 
            // panelMain
            // 
            this.panelMain.Location = new System.Drawing.Point(125, 31);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(892, 730);
            this.panelMain.TabIndex = 1;
            // 
            // panelMessage
            // 
            this.panelMessage.Controls.Add(this.txtMessage);
            this.panelMessage.Location = new System.Drawing.Point(12, 431);
            this.panelMessage.Name = "panelMessage";
            this.panelMessage.Size = new System.Drawing.Size(107, 330);
            this.panelMessage.TabIndex = 2;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(3, 3);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage.Size = new System.Drawing.Size(100, 324);
            this.txtMessage.TabIndex = 38;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.panelMessage);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSwitchButton);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelSwitchButton.ResumeLayout(false);
            this.panelMessage.ResumeLayout(false);
            this.panelMessage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSwitchButton;
        private System.Windows.Forms.Panel panelMain;
        private CCWin.SkinControl.SkinButton btn设置;
        private CCWin.SkinControl.SkinButton btn检测;
        private CCWin.SkinControl.SkinButton btn模板;
        private System.Windows.Forms.Panel panelMessage;
        private System.Windows.Forms.TextBox txtMessage;
    }
}

