using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 标准视觉软件
{
    public partial class 型号列表项 : UserControl
    {
        List<Label> labels = new List<Label>();
        public 型号列表项(string modelName)
        {        
            InitializeComponent();
            labModelName.Text = modelName;
        }
        public void AddTap(string text)
        {
            Label lb = new Label();
            if (labels.Count == 0)
            {
                lb.Location = new Point(25, 14);
            }
            else
            {
                Point pt = labels.Last().Location;
                int BeforWidth = labels.Last().Width;
                lb.Location = new Point(pt.X + BeforWidth + 20, pt.Y);
            }

            lb.ForeColor = Color.Black;
            lb.BackColor = Color.White;
            lb.Text = text;
            lb.AutoSize = true;
            panel1.Controls.Add(lb);

            labels.Add(lb);
        }

        private void 型号列表项_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(230,230,230);
        }

        private void 型号列表项_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(250, 250, 250);
        }

        private void 型号列表项_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(250, 250, 250);
        }
        public void SetTime(string time)
        {
            labTime.Text = time;
        }
    }
}
