using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LS_VisionMod.界面;

namespace LS_VisionMod.模板创建步骤
{
    public partial class 检测项编辑 : UserControl, I模板创建步骤
    {
        Model model;
        DataTable testItemsTable;
        编辑模板窗口 fatherForm;
        public 检测项编辑(ref Model model, Form fatherForm)
        {
            InitializeComponent();
            this.model = model;
            this.fatherForm = fatherForm as 编辑模板窗口;
            InitDataTable();
            this.Dock = DockStyle.Fill;
        }

        private void InitDataTable()
        {
            testItemsTable = new DataTable();
            testItemsTable.Columns.Add("检测项名称").ReadOnly = true;
            testItemsTable.Columns.Add("使用相机").ReadOnly = true;
            testItemsTable.Columns.Add("定位模板").ReadOnly = true;
            testItemsTable.Columns.Add("检测功能").ReadOnly = true;
            dgv检测项.DataSource = testItemsTable;
            ShowDataTable();
        }

        public void ShowDataTable()
        {
            testItemsTable.Rows.Clear();
            foreach (var testItem in model.testItems)
            {
                DataRow row = testItemsTable.NewRow();
                row["检测项名称"] = testItem.name;
                row["使用相机"] = testItem.CamName;
                row["定位模板"] = testItem.MatchName;
                row["检测功能"] = testItem.type;
                testItemsTable.Rows.Add(row);
            }
        } 
       
        private void 检测项编辑_Load(object sender, EventArgs e)
        {

        }

        public void Add()
        {
            
        }

        public void Revise()
        {
            
        }
        private void btn修改使用相机_Click(object sender, EventArgs e)
        {
            if (dgv检测项.CurrentRow != null)
            {
                model.nowTestItem = model.testItems[dgv检测项.CurrentRow.Index];
                fatherForm.SwitchWindow(StepName.相机配置);
            }
        }

        private void btn修改匹配定位模板_Click(object sender, EventArgs e)
        {
            if (dgv检测项.CurrentRow != null)
            {
                model.nowTestItem = model.testItems[dgv检测项.CurrentRow.Index];
                fatherForm.SwitchWindow(StepName.匹配定位);
            }
        }

        private void btn修改检测项功能_Click(object sender, EventArgs e)
        {
            if (dgv检测项.CurrentRow != null)
            {
                model.nowTestItem = model.testItems[dgv检测项.CurrentRow.Index];
                fatherForm.SwitchWindow(StepName.检测项添加);
            }
        }

        private void 检测项编辑_Enter(object sender, EventArgs e)
        {

            ShowDataTable();
        }
    }
}
