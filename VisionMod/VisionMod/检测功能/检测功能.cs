using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS_VisionMod
{
    public abstract class 检测功能
    {
        public string camName;
        public ImagePreprocess imagePreprocess;
        public Matching matching;
        public string outMessage;

        public abstract void Create(List<Parameter> inParameters);
        public abstract int Find(HObject inImage);

        public abstract void Show(HObject inImage, out HObject resultImage);

        public static void PaintOkNgRegion(HObject ho_image, HObject ho_region, out HObject ho_outImage,
            HTuple hv_okNg, HTuple hv_lineWidth)
        {
            //  HOperatorSet.SetDraw("margin");
            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];

            // Local iconic variables 

            HObject ho_Image, ho_DupImage1 = null, ho_DupImage2 = null, ho_DupImage3 = null;

            HObject ho_RegionErosion, ho_RegionDifference;

            // Local control variables 

            HTuple hv_Channels = null;
            // Initialize local and output iconic variables 
            //HOperatorSet.GenEmptyObj(out ho_outImage);
            HOperatorSet.GenEmptyObj(out ho_Image);
            HOperatorSet.GenEmptyObj(out ho_DupImage1);
            HOperatorSet.GenEmptyObj(out ho_DupImage2);
            HOperatorSet.GenEmptyObj(out ho_DupImage3);

            HOperatorSet.GenEmptyObj(out ho_RegionErosion);
            HOperatorSet.GenEmptyObj(out ho_RegionDifference);

            ho_Image.Dispose();
            HOperatorSet.CopyImage(ho_image, out ho_Image);
            HOperatorSet.CountChannels(ho_Image, out hv_Channels);
            int nChannel = hv_Channels;
            if ((int)(new HTuple(hv_Channels.TupleEqual(1))) != 0)
            {

                ho_DupImage1.Dispose();
                HOperatorSet.CopyImage(ho_Image, out ho_DupImage1);
                ho_DupImage2.Dispose();
                HOperatorSet.CopyImage(ho_Image, out ho_DupImage2);
                ho_DupImage3.Dispose();
                HOperatorSet.CopyImage(ho_Image, out ho_DupImage3);
            }
            else if ((int)(new HTuple(hv_Channels.TupleEqual(3))) != 0)
            {
                ho_DupImage1.Dispose(); ho_DupImage2.Dispose(); ho_DupImage3.Dispose();
                HOperatorSet.Decompose3(ho_Image, out ho_DupImage1, out ho_DupImage2, out ho_DupImage3
                    );
            }
            else
            {
                throw new Exception("M1 Exception");
            }

            ho_RegionErosion.Dispose();
            HOperatorSet.ErosionRectangle1(ho_region, out ho_RegionErosion, hv_lineWidth,
                hv_lineWidth);
            ho_RegionDifference.Dispose();
            HOperatorSet.Difference(ho_region, ho_RegionErosion, out ho_RegionDifference);
            if ((int)(new HTuple(hv_okNg.TupleEqual("OK"))) != 0)
            {
                {
                    HObject ExpTmpOutVar_1; HObject ExpTmpOutVar_2; HObject ExpTmpOutVar_3;
                    HOperatorSet.PaintRegion(ho_RegionDifference, ho_DupImage2, out ExpTmpOutVar_2,
                        255, "fill");
                    HOperatorSet.PaintRegion(ho_RegionDifference, ho_DupImage1, out ExpTmpOutVar_1,
                        0, "fill");
                    HOperatorSet.PaintRegion(ho_RegionDifference, ho_DupImage3, out ExpTmpOutVar_3,
                        0, "fill");
                    ho_DupImage2.Dispose();
                    ho_DupImage2 = ExpTmpOutVar_2;
                    ho_DupImage1.Dispose();
                    ho_DupImage1 = ExpTmpOutVar_1;
                    ho_DupImage3.Dispose();
                    ho_DupImage3 = ExpTmpOutVar_3;
                }
            }
            else
            {
                {
                    HObject ExpTmpOutVar_1; HObject ExpTmpOutVar_2; HObject ExpTmpOutVar_3;
                    HOperatorSet.PaintRegion(ho_RegionDifference, ho_DupImage1, out ExpTmpOutVar_1,
                        255, "fill");
                    HOperatorSet.PaintRegion(ho_RegionDifference, ho_DupImage2, out ExpTmpOutVar_2,
                        0, "fill");
                    HOperatorSet.PaintRegion(ho_RegionDifference, ho_DupImage3, out ExpTmpOutVar_3,
                        0, "fill");
                    ho_DupImage1.Dispose();
                    ho_DupImage1 = ExpTmpOutVar_1;
                    ho_DupImage2.Dispose();
                    ho_DupImage2 = ExpTmpOutVar_2;
                    ho_DupImage3.Dispose();
                    ho_DupImage3 = ExpTmpOutVar_3;
                }
            }
            ho_Image.Dispose();
            HOperatorSet.Compose3(ho_DupImage1, ho_DupImage2, ho_DupImage3, out ho_Image);
            ho_outImage = ho_Image.CopyObj(1, -1);
            ho_Image.Dispose();
            ho_DupImage1.Dispose();
            ho_DupImage2.Dispose();
            ho_DupImage3.Dispose();

            ho_RegionErosion.Dispose();
            ho_RegionDifference.Dispose();

            return;
        }
    }
}
