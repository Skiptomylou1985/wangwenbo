using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Office.Interop;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;


namespace TransferData
{
    partial class FormMain
    {
        //重写窗口处理消息，处理串口接收模块发出消息
        protected override void DefWndProc(ref Message m)
        {
            if(m.Msg == SystemUnit.WM_READBACK)
            {
                if (Global.runMode != RunMode.READ)
                    return;
                if ((int)ReturnResult.SUCCESS == (int)m.WParam)
                {
                    Global.breakNum = 0;
                    if ((int)DataType.SIZEANDPLAN == (int)m.LParam)
                        Global.readIndex++;
                    else if ((int)DataType.PIN == (int)m.LParam)
                    {
                        Global.runMode = RunMode.NORMAL;
                        Global.readIndex = 0;
                        toolbarReadIndex.Text = "0";
                        showInfo("数据读取完成", false,true);
                        setFormStatus(1);
                        writeProcDataToDGV();
                        return;
                    }
                }
                if (Global.readIndex == Global.dataCount)
                {
                    readPinData();
                    return;
                }
                timerRead.Enabled = true;
                return;
            }
            if(m.Msg == SystemUnit.WM_WRITEBACK)
            {
                if (Global.runMode != RunMode.WRITE)
                    return;
                if((int)ReturnResult.SUCCESS == (int)m.WParam)
                {
                    Global.breakNum = 0;
                    if ((int)DataType.SIZEANDPLAN == (int)m.LParam)
                        Global.writeIndex++;
                    else if ((int)DataType.PIN == (int)m.LParam)
                       {
                            Global.runMode = RunMode.NORMAL;
                            Global.writeIndex = 0;
                            toolbarSendIndex.Text = "0";
                            showInfo("数据发送完成", false,true);
                            setFormStatus(1);
                            return;
                        }
                }
                if (Global.writeIndex == Global.dataCount)
                {
                    writePinData();
                    return;
                }
                timerWrite.Enabled = true;
                return;
            }
            base.DefWndProc(ref m);
        }

