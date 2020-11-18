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
            this.SuspendLayout();
            // 
            // btn下一步
            // 
            this.btn下一步.Location = new System.Drawing.Point(952, 735);
            this.btn下一步.Name = "btn下一步";
            this.btn下一步.Size = new System.Drawing.Size(115, 37);
            this.btn下一步.TabIndex = 9;
            this.btn下一步.Text = "下一步";
            this.btn下一步.UseVisualStyleBackColor = true;
            this.btn下一步.Click += new System.EventHandler(this.btn下一步_Click);
            // 
            // panelMain
            // 
            this.panelMain.Location = new System.Drawing.Point(22, 12);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1045, 717);
            this.panelMain.TabIndex = 10;
            // 
            // 新建模板
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 806);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.btn下一步);
            this.Name = "新建模板";
            this.Text = "新建模板";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.新建模板_FormClosing);
            this.Load += new System.EventHandler(this.新建模板_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn下一步;
        private System.Windows.Forms.Panel panelMain;
    }
}