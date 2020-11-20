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
            this.cmb相机列表 = new System.Windows.Forms.ComboBox();
            this.cmb定位 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
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
            this.panelMain.Location = new System.Drawing.Point(22, 54);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1104, 675);
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
            this.lab当前型号.Location = new System.Drawing.Point(54, 16);
            this.lab当前型号.Name = "lab当前型号";
            this.lab当前型号.Size = new System.Drawing.Size(53, 12);
            this.lab当前型号.TabIndex = 12;
            this.lab当前型号.Text = "当前型号";
            // 
            // txt当前型号
            // 
            this.txt当前型号.Location = new System.Drawing.Point(132, 12);
            this.txt当前型号.Name = "txt当前型号";
            this.txt当前型号.ReadOnly = true;
            this.txt当前型号.Size = new System.Drawing.Size(84, 21);
            this.txt当前型号.TabIndex = 13;
            // 
            // lab当前相机
            // 
            this.lab当前相机.AutoSize = true;
            this.lab当前相机.Location = new System.Drawing.Point(275, 16);
            this.lab当前相机.Name = "lab当前相机";
            this.lab当前相机.Size = new System.Drawing.Size(53, 12);
            this.lab当前相机.TabIndex = 14;
            this.lab当前相机.Text = "当前相机";
            // 
            // lab当前定位
            // 
            this.lab当前定位.AutoSize = true;
            this.lab当前定位.Location = new System.Drawing.Point(512, 16);
            this.lab当前定位.Name = "lab当前定位";
            this.lab当前定位.Size = new System.Drawing.Size(53, 12);
            this.lab当前定位.TabIndex = 16;
            this.lab当前定位.Text = "当前定位";
            // 
            // lab当前检测项
            // 
            this.lab当前检测项.AutoSize = true;
            this.lab当前检测项.Location = new System.Drawing.Point(767, 16);
            this.lab当前检测项.Name = "lab当前检测项";
            this.lab当前检测项.Size = new System.Drawing.Size(65, 12);
            this.lab当前检测项.TabIndex = 18;
            this.lab当前检测项.Text = "当前检测项";
            // 
            // cmb相机列表
            // 
            this.cmb相机列表.FormattingEnabled = true;
            this.cmb相机列表.Location = new System.Drawing.Point(334, 12);
            this.cmb相机列表.Name = "cmb相机列表";
            this.cmb相机列表.Size = new System.Drawing.Size(147, 20);
            this.cmb相机列表.TabIndex = 20;
            // 
            // cmb定位
            // 
            this.cmb定位.FormattingEnabled = true;
            this.cmb定位.Location = new System.Drawing.Point(571, 12);
            this.cmb定位.Name = "cmb定位";
            this.cmb定位.Size = new System.Drawing.Size(147, 20);
            this.cmb定位.TabIndex = 21;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(865, 13);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(147, 20);
            this.comboBox2.TabIndex = 21;
            // 
            // 新建模板
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 806);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.cmb定位);
            this.Controls.Add(this.cmb相机列表);
            this.Controls.Add(this.lab当前检测项);
            this.Controls.Add(this.lab当前定位);
            this.Controls.Add(this.lab当前相机);
            this.Controls.Add(this.txt当前型号);
            this.Controls.Add(this.lab当前型号);
            this.Controls.Add(this.btn上一步);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.btn下一步);
            this.Name = "新建模板";
            this.Text = "新建模板";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.新建模板_FormClosing);
            this.Load += new System.EventHandler(this.新建模板_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ComboBox cmb相机列表;
        private System.Windows.Forms.ComboBox cmb定位;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}