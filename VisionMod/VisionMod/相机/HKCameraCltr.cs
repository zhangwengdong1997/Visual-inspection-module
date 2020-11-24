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


namespace 标准视觉软件
{
    class HkCameraCltr
    {
        static MyCamera.MV_CC_DEVICE_INFO_LIST m_pDeviceList;
        //private MyCamera m_pMyCamera;
        bool m_bGrabbing;
        // HWindow m_Window;
        byte[] m_pDataForRed = new byte[20 * 1024 * 1024];
        byte[] m_pDataForGreen = new byte[20 * 1024 * 1024];
        byte[] m_pDataForBlue = new byte[20 * 1024 * 1024];
        uint g_nPayloadSize = 0;
        public Dictionary<string, MyCamera> m_dicMyCamera = new Dictionary<string, MyCamera>();
        public Dictionary<string, string> m_dicFullMessage = new Dictionary<string, string>();
        public static List<string> m_listUserDefinedName = new List<string>();

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
                MessageBox.Show("Enum Devices Fail");
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
                        // cbDeviceList.Items.Add("GigE: " + gigeInfo.chUserDefinedName + " (" + gigeInfo.chSerialNumber + ")");
                    }
                    else
                    {
                        MessageBox.Show("没有给相机命名！" + "GigE: " + gigeInfo.chManufacturerName + " " + gigeInfo.chModelName + " (" + gigeInfo.chSerialNumber + ")");
                        // cbDeviceList.Items.Add("GigE: " + gigeInfo.chManufacturerName + " " + gigeInfo.chModelName + " (" + gigeInfo.chSerialNumber + ")");
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
                        // cbDeviceList.Items.Add("USB: " + usbInfo.chUserDefinedName + " (" + usbInfo.chSerialNumber + ")");
                    }
                    else
                    {
                        MessageBox.Show("没有给相机命名！" + "USB: " + usbInfo.chManufacturerName + " " + usbInfo.chModelName + " (" + usbInfo.chSerialNumber + ")");
                        // cbDeviceList.Items.Add("USB: " + usbInfo.chManufacturerName + " " + usbInfo.chModelName + " (" + usbInfo.chSerialNumber + ")");
                    }
                }
            }
        }

        private void DeviceOpenAll()
        {
            if (m_pDeviceList.nDeviceNum == 0)
            {
                //MessageBox.Show("No device,please select");
                return;
            }
            int nIndex = -1;
            foreach (MyCamera pMyCamera in m_dicMyCamera.Values)
            {
                nIndex++;

                int nRet = -1;

                //ch:获取选择的设备信息 | en:Get selected device information
                MyCamera.MV_CC_DEVICE_INFO device =
                //                     (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_pDeviceList.pDeviceInfo[cbDeviceList.SelectedIndex],
                //                                                                   typeof(MyCamera.MV_CC_DEVICE_INFO));
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
                    MessageBox.Show("Open Device Fail");
                    return;
                }

                // ch:获取包大小 || en: Get Payload Size
                MyCamera.MVCC_INTVALUE stParam = new MyCamera.MVCC_INTVALUE();
                nRet = pMyCamera.MV_CC_GetIntValue_NET("PayloadSize", ref stParam);
                if (MyCamera.MV_OK != nRet)
                {
                    MessageBox.Show("Get PayloadSize Fail");
                    return;
                }
                g_nPayloadSize = stParam.nCurValue;

                // ch:获取高 || en: Get Height
                nRet = pMyCamera.MV_CC_GetIntValue_NET("Height", ref stParam);
                if (MyCamera.MV_OK != nRet)
                {
                    MessageBox.Show("Get Height Fail");
                    return;
                }
                uint nHeight = stParam.nCurValue;

                // ch:获取宽 || en: Get Width
                nRet = pMyCamera.MV_CC_GetIntValue_NET("Width", ref stParam);
                if (MyCamera.MV_OK != nRet)
                {
                    MessageBox.Show("Get Width Fail");
                    return;
                }
                uint nWidth = stParam.nCurValue;

                m_pDataForRed = new byte[nWidth * nHeight];
                m_pDataForGreen = new byte[nWidth * nHeight];
                m_pDataForBlue = new byte[nWidth * nHeight];


                // ch:设置触发模式为off || en:set trigger mode as off
                //   pMyCamera.MV_CC_SetEnumValue_NET("AcquisitionMode",1);
                //      pMyCamera.MV_CC_SetEnumValue_NET("TriggerMode", 1);


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
                    MessageBox.Show("Start Grabbing Fail:" + pMyCamera.Key);
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
                    MessageBox.Show("Trigger Fail:" + pMyCamera.Key);
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
                return 2;
                //MessageBox.Show("Trigger Fail");
            }

            return 0;
        }

        public int SetCameraParam(string sUserDefineName, float fValue = -1, string sParamName = "ExposureTime")
        {
            if (m_dicMyCamera.ContainsKey(sUserDefineName) == false)
            {
                return -1;
            }
            if (fValue < 0)//小于0则用默认曝光
            {
                return 0;
            }
            MyCamera device = m_dicMyCamera[sUserDefineName];

            int nRet = device.MV_CC_SetFloatValue_NET(sParamName, fValue);

            if (nRet != MyCamera.MV_OK)
            {
                MessageBox.Show("Set Parameter Fail!" + "return= " + nRet.ToString() + " " + sParamName);
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
            MyCamera.MV_FRAME_OUT_INFO_EX pFrameInfo = new MyCamera.MV_FRAME_OUT_INFO_EX();
            IntPtr pData = Marshal.AllocHGlobal((int)g_nPayloadSize * 3);
            if (pData == IntPtr.Zero)
            {
                return 2;
            }
            IntPtr pImageBuffer = Marshal.AllocHGlobal((int)g_nPayloadSize * 3);
            if (pImageBuffer == IntPtr.Zero)
            {
                return 3;
            }

            uint nDataSize = g_nPayloadSize * 3;
            HObject Hobj = new HObject();
            IntPtr RedPtr = IntPtr.Zero;
            IntPtr GreenPtr = IntPtr.Zero;
            IntPtr BluePtr = IntPtr.Zero;
            IntPtr pTemp = IntPtr.Zero;

            if (m_bGrabbing)
            {
                nRet = device.MV_CC_GetOneFrameTimeout_NET(pData, nDataSize, ref pFrameInfo, 100);
                if (MyCamera.MV_OK == nRet)
                {
                    if (IsColorPixelFormat(pFrameInfo.enPixelType))
                    {
                        if (pFrameInfo.enPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed)
                        {
                            pTemp = pData;
                        }
                        else
                        {
                            nRet = ConvertToRGB(device, pData, pFrameInfo.nHeight, pFrameInfo.nWidth, pFrameInfo.enPixelType, pImageBuffer);
                            if (MyCamera.MV_OK != nRet)
                            {
                                return 4;
                            }
                            pTemp = pImageBuffer;
                        }

                        unsafe
                        {
                            byte* pBufForSaveImage = (byte*)pTemp;

                            UInt32 nSupWidth = (pFrameInfo.nWidth + (UInt32)3) & 0xfffffffc;

                            for (int nRow = 0; nRow < pFrameInfo.nHeight; nRow++)
                            {
                                for (int col = 0; col < pFrameInfo.nWidth; col++)
                                {
                                    m_pDataForRed[nRow * nSupWidth + col] = pBufForSaveImage[nRow * pFrameInfo.nWidth * 3 + (3 * col)];
                                    m_pDataForGreen[nRow * nSupWidth + col] = pBufForSaveImage[nRow * pFrameInfo.nWidth * 3 + (3 * col + 1)];
                                    m_pDataForBlue[nRow * nSupWidth + col] = pBufForSaveImage[nRow * pFrameInfo.nWidth * 3 + (3 * col + 2)];
                                }
                            }
                        }

                        RedPtr = Marshal.UnsafeAddrOfPinnedArrayElement(m_pDataForRed, 0);
                        GreenPtr = Marshal.UnsafeAddrOfPinnedArrayElement(m_pDataForGreen, 0);
                        BluePtr = Marshal.UnsafeAddrOfPinnedArrayElement(m_pDataForBlue, 0);

                        try
                        {
                            HOperatorSet.GenImage3Extern(out Hobj, (HTuple)"byte", pFrameInfo.nWidth, pFrameInfo.nHeight,
                                                (new HTuple(RedPtr)), (new HTuple(GreenPtr)), (new HTuple(BluePtr)), IntPtr.Zero);
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    else if (IsMonoPixelFormat(pFrameInfo.enPixelType))
                    {
                        if (pFrameInfo.enPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8)
                        {
                            pTemp = pData;
                        }
                        else
                        {
                            nRet = ConvertToMono8(device, pData, pImageBuffer, pFrameInfo.nHeight, pFrameInfo.nWidth, pFrameInfo.enPixelType);
                            if (MyCamera.MV_OK != nRet)
                            {
                                return 5;
                            }
                            pTemp = pImageBuffer;
                        }
                        try
                        {
                            HOperatorSet.GenImage1Extern(out Hobj, "byte", pFrameInfo.nWidth, pFrameInfo.nHeight, pTemp, IntPtr.Zero);
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                            return 6;
                        }
                    }
                    else
                    {
                        return 7;
                    }
                    outImage = Hobj.Clone();
                }
                else
                {
                    return 8;
                }
            }
            if (pData != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(pData);
            }
            if (pImageBuffer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(pImageBuffer);
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
