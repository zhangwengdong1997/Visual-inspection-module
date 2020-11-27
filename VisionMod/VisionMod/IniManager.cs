using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LS_VisionMod
{
    class IniManager
    {
        private static Mutex mutex = new Mutex();

        public static void WriteToIni(object inValue, string sPath)
        {
            mutex.WaitOne();
            FileStream fs = new FileStream(sPath, FileMode.Create);
            string s = JsonConvert.SerializeObject(inValue);
            string str = ConvertJsonString(s);
            //获得字节数组
            byte[] data = System.Text.Encoding.Default.GetBytes(str);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
            mutex.ReleaseMutex();
        }

        public static T ReadFromIni<T>(string sPath)
        {
            mutex.WaitOne();
            string jsonData = "";

            if (File.Exists(sPath) == false)
            {
                mutex.ReleaseMutex();
                return default;
            }
            foreach (string str in System.IO.File.ReadAllLines(sPath, Encoding.Default))
            {
                jsonData += str;
            }
            mutex.ReleaseMutex();
            return JsonConvert.DeserializeObject<T>(jsonData);
        }

        private static string ConvertJsonString(string str)
        {
            //格式化json字符串
            JsonSerializer serializer = new JsonSerializer();
            TextReader tr = new StringReader(str);
            JsonTextReader jtr = new JsonTextReader(tr);
            object obj = serializer.Deserialize(jtr);
            if (obj != null)
            {
                StringWriter textWriter = new StringWriter();
                JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                {
                    Formatting = Formatting.Indented,
                    Indentation = 4,
                    IndentChar = ' '
                };
                serializer.Serialize(jsonWriter, obj);
                return textWriter.ToString();
            }
            else
            {
                return str;
            }
        }
    }
}
