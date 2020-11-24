using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1
{
    class VisionModule
    {
        private Model model;
        public string SAppPath { get; set; }
        internal IModelCreatStep ChooseModelTypeWindow { get; set; }
        internal IModelCreatStep CamSetWindow { get; set; }
        internal IModelCreatStep ImagePretreatWindow { get; set; }
        internal IModelCreatStep MatchingWindow { get; set; }
        internal IModelCreatStep TestItemsAddWindow { get; set; }

        public void CreatNewModel()
        {
            model = new Model();
        }

        public void SetModelName(string modelName)
        {
            if (IsHaveModel(modelName))
            {
                //提示：模板名重复
            }
            model.Name = modelName;
        }

        public void WriteModelJS()
        {
            IniManager.WriteToIni(model, SAppPath + "\\model\\" + model.Name + "\\model.js");
        }

        public Model ReadModelJS(string modelName)
        {
            return IniManager.ReadFromIni<Model>(SAppPath + "\\model\\" + modelName + "\\model.js");
        }

        public bool IsHaveModel(string modelName)
        {
            Model model = ReadModelJS(modelName);
            return model != null;
        }

        public void SetModelType(params StepName[] stepNames)
        {
            if (stepNames is null)
            {
                //提示：检测步骤不能为空
                return;
            }
            foreach (StepName step in stepNames)
            {
                model.Steps.Add(step);
            }
        }

        public void CreateDirectory(params string[] names)
        {
            foreach (var item in names)
            {
                SAppPath = SAppPath + "\\" + item;
                if (Directory.Exists(SAppPath) == false)
                {
                    Directory.CreateDirectory(SAppPath);
                }
            }
        }

        public IModelCreatStep GetStepWindow(StepName stepName)
        {
            switch (stepName)
            {
                case StepName.选择模板类型:
                    return ChooseModelTypeWindow;
                case StepName.相机配置:
                    return CamSetWindow;
                case StepName.图像预处理:
                    return ImagePretreatWindow;
                case StepName.匹配定位:
                    return MatchingWindow;
                case StepName.检测项添加:
                    return TestItemsAddWindow;
                default:
                    return null;
            }
        }


    }
}
