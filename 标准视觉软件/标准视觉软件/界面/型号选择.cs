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

namespace 标准视觉软件
{
    public partial class 型号选择 : UserControl
    {
        Panel panelMain;
        List<型号列表项> modelList = new List<型号列表项>();
        public 型号选择(Panel panelMain)
        {
            InitializeComponent();
            this.panelMain = panelMain;
        }

        private void bnt新建模板_Click(object sender, EventArgs e)
        {
            新建模板 createModeFrom = new 新建模板();
            createModeFrom.ShowDialog();
            readModel();
        }

        private void 型号选择_Load(object sender, EventArgs e)
        {

            //初始化界面
            //列表中显示之前创建的所有型号
            //读取存储的json文件
            readModel();
        }

        public void readModel()
        {
            modelList.Clear();
            pnlModelList.Controls.Clear();
            List<String> modelNamelist = FileOperation.GetAllDirectoryName(Application.StartupPath + "\\model");
            foreach (var modelName in modelNamelist)
            {
                Model model = MyRun.ReadModelJS(modelName);
                if (model == null)
                    continue;
                型号列表项 listitem = new 型号列表项(modelName);
                FileInfo fi = new FileInfo(Application.StartupPath + "\\model\\" + model.modelName + "\\model.js");
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
                    if (model.camNum == 1 && model.cams.Count == 1)
                    {
                        listitem.AddTap(model.cams[0].CamName);
                    }
                    else
                    {
                    string camNames = "";
                    foreach (var item in model.cams)
                    {
                        camNames += item + " ";
                    }
                    listitem.AddTap(camNames);
                }
                listitem.AddTap("检测项数量 " + model.testItems.Count);
                modelList.Add(listitem);
                pnlModelList.Controls.Add(listitem);
            }
        }
    }
}
