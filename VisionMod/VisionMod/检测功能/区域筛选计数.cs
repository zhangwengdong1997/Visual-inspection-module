using HalconDotNet;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS_VisionMod
{
    class 区域筛选计数 : 检测功能
    {
        float row, column, phi, length1, length2;
        int minGray, maxGray;
        int minArea, maxArea;
        int num;
        string name;
        HObject ho_inRegion;
        string result;

        public 区域筛选计数(TestItem testItem)
        {
            this.camName = testItem.CamName;
            this.matchName = testItem.MatchName;
            this.name = testItem.name;
            Create(testItem.parameters);
        }
        public override void Create(List<Parameter> inParameters)
        {
            JArray region = inParameters[0].value as JArray;
            row = (float)region[0];
            column = (float)region[1];
            phi = (float)region[2];
            length1 = (float)region[3];
            length2 = (float)region[4];
            JArray Gray = inParameters[1].value as JArray;
            minGray = (int)Gray[0];
            maxGray = (int)Gray[1];
            JArray Area = inParameters[2].value as JArray;
            minArea = (int)Area[0];
            maxArea = (int)Area[1];
            num = int.Parse(inParameters[3].value.ToString());
        }

        public override int Find(HObject inImage)
        {
            try
            {
                HOperatorSet.GenRectangle2(out ho_inRegion, row, column, phi, length1, length2);
                HOperatorSet.ReduceDomain(inImage, ho_inRegion, out HObject ho_imageReduced);
                HOperatorSet.Threshold(ho_imageReduced, out HObject ho_ThresholdRegion, minGray, maxGray);
                HOperatorSet.Connection(ho_ThresholdRegion, out HObject ho_connectedRegions);
                HOperatorSet.SelectShape(ho_connectedRegions, out HObject ho_selectedRegion, "area", "and", minArea, maxArea);
                HOperatorSet.CountObj(ho_selectedRegion, out HTuple hv_number);
                if (hv_number.I == num)
                {
                    outMessage = name + "@OK@" + hv_number.I.ToString();
                    result = "OK";
                }
                else
                {
                    outMessage = name + "@NG@" + hv_number.I.ToString();
                    result = "NG";
                }
            }
            catch
            {
                return 1;
            }
            return 0;
        }

        public override void Show(HObject inImage, out HObject resultImage)
        {
            PaintOkNgRegion(inImage, ho_inRegion, out resultImage, result, 11);
        }
    }
}
