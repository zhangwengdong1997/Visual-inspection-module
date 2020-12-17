﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FFAlarm.Properties;

namespace FFAlarm.界面
{
    public partial class 设置界面 : UserControl
    {
        public 设置界面()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void 设置界面_Load(object sender, EventArgs e)
        {
            cmbPLC连接串口.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            cmbPLC连接串口.Text = Settings.Default.COM;
            cmb检测触发信号口.Text = Settings.Default.CheckIN;
            cmbOK输出信号口.Text = Settings.Default.OKOut;
            cmbNG输出信号口.Text = Settings.Default.NGOut;
            txtDuration.Text = Settings.Default.Duration.ToString();

            txtDelay.Text = Settings.Default.Delay.ToString();
            txtOKSave.Text = Settings.Default.OKSaveTime.ToString();
            txtNGSave.Text = Settings.Default.NGSaveTime.ToString();

        }

        private void btn保存设置_Click(object sender, EventArgs e)
        {
            if (!Settings.Default.COM.Equals(cmbPLC连接串口.Text))
                MessageBox.Show("修改PLC连接串口后，请重启软件");
            Settings.Default.COM = cmbPLC连接串口.Text;

            Settings.Default.CheckIN = cmb检测触发信号口.Text;
            Settings.Default.OKOut = cmbOK输出信号口.Text;
            Settings.Default.NGOut = cmbNG输出信号口.Text;


            try
            {
                if (int.Parse(txtOKSave.Text) <= 0 || 
                    int.Parse(txtNGSave.Text) <= 0 ||
                    int.Parse(txtDuration.Text) <= 0 ||
                    int.Parse(txtDelay.Text) <= 0) 

                {
                    throw new Exception();
                }
                Settings.Default.Duration = int.Parse(txtDuration.Text);
                Settings.Default.OKSaveTime = int.Parse(txtOKSave.Text);
                Settings.Default.NGSaveTime = int.Parse(txtNGSave.Text);
                Settings.Default.Delay = int.Parse(txtDelay.Text);
            }
            catch
            {
                MessageBox.Show("请输入大于0的整数");
            }


            
            Settings.Default.Save();
        }

    }
}
