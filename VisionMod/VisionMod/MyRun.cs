using HalconDotNet;
using MvCamCtrl.NET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LS_VisionMod
{
    class MyRun
    {
        static HKCamera cameraCltr;
        public static Dictionary<string, MatchingFun> MatchingFuns;
        public static Dictionary<string, I检测参数设置> ParameterSettingControls;

        public static string appPath = Application.StartupPath;
        public static MyCamera.MVCC_FLOATVALUE ExposureTime = new MyCamera.MVCC_FLOATVALUE();

        public static event EventHandler<TriggerIamge> SoftwareOnceEvent;

        public static string ErrorMsg { get; set; }
        public static int Init()
        {
            int Rnt;
            //连接相机
            cameraCltr = new HKCamera();
            cameraCltr.CamErrorEvent += CameraCltr_CamErrorEvent;
            if (!cameraCltr.StrErrorMsg.Equals(""))
            {
                ErrorMsg = "相机异常：" + cameraCltr.StrErrorMsg;
                Rnt = 1;
            }
            //加载可选定位功能
            MatchingFuns = new Dictionary<string, MatchingFun>();
            形状模板定位 形状模板 = new 形状模板定位();
            MatchingFuns.Add("形状模板定位", 形状模板);

            //加载检测项参数设置控件
            ParameterSettingControls = new Dictionary<string, I检测参数设置>();
            区域筛选计数参数设置 区域筛选计数 = new 区域筛选计数参数设置();
            ParameterSettingControls.Add("区域筛选计数", 区域筛选计数);
            字符识别参数设置 字符识别 = new 字符识别参数设置();
            ParameterSettingControls.Add("字符识别", 字符识别);


            ////加载可选预处理功能
            //ImagePreprocessFun = new Dictionary<string, 预处理功能>();

            Rnt = 0;
            return Rnt;
        }

        private static void CameraCltr_CamErrorEvent(object sender, string e)
        {
            ErrorMsg = "相机异常：" + e;
        }

        public static List<string> GetModelNameList()
        {
            List<string> modelNamelist = new List<string>();
            List<String> modelDirectorylist = FileOperation.GetAllDirectoryName(appPath + "\\model");
            foreach (var modelDirectory in modelDirectorylist)
            {
                Model model = MyRun.ReadModelJS(modelDirectory);
                if (model == null)
                    continue;
                modelNamelist.Add(modelDirectory);
            }
            return modelNamelist;
        }

        #region 相机
        public static List<string> GetCameraList()
        {
            return HKCamera.GetListUserDefinedName();
        }
        public static float GetCamExposureTime(string camName)
        {
            int nRet = cameraCltr.DicMyCamera(camName).MV_CC_GetExposureTime_NET(ref ExposureTime);
            if (MyCamera.MV_OK != nRet)
            {
                //警告相机参数获取失败
                return -1;
            }
            return ExposureTime.fCurValue;
        }
        public static (float, float) GetCamExposureTimeLimit(string camName)
        {
            int nRet = cameraCltr.DicMyCamera(camName).MV_CC_GetExposureTime_NET(ref ExposureTime);
            if (MyCamera.MV_OK != nRet)
            {
                //警告相机参数获取失败
                return (-1, -1);
            }
            return (ExposureTime.fMin, ExposureTime.fMax);
        }

        public static void SetCameraExposureTime(string camName, float exposureTime)
        {
            string sParamName = "ExposureTime";
            int nRet = cameraCltr.DicMyCamera(camName).MV_CC_SetFloatValue_NET(sParamName, exposureTime);
            if (MyCamera.MV_OK != nRet)
            {
                //警告相机曝光设置失败
            }
        }

        public static void TriggerCamera(string camName)
        {
            HObject outImage;

            int nRet = cameraCltr.Capture(camName, out outImage);
            if (nRet == 0)
                SoftwareOnceEvent?.Invoke(null, new TriggerIamge(camName, outImage));
            if(outImage != null)
                outImage.Dispose();
        }
        public static void TriggerCamera(string camName, out HObject outImage)
        {
            int nRet = cameraCltr.Capture(camName, out outImage);
        }

        public static void ContinuesMode()
        {
            cameraCltr.ContinuesMode();
        }

        public static void TriggerMode()
        {
            cameraCltr.TriggerMode();
        }
        #endregion


        #region 匹配定位

        public static List<string> GetMatchingList()
        {
            return MatchingFuns.Keys.ToList<string>();
        }

        public static MatchingFun GetMatchingFun(string MatchingType)
        {
            switch (MatchingType)
            {
                case "形状模板定位":
                    return new 形状模板定位();
                default:
                    return null;
            }
        }
        #endregion

        #region 检测项添加
        public static List<string> GetTestItemList()
        {
            return ParameterSettingControls.Keys.ToList<string>();
        }
        public static I检测参数设置 GetParameterSettingControl(string TestItemType)
        {
            return ParameterSettingControls[TestItemType];
        }

        public static 检测功能 GetTestItem(TestItem testItem)
        {
            switch (testItem.type)
            {
                case "字符识别":
                    return new 字符识别(testItem);
                case "区域筛选计数":
                    return new 区域筛选计数(testItem);
                default:
                    return null;
            }
        }

        #endregion

        public static void WriteModelJS(Model model)
        {
            IniManager.WriteToIni(model,appPath + "\\model\\" + model.modelName + "\\model.js");
        }

        public static Model ReadModelJS(string modelName)
        {
            return IniManager.ReadFromIni<Model>(appPath + "\\model\\" + modelName + "\\model.js");
        }

       

    }
    public class TriggerIamge
    {
        public string camName;
        public HObject ho_Image;
        public string outMessage;
        public Bitmap bitmap { get => HalconFun.Honject2Bitmap(ho_Image); }
        //public string time;
        public TriggerIamge(string camName, HObject ho_Image)
        {
            this.camName = camName;
            this.ho_Image = ho_Image;
        }
    }

    public class DetectionResult
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
