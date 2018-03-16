using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace JsonDemo
{
    public partial class Form1 : Form
    {
        private Socket socketSend;
        private bool isConnected = false;
        private byte[] buff = new byte[1024];
        const byte Cmd_Order = 0x01;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            WorkOrder order = new WorkOrder();
            order.ProductOrder = textOrder.Text.Trim();
            order.Type = textType.Text.Trim();
            order.Gross = int.Parse(textGross.Text.Trim());
            order.Length = int.Parse(textLength.Text.Trim());
            order.Width = int.Parse(textWidth.Text.Trim());
            order.Thickness = int.Parse(textThickness.Text.Trim());
            order.Undo = int.Parse(textUndo.Text.Trim()); 
            order.Done = int.Parse(textDone.Text.Trim()); 
            order.ScheduleDate = dtpSchedule.Value;
            order.CompleteDate = dtpComplete.Value;
            order.Remark = textRemark.Text.Trim();
            order.Worker = textWorker.Text.Trim();
            order.Worth = int.Parse(textWorth.Text.Trim());
            order.MachineCode = textCode.Text.Trim();
            string json = JsonHelper.SerializeObject(order);
            byte[] data = System.Text.Encoding.UTF8.GetBytes(json);
            byte[] sendbuff = new byte[1024];
            sendbuff[0] = 0xff;
            sendbuff[1] = 0xff;
            sendbuff[2] = Cmd_Order;
            Buffer.BlockCopy(data, 0, sendbuff, 3, data.Length);
            sendbuff[data.Length + 3] = 0xEE;
            sendbuff[data.Length + 4] = 0xEE;
            socketSend.Send(sendbuff,data.Length +5,SocketFlags.None);
        }
        private bool initSocket(string ip,int port)
        {
            try
            {
                //创建负责通信的Socket
                socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ipa = IPAddress.Parse(ip);
                IPEndPoint point = new IPEndPoint(ipa, port);
                //获得要连接的远程服务器应用程序的IP地址和端口号
                socketSend.Connect(point);

                //开启一个新的线程不停的接收服务端发来的消息
                Thread th = new Thread(Recive);
                th.IsBackground = true;
                isConnected = true;
                th.Start();
                return true;
            }
            catch
            {
                return false;
            }
        }
        void Recive()
        {
            while (isConnected)
            {
                int count = socketSend.Receive(buff);
                if (count > 5)
                {
                    if (buff[0] == 0xff && buff[1] == 0xff && buff[2] == 0x10 &&
                        buff[count-1] == 0xEE && buff[count-2] == 0xEE)
                    {
                        string info = Encoding.UTF8.GetString(buff,3,count-5);
                        Response res = JsonHelper.DeserializeJsonToObject<Response>(info);
                        if (res.Result)
                        {
                            MessageBox.Show("发送成功！");
                        }
                    }

                }
                   
                
            }
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            if (initSocket(txtIP.Text.Trim(), int.Parse(txtPort.Text.Trim())))
            {
                MessageBox.Show("连接成功！");
            }else{
                MessageBox.Show("连接失败！");
            }
            
        }
    }
}
