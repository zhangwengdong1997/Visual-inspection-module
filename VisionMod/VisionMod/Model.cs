using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 标准视觉软件
{
    public class Model
    {
        /// <summary>
        /// 型号模板的名称
        /// </summary>
        public string ModelName { get; set; }
        /// <summary>
        /// 调用的相机
        /// </summary>
        public List<Cam> Cams { get; set; }
        /// <summary>
        /// 相机数量
        /// </summary>
        public int CamNum { get; set; }
        /// <summary>
        /// 当前操作的相机
        /// </summary>
        public string NowCam { get; set; }
        /// <summary>
        /// 预处理
        /// </summary>
        public List<ImagePreprocess> ImagePreprocesses { get; set; }
        /// <summary>
        /// 当前预处理
        /// </summary>
        public ImagePreprocess NowImagePreprocess { get; set; }
        /// <summary>
        /// 定位模板
        /// </summary>
        public List<Matching> Matchings { get; set; }
        /// <summary>
        /// 当前定位模板
        /// </summary>
        public Matching NowMatching { get; set; }
        /// <summary>
        /// 检测项
        /// </summary>
        public List<TestItem> TestItems { get; set; }
        /// <summary>
        /// 当前检测项
        /// </summary>
        public TestItem NowTestItem { get; set; }
        /// <summary>
        /// 检测步骤
        /// </summary>
        public List<StepName> Steps { get; set; }
        /// <summary>
        /// 当前步骤
        /// </summary>
        public int NowStep { get; set; }

        public Model()
        {
            Cams = new List<Cam>();
            ImagePreprocesses = new List<ImagePreprocess>();
            Matchings = new List<Matching>();
            TestItems = new List<TestItem>();
            Steps = new List<StepName>();
            NowStep = 0;
        }
    }
    public enum StepName
    {
        选择模板类型 = 0,
        相机配置 = 1,
        图像预处理 = 2,
        匹配定位 = 3,
        检测项添加 = 4
    }

    public class Cam
    {
        /// <summary>
        /// 相机用户自定义名称UserDefinedName
        /// </summary>
        public string CamName { get; set; }
        /// <summary>
        /// 曝光时间
        /// </summary>
        public float ExposureTime { get; set; }

        public Cam(string camName, float exposureTime)
        {
            CamName = camName;
            ExposureTime = exposureTime;
        }
    }

    public class ImagePreprocess
    {
        /// <summary>
        /// 预处理的名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 预处理的类型
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 参数列表
        /// </summary>
        public List<Parameter> parameters { get; set; }
    }

    public class Parameter
    {
        public string name { get; set; }
        /// <summary>
        /// 参数类型
        /// </summary>
        public ParameterType type { get; set; }
        /// <summary>
        /// 参数值
        /// </summary>
        public object value { get; set; }
        public Parameter(string name, ParameterType type)
        {
            this.name = name;
            this.type = type;
        }
    }

    public enum ParameterType
    {
        数字 = 0,
        文字 = 1,
        区域 = 2,
        图片 = 3,
        文件 = 4,
        是否 = 5,
        阈值 = 6
    }

    public class Matching
    {
        /// <summary>
        /// 定位模板的名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 定位模板的类型
        /// </summary>
        public string type { get; set; }
        public Matching(string name, string type)
        {
            this.name = name;
            this.type = type;
        }
    }


    public class TestItem
    {
        /// <summary>
        /// 检测项名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 对应相机
        /// </summary>
        public string CamName { get; set; }
        /// <summary>
        /// 对应定位模板
        /// </summary>
        public Matching Match { get; set; }
        /// <summary>
        /// 检测项的类型
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 检测项是否屏蔽
        /// </summary>
        public bool enable { get; set; }
        /// <summary>
        /// 参数列表
        /// </summary>
        public List<Parameter> parameters { get; set; }
    }
}