        public void appInit()
        {
            getParamFromXML();
            setFormStatus(0);
            DataTable dt = SystemUnit.importData(Global.defaultPath);

            if (null == dt)
            {
                MessageBox.Show("初始化默认数据失败，请通过【导入表格】进行数据初始化！");
                return;
            }
            DataTable[] dts = DBHelp.devideTable(dt);
            DGV1.DataSource = dts[0];
            DGV2.DataSource = dts[1];
            setDGV(DGV1);
            setDGV(DGV2);
            toolImportFile.Text = "数据来源：默认表格";
            toolImportFile.ForeColor = toolbarReadIndex.ForeColor;
        }
        private void getParamFromXML()
        {
            if(!File.Exists(Global.xmlPath))
            {
                showInfo("配置文件不存在", false,false);
                return;
            }
            try
            {
                Global.comPort = XMLUnit.XmlGetValue(Global.xmlPath, "transferdata", "normal", "comport");
                Global.comBPS = int.Parse(XMLUnit.XmlGetValue(Global.xmlPath, "transferdata", "normal", "combps"));
                Global.parity = (Parity)Enum.Parse(typeof(Parity), XMLUnit.XmlGetValue(Global.xmlPath, "transferdata", "normal", "comparity"));
                Global.comTimeout = int.Parse(XMLUnit.XmlGetValue(Global.xmlPath, "transferdata", "normal", "comtimeout"));
                Global.stationAddr = byte.Parse(XMLUnit.XmlGetValue(Global.xmlPath, "transferdata", "normal", "stationaddr"));
                Global.writeCmd = byte.Parse(XMLUnit.XmlGetValue(Global.xmlPath, "transferdata", "normal", "writecmd"));
                Global.readCmd = byte.Parse(XMLUnit.XmlGetValue(Global.xmlPath, "transferdata", "normal", "readcmd"));
                Global.offset = int.Parse(XMLUnit.XmlGetValue(Global.xmlPath, "transferdata", "normal", "offset"));
                Global.pinOffset = int.Parse(XMLUnit.XmlGetValue(Global.xmlPath, "transferdata", "normal", "pinoffset"));
                Global.defaultPath = Application.StartupPath + "\\" + XMLUnit.XmlGetValue(Global.xmlPath, "transferdata", "normal", "defaultfile");
                Global.regCount = int.Parse(XMLUnit.XmlGetValue(Global.xmlPath, "transferdata", "normal", "regcount"));
                Global.bLogOpen = Convert.ToBoolean(int.Parse(XMLUnit.XmlGetValue(Global.xmlPath, "transferdata", "normal", "logopen")));
                Global.timeOut = int.Parse(XMLUnit.XmlGetValue(Global.xmlPath, "transferdata", "normal", "timeout"));
                Global.dataCount = int.Parse(XMLUnit.XmlGetValue(Global.xmlPath, "transferdata", "data", "datacount"));
                Global.sizeDistance = int.Parse(XMLUnit.XmlGetValue(Global.xmlPath, "transferdata", "data", "sizedistance"));
               
                showInfo("初始化配置文件成功", false,true);
            }
            catch (Exception ex)
            {
                showInfo("读取配置文件失败", false,false);
                return;
            }
            
            Global.procData = new DataFormat[Global.dataCount];
            comboPort.Text = Global.comPort;
            comboBPS.Text = Global.comBPS.ToString();
        }
        private bool exportData(string path)
        {
            try
            {
                DataTable[] dts = new DataTable[2];
                dts[0] = (DataTable)DGV1.DataSource;
                dts[1] = (DataTable)DGV2.DataSource;
                DataTable dt = DBHelp.mergeTable(dts);

                return (SystemUnit.ExportDataToExcel(dt, path));
            }
            catch (Exception ex)
            {
                Log.WriteLog("MainForm", "ERROR", "【exportData】 " + ex.Message);
                return false;

            }

        }
        private void showInfo(string msg, bool msgBox,bool success)
        {
            toolbarInfo.Text = msg;
            if (success)
                toolbarInfo.ForeColor = Color.Green;
            else
                toolbarInfo.ForeColor = Color.Red;
            if (msgBox)
                MessageBox.Show(msg, "提示");
            
        }

        private void writeSingleData2(int Index)
        {
            byte[] sendbuf = new byte[16];
            sendbuf[0] = Global.stationAddr;
            sendbuf[1] = Global.writeCmd;
            sendbuf[2] = (byte)((Global.offset + Global.sizeDistance * Index) / 256);
            sendbuf[3] = (byte)((Global.offset + Global.sizeDistance * Index) % 256);
            sendbuf[4] = 0x00;
            sendbuf[5] = 0x04;

            //双字，字间是低位在前高位在后，字内是高位在前低位在后 3412顺序
            sendbuf[6] = (byte)((Global.procData[Index].size << 16) >> 24);
            sendbuf[7] = (byte)((Global.procData[Index].size << 24) >> 24);
            sendbuf[8] = (byte)(Global.procData[Index].size >> 24);
            sendbuf[9] = (byte)((Global.procData[Index].size << 8) >> 24);
            sendbuf[10] = (byte)((Global.procData[Index].planCount << 16) >> 24);
            sendbuf[11] = (byte)((Global.procData[Index].planCount << 24) >> 24);
            sendbuf[12] = (byte)(Global.procData[Index].planCount >> 24);
            sendbuf[13] = (byte)((Global.procData[Index].planCount << 8) >> 24);

            uint crc = SystemUnit.getCRC(sendbuf, 0, 14);
            sendbuf[14] = (byte)(crc / 256);
            sendbuf[15] = (byte)(crc % 256);
            comm.SendControlCmd(sendbuf, sendbuf.Length);
        }
        private void writeSingleData(int Index)
        {
            byte[] sendbuf = new byte[17];
            sendbuf[0] = Global.stationAddr;
            sendbuf[1] = Global.writeCmd;
            sendbuf[2] = (byte)((Global.offset + Global.sizeDistance * Index) / 256);
            sendbuf[3] = (byte)((Global.offset + Global.sizeDistance * Index) % 256);
            sendbuf[4] = 0x00;
            sendbuf[5] = 0x04;
            sendbuf[6] = 0x08;

            //双字，字间是低位在前高位在后，字内是高位在前低位在后 3412顺序
            sendbuf[7] = (byte)((Global.procData[Index].size << 16) >> 24);
            sendbuf[8] = (byte)((Global.procData[Index].size << 24) >> 24);
            sendbuf[9] = (byte)(Global.procData[Index].size >> 24);
            sendbuf[10] = (byte)((Global.procData[Index].size << 8) >> 24);
            sendbuf[11] = (byte)((Global.procData[Index].planCount << 16) >> 24);
            sendbuf[12] = (byte)((Global.procData[Index].planCount << 24) >> 24);
            sendbuf[13] = (byte)(Global.procData[Index].planCount >> 24);
            sendbuf[14] = (byte)((Global.procData[Index].planCount << 8) >> 24);
           
            uint crc = SystemUnit.getCRC(sendbuf, 0, 15);
            sendbuf[15] = (byte)(crc / 256);
            sendbuf[16] = (byte)(crc % 256);
            comm.SendControlCmd(sendbuf, sendbuf.Length);
        }

