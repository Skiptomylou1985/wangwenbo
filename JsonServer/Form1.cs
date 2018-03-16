using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JsonServer
{
    public partial class Form1 : Form
    {
        private SocketTool socketTool;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            socketTool = new SocketTool("127.0.0.1", int.Parse(txtPort.Text.Trim()));
            socketTool.Run();
            timer1.Enabled = true;
            MessageBox.Show("服务开启成功！");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Global.orderList = new List<WorkOrder>();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Global.orderList.Count > 0)
            {
                string info = JsonHelper.SerializeObject(Global.orderList[0]);
                rtb.Clear();
                rtb.AppendText(info + "\n");
                Global.orderList.RemoveAt(0);
            }
        }
    }
}
