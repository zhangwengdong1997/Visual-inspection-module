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

        public static EventWaitHandle stopDetectionSignal = new EventWaitHandle(false, EventResetMode.ManualReset);

        
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
        public static List<MatchingFun> UseMatchingFun = new List<MatchingFun>();
        public static List<检测功能> UseTestItems = new List<检测功能>();

        static Model UseModel;
        /// <summary>
        /// 切换模板
        /// </summary>
        /// <param name="modelName">模板名称</param>
        /// <returns></returns>
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
                MyRun.SetCameraExposureTime(cam.name, cam.ExposureTime);
                UseCamsName.Add(cam.name);
            }

            UseMatchingFun.Clear();
            foreach (var matching in UseModel.matchings)
            {
                MatchingFun matchingFun = MyRun.GetMatchingFun(matching.type);
                matchingFun.Read(MyRun.appPath + "\\model\\" + UseModel.modelName, matching);
                UseMatchingFun.Add(matchingFun);
            }

            UseTestItems.Clear();
            foreach (var testItem in UseModel.testItems)
            {
                UseTestItems.Add(MyRun.GetTestItem(testItem));
            }
            return true;
        }
        /// <summary>
        /// 切换到实时模式，使用实时模式时请设置好相机的帧率，防止画面撕裂
        /// </summary>
        public static void ContinuesMode()
        {
            MyRun.ContinuesMode();
        }
        /// <summary>
        /// 切换到触发模式
        /// </summary>
        public static void TriggerMode()
        {
            MyRun.TriggerMode();
        }

        /// <summary>
        /// 触发拍照
        /// </summary>
        /// <returns></returns>
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
        public static bool TriggerDetection2()
        {
            lock (obj)
            {
                try
                {
                    Dictionary<string, HObject> camImages = new Dictionary<string, HObject>();
                    Dictionary<string, HObject> matchImages = new Dictionary<string, HObject>();

                    foreach (var camName in UseCamsName.ToArray())
                    {
                        MyRun.TriggerCamera(camName, out HObject camImage);
                        if (camImage != null)
                            camImages.Add(camName, camImage);
                    }
                    foreach (var matchingFun in UseMatchingFun.ToArray())
                    {
                        if (camImages.TryGetValue(matchingFun.matching.camName, out HObject camImage))
                        {
                            int nRet = matchingFun.Find(camImage, out HObject matchImage);
                            if (nRet == 0)
                            {
                                matchImages.Add(matchingFun.matching.name, matchImage);

                            }
                            else
                            {
                                DetectionOnceEvent?.Invoke(null, new DetectionResult(
                                    matchingFun.matching.camName, camImage, camImage, matchingFun.matching.camName + "@NG@模板匹配失败"));
                            }
                            
                        }
                    }

                    foreach (var testItem in UseTestItems.ToArray())
                    {
                        if (!testItem.hav && matchImages.TryGetValue(testItem.matchName, out HObject matchImage))
                        {
                            testItem.Find(matchImage);
                            testItem.Show(matchImage, out HObject resultImage);
                            DetectionOnceEvent?.Invoke(null, new DetectionResult(testItem.camName, camImages[testItem.camName], resultImage, testItem.outMessage));
                        }
                    }
                    foreach (var camImage in camImages.Values)
                    {
                        camImage.Dispose();
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
            /// <summary>
            /// 检测
            /// </summary>
            /// <returns></returns>
        public static bool TriggerDetection()
        {
            lock (obj)
            {
                try
                {
                    stopDetectionSignal.Reset();//防止之前暂停的信号影响到这次检测

                    ConcurrentDictionary<string, HObject> camImages = new ConcurrentDictionary<string, HObject>();
                    ConcurrentDictionary<string, HObject> matchImages = new ConcurrentDictionary<string, HObject>();
                    bool hav = true;
                    while (true)
                    {
                        Parallel.ForEach(UseCamsName.ToArray(), camName =>
                        {
                            MyRun.TriggerCamera(camName, out HObject camImage);
                            if (camImage != null)
                                camImages.AddOrUpdate(camName, camImage, (k, v) => v = camImage);
                        });

                        Parallel.ForEach(UseMatchingFun.ToArray(), matchingFun =>
                        {
                            if (camImages.TryGetValue(matchingFun.matching.camName, out HObject camImage))
                            {
                                int nRet = matchingFun.Find(camImage, out HObject matchImage);
                                if (nRet == 0)
                                {
                                    matchImages.AddOrUpdate(matchingFun.matching.name, matchImage, (k, v) => v = matchImage);
                                }
                                SoftwareOnceEvent?.Invoke(null, new TriggerIamge(matchingFun.matching.camName, camImage));
                            }
                        });


                        Parallel.ForEach(UseTestItems.ToArray(), testItem =>
                        {
                            if (!testItem.hav && matchImages.TryGetValue(testItem.matchName, out HObject matchImage))
                            {
                                testItem.Find(matchImage);
                                testItem.Show(matchImage, out HObject resultImage);
                                testItem.hav = true;
                                DetectionOnceEvent?.Invoke(null, new DetectionResult(testItem.camName, camImages[testItem.camName], resultImage, testItem.outMessage));                                
                            }
                        });
                        foreach (var camImage in camImages.Values)
                        {
                            camImage.Dispose();
                        }
                        hav = true;
                        foreach (var testItem in UseTestItems.ToArray())
                        {
                            hav &= testItem.hav;
                        }
                        if (hav)
                        {
                            foreach (var testItem in UseTestItems.ToArray())
                            {
                                testItem.hav = false;
                            }
                            break;
                        }
                        if (stopDetectionSignal.WaitOne(20))
                        {
                            break;
                        }
                        Thread.Sleep(20);
                    }
                }
                catch (Exception e)
                {
                    ErrorMsg = e.Message;
                    return false;
                }
                finally
                {
                    stopDetectionSignal.Reset();
                }
                return true;
            }
        }


        public static bool SaveImage(object Image, string path, string fileName)
        {
            try
            {
                if(Image is HObject ho_Imgae)
                {
                    HOperatorSet.WriteImage(ho_Imgae, "jpg", 0, path + "\\" + fileName);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                ErrorMsg = "图片保存失败";
                return false;
            }
            return true;
        }
        public static void StopDetection()
        {
            stopDetectionSignal.Set();
        }
        


    }
}
