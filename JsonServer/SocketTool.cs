using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace JsonServer
{
    struct struClient
    {
        Socket clent;
        bool isRun;
    }
    public class SocketTool
    {
        private Socket sSocket = null;
        private Socket cSocket = null;
        private TcpClient client = null;
        private TcpListener listener = null;
        private bool isRun = false;
        private int maxClientNum = 1;
        private byte[] sendbuff = new byte[1024];
        public SocketTool(string serverIP, int serverPort)
        {
            ip = serverIP;
            port = serverPort;

        }
        public SocketTool(string serverIP, int serverPort, int maxclientNum)
        {
            ip = serverIP;
            port = serverPort;
            maxClientNum = maxclientNum;
        }
        public SocketTool()
        {
        }
        public void SetIPnPort(string serverIP, int serverPort)
        {
            ip = serverIP;
            port = serverPort;
        }
        public bool Run()
        {
            try
            {

                IPAddress serverIP = IPAddress.Parse(ip);
                sSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sSocket.Bind(new IPEndPoint(serverIP, port));  //绑定IP地址：端口  
                sSocket.Listen(maxClientNum);    //设定最多10个排队连接请求  
                isRun = true;
                Thread myThread = new Thread(ListenClientConnect);
                myThread.IsBackground = true;
                myThread.Start();
                return true;
            }
            catch (System.Exception ex)
            {
                isRun = false;
                return false;
            }

        }

        public void Send(byte[] buff)
        {
            if (isRun && cSocket != null)
            {
                try
                {
                    cSocket.Send(buff);
                }
                catch (System.Exception ex)
                {
                    cSocket = null;
                }

            }
        }
        public void Close()
        {
            isRun = false;
            if (null != sSocket)
            {
                try
                {
                    this.sSocket.Shutdown(SocketShutdown.Both);
                    //this.sSocket.Dispose();
                    this.sSocket.Close();
                    this.sSocket = null;
                }
                catch
                {
                }
            }
            
            if (null != cSocket)
            {
                try
                {
                    this.cSocket.Shutdown(SocketShutdown.Both);
                    //this.cSocket.Dispose();
                    this.cSocket.Close();
                    this.cSocket = null;
                }
                catch
                {
                }
            }

        }
        public int GetStatus()
        {
            if (isRun && null != sSocket)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
        private void ListenClientConnect()
        {
            while (isRun)
            {
                try
                {
                    cSocket = sSocket.Accept();
                    cSocket.ReceiveTimeout = 1000;
                    Thread receiveThd = new Thread(ReceiveMasssage);
                    receiveThd.IsBackground = true;
                    receiveThd.Start(null);

                }
                catch (System.Exception ex)
                {

                }
                if (!isRun)
                {
                    break;
                }
            }
        }
        void AcceptCallBack(IAsyncResult ar)
        {
            Socket socket = ar.AsyncState as Socket;
             //结束异步Accept并获已连接的Socket
            cSocket = socket.EndAccept(ar);

            cSocket.ReceiveTimeout = 1000;
            Thread receiveThd = new Thread(ReceiveMasssage);
            receiveThd.Start(null);

            //继续异步Accept，保持Accept一直开启！
            socket.BeginAccept(AcceptCallBack, socket);
        }
        private void ReceiveMasssage(object clientSocket)
        {
           //Socket myClientSocket = (Socket)clientSocket;
            while (isRun)
            {
                 try
                 {
                    byte[] buff = new byte[1024];
                    
                    int count = cSocket.Receive(buff);
                    if (count > 5)
                    {
                        if (buff[0] == 0xff && buff[1] == 0xff && buff[2] == 0x01 &&
                        buff[count - 1] == 0xEE && buff[count - 2] == 0xEE)
                        {
                            string info = Encoding.UTF8.GetString(buff, 3, count-5);
                            WorkOrder order = JsonHelper.DeserializeJsonToObject<WorkOrder>(info);
                            Global.orderList.Add(order);
                            Response res = new Response();
                            res.Result = true;
                            res.Cmd = 1;
                            res.ErrorCode = 0;
                            res.Remark = "发送成功！";
                            string resp = JsonHelper.SerializeObject(res);
                            byte[] data = Encoding.UTF8.GetBytes(resp);
                            sendbuff[0] = 0xff;
                            sendbuff[1] = 0xff;
                            sendbuff[2] = 0x10;
                            Buffer.BlockCopy(data, 0, sendbuff, 3, data.Length);
                            sendbuff[data.Length + 3] = 0xEE;
                            sendbuff[data.Length + 4] = 0xEE;
                            cSocket.Send(sendbuff,data.Length+5,SocketFlags.None);
                        }
                    }
                }
                catch (System.Exception ex)
                {

                }

            }
        }

        public string ip
        {
            get { return _ip; }
            set { _ip = value; }
        }
        private string _ip = "127.0.0.1";

        public int port
        {
            get { return _port; }
            set { _port = value; }
        }
        private int _port = 6789;
    }
}
