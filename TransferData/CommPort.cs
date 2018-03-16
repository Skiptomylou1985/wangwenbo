//////////////////////////////////////////////////////////////////////////
//Commit:   串口操作类，包括串口设置和打开、串口关闭、发送数据、接收数据。
//          因现在对使用的协议不明确，故只接收数据不对数据进行解析。
//          添加测试串口打开状态, 发送字符串接口
//Author:   HYF
//Date：    2017-04-02
//Version:  1.2.1
//////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Runtime.InteropServices;

//using Sys;

namespace TransferData
{
    public class CommPort
    {
        private SerialPort comm = new SerialPort();
        private int curCount = 0;
        private byte[] curBuff = new byte[500];

        void comm_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {            
            int n = comm.BytesToRead;
            byte[] buff = new byte[n];
            comm.Read(buff, 0, n);
            if (Global.bLogOpen)
                Log.WriteLog("CommPort", "INFO", "【comm_DataReceived】 接收数据:" + SystemUnit.ToHexString(buff));
            
            Buffer.BlockCopy(buff, 0, curBuff, curCount, n);
            curCount = curCount + n;
            if (curCount < 5)
                return;
            if (SystemUnit.getCRC(curBuff, 0, curCount-2) == (curBuff[curCount - 2] << 8 | curBuff[curCount - 1]))
            {
                byte[] proBuff = new byte[curCount];
                Buffer.BlockCopy(curBuff, 0, proBuff, 0, curCount);
                curCount = 0;
                procData(proBuff);
            }
            if(curCount > 65)
            {
                curCount = 0;
            }
            
            
            
            
        }
       
        private void procData(byte[] buff)
        {
            //if (SystemUnit.getCRC(buff, 0, buff.Length - 2) != (buff[buff.Length - 2] << 8 | buff[buff.Length - 1]))
            //{
            //    Log.WriteLog("CommPort", "ERROR", "【procData】校验失败！接收数据:" + SystemUnit.ToHexString(buff));
            //    return;
            //}
               

            //读数据模式下回复
            if (buff[1] == 0x03 && Global.runMode == RunMode.READ)
            {

                if(buff[2] == 8)
                {
                    Global.procData[Global.readIndex].size = (buff[3] << 8 | buff[4]  | buff[5] << 24 | buff[6] << 16);
                    Global.procData[Global.readIndex].planCount = (buff[7] << 8  | buff[8]  | buff[9] << 24 | buff[10] << 16);
                    SystemUnit.PostMessage(SystemUnit.HWND_BROADCAST, SystemUnit.WM_READBACK, (int)ReturnResult.SUCCESS, (int)DataType.SIZEANDPLAN);
                }
                if(buff[2] == Global.dataCount*2)
                {
                    for(int i =0;i< Global.dataCount; i++)
                    {
                        Global.procData[i].pin = (short)(buff[3 + 2 * i] << 8 | buff[3 + 2 * i + 1]);
                    }
                    SystemUnit.PostMessage(SystemUnit.HWND_BROADCAST, SystemUnit.WM_READBACK, (int)ReturnResult.SUCCESS, (int)DataType.PIN);
                }

                
            }

            //写入数据时回复
            if (Global.runMode == RunMode.WRITE && buff[1] == 0x10 )
            {
                int offset = buff[2] << 8 | buff[3];
                if(Global.writeIndex == Global.dataCount && offset == Global.pinOffset)
                     SystemUnit.PostMessage(SystemUnit.HWND_BROADCAST, SystemUnit.WM_WRITEBACK, (int)ReturnResult.SUCCESS, (int)DataType.PIN);
                else if(offset == Global.offset + 6*Global.writeIndex)
                    SystemUnit.PostMessage(SystemUnit.HWND_BROADCAST, SystemUnit.WM_WRITEBACK, (int)ReturnResult.SUCCESS, (int)DataType.SIZEANDPLAN);
            }
            
            
        }
        //---------------------------------------------------------------
        //FUNCTION: open the serial port
        //IN:   
        //      portname, serial port name, e.g. "COM1"
        //      baudrate,  baudrate of the serial port
        //OUT:  true for success, false for failed
        //---------------------------------------------------------------
        public bool comOpen(string portname, int baudrate, bool rtsEnable)
        {
            comm.NewLine = "\r\n";
            comm.RtsEnable = rtsEnable;
            comm.DataReceived += comm_DataReceived;
            comm.PortName = portname;
            comm.BaudRate = baudrate;
            comm.Parity = Global.parity;
            comm.ReadTimeout = 100;
            try
            {
                comm.Open();
                if (comm.IsOpen)
                    return true;
            }
            catch (System.Exception ex)
            {
                Log.WriteLog("CommPort", "Error", "【comOpen】打开串口失败:" + ex.Message);
                comm = new SerialPort();
            }
            return false;
        }

        //---------------------------------------------------------------
        //FUNCTION: close the serial port
        //IN:   
        //OUT:  true for success, false for failed
        //---------------------------------------------------------------
        public bool comClose()
        {
            if (comm.IsOpen)
            {
                try
                {
                    comm.Close();
                    return true;
                }
                catch (System.Exception ex)
                {
                    Log.WriteLog("CommPort", "Error", "【comClose】关闭串口失败:" + ex.Message);
                    return false;
                }
            }
            else
                return true;
        }

        //---------------------------------------------------------------
        //FUNCTION: Check the serial port is open or not
        //IN:   
        //OUT:  true for open, false for close
        //---------------------------------------------------------------
        public bool comIsOpen()
        {
            return (comm.IsOpen);          
        }

        //---------------------------------------------------------------
        //FUNCTION: send command to the serial port
        //IN:   
        //      byte[] buf, the buffer for the command
        //      len,  the length of command 
        //OUT:  true for success, false for failed
        //---------------------------------------------------------------
        public bool SendControlCmd(byte[] buf, int len)
        {
            if (comm.IsOpen)
            {
                comm.Write(buf, 0, len);
                if(Global.bLogOpen)
                Log.WriteLog("CommPort", "INFO", "【SendControlCmd】 发送数据:" + SystemUnit.ToHexString(buf));
                return true;
            }
            else
                return false;
        }

        //---------------------------------------------------------------
        //FUNCTION: send string to the serial port
        //IN:   
        //      string str, the string to send
        //      len,  the length of command 
        //OUT:  true for success, false for failed
        //---------------------------------------------------------------
        public bool SendStr(string str)
        {
            if (comm.IsOpen)
            {
                comm.Write(str);
                return true;
            }
            else
                return false;
        }

    }
}
