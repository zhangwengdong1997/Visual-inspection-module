namespace 标准视觉软件
{
    partial class 选择模板类型
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
            this.chb检测项添加 = new System.Windows.Forms.CheckBox();
            this.chb相机配置 = new System.Windows.Forms.CheckBox();
            this.chb匹配定位 = new System.Windows.Forms.CheckBox();
            this.chb图像预处理 = new System.Windows.Forms.CheckBox();
            this.txt相机数量 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt模板名称 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lab模板名称提示 = new System.Windows.Forms.Label();
            this.lab相机数量提示 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // chb检测项添加
            // 
            this.chb检测项添加.AutoSize = true;
            this.chb检测项添加.Location = new System.Drawing.Point(428, 355);
            this.chb检测项添加.Name = "chb检测项添加";
            this.chb检测项添加.Size = new System.Drawing.Size(84, 16);
            this.chb检测项添加.TabIndex = 17;
            this.chb检测项添加.Text = "检测项添加";
            this.chb检测项添加.UseVisualStyleBackColor = true;
            // 
            // chb相机配置
            // 
            this.chb相机配置.AutoSize = true;
            this.chb相机配置.Location = new System.Drawing.Point(428, 239);
            this.chb相机配置.Name = "chb相机配置";
            this.chb相机配置.Size = new System.Drawing.Size(72, 16);
            this.chb相机配置.TabIndex = 16;
            this.chb相机配置.Text = "相机配置";
            this.chb相机配置.UseVisualStyleBackColor = true;
            // 
            // chb匹配定位
            // 
            this.chb匹配定位.AutoSize = true;
            this.chb匹配定位.Location = new System.Drawing.Point(428, 316);
            this.chb匹配定位.Name = "chb匹配定位";
            this.chb匹配定位.Size = new System.Drawing.Size(72, 16);
            this.chb匹配定位.TabIndex = 15;
            this.chb匹配定位.Text = "匹配定位";
            this.chb匹配定位.UseVisualStyleBackColor = true;
            // 
            // chb图像预处理
            // 
            this.chb图像预处理.AutoSize = true;
            this.chb图像预处理.Location = new System.Drawing.Point(428, 279);
            this.chb图像预处理.Name = "chb图像预处理";
            this.chb图像预处理.Size = new System.Drawing.Size(84, 16);
            this.chb图像预处理.TabIndex = 14;
            this.chb图像预处理.Text = "图像预处理";
            this.chb图像预处理.UseVisualStyleBackColor = true;
            // 
            // txt相机数量
            // 
            this.txt相机数量.Location = new System.Drawing.Point(502, 165);
            this.txt相机数量.Name = "txt相机数量";
            this.txt相机数量.Size = new System.Drawing.Size(75, 21);
            this.txt相机数量.TabIndex = 13;
            this.txt相机数量.TextChanged += new System.EventHandler(this.txt相机数量_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(37, 150);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(251, 368);
            this.dataGridView1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 24F);
            this.label2.Location = new System.Drawing.Point(30, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(271, 33);
            this.label2.TabIndex = 10;
            this.label2.Text = "最近常用模板类型";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(28, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 48);
            this.label1.TabIndex = 9;
            this.label1.Text = "创建新模板";
            // 
            // txt模板名称
            // 
            this.txt模板名称.Location = new System.Drawing.Point(502, 106);
            this.txt模板名称.Name = "txt模板名称";
            this.txt模板名称.Size = new System.Drawing.Size(156, 21);
            this.txt模板名称.TabIndex = 19;
            this.txt模板名称.TextChanged += new System.EventHandler(this.txt模板名称_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(432, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "模板名称";
            // 
            // lab模板名称提示
            // 
            this.lab模板名称提示.AutoSize = true;
            this.lab模板名称提示.Location = new System.Drawing.Point(500, 140);
            this.lab模板名称提示.Name = "lab模板名称提示";
            this.lab模板名称提示.Size = new System.Drawing.Size(0, 12);
            this.lab模板名称提示.TabIndex = 20;
            // 
            // lab相机数量提示
            // 
            this.lab相机数量提示.AutoSize = true;
            this.lab相机数量提示.Location = new System.Drawing.Point(500, 206);
            this.lab相机数量提示.Name = "lab相机数量提示";
            this.lab相机数量提示.Size = new System.Drawing.Size(0, 12);
            this.lab相机数量提示.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(432, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "相机数量";
            // 
            // 选择模板类型
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lab相机数量提示);
            this.Controls.Add(this.lab模板名称提示);
            this.Controls.Add(this.txt模板名称);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chb检测项添加);
            this.Controls.Add(this.chb相机配置);
            this.Controls.Add(this.chb匹配定位);
            this.Controls.Add(this.chb图像预处理);
            this.Controls.Add(this.txt相机数量);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "选择模板类型";
            this.Size = new System.Drawing.Size(761, 535);
            this.Load += new System.EventHandler(this.选择模板类型_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chb检测项添加;
        private System.Windows.Forms.CheckBox chb相机配置;
        private System.Windows.Forms.CheckBox chb匹配定位;
        private System.Windows.Forms.CheckBox chb图像预处理;
        private System.Windows.Forms.TextBox txt相机数量;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt模板名称;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lab模板名称提示;
        private System.Windows.Forms.Label lab相机数量提示;
        private System.Windows.Forms.Label label5;
    }
}
