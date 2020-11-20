using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 标准视觉软件
{
    public partial class 选择模板类型 : UserControl, 模板创建步骤
    {
        int allCamNum;
        int camNum = 1;
        int testItemNum = 1;

        public 选择模板类型()
        {
            InitializeComponent();
        }

        private void 选择模板类型_Load(object sender, EventArgs e)
        {
            allCamNum = HkCameraCltr.EnumDevices();
            //导入模板默认配置（未完成）
        }

        public void Save(Model model)
        {
            model.modelName = txt模板名称.Text;
            model.camNum = camNum;
            model.nowStep++;
            model.steps.Clear();
            model.steps.Add(StepName.选择模板类型);
            for (int i = 0; i < model.camNum; i++)
            {
                if (chb相机配置.Checked)
                {
                    model.steps.Add(StepName.相机配置);
                }
                else
                {
                    //默认相机配置
                }
                if (chb图像预处理.Checked)
                {
                    model.steps.Add(StepName.图像预处理);
                }
                else
                {
                    //默认图像预处理
                }
                if (chb匹配定位.Checked)
                {
                    model.steps.Add(StepName.匹配定位);
                }
                else
                {
                    //默认定位模板
                }
                for(int j = 0; j < testItemNum; j++)
                {
                    model.steps.Add(StepName.检测项添加);
                }
            }
        }

        private void txt相机数量_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txt相机数量.Text, out camNum))
            {
                if (camNum > allCamNum)
                {
                    lab相机数量提示.Text = "输入相机数量大于当前连接的相机数量";
                }
                else
                {
                    lab相机数量提示.Text = "";
                }
            }
            else
            {
                lab相机数量提示.Text = "请输入该模板使用相机的数量";
                txt相机数量.Text = "";
            }
        }

        private void txt模板名称_TextChanged(object sender, EventArgs e)
        {
            string modelName = txt模板名称.Text;
            //查找已有模板名称，模板名称是否重复（未完成）
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt相机数量.Text = "1";
            chb相机配置.Checked = true;
            chb图像预处理.Checked = false;
            chb匹配定位.Checked = false;
            txt检测项数量.Text = "1";
        }

        private void txt检测项数量_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txt检测项数量.Text, out testItemNum))
            {
                if (testItemNum < 0)
                {
                    lab检测项数量提示.Text = "输入检测项数量不能小于零";
                }
                else
                {
                    lab检测项数量提示.Text = "";
                }
            }
            else
            {
                lab检测项数量提示.Text = "请输入该模板需要检测的点数量";
                txt检测项数量.Text = "";
            }
        }
    }
}
