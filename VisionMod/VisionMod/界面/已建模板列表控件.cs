using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LS_VisionMod.界面
{
    public partial class 已建模板列表控件 : UserControl
    {
        public List<型号列表项> modelList = new List<型号列表项>();
        string chooseModel;
        public 已建模板列表控件()
        {
            InitializeComponent();
        }
        public void readModel()
        {
            modelList.Clear();
            pnlModelList.Controls.Clear();
            List<String> modelNamelist = FileOperation.GetAllDirectoryName(MyRun.appPath + "\\model");
            foreach (var modelName in modelNamelist)
            {
                Model model = MyRun.ReadModelJS(modelName);
                if (model == null)
                    continue;
                型号列表项 listitem = new 型号列表项(modelName);
                FileInfo fi = new FileInfo(MyRun.appPath + "\\model\\" + model.modelName + "\\model.js");
                listitem.SetTime(fi.LastWriteTime.ToString("G"));
                if (modelList.Count == 0)
                {
                    listitem.Location = new Point(3, 3);
                }
                else
                {
                    Point pt = modelList.Last().Location;
                    int BeforHeight = modelList.Last().Height;
                    listitem.Location = new Point(pt.X, pt.Y + BeforHeight + 3);
                }
                listitem.Size = new Size(this.Width, 71);
                //if (model.camNum == 1 && model.cams.Count == 1)
                //{
                //    listitem.AddTap(model.cams[0].CamName);
                //}
                //else
                //{
                //    string camNames = "";
                //    foreach (var item in model.cams)
                //    {
                //        camNames += item + " ";
                //    }
                //    listitem.AddTap(camNames);
                //}
                //listitem.AddTap("检测项数量 " + model.testItems.Count);

                modelList.Add(listitem);
                pnlModelList.Controls.Add(listitem);
            }
        }
    }
}
