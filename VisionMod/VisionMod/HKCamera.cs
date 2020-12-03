using HalconDotNet;
using MvCamCtrl.NET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LS_VisionMod
{


    class HKCamera
    {
        [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        private static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);
        /// <summary>
        /// 设备列表
        /// </summary>
        private static MyCamera.MV_CC_DEVICE_INFO_LIST m_stDeviceList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
        public static Dictionary<int, string> m_listUserDefinedName = new Dictionary<int, string>();

        private MyCamera.cbOutputExdelegate cbImage;
        private Dictionary<int, MyCamera> m_dicMyCamera = new Dictionary<int, MyCamera>();
        private Dictionary<int, MyCamera.MV_CC_DEVICE_INFO> m_pDeviceInfo = new Dictionary<int, MyCamera.MV_CC_DEVICE_INFO>();
        private bool m_bGrabbing = false;

        private Dictionary<int, MyCamera.MV_FRAME_OUT_INFO_EX> m_stFrameInfo = new Dictionary<int, MyCamera.MV_FRAME_OUT_INFO_EX>();
        public MyCamera DicMyCamera(string sUserDefineName)
        {
            int nRet;
            var keys = m_listUserDefinedName.Where(q => q.Value == sUserDefineName).Select(q => q.Key).ToList<int>();  //get all keys
            if (keys.Count != 1)
            {
                strErrorMsg = "相机" + sUserDefineName + "未连接";
                return null;
            }
            int nIndex = keys[0];
            return m_dicMyCamera[nIndex];
        }

        //用于从驱动获取图像的缓存
        class SaveImage
        {
            public UInt32 Size = 0;
            public IntPtr Buf = IntPtr.Zero;
            public Object Lock = new object();
        }
        private Dictionary<int, SaveImage> m_dicSaveImge = new Dictionary<int, SaveImage>();

        public string strErrorMsg
        {
            get; private set;
        } = "";

        public HKCamera()
        {
            DeviceListAcq();
            DeviceOpenAll();
            StartGrab();
        }

        public static List<string> GetListUserDefinedName()
        {
            return m_listUserDefinedName.Values.ToList();
        }
        private void ClearAllCamera()
        {
            foreach (MyCamera pMyCamera in m_dicMyCamera.Values)
            {
                if (m_bGrabbing)
                {
                    // ch:停止抓图 || en:Stop grab image
                    pMyCamera.MV_CC_StopGrabbing_NET();
                }
                // ch:关闭设备 || en: Close device
                pMyCamera.MV_CC_CloseDevice_NET();
            }
            m_bGrabbing = false;
            m_dicMyCamera.Clear();
            m_listUserDefinedName.Clear();
        }

        private void DeviceListAcq()
        {
            System.GC.Collect();
            m_stDeviceList.nDeviceNum = 0;

            int nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE, ref m_stDeviceList);
            if (0 != nRet)
            {
                strErrorMsg = "枚举设备失败！";
                return;
            }

            for (int i = 0; i < m_stDeviceList.nDeviceNum; i++)
            {
                MyCamera.MV_CC_DEVICE_INFO device =
                    (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_stDeviceList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));
                if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                {
                    MyCamera.MV_GIGE_DEVICE_INFO gigeInfo = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(device.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));

                    if (gigeInfo.chUserDefinedName != "")
                    {
                        m_listUserDefinedName.Add(i, gigeInfo.chUserDefinedName);
                    }
                    else
                    {
                        strErrorMsg = "没有给相机命名！" + "GigE: " + gigeInfo.chManufacturerName + " " + gigeInfo.chModelName + " (" + gigeInfo.chSerialNumber + ")";
                    }
                }
            }
        }

        private void DeviceOpenAll()
        {
            if (m_stDeviceList.nDeviceNum == 0)
            {
                strErrorMsg = "无相机设备";
                return;
            }
            int nIndex;
            string UserDefinedName;
            foreach (var item in m_listUserDefinedName)
            {
                nIndex = item.Key;
                UserDefinedName = item.Value;
                //获取选择的设备信息
                MyCamera.MV_CC_DEVICE_INFO device =
                    (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_stDeviceList.pDeviceInfo[nIndex], typeof(MyCamera.MV_CC_DEVICE_INFO));

                m_dicMyCamera[nIndex] = new MyCamera();
                if (m_dicMyCamera[nIndex] == null)
                {
                    strErrorMsg = "相机" + UserDefinedName + "对象创建失败";
                    return;
                }
                int nRet = m_dicMyCamera[nIndex].MV_CC_CreateDevice_NET(ref device);
                if (MyCamera.MV_OK != nRet)
                {
                    strErrorMsg = "相机" + UserDefinedName + "创建设备失败";
                    return;
                }
                nRet = m_dicMyCamera[nIndex].MV_CC_OpenDevice_NET();
                if (MyCamera.MV_OK != nRet)
                {
                    strErrorMsg = "相机" + UserDefinedName + "打开设备失败(" + nRet.ToString("X") + ")";
                    continue;
                }
                else
                {
                    m_pDeviceInfo[nIndex] = device;
                    //探测网络最佳包大小
                    int nPacketSize = m_dicMyCamera[nIndex].MV_CC_GetOptimalPacketSize_NET();
                    if (nPacketSize > 0)
                    {
                        nRet = m_dicMyCamera[nIndex].MV_CC_SetIntValue_NET("GevSCPSPacketSize", (uint)nPacketSize);
                        if (nRet != MyCamera.MV_OK)
                        {
                            strErrorMsg = "相机" + UserDefinedName + "设置数据包大小失败(" + nRet.ToString("X") + ")";
                        }
                    }
                    else
                    {
                        strErrorMsg = "相机" + UserDefinedName + "设置数据包大小失败(" + nRet.ToString("X") + ")";
                    }
                    //打开软触发模式
                    m_dicMyCamera[nIndex].MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);
                    m_dicMyCamera[nIndex].MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE);
                    m_stFrameInfo[nIndex] = new MyCamera.MV_FRAME_OUT_INFO_EX();
                    m_dicSaveImge[nIndex] = new SaveImage();
                    cbImage = new MyCamera.cbOutputExdelegate(ImageCallBack);
                    m_dicMyCamera[nIndex].MV_CC_RegisterImageCallBackEx_NET(cbImage, (IntPtr)nIndex);
                }
            }

        }
        private void StartGrab()
        {
            int nRet;
            foreach (var pMyCamera in m_dicMyCamera)
            {
                MyCamera.MV_FRAME_OUT_INFO_EX frameInfo = m_stFrameInfo[pMyCamera.Key];
                frameInfo.nFrameLen = 0;//取流之前先清除帧长度
                frameInfo.enPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_Undefined;
                //开启抓图
                nRet = pMyCamera.Value.MV_CC_StartGrabbing_NET();
                if (MyCamera.MV_OK != nRet)
                {
                    strErrorMsg = "相机" + m_listUserDefinedName[pMyCamera.Key] + "开始抓图失败(" + nRet.ToString("X") + ")";
                    return;
                }
            }
            m_bGrabbing = true;
            return;
        }

        private void ImageCallBack(IntPtr pData, ref MyCamera.MV_FRAME_OUT_INFO_EX pFrameInfo, IntPtr pUser)
        {
            int nIndex = (int)pUser;

            lock (m_dicSaveImge[nIndex].Lock)
            {
                if (m_dicSaveImge[nIndex].Buf == IntPtr.Zero || pFrameInfo.nFrameLen > m_dicSaveImge[nIndex].Size)
                {
                    if (m_dicSaveImge[nIndex].Buf != IntPtr.Zero)
                    {
                        Marshal.Release(m_dicSaveImge[nIndex].Buf);
                        m_dicSaveImge[nIndex].Buf = IntPtr.Zero;
                    }

                    m_dicSaveImge[nIndex].Buf = Marshal.AllocHGlobal((Int32)pFrameInfo.nFrameLen);
                    if (m_dicSaveImge[nIndex].Buf == IntPtr.Zero)
                    {
                        strErrorMsg = "缓存图片分配内存失败";
                        return;
                    }
                    m_dicSaveImge[nIndex].Size = pFrameInfo.nFrameLen;
                }
                m_stFrameInfo[nIndex] = pFrameInfo;
                CopyMemory(m_dicSaveImge[nIndex].Buf, pData, pFrameInfo.nFrameLen);
            }
        }

        public void DoSoftTriggerSpecify(string sUserDefineName)
        {
            int nRet;
            var keys = m_listUserDefinedName.Where(q => q.Value == sUserDefineName).Select(q => q.Key).ToList<int>();  //get all keys
            if (keys.Count != 1)
            {
                strErrorMsg = "相机" + sUserDefineName + "未连接";
                return;
            }
            int nIndex = keys[0];

            nRet = m_dicMyCamera[nIndex].MV_CC_SetCommandValue_NET("TriggerSoftware");
            if (MyCamera.MV_OK != nRet)
            {
                strErrorMsg = "相机" + sUserDefineName + "软触发失败(" + nRet.ToString("X") + ")";
                return;
            }
        }
        public int Capture(string sUserDefineName, out HObject outImage)
        {
            outImage = null;

            if (!m_bGrabbing)
            {
                return 1;
            }

            DoSoftTriggerSpecify(sUserDefineName);
            
            int nRet;
            var keys = m_listUserDefinedName.Where(q => q.Value == sUserDefineName).Select(q => q.Key).ToList<int>();  //get all keys
            if (keys.Count != 1)
            {
                strErrorMsg = "相机" + sUserDefineName + "未连接";
                
                return 1;
            }
            int nIndex = keys[0];
            IntPtr pImageBuf = IntPtr.Zero;
            int nImageBufSize = 0;
            IntPtr pTemp = IntPtr.Zero;
            lock (m_dicSaveImge[nIndex].Lock)
            {
                if (IsColorPixelFormat(m_stFrameInfo[nIndex].enPixelType))
                {
                    if (m_stFrameInfo[nIndex].enPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed)
                    {
                        pTemp = m_dicSaveImge[nIndex].Buf;
                    }
                    else
                    {
                        if (IntPtr.Zero == pImageBuf || nImageBufSize < (m_stFrameInfo[nIndex].nWidth * m_stFrameInfo[nIndex].nHeight * 3))
                        {
                            if (pImageBuf != IntPtr.Zero)
                            {
                                Marshal.FreeHGlobal(pImageBuf);
                                pImageBuf = IntPtr.Zero;
                            }

                            pImageBuf = Marshal.AllocHGlobal((int)m_stFrameInfo[nIndex].nWidth * m_stFrameInfo[nIndex].nHeight * 3);
                            if (IntPtr.Zero == pImageBuf)
                            {
                                return 2;
                            }
                            nImageBufSize = m_stFrameInfo[nIndex].nWidth * m_stFrameInfo[nIndex].nHeight * 3;
                        }

                        MyCamera.MV_PIXEL_CONVERT_PARAM stPixelConvertParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();

                        stPixelConvertParam.pSrcData = m_dicSaveImge[nIndex].Buf;//源数据
                        stPixelConvertParam.nWidth = m_stFrameInfo[nIndex].nWidth;//图像宽度
                        stPixelConvertParam.nHeight = m_stFrameInfo[nIndex].nHeight;//图像高度
                        stPixelConvertParam.enSrcPixelType = m_stFrameInfo[nIndex].enPixelType;//源数据的格式
                        stPixelConvertParam.nSrcDataLen = m_stFrameInfo[nIndex].nFrameLen;

                        stPixelConvertParam.nDstBufferSize = (uint)nImageBufSize;
                        stPixelConvertParam.pDstBuffer = pImageBuf;//转换后的数据
                        stPixelConvertParam.enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed;
                        nRet = m_dicMyCamera[nIndex].MV_CC_ConvertPixelType_NET(ref stPixelConvertParam);//格式转换
                        if (MyCamera.MV_OK != nRet)
                        {
                            return 3;
                        }
                        pTemp = pImageBuf;
                    }

                    try
                    {
                        HOperatorSet.GenImageInterleaved(out outImage, (HTuple)pTemp, (HTuple)"rgb", (HTuple)m_stFrameInfo[nIndex].nWidth, (HTuple)m_stFrameInfo[nIndex].nHeight, -1, "byte", 0, 0, 0, 0, -1, 0);
                    }
                    catch (System.Exception ex)
                    {

                        return 4;
                    }
                }
                else if (IsMonoPixelFormat(m_stFrameInfo[nIndex].enPixelType))
                {
                    if (m_stFrameInfo[nIndex].enPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8)
                    {
                        pTemp = m_dicSaveImge[nIndex].Buf;
                    }
                    else
                    {
                        if (IntPtr.Zero == pImageBuf || nImageBufSize < (m_stFrameInfo[nIndex].nWidth * m_stFrameInfo[nIndex].nHeight))
                        {
                            if (pImageBuf != IntPtr.Zero)
                            {
                                Marshal.FreeHGlobal(pImageBuf);
                                pImageBuf = IntPtr.Zero;
                            }

                            pImageBuf = Marshal.AllocHGlobal((int)m_stFrameInfo[nIndex].nWidth * m_stFrameInfo[nIndex].nHeight);
                            if (IntPtr.Zero == pImageBuf)
                            {
                                return 5;
                            }
                            nImageBufSize = m_stFrameInfo[nIndex].nWidth * m_stFrameInfo[nIndex].nHeight;
                        }

                        MyCamera.MV_PIXEL_CONVERT_PARAM stPixelConvertParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();

                        stPixelConvertParam.pSrcData = m_dicSaveImge[nIndex].Buf;//源数据
                        stPixelConvertParam.nWidth = m_stFrameInfo[nIndex].nWidth;//图像宽度
                        stPixelConvertParam.nHeight = m_stFrameInfo[nIndex].nHeight;//图像高度
                        stPixelConvertParam.enSrcPixelType = m_stFrameInfo[nIndex].enPixelType;//源数据的格式
                        stPixelConvertParam.nSrcDataLen = m_stFrameInfo[nIndex].nFrameLen;

                        stPixelConvertParam.nDstBufferSize = (uint)nImageBufSize;
                        stPixelConvertParam.pDstBuffer = pImageBuf;//转换后的数据
                        stPixelConvertParam.enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8;
                        nRet = m_dicMyCamera[nIndex].MV_CC_ConvertPixelType_NET(ref stPixelConvertParam);//格式转换
                        if (MyCamera.MV_OK != nRet)
                        {
                            return 6;
                        }
                        pTemp = pImageBuf;
                    }
                    try
                    {
                        HOperatorSet.GenImage1Extern(out outImage, "byte", m_stFrameInfo[nIndex].nWidth, m_stFrameInfo[nIndex].nHeight, pTemp, IntPtr.Zero);
                    }
                    catch (System.Exception ex)
                    {
                        return 7;
                    }
                }
                if (pImageBuf != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pImageBuf);
                    pImageBuf = IntPtr.Zero;
                }
            }
            return 0;
        }

        public void SaveJpg(string sUserDefineName, string path)
        {
            //if (!m_bGrabbing)
            //{
            //    strErrorMsg = "相机" + sUserDefineName + "已停止抓取图片";
            //    return;
            //}
            //int nRet;
            //var keys = m_listUserDefinedName.Where(q => q.Value == sUserDefineName).Select(q => q.Key).ToList<int>();  //get all keys
            //if (keys.Count != 1)
            //{
            //    strErrorMsg = "相机" + sUserDefineName + "未连接";
            //    return;
            //}
            //int nIndex = keys[0];




        }

        private bool IsMonoPixelFormat(MyCamera.MvGvspPixelType enType)
        {
            switch (enType)
            {
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12_Packed:
                    return true;
                default:
                    return false;
            }
        }

        private bool IsColorPixelFormat(MyCamera.MvGvspPixelType enType)
        {
            switch (enType)
            {
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BGR8_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_RGBA8_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BGRA8_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_YUYV_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12_Packed:
                    return true;
                default:
                    return false;
            }
        }
    }
}
