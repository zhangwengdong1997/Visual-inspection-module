using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 标准视觉软件.Halcon;

namespace 标准视觉软件
{
    class MyRun
    {
        static HkCameraCltr cameraCltr;
        static Dictionary<string, 检测参数设置> ParameterSettingControls;
        static Dictionary<string, 预处理功能> ImagePreprocessFun;
        static Dictionary<string, 定位功能> MatchingFun;

        public static event EventHandler<TriggerIamge> SoftwareOnceEvent;
        public static event EventHandler<DetectionResult> DetectionOnceEvent;


        public static List<string> UseCamsName = new List<string>();
        public static List<检测功能> UseTestItems = new List<检测功能>();

        static Model UseModel;
        public static void Init()
        {
            //连接相机
            cameraCltr = new HkCameraCltr();
            //加载检测项参数设置控件
            ParameterSettingControls = new Dictionary<string, 检测参数设置>();
            字符识别参数设置 字符识别 = new 字符识别参数设置();
            ParameterSettingControls.Add("字符识别", 字符识别);
            区域筛选计数参数设置 区域筛选计数 = new 区域筛选计数参数设置();
            ParameterSettingControls.Add("区域筛选计数", 区域筛选计数);

            //加载可选预处理功能
            ImagePreprocessFun = new Dictionary<string, 预处理功能>();

            //加载可选定位功能
            MatchingFun = new Dictionary<string, 定位功能>();
            形状模板定位 形状模板 = new 形状模板定位();
            MatchingFun.Add("形状模板定位", 形状模板);
            
        }

        public static List<string> GetCameraList()
        {
            return HkCameraCltr.GetListUserDefinedName();
        }

        public static List<string> GetImagePreprocessList()
        {
            return ImagePreprocessFun.Keys.ToList<string>();
        }

        public static List<string> GetMatchingList()
        {
            return MatchingFun.Keys.ToList<string>();
        }

        public static List<string> GetTestItemList()
        {
            return ParameterSettingControls.Keys.ToList<string>();
        }

        public static 检测参数设置 GetParameterSettingControl(string TestItemType)
        {
            return ParameterSettingControls[TestItemType];
        }

        public static 预处理功能 GetImagePreprocessFun(string ImagePreprocessType)
        {
            return ImagePreprocessFun[ImagePreprocessType];
        }

        public static 定位功能 GetMatchingFun(string MatchingType)
        {
            return MatchingFun[MatchingType];
        }

        public static 检测功能 GetTestItem(string testItemName, string camName, Matching matching, List<Parameter> parameters)
        {
            switch (testItemName)
            {
                case "字符识别":
                    return new 字符识别(camName, matching, parameters);
                default:
                    return null;
            }
        }


        public static void WriteModelJS(Model model)
        {
            IniManager.WriteToIni(model, Application.StartupPath + "\\model\\" + model.modelName + "\\model.js");
        }

        public static Model ReadModelJS(string modelName)
        {
            return IniManager.ReadFromIni<Model>(Application.StartupPath + "\\model\\" + modelName + "\\model.js");
        }




        public static void TriggerCamera(string camName)
        {
            HObject outImage;

            int nRet = cameraCltr.Capture(camName, out outImage);
            if (nRet == 0)
                SoftwareOnceEvent?.Invoke(null, new TriggerIamge(camName, outImage));
        }

        public static void SetCameraExposureTime(string camName, float exposureTime)
        {
            cameraCltr.SetCameraParam(camName, exposureTime);
        }

        public static void PrepareModel(string modelName)
        {
            UseModel = ReadModelJS(modelName);
            UseCamsName.Clear();
            foreach (var cam in UseModel.cams)
            {
                cameraCltr.SetCameraParam(cam.CamName, cam.ExposureTime);
                UseCamsName.Add(cam.CamName);
            }
            UseTestItems.Clear();
            foreach (var testItem in UseModel.testItems)
            {
                UseTestItems.Add(GetTestItem(testItem.name, testItem.CamName, testItem.Match, testItem.parameters));
            }
        }

        public static void TriggerCamera()
        {
            foreach (var camName in UseCamsName)
            {
                HObject outImage;
                int nRet = cameraCltr.Capture(camName, out outImage);
                if (nRet == 0)
                    SoftwareOnceEvent?.Invoke(null, new TriggerIamge(camName, outImage));
            }
        }

        public static void TriggerDetection()
        {
            Dictionary<string, HObject> Images = new Dictionary<string, HObject>();
            foreach (var camName in UseCamsName)
            {
                HObject outImage;
                int nRet = cameraCltr.Capture(camName, out outImage);
                if (nRet == 0)
                    Images.Add(camName, outImage);
            }
            foreach (var testItem in UseTestItems)
            {
                HObject outImage = Images[testItem.camName];
                HObject resultImage;
                if(testItem.imagePreprocess != null)
                {
                    ImagePreprocessFun[testItem.imagePreprocess.type].Read(Application.StartupPath + "\\model\\" + UseModel.modelName, testItem.imagePreprocess.name);
                    ImagePreprocessFun[testItem.imagePreprocess.type].Find(outImage, out outImage);
                }

                if (testItem.matching != null)
                {
                    MatchingFun[testItem.matching.type].Read(Application.StartupPath + "\\model\\" + UseModel.modelName, testItem.matching.name);
                    MatchingFun[testItem.matching.type].Find(outImage, out outImage);
                }
                testItem.Find(outImage);
                testItem.Show(outImage, out resultImage);
                DetectionOnceEvent?.Invoke(null, new DetectionResult(testItem.camName, Images[testItem.camName], resultImage, testItem.outMessage));
            }
        }



    }


    class TriggerIamge
    {
        public string camName;
        public HObject ho_Image;
        public Bitmap bitmap { get => HalconFun.Honject2Bitmap(ho_Image); }
        //public string time;
        public TriggerIamge(string camName, HObject ho_Image)
        {
            this.camName = camName;
            this.ho_Image = ho_Image;
        }
    }

    class DetectionResult
    {
        public string camName;
        public HObject ho_outImage;
        public HObject ho_resultImage;
        public Bitmap outBitmap { get => HalconFun.Honject2Bitmap(ho_outImage); }
        public Bitmap resultBitmap { get => HalconFun.Honject2Bitmap(ho_resultImage); }
        public string outMessage;
        public DetectionResult(string camName, HObject ho_outImage, HObject ho_resultImage, string outMessage)
        {
            this.camName = camName;
            this.ho_outImage = ho_outImage;
            this.ho_resultImage = ho_resultImage;
            this.outMessage = outMessage;
        }
    }
}
