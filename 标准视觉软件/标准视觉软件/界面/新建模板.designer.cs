namespace 标准视觉软件
{
    partial class 新建模板
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn下一步 = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.btn上一步 = new System.Windows.Forms.Button();
            this.lab当前型号 = new System.Windows.Forms.Label();
            this.txt当前型号 = new System.Windows.Forms.TextBox();
            this.lab当前相机 = new System.Windows.Forms.Label();
            this.lab当前定位 = new System.Windows.Forms.Label();
            this.lab当前检测项 = new System.Windows.Forms.Label();
            this.cmb当前相机 = new System.Windows.Forms.ComboBox();
            this.cmb当前定位 = new System.Windows.Forms.ComboBox();
            this.cmb当前检测项 = new System.Windows.Forms.ComboBox();
            this.cmb当前图像预处理 = new System.Windows.Forms.ComboBox();
            this.lab当前图像预处理 = new System.Windows.Forms.Label();
            this.palNow = new System.Windows.Forms.Panel();
            this.palNow.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn下一步
            // 
            this.btn下一步.Location = new System.Drawing.Point(1010, 747);
            this.btn下一步.Name = "btn下一步";
            this.btn下一步.Size = new System.Drawing.Size(115, 37);
            this.btn下一步.TabIndex = 9;
            this.btn下一步.Text = "下一步";
            this.btn下一步.UseVisualStyleBackColor = true;
            this.btn下一步.Click += new System.EventHandler(this.btn下一步_Click);
            // 
            // panelMain
            // 
            this.panelMain.Location = new System.Drawing.Point(22, 53);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1104, 676);
            this.panelMain.TabIndex = 10;
            // 
            // btn上一步
            // 
            this.btn上一步.Location = new System.Drawing.Point(844, 747);
            this.btn上一步.Name = "btn上一步";
            this.btn上一步.Size = new System.Drawing.Size(115, 37);
            this.btn上一步.TabIndex = 11;
            this.btn上一步.Text = "上一步";
            this.btn上一步.UseVisualStyleBackColor = true;
            this.btn上一步.Click += new System.EventHandler(this.btn上一步_Click);
            // 
            // lab当前型号
            // 
            this.lab当前型号.AutoSize = true;
            this.lab当前型号.Location = new System.Drawing.Point(40, 11);
            this.lab当前型号.Name = "lab当前型号";
            this.lab当前型号.Size = new System.Drawing.Size(53, 12);
            this.lab当前型号.TabIndex = 12;
            this.lab当前型号.Text = "模板型号";
            // 
            // txt当前型号
            // 
            this.txt当前型号.Location = new System.Drawing.Point(107, 7);
            this.txt当前型号.Name = "txt当前型号";
            this.txt当前型号.ReadOnly = true;
            this.txt当前型号.Size = new System.Drawing.Size(111, 21);
            this.txt当前型号.TabIndex = 13;
            // 
            // lab当前相机
            // 
            this.lab当前相机.AutoSize = true;
            this.lab当前相机.Location = new System.Drawing.Point(262, 11);
            this.lab当前相机.Name = "lab当前相机";
            this.lab当前相机.Size = new System.Drawing.Size(29, 12);
            this.lab当前相机.TabIndex = 14;
            this.lab当前相机.Text = "相机";
            // 
            // lab当前定位
            // 
            this.lab当前定位.AutoSize = true;
            this.lab当前定位.Location = new System.Drawing.Point(694, 10);
            this.lab当前定位.Name = "lab当前定位";
            this.lab当前定位.Size = new System.Drawing.Size(29, 12);
            this.lab当前定位.TabIndex = 16;
            this.lab当前定位.Text = "定位";
            // 
            // lab当前检测项
            // 
            this.lab当前检测项.AutoSize = true;
            this.lab当前检测项.Location = new System.Drawing.Point(892, 11);
            this.lab当前检测项.Name = "lab当前检测项";
            this.lab当前检测项.Size = new System.Drawing.Size(41, 12);
            this.lab当前检测项.TabIndex = 18;
            this.lab当前检测项.Text = "检测项";
            // 
            // cmb当前相机
            // 
            this.cmb当前相机.FormattingEnabled = true;
            this.cmb当前相机.Location = new System.Drawing.Point(305, 7);
            this.cmb当前相机.Name = "cmb当前相机";
            this.cmb当前相机.Size = new System.Drawing.Size(111, 20);
            this.cmb当前相机.TabIndex = 20;
            this.cmb当前相机.SelectedIndexChanged += new System.EventHandler(this.cmb当前相机_SelectedIndexChanged);
            // 
            // cmb当前定位
            // 
            this.cmb当前定位.FormattingEnabled = true;
            this.cmb当前定位.Location = new System.Drawing.Point(737, 7);
            this.cmb当前定位.Name = "cmb当前定位";
            this.cmb当前定位.Size = new System.Drawing.Size(111, 20);
            this.cmb当前定位.TabIndex = 21;
            this.cmb当前定位.SelectedIndexChanged += new System.EventHandler(this.cmb当前定位_SelectedIndexChanged);
            // 
            // cmb当前检测项
            // 
            this.cmb当前检测项.FormattingEnabled = true;
            this.cmb当前检测项.Location = new System.Drawing.Point(947, 7);
            this.cmb当前检测项.Name = "cmb当前检测项";
            this.cmb当前检测项.Size = new System.Drawing.Size(111, 20);
            this.cmb当前检测项.TabIndex = 21;
            this.cmb当前检测项.SelectedIndexChanged += new System.EventHandler(this.cmb当前检测项_SelectedIndexChanged);
            this.cmb当前检测项.DropDownClosed += new System.EventHandler(this.cmb当前检测项_DropDownClosed);
            // 
            // cmb当前图像预处理
            // 
            this.cmb当前图像预处理.FormattingEnabled = true;
            this.cmb当前图像预处理.Location = new System.Drawing.Point(539, 7);
            this.cmb当前图像预处理.Name = "cmb当前图像预处理";
            this.cmb当前图像预处理.Size = new System.Drawing.Size(111, 20);
            this.cmb当前图像预处理.TabIndex = 23;
            this.cmb当前图像预处理.SelectedIndexChanged += new System.EventHandler(this.cmb当前图像预处理_SelectedIndexChanged);
            // 
            // lab当前图像预处理
            // 
            this.lab当前图像预处理.AutoSize = true;
            this.lab当前图像预处理.Location = new System.Drawing.Point(460, 11);
            this.lab当前图像预处理.Name = "lab当前图像预处理";
            this.lab当前图像预处理.Size = new System.Drawing.Size(65, 12);
            this.lab当前图像预处理.TabIndex = 22;
            this.lab当前图像预处理.Text = "图像预处理";
            // 
            // palNow
            // 
            this.palNow.Controls.Add(this.cmb当前检测项);
            this.palNow.Controls.Add(this.cmb当前图像预处理);
            this.palNow.Controls.Add(this.lab当前型号);
            this.palNow.Controls.Add(this.lab当前图像预处理);
            this.palNow.Controls.Add(this.txt当前型号);
            this.palNow.Controls.Add(this.lab当前相机);
            this.palNow.Controls.Add(this.cmb当前定位);
            this.palNow.Controls.Add(this.lab当前定位);
            this.palNow.Controls.Add(this.cmb当前相机);
            this.palNow.Controls.Add(this.lab当前检测项);
            this.palNow.Location = new System.Drawing.Point(22, 12);
            this.palNow.Name = "palNow";
            this.palNow.Size = new System.Drawing.Size(1075, 35);
            this.palNow.TabIndex = 24;
            this.palNow.Visible = false;
            // 
            // 新建模板
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 806);
            this.Controls.Add(this.palNow);
            this.Controls.Add(this.btn上一步);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.btn下一步);
            this.Name = "新建模板";
            this.Text = "新建模板";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.新建模板_FormClosing);
            this.Load += new System.EventHandler(this.新建模板_Load);
            this.palNow.ResumeLayout(false);
            this.palNow.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn下一步;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btn上一步;
        private System.Windows.Forms.Label lab当前型号;
        private System.Windows.Forms.TextBox txt当前型号;
        private System.Windows.Forms.Label lab当前相机;
        private System.Windows.Forms.Label lab当前定位;
        private System.Windows.Forms.Label lab当前检测项;
        private System.Windows.Forms.ComboBox cmb当前相机;
        private System.Windows.Forms.ComboBox cmb当前定位;
        private System.Windows.Forms.ComboBox cmb当前检测项;
        private System.Windows.Forms.ComboBox cmb当前图像预处理;
        private System.Windows.Forms.Label lab当前图像预处理;
        private System.Windows.Forms.Panel palNow;
    }
}