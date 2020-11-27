namespace 标准视觉软件
{
    partial class 匹配定位
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
            this.label2 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb定位模板类型 = new System.Windows.Forms.ComboBox();
            this.btn减少区域 = new System.Windows.Forms.Button();
            this.btn添加区域 = new System.Windows.Forms.Button();
            this.btn新建区域 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdo多边形区域 = new System.Windows.Forms.RadioButton();
            this.rdo圆形区域 = new System.Windows.Forms.RadioButton();
            this.rdo矩形区域 = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chb测试定位模板 = new System.Windows.Forms.CheckBox();
            this.btn撤销上一步 = new System.Windows.Forms.Button();
            this.btn获取图片 = new System.Windows.Forms.Button();
            this.rdo本地模式 = new System.Windows.Forms.RadioButton();
            this.rdo相机模式 = new System.Windows.Forms.RadioButton();
            this.lab本地图片数量 = new System.Windows.Forms.Label();
            this.lab当前相机 = new System.Windows.Forms.Label();
            this.btn创建模板 = new System.Windows.Forms.Button();
            this.btn保存模板 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(609, 533);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 41;
            this.label2.Text = "模板匹配率";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(446, 596);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(141, 40);
            this.button10.TabIndex = 40;
            this.button10.Text = "下一张";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(16, 596);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(141, 40);
            this.button9.TabIndex = 39;
            this.button9.Text = "上一张";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(614, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 37;
            this.label1.Text = "定位模板类型";
            // 
            // cmb定位模板类型
            // 
            this.cmb定位模板类型.FormattingEnabled = true;
            this.cmb定位模板类型.Location = new System.Drawing.Point(697, 209);
            this.cmb定位模板类型.Name = "cmb定位模板类型";
            this.cmb定位模板类型.Size = new System.Drawing.Size(137, 20);
            this.cmb定位模板类型.TabIndex = 36;
            this.cmb定位模板类型.SelectedIndexChanged += new System.EventHandler(this.cmb定位模板类型_SelectedIndexChanged);
            // 
            // btn减少区域
            // 
            this.btn减少区域.Location = new System.Drawing.Point(743, 316);
            this.btn减少区域.Name = "btn减少区域";
            this.btn减少区域.Size = new System.Drawing.Size(91, 40);
            this.btn减少区域.TabIndex = 35;
            this.btn减少区域.Text = "减少区域";
            this.btn减少区域.UseVisualStyleBackColor = true;
            this.btn减少区域.Click += new System.EventHandler(this.btn减少区域_Click);
            // 
            // btn添加区域
            // 
            this.btn添加区域.Location = new System.Drawing.Point(616, 316);
            this.btn添加区域.Name = "btn添加区域";
            this.btn添加区域.Size = new System.Drawing.Size(91, 40);
            this.btn添加区域.TabIndex = 34;
            this.btn添加区域.Text = "添加区域";
            this.btn添加区域.UseVisualStyleBackColor = true;
            this.btn添加区域.Click += new System.EventHandler(this.btn添加区域_Click);
            // 
            // btn新建区域
            // 
            this.btn新建区域.Location = new System.Drawing.Point(616, 253);
            this.btn新建区域.Name = "btn新建区域";
            this.btn新建区域.Size = new System.Drawing.Size(91, 40);
            this.btn新建区域.TabIndex = 33;
            this.btn新建区域.Text = "新建区域";
            this.btn新建区域.UseVisualStyleBackColor = true;
            this.btn新建区域.Click += new System.EventHandler(this.btn新建区域_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdo多边形区域);
            this.groupBox1.Controls.Add(this.rdo圆形区域);
            this.groupBox1.Controls.Add(this.rdo矩形区域);
            this.groupBox1.Location = new System.Drawing.Point(611, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 180);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "形状选择";
            // 
            // rdo多边形区域
            // 
            this.rdo多边形区域.AutoSize = true;
            this.rdo多边形区域.Location = new System.Drawing.Point(64, 122);
            this.rdo多边形区域.Name = "rdo多边形区域";
            this.rdo多边形区域.Size = new System.Drawing.Size(83, 16);
            this.rdo多边形区域.TabIndex = 2;
            this.rdo多边形区域.Text = "多边形区域";
            this.rdo多边形区域.UseVisualStyleBackColor = true;
            // 
            // rdo圆形区域
            // 
            this.rdo圆形区域.AutoSize = true;
            this.rdo圆形区域.Location = new System.Drawing.Point(64, 80);
            this.rdo圆形区域.Name = "rdo圆形区域";
            this.rdo圆形区域.Size = new System.Drawing.Size(71, 16);
            this.rdo圆形区域.TabIndex = 1;
            this.rdo圆形区域.Text = "圆形区域";
            this.rdo圆形区域.UseVisualStyleBackColor = true;
            // 
            // rdo矩形区域
            // 
            this.rdo矩形区域.AutoSize = true;
            this.rdo矩形区域.Checked = true;
            this.rdo矩形区域.Location = new System.Drawing.Point(64, 35);
            this.rdo矩形区域.Name = "rdo矩形区域";
            this.rdo矩形区域.Size = new System.Drawing.Size(71, 16);
            this.rdo矩形区域.TabIndex = 0;
            this.rdo矩形区域.TabStop = true;
            this.rdo矩形区域.Text = "矩形区域";
            this.rdo矩形区域.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(584, 561);
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // chb测试定位模板
            // 
            this.chb测试定位模板.AutoSize = true;
            this.chb测试定位模板.Location = new System.Drawing.Point(705, 532);
            this.chb测试定位模板.Name = "chb测试定位模板";
            this.chb测试定位模板.Size = new System.Drawing.Size(96, 16);
            this.chb测试定位模板.TabIndex = 42;
            this.chb测试定位模板.Text = "测试定位模板";
            this.chb测试定位模板.UseVisualStyleBackColor = true;
            // 
            // btn撤销上一步
            // 
            this.btn撤销上一步.Location = new System.Drawing.Point(743, 253);
            this.btn撤销上一步.Name = "btn撤销上一步";
            this.btn撤销上一步.Size = new System.Drawing.Size(91, 40);
            this.btn撤销上一步.TabIndex = 45;
            this.btn撤销上一步.Text = "撤销上一步";
            this.btn撤销上一步.UseVisualStyleBackColor = true;
            this.btn撤销上一步.Click += new System.EventHandler(this.btn撤销上一步_Click);
            // 
            // btn获取图片
            // 
            this.btn获取图片.Location = new System.Drawing.Point(611, 565);
            this.btn获取图片.Name = "btn获取图片";
            this.btn获取图片.Size = new System.Drawing.Size(138, 45);
            this.btn获取图片.TabIndex = 46;
            this.btn获取图片.Text = "获取图片";
            this.btn获取图片.UseVisualStyleBackColor = true;
            this.btn获取图片.Click += new System.EventHandler(this.btn获取图片_Click);
            // 
            // rdo本地模式
            // 
            this.rdo本地模式.AutoSize = true;
            this.rdo本地模式.Location = new System.Drawing.Point(725, 496);
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
            this.rdo相机模式.Location = new System.Drawing.Point(619, 496);
            this.rdo相机模式.Name = "rdo相机模式";
            this.rdo相机模式.Size = new System.Drawing.Size(71, 16);
            this.rdo相机模式.TabIndex = 47;
            this.rdo相机模式.TabStop = true;
            this.rdo相机模式.Text = "相机模式";
            this.rdo相机模式.UseVisualStyleBackColor = true;
            // 
            // lab本地图片数量
            // 
            this.lab本地图片数量.AutoSize = true;
            this.lab本地图片数量.Location = new System.Drawing.Point(724, 461);
            this.lab本地图片数量.Name = "lab本地图片数量";
            this.lab本地图片数量.Size = new System.Drawing.Size(77, 12);
            this.lab本地图片数量.TabIndex = 52;
            this.lab本地图片数量.Text = "本地图片数量";
            // 
            // lab当前相机
            // 
            this.lab当前相机.AutoSize = true;
            this.lab当前相机.Location = new System.Drawing.Point(621, 461);
            this.lab当前相机.Name = "lab当前相机";
            this.lab当前相机.Size = new System.Drawing.Size(53, 12);
            this.lab当前相机.TabIndex = 51;
            this.lab当前相机.Text = "当前相机";
            // 
            // btn创建模板
            // 
            this.btn创建模板.Location = new System.Drawing.Point(616, 390);
            this.btn创建模板.Name = "btn创建模板";
            this.btn创建模板.Size = new System.Drawing.Size(91, 40);
            this.btn创建模板.TabIndex = 53;
            this.btn创建模板.Text = "创建模板";
            this.btn创建模板.UseVisualStyleBackColor = true;
            this.btn创建模板.Click += new System.EventHandler(this.btn创建模板_Click);
            // 
            // btn保存模板
            // 
            this.btn保存模板.Location = new System.Drawing.Point(743, 390);
            this.btn保存模板.Name = "btn保存模板";
            this.btn保存模板.Size = new System.Drawing.Size(91, 40);
            this.btn保存模板.TabIndex = 54;
            this.btn保存模板.Text = "保存模板";
            this.btn保存模板.UseVisualStyleBackColor = true;
            this.btn保存模板.Click += new System.EventHandler(this.btn保存模板_Click);
            // 
            // 匹配定位
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn保存模板);
            this.Controls.Add(this.btn创建模板);
            this.Controls.Add(this.lab本地图片数量);
            this.Controls.Add(this.lab当前相机);
            this.Controls.Add(this.rdo本地模式);
            this.Controls.Add(this.rdo相机模式);
            this.Controls.Add(this.btn获取图片);
            this.Controls.Add(this.btn撤销上一步);
            this.Controls.Add(this.chb测试定位模板);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb定位模板类型);
            this.Controls.Add(this.btn减少区域);
            this.Controls.Add(this.btn添加区域);
            this.Controls.Add(this.btn新建区域);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "匹配定位";
            this.Size = new System.Drawing.Size(846, 660);
            this.Load += new System.EventHandler(this.匹配定位_Load);
            this.Enter += new System.EventHandler(this.匹配定位_Enter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb定位模板类型;
        private System.Windows.Forms.Button btn减少区域;
        private System.Windows.Forms.Button btn添加区域;
        private System.Windows.Forms.Button btn新建区域;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdo多边形区域;
        private System.Windows.Forms.RadioButton rdo圆形区域;
        private System.Windows.Forms.RadioButton rdo矩形区域;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chb测试定位模板;
        private System.Windows.Forms.Button btn撤销上一步;
        private System.Windows.Forms.Button btn获取图片;
        private System.Windows.Forms.RadioButton rdo本地模式;
        private System.Windows.Forms.RadioButton rdo相机模式;
        private System.Windows.Forms.Label lab本地图片数量;
        private System.Windows.Forms.Label lab当前相机;
        private System.Windows.Forms.Button btn创建模板;
        private System.Windows.Forms.Button btn保存模板;
    }
}
