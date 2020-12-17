using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LS_VisionMod
{
    interface I检测参数设置
    {
        void Save(ref List<Parameter> parameterList);

        string GetName();

        List<Parameter> initParameterList();

        void SetHalconWindow(HTuple hWindow);

        void SetHalconImage(HObject ho_image);

        void Find(HObject inImage, List<Parameter> inParameters, out string outMessage);

        void Create(TestItem testItem);
    }
}
