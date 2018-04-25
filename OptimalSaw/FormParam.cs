using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace OptimalSaw
{
    public partial class FormParam : Form
    {
        private string iniPath = Application.StartupPath + "\\config.ini";
        public FormParam()
        {
            InitializeComponent();
        }

        private void btnSetComm_Click(object sender, EventArgs e)
        {
            Global.commHelper.comClose();
            Global.comm.PortName = comboComm.Text;
            Global.comm.BaudRate = int.Parse(comboBPS.Text);
            Global.comm.Parity = (Parity)Enum.Parse(typeof(Parity),comboParity.SelectedIndex.ToString());
            if (Global.commHelper.comOpen(Global.comm))
            {
                IniHelper.SetINIValue(iniPath, "comm", "port", Global.comm.PortName);
                IniHelper.SetINIValue(iniPath, "comm", "bps", Global.comm.BaudRate.ToString());
                IniHelper.SetINIValue(iniPath, "comm", "parity", ((int)Global.comm.Parity).ToString());
                MessageBox.Show("串口参数设置成功");
            }
            else
            {
                MessageBox.Show("串口设置失败！");
            }
        }

        private void btnSetRunParam_Click(object sender, EventArgs e)
        {
            Global.nRestFlag = int.Parse(comboRestFlag.Text);
            Global.dataCount = int.Parse(comboDataCount.Text);
            Global.logOpen = comboLogOpen.SelectedIndex;
            IniHelper.SetINIValue(iniPath, "main", "restflag", Global.nRestFlag.ToString());
            IniHelper.SetINIValue(iniPath, "main", "datacount", Global.dataCount.ToString());
            IniHelper.SetINIValue(iniPath, "main", "logopen", Global.logOpen.ToString());

            try
            {
                Global.socketPort = int.Parse(textSocketPort.Text.Trim());
                Global.socketHelper.Close();
                Thread.Sleep(100);
                Global.socketHelper = new SocketHelper("127.0.0.1", Global.socketPort);
                if (Global.socketHelper.Run())
                {
                    IniHelper.SetINIValue(iniPath, "main", "socketport", Global.socketPort.ToString());
                    MessageBox.Show("参数设置成功，网络服务已重新启动！");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("网络服务端口有误，请填写大于1024整数！");
            }

                 
        }

        private void FormParam_Load(object sender, EventArgs e)
        {
            comboComm.Text = Global.comm.PortName;
            comboBPS.Text = Global.comm.BaudRate.ToString();
            comboParity.SelectedIndex = (int)Global.comm.Parity;

            comboRestFlag.Text = Global.nRestFlag.ToString();
            textSocketPort.Text = Global.socketPort.ToString();
            comboDataCount.Text = Global.dataCount.ToString();
            comboLogOpen.SelectedIndex = Global.logOpen;
        }
    }
}
