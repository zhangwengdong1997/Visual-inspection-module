using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS_VisionMod
{
    class 形状模板定位 : MatchingFun
    {
        public 形状模板定位()
        {
            type = "形状模板定位";
        }
        ~形状模板定位()
        {
            Release();
        }
        public override void Create(HObject inImage, HObject inRegion)
        {
            Release();
            CreateModel(inImage, inRegion, out outContour, out outModelID);
            this.InRegion = inRegion;
            this.InImage = new HObject(inImage);
        }

        public override int Find(HObject inImage, out HObject outImage)
        {
            return FindModel(inImage, InRegion, outModelID, out outImage, completionTest, CompleteRegion);
        }

        void  CreateModel(HObject ho_inImage, HObject ho_inRegion, out HObject ho_outContour, out HTuple hv_outModelID)
        {
            HOperatorSet.GenEmptyObj(out ho_outContour);
            HOperatorSet.GenEmptyObj(out HObject ho_TemplateImage);

            HOperatorSet.SetSystem("border_shape_models", "false");
            ho_TemplateImage.Dispose();
            HOperatorSet.ReduceDomain(ho_inImage, ho_inRegion, out ho_TemplateImage);

            HOperatorSet.CreateShapeModel(ho_TemplateImage, 5, (new HTuple(-50)).TupleRad()
                , (new HTuple(100)).TupleRad(), (new HTuple(0.2733)).TupleRad(), "auto",
                "use_polarity", "auto", "auto", out hv_outModelID);
            HOperatorSet.GetShapeModelContours(out HObject ho_ModelContours, hv_outModelID, 1);
            HOperatorSet.AreaCenter(ho_inRegion, out _, out HTuple hv_RefRow, out HTuple hv_RefColumn);
            HOperatorSet.VectorAngleToRigid(0, 0, 0, hv_RefRow, hv_RefColumn, 0, out HTuple hv_HomMat2D);
            ho_outContour.Dispose();
            HOperatorSet.AffineTransContourXld(ho_ModelContours, out ho_outContour, hv_HomMat2D);
            ho_TemplateImage.Dispose();
        }

        public int FindModel(HObject ho_inImage, HObject ho_inRegion, HTuple hv_inModelID, out HObject ho_outRectifiedImage, bool completionTest, HObject ho_completeRegion)
        {
            int nRet = 1;

            HOperatorSet.AreaCenter(ho_inRegion, out _, out HTuple hv_RefRow, out HTuple hv_RefColumn);

            HOperatorSet.FindShapeModel(ho_inImage, hv_inModelID, (new HTuple(-50)).TupleRad()
                , (new HTuple(100)).TupleRad(), 0.5, 1, 0, "least_squares", (new HTuple(3)).TupleConcat(
                1), 0.75, out HTuple hv_Row, out HTuple hv_Column, out HTuple hv_Angle, out HTuple hv_Score);

            if(hv_Score.TupleLength() > 0)
            {
                HOperatorSet.HomMat2dIdentity(out HTuple hv_RectificationHomMat2D);
                HOperatorSet.HomMat2dTranslate(hv_RectificationHomMat2D, hv_RefRow - (hv_Row.TupleSelect(0)), hv_RefColumn - (hv_Column.TupleSelect(0)), out hv_RectificationHomMat2D);
                HOperatorSet.HomMat2dRotate(hv_RectificationHomMat2D, -(hv_Angle.TupleSelect(0)), hv_RefRow, hv_RefColumn, out hv_RectificationHomMat2D);

                if (completionTest)
                {
                    HOperatorSet.AffineTransRegion(ho_completeRegion, out HObject ho_AffineTransRegion, hv_RectificationHomMat2D, "constant");
                    HOperatorSet.SmallestRectangle1(ho_inImage, out HTuple hv_Row1, out HTuple hv_Column1, out HTuple hv_Row2, out HTuple hv_Column2);
                    HOperatorSet.GenRectangle1(out HObject ho_WindowRegion1, hv_Row1, hv_Column1, hv_Row2, hv_Column2);
                    HOperatorSet.GenRectangle1(out HObject ho_WindowRegion2, hv_Row1 + 1, hv_Column1 + 1, hv_Row2 - 1, hv_Column2 - 1);


                    HOperatorSet.Difference(ho_WindowRegion1, ho_WindowRegion2, out HObject ho_WindowRegion);
                    HOperatorSet.Union2(ho_WindowRegion, ho_AffineTransRegion, out HObject ho_BeyondRegion);
                    HOperatorSet.AreaCenter(ho_BeyondRegion, out HTuple hv_Area, out _, out _);
                    int BeyondCount = hv_Area.I;
                    HOperatorSet.WriteRegion(ho_completeRegion, MyRun.appPath + "\\ho_completeRegion.hobj");
                    HOperatorSet.WriteRegion(ho_AffineTransRegion, MyRun.appPath + "\\ho_AffineTransRegion.hobj");
                    HOperatorSet.WriteRegion(ho_BeyondRegion, MyRun.appPath + "\\ho_BeyondRegion.hobj");

                    ho_AffineTransRegion.Dispose();
                    ho_WindowRegion.Dispose();
                    ho_BeyondRegion.Dispose();
                    if (BeyondCount != 0)
                    {
                        HOperatorSet.CopyImage(ho_inImage, out ho_outRectifiedImage);
                        return nRet;
                    }
                }
                HOperatorSet.AffineTransImage(ho_inImage, out ho_outRectifiedImage, hv_RectificationHomMat2D, "constant", "false");
                nRet = 0;
            }
            else
            {
                HOperatorSet.CopyImage(ho_inImage, out ho_outRectifiedImage);
            }
            return nRet;
        }

        public override void Release()
        {
            if (outModelID != null)
            {
                HOperatorSet.ClearShapeModel(outModelID);
                outModelID = null;
            }
            if (outContour != null)
            {
                outContour.Dispose();
                outContour = null;
            }
        }

        public override void Write(string sFolderPath, string matchingName)
        {
            System.IO.Directory.CreateDirectory(sFolderPath);
            string sPath;
            sPath = sFolderPath + "\\" + matchingName + ".hobj";
            HOperatorSet.WriteRegion(InRegion, sPath);
            sPath = sFolderPath + "\\" + matchingName + ".jpg";
            HOperatorSet.WriteImage(InImage, "jpg", 0, sPath);
            sPath = sFolderPath + "\\" + matchingName + ".shm";
            HOperatorSet.WriteShapeModel(outModelID, sPath);
            if(completionTest)
            {
                sPath = sFolderPath + "\\" + matchingName + "-Complete.hobj";
                HOperatorSet.WriteRegion(CompleteRegion, sPath);
            }
        }

        public override void Read(string sFolderPath, Matching matching)
        {
            this.matching = matching;
            string sPath;
            sPath = sFolderPath + "\\" + matching.name + ".hobj";
            HOperatorSet.ReadRegion(out InRegion, sPath);
            sPath = sFolderPath + "\\" + matching.name + ".jpg";
            HOperatorSet.ReadImage(out InImage, sPath);

            sPath = sFolderPath + "\\" + matching.name + ".shm";
            HOperatorSet.ReadShapeModel(sPath, out outModelID);
            if (matching.completionTest)
            {
                completionTest = true;
                sPath = sFolderPath + "\\" + matching.name + "-Complete.hobj";
                HOperatorSet.ReadRegion(out CompleteRegion, sPath);
            }

        }

    }
}