        private void readSingleData(int Index)
        {
            byte[] sendbuf = new byte[8];
            sendbuf[0] = Global.stationAddr;
            sendbuf[1] = Global.readCmd;
            sendbuf[2] = (byte)((Global.offset + Global.sizeDistance * Index) / 256);
            sendbuf[3] = (byte)((Global.offset + Global.sizeDistance * Index) % 256);
            sendbuf[4] = 0x00;
            sendbuf[5] = 4;
            uint crc = SystemUnit.getCRC(sendbuf, 0, 6);
            sendbuf[6] = (byte)(crc / 256);
            sendbuf[7] = (byte)(crc % 256);
            comm.SendControlCmd(sendbuf, 8);
        }

        private void writePinData()
        {
            byte[] sendbuf = new byte[9 + Global.dataCount * 2];
            sendbuf[0] = Global.stationAddr;
            sendbuf[1] = Global.writeCmd;
            sendbuf[2] = (byte)(Global.pinOffset / 256);
            sendbuf[3] = (byte)(Global.pinOffset % 256);
            sendbuf[4] = (byte)(Global.dataCount / 256);
            sendbuf[5] = (byte)(Global.dataCount % 256);
            sendbuf[6] = (byte)(Global.dataCount * 2);
            for (int i = 0; i < Global.dataCount; i++)
            {
                sendbuf[7 + i * 2] = (byte)(Global.procData[i].pin / 256);
                sendbuf[7 + i * 2 + 1] = (byte)(Global.procData[i].pin % 256);
            }
            uint crc = SystemUnit.getCRC(sendbuf, 0, 7 + Global.dataCount * 2);
            sendbuf[7 + Global.dataCount * 2] = (byte)(crc / 256);
            sendbuf[8 + Global.dataCount * 2] = (byte)(crc % 256);
            comm.SendControlCmd(sendbuf, 9 + Global.dataCount * 2);
        }

        private void readPinData()
        {
            byte[] sendbuf = new byte[8];
            sendbuf[0] = Global.stationAddr;
            sendbuf[1] = Global.readCmd;
            sendbuf[2] = (byte)((Global.pinOffset) / 256);
            sendbuf[3] = (byte)((Global.pinOffset) % 256);
            sendbuf[4] = 0x00;
            sendbuf[5] = (byte)Global.dataCount;
            uint crc = SystemUnit.getCRC(sendbuf, 0, 6);
            sendbuf[6] = (byte)(crc / 256);
            sendbuf[7] = (byte)(crc % 256);
            comm.SendControlCmd(sendbuf, 8);
        }

        

