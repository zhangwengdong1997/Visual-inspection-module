using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionMod.模板创建步骤
{
    public partial class 选择模板类型 : UserControl, I模板创建步骤
    {
        Model model;
        public 选择模板类型(Model model)
        {
            InitializeComponent();
            this.model = model;
        }



        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
