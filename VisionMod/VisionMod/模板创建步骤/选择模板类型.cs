using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LS_VisionMod.模板创建步骤
{
    public partial class 选择模板类型 : UserControl, I模板创建步骤
    {
        Model model;
        List<StepName> stepNames = new List<StepName>();
        public 选择模板类型(ref Model model)
        {
            InitializeComponent();
            this.model = model;
            this.Dock = DockStyle.Fill;
        }
        public void Add()
        {
            //设置模板名称
            model.modelName = txt模板名称.Text;
            //创建以模板名称命名的文件夹
            FileOperation.CreateDirectory("model", model.modelName);
            //设置检测步骤
            model.steps = stepNames;
            model.nowStep = 0;
        }

        private void 选择模板类型_Load(object sender, EventArgs e)
        {
            //读取常用模板类型的配置文件
        }

        private void ShowStepList(string stepName)
        {
            ListViewItem lt = new ListViewItem(stepNames.Count.ToString());
            lt.SubItems.Add(stepName);
            lvwModelStep.Items.Add(lt);
        }

        private void btn添加相机_Click(object sender, EventArgs e)
        {
            stepNames.Add(StepName.相机配置);
            ShowStepList("相机配置");
        }

        private void btn添加预处理_Click(object sender, EventArgs e)
        {
            stepNames.Add(StepName.图像预处理);
            ShowStepList("图像预处理");
        }

        private void btn添加匹配定位_Click(object sender, EventArgs e)
        {
            stepNames.Add(StepName.匹配定位);
            ShowStepList("匹配定位");
        }

        private void btn添加检测项_Click(object sender, EventArgs e)
        {
            stepNames.Add(StepName.检测项添加);
            ShowStepList("检测项添加");
        }

        private void btn撤销_Click(object sender, EventArgs e)
        {
            if(stepNames.Count != 0)
            {
                stepNames.RemoveAt(stepNames.Count - 1);
                lvwModelStep.Items.RemoveAt(lvwModelStep.Items.Count - 1);
            }
        }

        private void btn默认_Click(object sender, EventArgs e)
        {
            stepNames.Add(StepName.相机配置);
            ShowStepList("相机配置");
            stepNames.Add(StepName.匹配定位);
            ShowStepList("匹配定位");
            stepNames.Add(StepName.检测项添加);
            ShowStepList("检测项添加");
        }

        public void Revise()
        {

        }
    }
}
