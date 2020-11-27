using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;

namespace 标准视觉软件
{
    public partial class 选择模板类型 : UserControl, I模板创建步骤
    {
        int allCamNum;
        int camNum = 1;
        int testItemNum = 0;

        public 选择模板类型()
        {
            InitializeComponent();
        }

        private void 选择模板类型_Load(object sender, EventArgs e)
        {
            allCamNum = HkCameraCltr.EnumDevices();
            //导入模板默认配置（未完成）
        }
        //根据模板创建的步骤，依次显示各步骤对应的界面
        public void Save(Model model)
        {
            model.modelName = txt模板名称.Text;
            model.camNum = camNum;
            model.nowStep++;
            model.steps.Clear();
            model.steps.Add(StepName.选择模板类型);
            //创建以模板名称命名的文件夹
            FileOperation.CreateDirectory("model", model.modelName);
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


        //选择要创建的模板的类型，决定模板创建所需的步骤
        //模板的类型可以由配置文件进行配置添加
        private void button1_Click(object sender, EventArgs e)
        {
            Hashtable stepSettings = (Hashtable)ConfigurationManager.GetSection("stepSettings");

            txt相机数量.Text = (string)stepSettings["cam"];
            chb相机配置.Checked = !stepSettings["cam"].Equals("0");
            chb图像预处理.Checked = !stepSettings["imagePreprocess"].Equals("0");
            chb匹配定位.Checked = !stepSettings["matching"].Equals("0");
            txt检测项数量.Text = (string)stepSettings["testItem"];
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
            //输入新建模板名称
            string modelName = txt模板名称.Text;
            //检测模板名称是否重复
            Model model = MyRun.ReadModelJS(modelName);
            if (model != null)
            {
                lab模板名称提示.Text = "模板名称已存在";
            }
            else
            {
                lab模板名称提示.Text = "";
            }

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
