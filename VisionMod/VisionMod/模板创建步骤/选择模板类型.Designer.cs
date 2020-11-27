namespace LS_VisionMod.模板创建步骤
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btn默认 = new System.Windows.Forms.Button();
            this.txt模板名称 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn添加相机 = new System.Windows.Forms.Button();
            this.lvwModelStep = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn添加图片预处理 = new System.Windows.Forms.Button();
            this.btn添加匹配定位 = new System.Windows.Forms.Button();
            this.btn添加检测项 = new System.Windows.Forms.Button();
            this.btn撤销 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btn默认);
            this.panel1.Location = new System.Drawing.Point(77, 194);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 362);
            this.panel1.TabIndex = 38;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(46, 154);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(198, 54);
            this.button2.TabIndex = 1;
            this.button2.Text = "单相机固定位置单检测项";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btn默认
            // 
            this.btn默认.Location = new System.Drawing.Point(43, 32);
            this.btn默认.Name = "btn默认";
            this.btn默认.Size = new System.Drawing.Size(198, 54);
            this.btn默认.TabIndex = 0;
            this.btn默认.Text = "默认";
            this.btn默认.UseVisualStyleBackColor = true;
            this.btn默认.Click += new System.EventHandler(this.btn默认_Click);
            // 
            // txt模板名称
            // 
            this.txt模板名称.Location = new System.Drawing.Point(532, 82);
            this.txt模板名称.Name = "txt模板名称";
            this.txt模板名称.Size = new System.Drawing.Size(156, 21);
            this.txt模板名称.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(462, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 33;
            this.label4.Text = "模板名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 24F);
            this.label2.Location = new System.Drawing.Point(71, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(271, 33);
            this.label2.TabIndex = 28;
            this.label2.Text = "最近常用模板类型";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(69, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 48);
            this.label1.TabIndex = 27;
            this.label1.Text = "创建新模板";
            // 
            // btn添加相机
            // 
            this.btn添加相机.Location = new System.Drawing.Point(455, 146);
            this.btn添加相机.Name = "btn添加相机";
            this.btn添加相机.Size = new System.Drawing.Size(135, 42);
            this.btn添加相机.TabIndex = 40;
            this.btn添加相机.Text = "添加相机";
            this.btn添加相机.UseVisualStyleBackColor = true;
            this.btn添加相机.Click += new System.EventHandler(this.btn添加相机_Click);
            // 
            // lvwModelStep
            // 
            this.lvwModelStep.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwModelStep.HideSelection = false;
            this.lvwModelStep.Location = new System.Drawing.Point(665, 146);
            this.lvwModelStep.Name = "lvwModelStep";
            this.lvwModelStep.Size = new System.Drawing.Size(184, 410);
            this.lvwModelStep.TabIndex = 41;
            this.lvwModelStep.UseCompatibleStateImageBehavior = false;
            this.lvwModelStep.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "序号";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "创建模板步骤";
            this.columnHeader2.Width = 115;
            // 
            // btn添加图片预处理
            // 
            this.btn添加图片预处理.Location = new System.Drawing.Point(455, 217);
            this.btn添加图片预处理.Name = "btn添加图片预处理";
            this.btn添加图片预处理.Size = new System.Drawing.Size(135, 42);
            this.btn添加图片预处理.TabIndex = 42;
            this.btn添加图片预处理.Text = "添加预处理";
            this.btn添加图片预处理.UseVisualStyleBackColor = true;
            this.btn添加图片预处理.Click += new System.EventHandler(this.btn添加预处理_Click);
            // 
            // btn添加匹配定位
            // 
            this.btn添加匹配定位.Location = new System.Drawing.Point(455, 292);
            this.btn添加匹配定位.Name = "btn添加匹配定位";
            this.btn添加匹配定位.Size = new System.Drawing.Size(135, 42);
            this.btn添加匹配定位.TabIndex = 43;
            this.btn添加匹配定位.Text = "添加匹配定位";
            this.btn添加匹配定位.UseVisualStyleBackColor = true;
            this.btn添加匹配定位.Click += new System.EventHandler(this.btn添加匹配定位_Click);
            // 
            // btn添加检测项
            // 
            this.btn添加检测项.Location = new System.Drawing.Point(455, 360);
            this.btn添加检测项.Name = "btn添加检测项";
            this.btn添加检测项.Size = new System.Drawing.Size(135, 42);
            this.btn添加检测项.TabIndex = 44;
            this.btn添加检测项.Text = "添加检测项";
            this.btn添加检测项.UseVisualStyleBackColor = true;
            this.btn添加检测项.Click += new System.EventHandler(this.btn添加检测项_Click);
            // 
            // btn撤销
            // 
            this.btn撤销.Location = new System.Drawing.Point(455, 430);
            this.btn撤销.Name = "btn撤销";
            this.btn撤销.Size = new System.Drawing.Size(135, 42);
            this.btn撤销.TabIndex = 45;
            this.btn撤销.Text = "撤销";
            this.btn撤销.UseVisualStyleBackColor = true;
            this.btn撤销.Click += new System.EventHandler(this.btn撤销_Click);
            // 
            // 选择模板类型
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn撤销);
            this.Controls.Add(this.btn添加检测项);
            this.Controls.Add(this.btn添加匹配定位);
            this.Controls.Add(this.btn添加图片预处理);
            this.Controls.Add(this.lvwModelStep);
            this.Controls.Add(this.btn添加相机);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt模板名称);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "选择模板类型";
            this.Size = new System.Drawing.Size(993, 634);
            this.Load += new System.EventHandler(this.选择模板类型_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn默认;
        private System.Windows.Forms.TextBox txt模板名称;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn添加相机;
        private System.Windows.Forms.ListView lvwModelStep;
        private System.Windows.Forms.Button btn添加图片预处理;
        private System.Windows.Forms.Button btn添加匹配定位;
        private System.Windows.Forms.Button btn添加检测项;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btn撤销;
    }
}
