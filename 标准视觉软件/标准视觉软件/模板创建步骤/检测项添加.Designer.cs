namespace 标准视觉软件
{
    partial class 检测项添加
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
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn测试 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb选择检测项 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt检测项说明 = new System.Windows.Forms.TextBox();
            this.txt检测结果 = new System.Windows.Forms.TextBox();
            this.pnl参数设置 = new System.Windows.Forms.Panel();
            this.rdo本地模式 = new System.Windows.Forms.RadioButton();
            this.rdo相机模式 = new System.Windows.Forms.RadioButton();
            this.btn获取图片 = new System.Windows.Forms.Button();
            this.lab当前相机 = new System.Windows.Forms.Label();
            this.lab本地图片数量 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(679, 582);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(141, 40);
            this.button12.TabIndex = 41;
            this.button12.Text = "下一张";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(527, 582);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(141, 40);
            this.button13.TabIndex = 40;
            this.button13.Text = "上一张";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(544, 293);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 39;
            this.label2.Text = "检测结果";
            // 
            // btn测试
            // 
            this.btn测试.Location = new System.Drawing.Point(679, 505);
            this.btn测试.Name = "btn测试";
            this.btn测试.Size = new System.Drawing.Size(141, 40);
            this.btn测试.TabIndex = 38;
            this.btn测试.Text = "测试";
            this.btn测试.UseVisualStyleBackColor = true;
            this.btn测试.Click += new System.EventHandler(this.btn测试_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(501, 463);
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(532, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 35;
            this.label1.Text = "选择检测项";
            // 
            // cmb选择检测项
            // 
            this.cmb选择检测项.FormattingEnabled = true;
            this.cmb选择检测项.Location = new System.Drawing.Point(627, 27);
            this.cmb选择检测项.Name = "cmb选择检测项";
            this.cmb选择检测项.Size = new System.Drawing.Size(150, 20);
            this.cmb选择检测项.TabIndex = 34;
            this.cmb选择检测项.SelectedIndexChanged += new System.EventHandler(this.cmb选择检测项_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(532, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 42;
            this.label3.Text = "检测项说明";
            // 
            // txt检测项说明
            // 
            this.txt检测项说明.Location = new System.Drawing.Point(614, 72);
            this.txt检测项说明.Multiline = true;
            this.txt检测项说明.Name = "txt检测项说明";
            this.txt检测项说明.Size = new System.Drawing.Size(206, 212);
            this.txt检测项说明.TabIndex = 43;
            // 
            // txt检测结果
            // 
            this.txt检测结果.Location = new System.Drawing.Point(614, 290);
            this.txt检测结果.Multiline = true;
            this.txt检测结果.Name = "txt检测结果";
            this.txt检测结果.Size = new System.Drawing.Size(206, 121);
            this.txt检测结果.TabIndex = 44;
            // 
            // pnl参数设置
            // 
            this.pnl参数设置.Location = new System.Drawing.Point(3, 472);
            this.pnl参数设置.Name = "pnl参数设置";
            this.pnl参数设置.Size = new System.Drawing.Size(501, 162);
            this.pnl参数设置.TabIndex = 45;
            // 
            // rdo本地模式
            // 
            this.rdo本地模式.AutoSize = true;
            this.rdo本地模式.Location = new System.Drawing.Point(720, 460);
            this.rdo本地模式.Name = "rdo本地模式";
            this.rdo本地模式.Size = new System.Drawing.Size(71, 16);
            this.rdo本地模式.TabIndex = 48;
            this.rdo本地模式.TabStop = true;
            this.rdo本地模式.Text = "本地模式";
            this.rdo本地模式.UseVisualStyleBackColor = true;
            // 
            // rdo相机模式
            // 
            this.rdo相机模式.AutoSize = true;
            this.rdo相机模式.Location = new System.Drawing.Point(614, 460);
            this.rdo相机模式.Name = "rdo相机模式";
            this.rdo相机模式.Size = new System.Drawing.Size(71, 16);
            this.rdo相机模式.TabIndex = 47;
            this.rdo相机模式.TabStop = true;
            this.rdo相机模式.Text = "相机模式";
            this.rdo相机模式.UseVisualStyleBackColor = true;
            // 
            // btn获取图片
            // 
            this.btn获取图片.Location = new System.Drawing.Point(527, 503);
            this.btn获取图片.Name = "btn获取图片";
            this.btn获取图片.Size = new System.Drawing.Size(138, 45);
            this.btn获取图片.TabIndex = 46;
            this.btn获取图片.Text = "获取图片";
            this.btn获取图片.UseVisualStyleBackColor = true;
            this.btn获取图片.Click += new System.EventHandler(this.btn获取图片_Click);
            // 
            // lab当前相机
            // 
            this.lab当前相机.AutoSize = true;
            this.lab当前相机.Location = new System.Drawing.Point(544, 427);
            this.lab当前相机.Name = "lab当前相机";
            this.lab当前相机.Size = new System.Drawing.Size(53, 12);
            this.lab当前相机.TabIndex = 49;
            this.lab当前相机.Text = "当前相机";
            // 
            // lab本地图片数量
            // 
            this.lab本地图片数量.AutoSize = true;
            this.lab本地图片数量.Location = new System.Drawing.Point(688, 427);
            this.lab本地图片数量.Name = "lab本地图片数量";
            this.lab本地图片数量.Size = new System.Drawing.Size(77, 12);
            this.lab本地图片数量.TabIndex = 50;
            this.lab本地图片数量.Text = "本地图片数量";
            // 
            // 检测项添加
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lab本地图片数量);
            this.Controls.Add(this.lab当前相机);
            this.Controls.Add(this.rdo本地模式);
            this.Controls.Add(this.rdo相机模式);
            this.Controls.Add(this.btn获取图片);
            this.Controls.Add(this.pnl参数设置);
            this.Controls.Add(this.txt检测结果);
            this.Controls.Add(this.txt检测项说明);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn测试);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb选择检测项);
            this.Name = "检测项添加";
            this.Size = new System.Drawing.Size(846, 660);
            this.Load += new System.EventHandler(this.检测项添加_Load);
            this.Enter += new System.EventHandler(this.检测项添加_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn测试;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb选择检测项;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt检测项说明;
        private System.Windows.Forms.TextBox txt检测结果;
        private System.Windows.Forms.Panel pnl参数设置;
        private System.Windows.Forms.RadioButton rdo本地模式;
        private System.Windows.Forms.RadioButton rdo相机模式;
        private System.Windows.Forms.Button btn获取图片;
        private System.Windows.Forms.Label lab当前相机;
        private System.Windows.Forms.Label lab本地图片数量;
    }
}
