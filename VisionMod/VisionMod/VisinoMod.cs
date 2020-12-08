using HalconDotNet;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LS_VisionMod
{
    public class VisinoMod
    {

        static bool havConect = false;
        public static string ErrorMsg;
        /// <summary>
        /// 拍照事件
        /// </summary>
        public static event EventHandler<TriggerIamge> SoftwareOnceEvent;
        /// <summary>
        /// 检测事件
        /// </summary>
        public static event EventHandler<DetectionResult> DetectionOnceEvent;

        private static int camSleepTime = 20;

        // public  SoftwareOnceEvent softwareOnceEvent;
        public static List<string> ModelNameList => MyRun.GetModelNameList();

        static object obj = new object();
        public static bool Connect()
        {
            if (havConect)
                return true;
            int nRet = MyRun.Init();
            if (nRet == 0)
            {
                havConect = true;
                return true;
            }
            return false;
        }

        public static int TestItemNumber()
        {
            return UseModel.testItems.Count;
        }

        public static List<string> UseCamsName = new List<string>();
        public static List<检测功能> UseTestItems = new List<检测功能>();

        public static ConcurrentDictionary<string, Bitmap> ImagePool = new ConcurrentDictionary<string, Bitmap>();

        
        static Model UseModel;
        public static bool PrepareModel(string modelName)
        {
                UseModel = MyRun.ReadModelJS(modelName);
                if (UseModel is null)
                {
                    ErrorMsg = "模板" + modelName + "不存在";
                    return false;
                }
                UseCamsName.Clear();
                foreach (var cam in UseModel.cams)
                {
                    MyRun.SetCameraExposureTime(cam.CamName, cam.ExposureTime);
                    
                    UseCamsName.Add(cam.CamName);
                }
                UseTestItems.Clear();
                foreach (var testItem in UseModel.testItems)
                {
                    UseTestItems.Add(MyRun.GetTestItem(testItem));
                }
                return true;
        }

        public static bool TriggerCamera()
        {
            lock (obj)
            {
                if (UseCamsName.Count == 0)
                {
                    ErrorMsg = "未选择模板";
                    return false;
                }
                foreach (var camName in UseCamsName.ToArray())
                {
                    MyRun.TriggerCamera(camName, out HObject outImage);
                    //HOperatorSet.ReadImage(out HObject outImage, MyRun.appPath + "//a.jpg");
                    if (outImage != null)
                        SoftwareOnceEvent?.Invoke(null, new TriggerIamge(camName, outImage));
                    outImage.Dispose();
                }
                return true;
            }
        }

        public static bool TriggerDetection()
        {
            lock (obj)
            {
                try
                {
                    Dictionary<string, HObject> Images = new Dictionary<string, HObject>();
                    foreach (var camName in UseCamsName.ToArray())
                    {
                        MyRun.TriggerCamera(camName, out HObject outImage);
                        if (outImage != null)
                            Images.Add(camName, outImage);
                    }

                    foreach (var testItem in UseTestItems.ToArray())
                    {
                        HObject outImage = Images[testItem.camName];
                        HObject resultImage;
                        //图片预处理的功能暂时不加
                        //if (testItem.imagePreprocess != null)
                        //{
                        //    ImagePreprocessFun[testItem.imagePreprocess.type].Read(Application.StartupPath + "\\model\\" + UseModel.modelName, testItem.imagePreprocess.name);
                        //    ImagePreprocessFun[testItem.imagePreprocess.type].Find(outImage, out outImage);
                        //}

                        if (testItem.matching != null)
                        {
                            MyRun.MatchingFuns[testItem.matching.type].Read(MyRun.appPath + "\\model\\" + UseModel.modelName, testItem.matching.name);
                            MyRun.MatchingFuns[testItem.matching.type].Find(outImage, out outImage);
                        }
                        testItem.Find(outImage);
                        testItem.Show(outImage, out resultImage);

                        DetectionOnceEvent?.Invoke(null, new DetectionResult(testItem.camName, Images[testItem.camName], resultImage, testItem.outMessage));
                        outImage.Dispose();
                        resultImage.Dispose();
                    }
                }
                catch (Exception e)
                {
                    ErrorMsg = e.Message;
                    return false;
                }
                return true;
            }
        }

        public static bool TriggerDetection2()
        {
            try
            {
                



            }
            catch (Exception e)
            {
                ErrorMsg = e.Message;
                return false;
            }
            return true;
        }

        //public void CameraThreading(string camName)
        //{
        //    while (true)
        //    {
        //        MyRun.TriggerCamera(camName, );
        //        ImagePool.TryAdd(camName,)
        //        Thread.Sleep(camSleepTime);
        //    }
        //}
    }
}
