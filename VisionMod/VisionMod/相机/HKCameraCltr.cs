using HalconDotNet;
using MvCamCtrl.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LS_VisionMod
{
    class HkCameraCltr
    {
        static MyCamera.MV_CC_DEVICE_INFO_LIST m_pDeviceList;
        bool m_bGrabbing;
        private Dictionary<string, MyCamera> m_dicMyCamera = new Dictionary<string, MyCamera>();
        public Dictionary<string, string> m_dicFullMessage = new Dictionary<string, string>();
        public static List<string> m_listUserDefinedName = new List<string>();

        public Dictionary<string, MyCamera> DicMyCamera { get => m_dicMyCamera; private set => m_dicMyCamera = value; }

        public string strErrorMsg
        {
            get; private set;
        } = "";

        public HkCameraCltr()
        {
            m_pDeviceList = new MyCamera.MV_CC_DEVICE_INFO_LIST();

            m_bGrabbing = false;

            DeviceListAcq();
            DeviceOpenAll();
            StartGrab();

        }
        ~HkCameraCltr()
        {
            ClearAllCamera();
        }
        public static int EnumDevices()
        {
            int nRet;
            // ch:创建设备列表 || en: Create device list
            System.GC.Collect();
            nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref m_pDeviceList);
            return (int)m_pDeviceList.nDeviceNum;
        }
        public static List<string> GetListUserDefinedName()
        {
            return m_listUserDefinedName;
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
            m_dicMyCamera.Clear();
            m_dicFullMessage.Clear();
            m_listUserDefinedName.Clear();
            m_bGrabbing = false;
        }
        private void DeviceListAcq()
        {
            ClearAllCamera();
            int nRet;
            // ch:创建设备列表 || en: Create device list
            GC.Collect();

            // cbDeviceList.Items.Clear();
            nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref m_pDeviceList);
            if (MyCamera.MV_OK != nRet)
            {
                strErrorMsg = "Enum Devices Fail";
                return;
            }

            // ch:在窗体列表中显示设备名 || Display the device'name on window's list
            for (int i = 0; i < m_pDeviceList.nDeviceNum; i++)
            {
                MyCamera.MV_CC_DEVICE_INFO device = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_pDeviceList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));
                if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                {
                    IntPtr buffer = Marshal.UnsafeAddrOfPinnedArrayElement(device.SpecialInfo.stGigEInfo, 0);
                    MyCamera.MV_GIGE_DEVICE_INFO gigeInfo = (MyCamera.MV_GIGE_DEVICE_INFO)Marshal.PtrToStructure(buffer, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                    if (gigeInfo.chUserDefinedName != "")
                    {
                        m_dicMyCamera[gigeInfo.chUserDefinedName] = new MyCamera();
                        m_dicFullMessage.Add(gigeInfo.chUserDefinedName, "GigE: " + gigeInfo.chUserDefinedName + " (" + gigeInfo.chSerialNumber + ")");
                        m_listUserDefinedName.Add(gigeInfo.chUserDefinedName);
                    }
                    else
                    {
                        strErrorMsg = "没有给相机命名！" + "GigE: " + gigeInfo.chManufacturerName + " " + gigeInfo.chModelName + " (" + gigeInfo.chSerialNumber + ")";
                    }
                }
                else if (device.nTLayerType == MyCamera.MV_USB_DEVICE)
                {
                    IntPtr buffer = Marshal.UnsafeAddrOfPinnedArrayElement(device.SpecialInfo.stUsb3VInfo, 0);
                    MyCamera.MV_USB3_DEVICE_INFO usbInfo = (MyCamera.MV_USB3_DEVICE_INFO)Marshal.PtrToStructure(buffer, typeof(MyCamera.MV_USB3_DEVICE_INFO));
                    if (usbInfo.chUserDefinedName != "")
                    {
                        m_dicMyCamera[usbInfo.chUserDefinedName] = new MyCamera();
                        m_dicFullMessage.Add(usbInfo.chUserDefinedName, "GigE: " + usbInfo.chUserDefinedName + " (" + usbInfo.chSerialNumber + ")");
                        m_listUserDefinedName.Add(usbInfo.chUserDefinedName);
                   }
                    else
                    {
                        strErrorMsg = "没有给相机命名！" + "USB: " + usbInfo.chManufacturerName + " " + usbInfo.chModelName + " (" + usbInfo.chSerialNumber + ")";
                    }
                }
            }
        }

        private void DeviceOpenAll()
        {
            if (m_pDeviceList.nDeviceNum == 0)
            {
                return;
            }
            int nIndex = -1;
            foreach (MyCamera pMyCamera in m_dicMyCamera.Values)
            {
                nIndex++;

                int nRet = -1;

                //ch:获取选择的设备信息 | en:Get selected device information
                MyCamera.MV_CC_DEVICE_INFO device =
                 (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_pDeviceList.pDeviceInfo[nIndex],
                                                                  typeof(MyCamera.MV_CC_DEVICE_INFO));
                nRet = pMyCamera.MV_CC_CreateDevice_NET(ref device);
                if (MyCamera.MV_OK != nRet)
                {
                    return;
                }

                // ch:打开设备 | en:Open device
                nRet = pMyCamera.MV_CC_OpenDevice_NET();
                if (MyCamera.MV_OK != nRet)
                {
                    strErrorMsg = "Open Device Fail";
                    return;
                }
            }
        }

        private int StartGrab()
        {
            int nRet;
            foreach (var pMyCamera in m_dicMyCamera)
            {
                // ch:开启抓图 | en:start grab
                nRet = pMyCamera.Value.MV_CC_StartGrabbing_NET();
                if (MyCamera.MV_OK != nRet)
                {
                    strErrorMsg = "Start Grabbing Fail:" + pMyCamera.Key;
                    return 1;
                }
            }
            m_bGrabbing = true;
            return 0;
        }

        public void DoSoftTriggerAll()
        {
            int nRet;
            foreach (var pMyCamera in m_dicMyCamera)
            {
                // ch: 触发命令 || en: Trigger command
                nRet = pMyCamera.Value.MV_CC_SetCommandValue_NET("TriggerSoftware");
                if (MyCamera.MV_OK != nRet)
                {
                    strErrorMsg = "Trigger Fail:" + pMyCamera.Key;
                }
            }
        }

        public int DoSoftTriggerSpecify(string sUserDefineName)
        {
            int nRet = -1;
            if (m_dicMyCamera.ContainsKey(sUserDefineName) == false)
            {
                return 1;
            }
            // ch: 触发命令 || en: Trigger command
            nRet = m_dicMyCamera[sUserDefineName].MV_CC_SetCommandValue_NET("TriggerSoftware");
            if (MyCamera.MV_OK != nRet)
            {
                strErrorMsg = "Trigger Fail";
                return 2;
                
            }

            return 0;
        }

        public int Capture(string sUserDefineName, out HObject outImage)
        {

            outImage = null;
            if (sUserDefineName == null || m_dicMyCamera.ContainsKey(sUserDefineName) == false)
            {
                return 1;
            }
            int nRet = MyCamera.MV_OK;
            nRet = DoSoftTriggerSpecify(sUserDefineName);
            MyCamera device = m_dicMyCamera[sUserDefineName];
            MyCamera.MV_FRAME_OUT stFrameOut = new MyCamera.MV_FRAME_OUT();

            IntPtr pImageBuf = IntPtr.Zero;
            int nImageBufSize = 0;

            HObject Hobj = new HObject();
            IntPtr pTemp = IntPtr.Zero;

            if (m_bGrabbing)
            {
                nRet = device.MV_CC_GetImageBuffer_NET(ref stFrameOut, 1000);
                if (MyCamera.MV_OK == nRet)
                {
                    if (IsColorPixelFormat(stFrameOut.stFrameInfo.enPixelType))
                    {
                        if (stFrameOut.stFrameInfo.enPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed)
                        {
                            pTemp = stFrameOut.pBufAddr;
                        }
                        else
                        {
                            if (IntPtr.Zero == pImageBuf || nImageBufSize < (stFrameOut.stFrameInfo.nWidth * stFrameOut.stFrameInfo.nHeight * 3))
                            {
                                if (pImageBuf != IntPtr.Zero)
                                {
                                    Marshal.FreeHGlobal(pImageBuf);
                                    pImageBuf = IntPtr.Zero;
                                }

                                pImageBuf = Marshal.AllocHGlobal((int)stFrameOut.stFrameInfo.nWidth * stFrameOut.stFrameInfo.nHeight * 3);
                                if (IntPtr.Zero == pImageBuf)
                                {
                                    return 2;
                                }
                                nImageBufSize = stFrameOut.stFrameInfo.nWidth * stFrameOut.stFrameInfo.nHeight * 3;
                            }

                            MyCamera.MV_PIXEL_CONVERT_PARAM stPixelConvertParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();

                            stPixelConvertParam.pSrcData = stFrameOut.pBufAddr;//源数据
                            stPixelConvertParam.nWidth = stFrameOut.stFrameInfo.nWidth;//图像宽度
                            stPixelConvertParam.nHeight = stFrameOut.stFrameInfo.nHeight;//图像高度
                            stPixelConvertParam.enSrcPixelType = stFrameOut.stFrameInfo.enPixelType;//源数据的格式
                            stPixelConvertParam.nSrcDataLen = stFrameOut.stFrameInfo.nFrameLen;

                            stPixelConvertParam.nDstBufferSize = (uint)nImageBufSize;
                            stPixelConvertParam.pDstBuffer = pImageBuf;//转换后的数据
                            stPixelConvertParam.enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed;
                            nRet = device.MV_CC_ConvertPixelType_NET(ref stPixelConvertParam);//格式转换
                            if (MyCamera.MV_OK != nRet)
                            {
                                return 3;
                            }
                            pTemp = pImageBuf;
                        }

                        try
                        {
                            HOperatorSet.GenImageInterleaved(out Hobj, (HTuple)pTemp, (HTuple)"rgb", (HTuple)stFrameOut.stFrameInfo.nWidth, (HTuple)stFrameOut.stFrameInfo.nHeight, -1, "byte", 0, 0, 0, 0, -1, 0);
                        }
                        catch
                        {
                            
                            return 4;
                        }
                    }
                    else if (IsMonoPixelFormat(stFrameOut.stFrameInfo.enPixelType))
                    {
                        if (stFrameOut.stFrameInfo.enPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8)
                        {
                            pTemp = stFrameOut.pBufAddr;
                        }
                        else
                        {
                            if (IntPtr.Zero == pImageBuf || nImageBufSize < (stFrameOut.stFrameInfo.nWidth * stFrameOut.stFrameInfo.nHeight))
                            {
                                if (pImageBuf != IntPtr.Zero)
                                {
                                    Marshal.FreeHGlobal(pImageBuf);
                                    pImageBuf = IntPtr.Zero;
                                }

                                pImageBuf = Marshal.AllocHGlobal((int)stFrameOut.stFrameInfo.nWidth * stFrameOut.stFrameInfo.nHeight);
                                if (IntPtr.Zero == pImageBuf)
                                {
                                    return 5;
                                }
                                nImageBufSize = stFrameOut.stFrameInfo.nWidth * stFrameOut.stFrameInfo.nHeight;
                            }

                            MyCamera.MV_PIXEL_CONVERT_PARAM stPixelConvertParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();

                            stPixelConvertParam.pSrcData = stFrameOut.pBufAddr;//源数据
                            stPixelConvertParam.nWidth = stFrameOut.stFrameInfo.nWidth;//图像宽度
                            stPixelConvertParam.nHeight = stFrameOut.stFrameInfo.nHeight;//图像高度
                            stPixelConvertParam.enSrcPixelType = stFrameOut.stFrameInfo.enPixelType;//源数据的格式
                            stPixelConvertParam.nSrcDataLen = stFrameOut.stFrameInfo.nFrameLen;

                            stPixelConvertParam.nDstBufferSize = (uint)nImageBufSize;
                            stPixelConvertParam.pDstBuffer = pImageBuf;//转换后的数据
                            stPixelConvertParam.enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8;
                            nRet = device.MV_CC_ConvertPixelType_NET(ref stPixelConvertParam);//格式转换
                            if (MyCamera.MV_OK != nRet)
                            {
                                return 6;
                            }
                            pTemp = pImageBuf;
                        }
                        try
                        {
                            HOperatorSet.GenImage1Extern(out Hobj, "byte", stFrameOut.stFrameInfo.nWidth, stFrameOut.stFrameInfo.nHeight, pTemp, IntPtr.Zero);
                        }
                        catch
                        {
                            return 7;
                        }
                        
                    }
                    else
                    {
                        device.MV_CC_FreeImageBuffer_NET(ref stFrameOut);
                        return 7;
                    }
                    outImage = Hobj.Clone();
                    device.MV_CC_FreeImageBuffer_NET(ref stFrameOut);
                }
                else
                {
                    return 8;
                }
            }

            if (pImageBuf != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(pImageBuf);
                pImageBuf = IntPtr.Zero;
            }
            return 0;
        }


        private Int32 ConvertToMono8(object obj, IntPtr pInData, IntPtr pOutData, ushort nHeight, ushort nWidth, MyCamera.MvGvspPixelType nPixelType)
        {
            if (IntPtr.Zero == pInData || IntPtr.Zero == pOutData)
            {
                return MyCamera.MV_E_PARAMETER;
            }

            int nRet = MyCamera.MV_OK;
            MyCamera device = obj as MyCamera;
            MyCamera.MV_PIXEL_CONVERT_PARAM stPixelConvertParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();

            stPixelConvertParam.pSrcData = pInData;//源数据
            if (IntPtr.Zero == stPixelConvertParam.pSrcData)
            {
                return -1;
            }

            stPixelConvertParam.nWidth = nWidth;//图像宽度
            stPixelConvertParam.nHeight = nHeight;//图像高度
            stPixelConvertParam.enSrcPixelType = nPixelType;//源数据的格式
            stPixelConvertParam.nSrcDataLen = (uint)(nWidth * nHeight * ((((uint)nPixelType) >> 16) & 0x00ff) >> 3);

            stPixelConvertParam.nDstBufferSize = (uint)(nWidth * nHeight * ((((uint)MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed) >> 16) & 0x00ff) >> 3);
            stPixelConvertParam.pDstBuffer = pOutData;//转换后的数据
            stPixelConvertParam.enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8;
            stPixelConvertParam.nDstBufferSize = (uint)(nWidth * nHeight * 3);

            nRet = device.MV_CC_ConvertPixelType_NET(ref stPixelConvertParam);//格式转换
            if (MyCamera.MV_OK != nRet)
            {
                return -1;
            }

            return nRet;
        }

        private Int32 ConvertToRGB(object obj, IntPtr pSrc, ushort nHeight, ushort nWidth, MyCamera.MvGvspPixelType nPixelType, IntPtr pDst)
        {
            if (IntPtr.Zero == pSrc || IntPtr.Zero == pDst)
            {
                return MyCamera.MV_E_PARAMETER;
            }

            int nRet = MyCamera.MV_OK;
            MyCamera device = obj as MyCamera;
            MyCamera.MV_PIXEL_CONVERT_PARAM stPixelConvertParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();

            stPixelConvertParam.pSrcData = pSrc;//源数据
            if (IntPtr.Zero == stPixelConvertParam.pSrcData)
            {
                return -1;
            }

            stPixelConvertParam.nWidth = nWidth;//图像宽度
            stPixelConvertParam.nHeight = nHeight;//图像高度
            stPixelConvertParam.enSrcPixelType = nPixelType;//源数据的格式
            stPixelConvertParam.nSrcDataLen = (uint)(nWidth * nHeight * ((((uint)nPixelType) >> 16) & 0x00ff) >> 3);

            stPixelConvertParam.nDstBufferSize = (uint)(nWidth * nHeight * ((((uint)MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed) >> 16) & 0x00ff) >> 3);
            stPixelConvertParam.pDstBuffer = pDst;//转换后的数据
            stPixelConvertParam.enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed;
            stPixelConvertParam.nDstBufferSize = (uint)nWidth * nHeight * 3;

            nRet = device.MV_CC_ConvertPixelType_NET(ref stPixelConvertParam);//格式转换
            if (MyCamera.MV_OK != nRet)
            {
                return -1;
            }

            return MyCamera.MV_OK;
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
