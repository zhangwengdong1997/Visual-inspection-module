using CCWin;
using CCWin.SkinControl;
using FFAlarm.界面;
using LS_CLASS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFAlarm
{
    public partial class FrmMain : CCSkinMain
    {
        检测运行界面 runWindow = new 检测运行界面();
        模板创建界面 modelWindow = new 模板创建界面();
        设置界面 settingWindow = new 设置界面();
        AutoControlSize autoSize;
        public FrmMain()
        {
            InitializeComponent();
            autoSize = new AutoControlSize();
            autoSize.InitializeControlsSize(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            MyRun.SendMsg += MyRun_SendMsg;        
            MyRun.ConnectState += MyRun_ConnectState;
            MyRun.Init();

            
            ButtonColorChange(btn检测);
            panelMain.Controls.Add(runWindow);
            runWindow.Focus();
        }

        private void MyRun_ConnectState(int nId, string state)
        {
            txtMessage.Text += "\r\n" + DateTime.Now.ToString("HH:mm:ss") + "\r\n  " + state;
            txtMessage.Select(txtMessage.TextLength, 0);
            txtMessage.ScrollToCaret();
        }

        private void MyRun_SendMsg(object sender, string e)
        {
            txtMessage.Text += "\r\n" + DateTime.Now.ToString("HH:mm:ss") + "\r\n  " + e;
            txtMessage.Select(txtMessage.TextLength, 0);
            txtMessage.ScrollToCaret();
        }

        private void ButtonColorChange(SkinButton skinButton)
        {
            foreach (SkinButton button in panelSwitchButton.Controls)
            {
                button.BaseColor = Color.Transparent;
            }
            skinButton.BaseColor = Color.FromArgb(80, 134, 253);
        }

        private void btn检测_Click(object sender, EventArgs e)
        {
            ButtonColorChange(btn检测);
            panelMain.Controls.Clear();
            panelMain.Controls.Add(runWindow);
            runWindow.Focus();
        }

        private void btn模板_Click(object sender, EventArgs e)
        {
            if(MyRun.nState == 1)
            {
                DialogResult dialogResult = MessageBox.Show("进入模板编辑模式，检测会终止", "是否停止检测进入模板编辑模式", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    runWindow.StopRun();
                }
                else
                {
                    return;
                }
            }
            
            ButtonColorChange(btn模板);
            panelMain.Controls.Clear();
            panelMain.Controls.Add(modelWindow);
            modelWindow.Focus();

        }

        private void btn设置_Click(object sender, EventArgs e)
        {
            ButtonColorChange(btn设置);
            panelMain.Controls.Clear();
            panelMain.Controls.Add(settingWindow);
            modelWindow.Focus();
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            autoSize.Resize(this);
        }
    }
}