        private void readProcDataFromDGV()
        {
            for (int i = 0; i < DGV1.RowCount; i++)
            {
                Global.procData[i].size = int.Parse(DGV1[1, i].Value.ToString())*10;
                Global.procData[i].planCount = int.Parse(DGV1[2, i].Value.ToString())*Global.multiple;
                Global.procData[i].pin = short.Parse(DGV1[3, i].Value.ToString());
            }
            for (int i = 0; i < DGV2.RowCount; i++)
            {
                Global.procData[i + DGV1.RowCount].size = int.Parse(DGV2[1, i].Value.ToString())*10;
                Global.procData[i + DGV1.RowCount].planCount = int.Parse(DGV2[2, i].Value.ToString()) * Global.multiple;
                Global.procData[i + DGV1.RowCount].pin = short.Parse(DGV2[3, i].Value.ToString());
            }

        }
        private void writeProcDataToDGV()
        {
            for (int i = 0; i < (Global.dataCount / 2+Global.dataCount%2); i++)
            {
                DGV1[1, i].Value = Global.procData[i].size/10;
                DGV1[2, i].Value = Global.procData[i].planCount;
                DGV1[3, i].Value = Global.procData[i].pin;
            }
            for (int i = 0; i < (Global.dataCount + 1) / 2; i++)
            {
                DGV2[1, i].Value = Global.procData[i + Global.dataCount / 2].size/10;
                DGV2[2, i].Value = Global.procData[i + Global.dataCount / 2].planCount;
                DGV2[3, i].Value = Global.procData[i + Global.dataCount / 2].pin;
            }
        }


        public void setDGV(DataGridView dgv)
        {
            dgv.Columns[0].ReadOnly = true;
            dgv.Columns[0].HeaderText = "序号";
            dgv.Columns[1].HeaderText = "尺寸(mm)";
            dgv.Columns[2].HeaderText = "计划";
            dgv.Columns[3].HeaderText = "踢脚位置";
            dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            foreach (DataGridViewColumn item in dgv.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        /**
         * 设置窗体内各控件显示状态；
         * status : 0 初始状态；
         *          1 串口已打开；
         * */
        private void setFormStatus(int status)
        {
            switch (status)
            {
                case 0:

                    comboPort.Enabled = true;
                    comboBPS.Enabled = true;
                    btnOpenClosePort.Enabled = true;
                    btnOpenClosePort.Text = "打开串口";
                    btnRead.Enabled = false;
                    btnWrite.Enabled = false;
                    btnImport.Enabled = true;
                    btnExport.Enabled = true;
                    btnSave.Enabled = true;
                    break;
                case 1:
                    comboPort.Enabled = false;
                    comboBPS.Enabled = false;
                    btnOpenClosePort.Enabled = true;
                    btnOpenClosePort.Text = "关闭串口";
                    btnRead.Enabled = true;
                    btnWrite.Enabled = true;
                    btnImport.Enabled = true;
                    btnExport.Enabled = true;
                    btnSave.Enabled = true;
                    break;
                case 2:
                    comboPort.Enabled = false;
                    comboBPS.Enabled = false;
                    btnRead.Enabled = false;
                    btnWrite.Enabled = false;
                    btnImport.Enabled = false;
                    btnExport.Enabled = false;
                    btnOpenClosePort.Enabled = false;
                    btnSave.Enabled = false;
                    break;
                case 3:
                    comboPort.Enabled = true;
                    comboBPS.Enabled = true;
                    btnRead.Enabled = true;
                    btnWrite.Enabled = true;
                    btnImport.Enabled = true;
                    btnExport.Enabled = true;
                    btnOpenClosePort.Enabled = true;
                    btnSave.Enabled = true;
                    break;
                default:
                    break;
            }
        }
    }
}
