using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace 标准视觉软件
{
    interface 检测参数设置
    {
        void Save(ref List<Parameter> parameterList);

        string GetName();

        List<Parameter> initParameterList();

        void SetHalconWindow(HWindow hWindow);

        void SetHalconImage(HObject ho_image);

        void Find(HObject inImage, List<Parameter> inParameters, out string outMessage);
    }
}
