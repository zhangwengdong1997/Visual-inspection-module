namespace 标准视觉软件
{
    partial class 相机配置
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
            this.rdo本地模式 = new System.Windows.Forms.RadioButton();
            this.rdo相机模式 = new System.Windows.Forms.RadioButton();
            this.lab关联图片数量 = new System.Windows.Forms.Label();
            this.btn添加本地图片关联相机 = new System.Windows.Forms.Button();
            this.btn获取图片 = new System.Windows.Forms.Button();
            this.txt相机曝光值 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb相机列表 = new System.Windows.Forms.ComboBox();
            this.lab相机曝光值提示 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt关联图片路径 = new System.Windows.Forms.TextBox();
            this.lab选择相机提示 = new System.Windows.Forms.Label();
            this.btn添加当前图片关联相机 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rdo本地模式
            // 
            this.rdo本地模式.AutoSize = true;
            this.rdo本地模式.Location = new System.Drawing.Point(660, 338);
            this.rdo本地模式.Name = "rdo本地模式";
            this.rdo本地模式.Size = new System.Drawing.Size(71, 16);
            this.rdo本地模式.TabIndex = 27;
            this.rdo本地模式.TabStop = true;
            this.rdo本地模式.Text = "本地模式";
            this.rdo本地模式.UseVisualStyleBackColor = true;
            this.rdo本地模式.CheckedChanged += new System.EventHandler(this.rdo本地模式_CheckedChanged);
            // 
            // rdo相机模式
            // 
            this.rdo相机模式.AutoSize = true;
            this.rdo相机模式.Location = new System.Drawing.Point(554, 338);
            this.rdo相机模式.Name = "rdo相机模式";
            this.rdo相机模式.Size = new System.Drawing.Size(71, 16);
            this.rdo相机模式.TabIndex = 26;
            this.rdo相机模式.TabStop = true;
            this.rdo相机模式.Text = "相机模式";
            this.rdo相机模式.UseVisualStyleBackColor = true;
            this.rdo相机模式.CheckedChanged += new System.EventHandler(this.rdo相机模式_CheckedChanged);
            // 
            // lab关联图片数量
            // 
            this.lab关联图片数量.AutoSize = true;
            this.lab关联图片数量.Location = new System.Drawing.Point(546, 290);
            this.lab关联图片数量.Name = "lab关联图片数量";
            this.lab关联图片数量.Size = new System.Drawing.Size(77, 12);
            this.lab关联图片数量.TabIndex = 25;
            this.lab关联图片数量.Text = "关联图片数量";
            // 
            // btn添加本地图片关联相机
            // 
            this.btn添加本地图片关联相机.Location = new System.Drawing.Point(651, 182);
            this.btn添加本地图片关联相机.Name = "btn添加本地图片关联相机";
            this.btn添加本地图片关联相机.Size = new System.Drawing.Size(153, 45);
            this.btn添加本地图片关联相机.TabIndex = 23;
            this.btn添加本地图片关联相机.Text = "添加本地图片关联相机";
            this.btn添加本地图片关联相机.UseVisualStyleBackColor = true;
            this.btn添加本地图片关联相机.Click += new System.EventHandler(this.btn添加本地图片关联相机_Click);
            // 
            // btn获取图片
            // 
            this.btn获取图片.Location = new System.Drawing.Point(543, 397);
            this.btn获取图片.Name = "btn获取图片";
            this.btn获取图片.Size = new System.Drawing.Size(138, 45);
            this.btn获取图片.TabIndex = 22;
            this.btn获取图片.Text = "获取图片";
            this.btn获取图片.UseVisualStyleBackColor = true;
            this.btn获取图片.Click += new System.EventHandler(this.btn获取图片_Click);
            // 
            // txt相机曝光值
            // 
            this.txt相机曝光值.Location = new System.Drawing.Point(651, 101);
            this.txt相机曝光值.Name = "txt相机曝光值";
            this.txt相机曝光值.Size = new System.Drawing.Size(136, 21);
            this.txt相机曝光值.TabIndex = 21;
            this.txt相机曝光值.TextChanged += new System.EventHandler(this.txt相机曝光值_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(548, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "相机曝光值";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(16, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(523, 560);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(548, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "选择相机";
            // 
            // cmb相机列表
            // 
            this.cmb相机列表.FormattingEnabled = true;
            this.cmb相机列表.Location = new System.Drawing.Point(616, 27);
            this.cmb相机列表.Name = "cmb相机列表";
            this.cmb相机列表.Size = new System.Drawing.Size(207, 20);
            this.cmb相机列表.TabIndex = 17;
            this.cmb相机列表.SelectedIndexChanged += new System.EventHandler(this.cmb相机列表_SelectedIndexChanged);
            // 
            // lab相机曝光值提示
            // 
            this.lab相机曝光值提示.AutoSize = true;
            this.lab相机曝光值提示.Location = new System.Drawing.Point(649, 140);
            this.lab相机曝光值提示.Name = "lab相机曝光值提示";
            this.lab相机曝光值提示.Size = new System.Drawing.Size(0, 12);
            this.lab相机曝光值提示.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(548, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 29;
            this.label3.Text = "关联图片路径";
            // 
            // txt关联图片路径
            // 
            this.txt关联图片路径.Location = new System.Drawing.Point(631, 155);
            this.txt关联图片路径.Name = "txt关联图片路径";
            this.txt关联图片路径.ReadOnly = true;
            this.txt关联图片路径.Size = new System.Drawing.Size(182, 21);
            this.txt关联图片路径.TabIndex = 30;
            // 
            // lab选择相机提示
            // 
            this.lab选择相机提示.AutoSize = true;
            this.lab选择相机提示.Location = new System.Drawing.Point(601, 67);
            this.lab选择相机提示.Name = "lab选择相机提示";
            this.lab选择相机提示.Size = new System.Drawing.Size(0, 12);
            this.lab选择相机提示.TabIndex = 31;
            // 
            // btn添加当前图片关联相机
            // 
            this.btn添加当前图片关联相机.Location = new System.Drawing.Point(651, 233);
            this.btn添加当前图片关联相机.Name = "btn添加当前图片关联相机";
            this.btn添加当前图片关联相机.Size = new System.Drawing.Size(153, 45);
            this.btn添加当前图片关联相机.TabIndex = 32;
            this.btn添加当前图片关联相机.Text = "添加当前图片关联相机";
            this.btn添加当前图片关联相机.UseVisualStyleBackColor = true;
            this.btn添加当前图片关联相机.Click += new System.EventHandler(this.btn添加当前图片关联相机_Click);
            // 
            // 相机配置
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn添加当前图片关联相机);
            this.Controls.Add(this.lab选择相机提示);
            this.Controls.Add(this.txt关联图片路径);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lab相机曝光值提示);
            this.Controls.Add(this.rdo本地模式);
            this.Controls.Add(this.rdo相机模式);
            this.Controls.Add(this.lab关联图片数量);
            this.Controls.Add(this.btn添加本地图片关联相机);
            this.Controls.Add(this.btn获取图片);
            this.Controls.Add(this.txt相机曝光值);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb相机列表);
            this.Name = "相机配置";
            this.Size = new System.Drawing.Size(846, 660);
            this.Load += new System.EventHandler(this.相机配置_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdo本地模式;
        private System.Windows.Forms.RadioButton rdo相机模式;
        private System.Windows.Forms.Label lab关联图片数量;
        private System.Windows.Forms.Button btn添加本地图片关联相机;
        private System.Windows.Forms.Button btn获取图片;
        private System.Windows.Forms.TextBox txt相机曝光值;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb相机列表;
        private System.Windows.Forms.Label lab相机曝光值提示;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt关联图片路径;
        private System.Windows.Forms.Label lab选择相机提示;
        private System.Windows.Forms.Button btn添加当前图片关联相机;
    }
}
