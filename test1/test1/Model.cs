using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    class Model
    {
        public string Name { get; set; }
        public List<StepName> Steps { get; set; }
    }

    public enum StepName
    {
        选择模板类型 = 0,
        相机配置 = 1,
        图像预处理 = 2,
        匹配定位 = 3,
        检测项添加 = 4
    }
}
