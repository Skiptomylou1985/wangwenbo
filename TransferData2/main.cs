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
            if(m.Msg == SystemUnit.WM_READSIZEBACK)
            {
                if (Global.runMode != RunMode.READSIZE)
                    return;
                if ((int)ReturnResult.SUCCESS == (int)m.WParam && (int)DataType.SIZE == (int)m.LParam)
                {
                    Global.breakNum = 0;
                    Global.runMode = RunMode.READPLAN;
                    timerRead.Enabled = true;
                }
                return;

            }
            if (m.Msg == SystemUnit.WM_READPLANBACK)
            {
                if (Global.runMode != RunMode.READPLAN)
                    return;
                if ((int)ReturnResult.SUCCESS == (int)m.WParam && (int)DataType.PLAN == (int)m.LParam)
                {
                    Global.breakNum = 0;
                    Global.runMode = RunMode.NORMAL;
                    showInfo("数据读取完成", false, true);
                    timerBreak.Enabled = false;
                    setFormStatus(1);
                    writeProcDataToDGV();
                }
                return;
            }
            if (m.Msg == SystemUnit.WM_WRITESIZEBACK)
            {
                if (Global.runMode != RunMode.WRITESIZE)
                    return;
                if((int)ReturnResult.SUCCESS == (int)m.WParam)
                {
                    Global.breakNum = 0;
                    Global.runMode = RunMode.WRITEPLAN;
//                     if ((int)DataType.SIZE == (int)m.LParam)
//                         Global.writeIndex++;
                }
//                 if (Global.writeIndex == Global.dataCount)
//                 {
//                     Global.runMode = RunMode.WRITEPLAN;
//                     Global.writeIndex = 0;
//                     writeSinglePlanData(Global.writeIndex);
//                     return;
//                 }
                timerWrite.Enabled = true;
                return;
            }
            if (m.Msg == SystemUnit.WM_WRITEPLANBACK)
            {
                if (Global.runMode != RunMode.WRITEPLAN)
                    return;
                if ((int)ReturnResult.SUCCESS == (int)m.WParam)
                {
                    Global.breakNum = 0;
                    Global.runMode = RunMode.NORMAL;
                    showInfo("数据发送完成", false, true);
                    timerBreak.Enabled = false;
                    setFormStatus(1);
                    return;
                    
//                     if ((int)DataType.PLAN == (int)m.LParam)
//                         Global.writeIndex++;
                }
//                 if (Global.writeIndex == Global.dataCount)
//                 {
//                     Global.runMode = RunMode.NORMAL;
//                     Global.writeIndex = 0;
//                     toolbarSendIndex.Text = "0";
//                     showInfo("数据发送完成", false, true);
//                     timerBreak.Enabled = false;
//                     setFormStatus(1);
//                     return;
//                 }
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
            lblImportFile.Text = "数据来源：默认表格";
            lblImportFile.ForeColor = toolbarReadIndex.ForeColor;
            comboUnit.SelectedIndex = Global.unit;
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
                Global.sizeOffset = int.Parse(XMLUnit.XmlGetValue(Global.xmlPath, "transferdata", "normal", "sizeoffset"));
                Global.planOffset = int.Parse(XMLUnit.XmlGetValue(Global.xmlPath, "transferdata", "normal", "planoffset"));
                Global.pinOffset = int.Parse(XMLUnit.XmlGetValue(Global.xmlPath, "transferdata", "normal", "pinoffset"));
                Global.defaultPath = Application.StartupPath + "\\" + XMLUnit.XmlGetValue(Global.xmlPath, "transferdata", "normal", "defaultfile");
                Global.regCount = int.Parse(XMLUnit.XmlGetValue(Global.xmlPath, "transferdata", "normal", "regcount"));
                Global.bLogOpen = Convert.ToBoolean(int.Parse(XMLUnit.XmlGetValue(Global.xmlPath, "transferdata", "normal", "logopen")));
                Global.timeOut = int.Parse(XMLUnit.XmlGetValue(Global.xmlPath, "transferdata", "normal", "timeout"));
                Global.dataCount = int.Parse(XMLUnit.XmlGetValue(Global.xmlPath, "transferdata", "data", "datacount"));
                Global.sizeDistance = int.Parse(XMLUnit.XmlGetValue(Global.xmlPath, "transferdata", "data", "sizedistance"));
                Global.unit = int.Parse(XMLUnit.XmlGetValue(Global.xmlPath, "transferdata", "data", "unit"));
                Global.accuracy = double.Parse(XMLUnit.XmlGetValue(Global.xmlPath, "transferdata", "data", "accuracy"));
                for (int i=0;i<Global.convFactor.Length;i++)
                {
                    Global.convFactor[i] = Global.convFactor[i] / Global.accuracy;
                }

                showInfo("初始化配置文件成功", false,true);
            }
            catch (Exception ex)
            {
                showInfo("读取配置文件失败", false,false);
                return;
            }
            
            Global.procData = new DataFormat[Global.dataCount];
            comboPort.Text = Global.comPort;
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

        private void writeSingleSizeData(int Index)
        {
            byte[] sendbuf = new byte[13];
            sendbuf[0] = Global.stationAddr;
            sendbuf[1] = Global.writeCmd;
            sendbuf[2] = (byte)((Global.sizeOffset + Global.sizeDistance * Index) / 256);
            sendbuf[3] = (byte)((Global.sizeOffset + Global.sizeDistance * Index) % 256);
            sendbuf[4] = 0x00;
            sendbuf[5] = 0x02;
            sendbuf[6] = 0x04;
            //双字，字间是低位在前高位在后，字内是高位在前低位在后 3412顺序
            sendbuf[7] = (byte)((Global.procData[Index].size << 16) >> 24);
            sendbuf[8] = (byte)((Global.procData[Index].size << 24) >> 24);
            sendbuf[9] = (byte)(Global.procData[Index].size >> 24);
            sendbuf[10] = (byte)((Global.procData[Index].size << 8) >> 24);

            uint crc = SystemUnit.getCRC(sendbuf, 0, 11);
            sendbuf[11] = (byte)(crc / 256);
            sendbuf[12] = (byte)(crc % 256);
            comm.SendControlCmd(sendbuf, sendbuf.Length);
        }

        private void WriteAllSizeData()
        {
            byte[] sendbuf = new byte[4*Global.dataCount+9];
            sendbuf[0] = Global.stationAddr;
            sendbuf[1] = Global.writeCmd;
            sendbuf[2] = (byte)((Global.sizeOffset ) / 256);
            sendbuf[3] = (byte)((Global.sizeOffset ) % 256);
            sendbuf[4] = 0x00;
            sendbuf[5] = (byte)(Global.dataCount*2);
            sendbuf[6] = (byte)(Global.dataCount*4);
            //双字，字间是低位在前高位在后，字内是高位在前低位在后 3412顺序
            for (int i=0;i<Global.dataCount;i++)
            {
                sendbuf[7+i*4] = (byte)((Global.procData[i].size << 16) >> 24);
                sendbuf[8 + i * 4] = (byte)((Global.procData[i].size << 24) >> 24);
                sendbuf[9 + i * 4] = (byte)(Global.procData[i].size >> 24);
                sendbuf[10 + i * 4] = (byte)((Global.procData[i].size << 8) >> 24);

            }
            uint crc = SystemUnit.getCRC(sendbuf, 0, 4 * Global.dataCount + 7);
            sendbuf[4 * Global.dataCount + 7] = (byte)(crc / 256);
            sendbuf[4 * Global.dataCount + 8] = (byte)(crc % 256);
            comm.SendControlCmd(sendbuf, sendbuf.Length);

        }

        private void WriteAllPlanData()
        {
            byte[] sendbuf = new byte[4 * Global.dataCount + 9];
            sendbuf[0] = Global.stationAddr;
            sendbuf[1] = Global.writeCmd;
            sendbuf[2] = (byte)((Global.planOffset) / 256);
            sendbuf[3] = (byte)((Global.planOffset) % 256);
            sendbuf[4] = 0x00;
            sendbuf[5] = (byte)(Global.dataCount*2);
            sendbuf[6] = (byte)(Global.dataCount * 4);
            //双字，字间是低位在前高位在后，字内是高位在前低位在后 3412顺序
            for (int i = 0; i < Global.dataCount; i++)
            {
                sendbuf[7 + i * 4] = (byte)((Global.procData[i].planCount << 16) >> 24);
                sendbuf[8 + i * 4] = (byte)((Global.procData[i].planCount << 24) >> 24);
                sendbuf[9 + i * 4] = (byte)(Global.procData[i].planCount >> 24);
                sendbuf[10 + i * 4] = (byte)((Global.procData[i].planCount << 8) >> 24);

            }
            uint crc = SystemUnit.getCRC(sendbuf, 0, 4 * Global.dataCount + 7);
            sendbuf[4 * Global.dataCount + 7] = (byte)(crc / 256);
            sendbuf[4 * Global.dataCount + 8] = (byte)(crc % 256);
            comm.SendControlCmd(sendbuf, sendbuf.Length);

        }
        private void writeSinglePlanData(int Index)
        {
            byte[] sendbuf = new byte[13];
            sendbuf[0] = Global.stationAddr;
            sendbuf[1] = Global.writeCmd;
            sendbuf[2] = (byte)((Global.planOffset + Global.sizeDistance * Index) / 256);
            sendbuf[3] = (byte)((Global.planOffset + Global.sizeDistance * Index) % 256);
            sendbuf[4] = 0x00;
            sendbuf[5] = 0x02;
            sendbuf[6] = 0x04;
            //双字，字间是低位在前高位在后，字内是高位在前低位在后 3412顺序
            sendbuf[7] = (byte)((Global.procData[Index].planCount << 16) >> 24);
            sendbuf[8] = (byte)((Global.procData[Index].planCount << 24) >> 24);
            sendbuf[9] = (byte)(Global.procData[Index].planCount >> 24);
            sendbuf[10] = (byte)((Global.procData[Index].planCount << 8) >> 24);

            uint crc = SystemUnit.getCRC(sendbuf, 0, 11);
            sendbuf[11] = (byte)(crc / 256);
            sendbuf[12] = (byte)(crc % 256);
            comm.SendControlCmd(sendbuf, sendbuf.Length);
        }


        private void ReadAllSizeData()
        {
            byte[] sendbuf = new byte[8];
            sendbuf[0] = Global.stationAddr;
            sendbuf[1] = Global.readCmd;
            sendbuf[2] = (byte)((Global.sizeOffset ) / 256);
            sendbuf[3] = (byte)((Global.sizeOffset ) % 256);
            sendbuf[4] = 0x00;
            sendbuf[5] = (byte)(Global.dataCount*2);
            uint crc = SystemUnit.getCRC(sendbuf, 0, 6);
            sendbuf[6] = (byte)(crc / 256);
            sendbuf[7] = (byte)(crc % 256);
            comm.SendControlCmd(sendbuf, 8);
        }

        private void ReadAllPlanData()
        {
            byte[] sendbuf = new byte[8];
            sendbuf[0] = Global.stationAddr;
            sendbuf[1] = Global.readCmd;
            sendbuf[2] = (byte)((Global.planOffset) / 256);
            sendbuf[3] = (byte)((Global.planOffset) % 256);
            sendbuf[4] = 0x00;
            sendbuf[5] = (byte)(Global.dataCount * 2);
            uint crc = SystemUnit.getCRC(sendbuf, 0, 6);
            sendbuf[6] = (byte)(crc / 256);
            sendbuf[7] = (byte)(crc % 256);
            comm.SendControlCmd(sendbuf, 8);
        }
        private void readSingleSizeData(int Index)
        {
            byte[] sendbuf = new byte[8];
            sendbuf[0] = Global.stationAddr;
            sendbuf[1] = Global.readCmd;
            sendbuf[2] = (byte)((Global.sizeOffset + Global.sizeDistance * Index) / 256);
            sendbuf[3] = (byte)((Global.sizeOffset + Global.sizeDistance * Index) % 256);
            sendbuf[4] = 0x00;
            sendbuf[5] = 2;
            uint crc = SystemUnit.getCRC(sendbuf, 0, 6);
            sendbuf[6] = (byte)(crc / 256);
            sendbuf[7] = (byte)(crc % 256);
            comm.SendControlCmd(sendbuf, 8);
        }
        private void readSinglePlanData(int Index)
        {
            byte[] sendbuf = new byte[8];
            sendbuf[0] = Global.stationAddr;
            sendbuf[1] = Global.readCmd;
            sendbuf[2] = (byte)((Global.planOffset + Global.sizeDistance * Index) / 256);
            sendbuf[3] = (byte)((Global.planOffset + Global.sizeDistance * Index) % 256);
            sendbuf[4] = 0x00;
            sendbuf[5] = 2;
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
                Global.procData[i].size = (int)(double.Parse(DGV1[1, i].Value.ToString())*Global.convFactor[Global.unit]);
                Global.procData[i].planCount = int.Parse(DGV1[2, i].Value.ToString())*Global.multiple;
                //Global.procData[i].pin = short.Parse(DGV1[3, i].Value.ToString());
            }
            for (int i = 0; i < DGV2.RowCount; i++)
            {
                Global.procData[i + DGV1.RowCount].size = (int)(double.Parse(DGV2[1, i].Value.ToString())*Global.convFactor[Global.unit]);
                Global.procData[i + DGV1.RowCount].planCount = int.Parse(DGV2[2, i].Value.ToString()) * Global.multiple;
                //Global.procData[i + DGV1.RowCount].pin = short.Parse(DGV2[3, i].Value.ToString());
            }

        }
        private void writeProcDataToDGV()
        {
            for (int i = 0; i < (Global.dataCount / 2+Global.dataCount%2); i++)
            {
                double vale = Global.procData[i].size / Global.convFactor[Global.unit];
                DGV1[1, i].Value = vale;
                DGV1[2, i].Value = Global.procData[i].planCount;
               // DGV1[3, i].Value = Global.procData[i].pin;
            }
            for (int i = 0; i < (Global.dataCount + 1) / 2; i++)
            {
                double vale = Global.procData[i + Global.dataCount / 2].size / Global.convFactor[Global.unit];
                DGV2[1, i].Value = vale;
                DGV2[2, i].Value = Global.procData[i + Global.dataCount / 2].planCount;
                //DGV2[3, i].Value = Global.procData[i + Global.dataCount / 2].pin;
            }
        }


        public void setDGV(DataGridView dgv)
        {
            dgv.Columns[0].ReadOnly = true;
            dgv.Columns[0].HeaderText = "序号";
            dgv.Columns[1].HeaderText = "尺寸";
            dgv.Columns[2].HeaderText = "计划数量";
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
                    btnRead.Enabled = false;
                    btnWrite.Enabled = false;
                    btnImport.Enabled = false;
                    btnExport.Enabled = false;
                    btnOpenClosePort.Enabled = false;
                    btnSave.Enabled = false;
                    break;
                case 3:
                    comboPort.Enabled = true;
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
