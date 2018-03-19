using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace OptimalSaw
{
    partial class FormMain
    {
        private string iniPath = Application.StartupPath + "\\config.ini";

        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == SystemUnit.WM_READBACK)
            {
                
                Global.breakNum = 0;
                timerBreak.Enabled = false;

                if ((int)DataType.STATUS == (int)m.LParam)
                {
                    int status = (int)m.WParam;
                    Global.macRunStatus = status >> 8;
                    Global.macErrorStatus = (status & 0x08) >> 3;
                    Global.macRunMode = (status & 0x80) >> 7;
                    Global.runMode = RunMode.NORMAL;
                    //lblWorkingShowInfo.Text = "状态值:" + status.ToString();
                    //判断设备状态
                }
                else if ((int)ReturnResult.SUCCESS == (int)m.WParam)
                {
                    if ((int)DataType.READCONTINUE == (int)m.LParam)
                    {
                        Global.readDataDone = true;
                        SendReadDataCmd(Global.offset + Global.dataCount * 6, 30 - Global.dataCount);
                        timerBreak.Enabled = true;

                    } 
                    else if((int)DataType.READDONE == (int)m.LParam)
                    {
                        Global.runMode = RunMode.NORMAL;
                    }
                    
                }
                
                return;
            }
            if (m.Msg == SystemUnit.WM_WRITEBACK)
            {
                if (Global.runMode != RunMode.WRITE)
                    return;
                if ((int)ReturnResult.SUCCESS == (int)m.WParam)
                {
                    Global.breakNum = 0;
                    timerBreak.Enabled = false;
                    if ((int)DataType.WRITEDONE == (int)m.LParam)
                    {
                        lblWorkingShowInfo.Text = "订单发送成功！";
                        lblWorkingShowInfo.ForeColor = Color.Green;
                        ShowSendBtn(false);
                        timerRead.Enabled = true;
                        Global.runMode = RunMode.NORMAL;
                    }
                    else if ((int)DataType.WRITECONTINUE == (int)m.LParam)
                    {
                        SendRestData();
                        
                        return;
                    }
                    else if ((int)DataType.PIN == (int)m.LParam)
                    {
                        Global.runMode = RunMode.NORMAL;
                        return;
                    }
                }
                
                return;
            }
            base.DefWndProc(ref m);
        }


        //初始化数据库参数及连接
        private bool InitDatabase()
        {
            try
            {
                DBInfo info = new DBInfo();
                info.type = IniHelper.GetINIValue(iniPath, "database", "type");
                info.ip = IniHelper.GetINIValue(iniPath, "database", "ip");
                info.dbname = IniHelper.GetINIValue(iniPath, "database", "name");
                info.username = IniHelper.GetINIValue(iniPath, "database", "username");
                info.password = IniHelper.GetINIValue(iniPath, "database", "password");
                info.port = int.Parse(IniHelper.GetINIValue(iniPath, "database", "port"));
                Global.mysqlHelper = new MysqlHelper(info);

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("初始化数据库失败！");
                return false;
            }
            return true;
        }
        //初始化串口参数及连接串口
        private bool InitComm()
        {
            SerialPort comm = new SerialPort();
            comm.PortName = IniHelper.GetINIValue(iniPath, "comm", "port");
            comm.BaudRate = int.Parse(IniHelper.GetINIValue(iniPath, "comm", "bps"));
            comm.Parity = (Parity)Enum.Parse(typeof(Parity), IniHelper.GetINIValue(iniPath, "comm", "parity"));
            comm.RtsEnable = false;
            Global.commHelper = new CommHelper();
            if (Global.commHelper.comOpen(comm))
            {
                return true;
            }
            else
            {
                MessageBox.Show("串口打开失败！");
                return false;
            }
        }

        private void FlushComboThickness()
        {
            comboThickness.Items.Clear();
            btnSend.Enabled = false;
            string sql = "select distinct thickness from workorder where status = 1";
            DataTable dt = Global.mysqlHelper.GetDataTable(sql);
            if (dt == null || dt.Rows.Count < 1)
            {
                comboThickness.Items.Add("无订单");
            }
            else
            {
                comboThickness.Items.Add("全部");
                foreach(DataRow dr in dt.Rows)
                {
                    comboThickness.Items.Add(dr["thickness"].ToString());
                }
                btnSend.Enabled = true;
            }
            comboThickness.SelectedIndex = 0;

        }

        private void SetDGVWork()
        {
            dgvWork.Columns[0].ReadOnly = true;
            dgvWork.Columns[0].HeaderText = "序号";
            dgvWork.Columns[1].HeaderText = "生产指令单";
            dgvWork.Columns[2].HeaderText = "材料类型";
            
            dgvWork.Columns[3].HeaderText = "排产日期";
            dgvWork.Columns[3].Visible = false;
            dgvWork.Columns[4].HeaderText = "长度";
            dgvWork.Columns[5].HeaderText = "宽度";
            dgvWork.Columns[6].HeaderText = "厚度";
            dgvWork.Columns[7].HeaderText = "数量";
            dgvWork.Columns[8].HeaderText = "已生产";
            dgvWork.Columns[9].HeaderText = "未生产";
            dgvWork.Columns[10].HeaderText = "完成日期";
            dgvWork.Columns[10].Visible = false;
            dgvWork.Columns[11].HeaderText = "设备编码";
            dgvWork.Columns[11].Visible = false;
            dgvWork.Columns[12].HeaderText = "操作员";
            dgvWork.Columns[12].Visible = false;
            dgvWork.Columns[13].HeaderText = "产值";
            dgvWork.Columns[13].Visible = false;
            dgvWork.Columns[14].HeaderText = "备注";
            dgvWork.Columns[14].Visible = false;
            dgvWork.Columns[15].HeaderText = "订单状态";
            dgvWork.Columns[15].Visible = false;
            dgvWork.Columns[16].HeaderText = "接收日期";
            dgvWork.Columns[16].Visible = false;
            dgvWork.Columns[17].HeaderText = "总宽度";
            dgvWork.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvWork.AllowUserToAddRows = false;
            dgvWork.AllowUserToResizeRows = false;
            dgvWork.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dgv.AllowUserToAddRows = false;
            //dgv.AllowUserToResizeRows = false;
            dgvWork.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
         
            foreach (DataGridViewColumn item in dgvWork.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.ReadOnly = true;
            }
        }

        private void FlushWorkingData()
        {
            string sql = "select * from working order by workingid asc";
            DataTable dt = Global.mysqlHelper.GetDataTable(sql);
            dgvWork.DataSource = dt;
            SetDGVWork();
        }

        private void FlushUndoData()
        {
            string sql = "select * from workorder where status = 1 order by id asc";
            DataTable dt = Global.mysqlHelper.GetDataTable(sql);
            dgvWork.DataSource = dt;
            SetDGVWork();
        }
        private void flushBoard()
        {

        }
        private void SendReadDataCmd(int offset,int count)
        {
            byte[] sendbuf = new byte[8];
            sendbuf[0] = Global.stationAddr;
            sendbuf[1] = Global.readCmd;
            sendbuf[2] = (byte)(offset / 256);
            sendbuf[3] = (byte)(offset % 256);
            sendbuf[4] = (byte)(count*6/256);
            sendbuf[5] = (byte)(count* 6% 256);
            uint crc = SystemUnit.getCRC(sendbuf, 0, 6);
            sendbuf[6] = (byte)(crc / 256);
            sendbuf[7] = (byte)(crc % 256);
            Global.commHelper.SendControlCmd(sendbuf, 8);
        }
        private void SendReadStatusCmd()
        {
            byte[] sendbuf = new byte[8];
            sendbuf[0] = Global.stationAddr;
            sendbuf[1] = Global.readCmd;
            sendbuf[2] = (byte)(Global.runStatusOffset / 256);
            sendbuf[3] = (byte)(Global.runStatusOffset % 256);
            sendbuf[4] = 0;
            sendbuf[5] = 2;
            uint crc = SystemUnit.getCRC(sendbuf, 0, 6);
            sendbuf[6] = (byte)(crc / 256);
            sendbuf[7] = (byte)(crc % 256);
            Global.commHelper.SendControlCmd(sendbuf, 8);
        }

        private void SendRestData()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update workorder set status = 2 where id in (");

            DataTable dt = Global.mysqlHelper.GetDataTable("select * from workorder where status = 1 and thickness = "
                + comboThickness.Text + " order by id asc");
            byte[] sendbuf = new byte[400];
            int count = dt.Rows.Count;
            if (count > (30-Global.dataCount))
            {
                count = 30-Global.dataCount;
            }
            sendbuf[0] = Global.stationAddr;
            sendbuf[1] = Global.writeCmd;
            sendbuf[2] = (byte)((Global.offset+Global.dataCount*6) / 256);
            sendbuf[3] = (byte)((Global.offset + Global.dataCount * 6) % 256);
            sendbuf[4] = (byte)(count * 6 / 256);
            sendbuf[5] = (byte)(count * 6 % 256);


            sendbuf[6] = (byte)(count * 12);

            for (int i = 0; i < count; i++)
            {
                WorkOrder order = new WorkOrder(dt.Rows[i]);
                sendbuf[7 + 12 * i] = (byte)((order.Length << 16) >> 24);
                sendbuf[7 + 12 * i + 1] = (byte)((order.Length << 24) >> 24);
                sendbuf[7 + 12 * i + 2] = (byte)(order.Length >> 24);
                sendbuf[7 + 12 * i + 3] = (byte)((order.Length << 8) >> 24);

                sendbuf[7 + 12 * i + 4] = (byte)((order.GrossWidth << 16) >> 24);
                sendbuf[7 + 12 * i + 5] = (byte)((order.GrossWidth << 24) >> 24);
                sendbuf[7 + 12 * i + 6] = (byte)(order.GrossWidth >> 24);
                sendbuf[7 + 12 * i + 7] = (byte)((order.GrossWidth << 8) >> 24);

                sendbuf[7 + 12 * i + 8] = (byte)((order.Done << 16) >> 24);
                sendbuf[7 + 12 * i + 9] = (byte)((order.Done << 24) >> 24);
                sendbuf[7 + 12 * i + 10] = (byte)(order.Done >> 24);
                sendbuf[7 + 12 * i + 11] = (byte)((order.Done << 8) >> 24);

                sb.Append(order.id.ToString() + ",");
                Global.procData[i+Global.dataCount].id = order.id;
                Global.procData[i + Global.dataCount].Lenth = order.Length;
                Global.procData[i + Global.dataCount].Thickness = order.Thickness;
                Global.procData[i + Global.dataCount].GrossWidth = order.GrossWidth;
                Global.procData[i + Global.dataCount].status = (int)OrderStatus.WORKING;
            }
            uint crc = SystemUnit.getCRC(sendbuf, 0, count * 12 + 7);
            sendbuf[count * 12 + 7] = (byte)(crc / 256);
            sendbuf[count * 12 + 8] = (byte)(crc % 256);
            Global.commHelper.SendControlCmd(sendbuf, count * 12 + 9);
            timerBreak.Enabled = true;
            sb.Append("0)");
            Global.mysqlHelper.ExecuteSql(sb.ToString());
        }

        private void InitWorkingData()
        {

            string sql = "select * from working where status = 2 order by workingid asc";
            DataTable dt = Global.mysqlHelper.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Global.procData[i].Lenth = int.Parse(dt.Rows[i]["lenth"].ToString());
                    Global.procData[i].GrossWidth = int.Parse(dt.Rows[i]["grosswidth"].ToString());
                    Global.procData[i].id = int.Parse(dt.Rows[i]["id"].ToString());
                    Global.procData[i].Thickness = int.Parse(dt.Rows[i]["thickness"].ToString());
                    Global.procData[i].status = (int)OrderStatus.WORKING;
                    Global.procData[i].Done = int.Parse(dt.Rows[i]["done"].ToString());
                }
                sql = "select * from working where status = 1 ";
                dt = Global.mysqlHelper.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    Global.queueOrders = dt.Rows.Count;
                }
                timerRead.Enabled = true;
            }
        }

        private void ShowSendBtn(bool isShow)
        {
            lblSelectWidth.Visible = isShow;
            FlushComboThickness();
            comboThickness.Visible = isShow;
            btnSend.Visible = isShow;
        }

        private void FlushMacStatus()
        {
            if (Global.macCommStatus == 0)
            {
                lblCommStatus.Text = "通讯异常";
                lblCommStatus.ForeColor = Color.Red;
            }
            else
            {
                lblCommStatus.Text = "通讯正常";
                lblCommStatus.ForeColor = Color.Green;
            }
            if (Global.macRunStatus == 0)
            {
                lblMacRunStatus.Text = "停止";
                lblMacRunStatus.ForeColor = Color.Green;
            }
            else
            {
                lblMacRunStatus.Text = "运行中";
                lblMacRunStatus.ForeColor = Color.Red;
            }

            if (Global.macRunMode == 0)
            {
                lblMacRunMode.Text = "本地模式";
                lblMacRunMode.ForeColor = Color.Green;
            }
            else
            {
                lblMacRunMode.Text = "远程模式";
                lblMacRunMode.ForeColor = Color.Green;
            }
            if (Global.macErrorStatus == 0)
            {
                lblMacError.Text = "无故障";
                lblMacError.ForeColor = Color.Green;
            }
            else
            {
                lblMacError.Text = "故障";
                lblMacError.ForeColor = Color.Red;
            }
        }

        private void sendNewOrders(int thickness)
        {

            FlushProcData();
            Global.runMode = RunMode.WRITE;
            string sql = "insert into working " +
                            "(id, productorder, type, scheduledate, lenth, width, thickness, gross, done, undone," +
                            "completedate, machinecode, worker, worth, remark, status, receivedate, grosswidth)" +
                            "select* from workorder a where a.status = 1 and a.thickness = " + thickness.ToString();
            Global.mysqlHelper.ExecuteSql(sql);
            sql = "update workorder a, working b set a.status = 2 where a.id = b.id";
            Global.mysqlHelper.ExecuteSql(sql);

            StringBuilder sb = new StringBuilder();
            sb.Append("update working set status = 2 where id in (");
            DataTable dt = Global.mysqlHelper.GetDataTable("select * from working order by workingid asc");
            byte[] sendbuf = new byte[400];
            int count = dt.Rows.Count;
            //判断订单数是否大于设备最大订单数30
            if (count > 30)
            {
                Global.isDataOver = true;
            }
            else
            {
                Global.isDataOver = false;
            }

            //判断是否可以一次发完
            Global.isSendAll = true;
            if (count > Global.dataCount)
            {
                Global.isSendAll = false;
                count = Global.dataCount;
            }
            sendbuf[0] = Global.stationAddr;
            sendbuf[1] = Global.writeCmd;
            sendbuf[2] = (byte)(Global.offset / 256);
            sendbuf[3] = (byte)(Global.offset % 256);
            sendbuf[4] = (byte)(Global.dataCount * 6 / 256);
            sendbuf[5] = (byte)(Global.dataCount * 6 % 256);
            sendbuf[6] = (byte)(Global.dataCount * 12);

            for (int i = 0; i < count; i++)
            {
                WorkOrder order = new WorkOrder(dt.Rows[i]);
                sendbuf[7 + 12 * i] = (byte)((order.Length << 16) >> 24);
                sendbuf[7 + 12 * i + 1] = (byte)((order.Length << 24) >> 24);
                sendbuf[7 + 12 * i + 2] = (byte)(order.Length >> 24);
                sendbuf[7 + 12 * i + 3] = (byte)((order.Length << 8) >> 24);

                sendbuf[7 + 12 * i + 4] = (byte)((order.GrossWidth << 16) >> 24);
                sendbuf[7 + 12 * i + 5] = (byte)((order.GrossWidth << 24) >> 24);
                sendbuf[7 + 12 * i + 6] = (byte)(order.GrossWidth >> 24);
                sendbuf[7 + 12 * i + 7] = (byte)((order.GrossWidth << 8) >> 24);

                sendbuf[7 + 12 * i + 8] = (byte)((order.Done << 16) >> 24);
                sendbuf[7 + 12 * i + 9] = (byte)((order.Done << 24) >> 24);
                sendbuf[7 + 12 * i + 10] = (byte)(order.Done >> 24);
                sendbuf[7 + 12 * i + 11] = (byte)((order.Done << 8) >> 24);

                sb.Append(order.id.ToString() + ",");
                Global.procData[i].id = order.id;
                Global.procData[i].Lenth = order.Length;
                Global.procData[i].Thickness = order.Thickness;
                Global.procData[i].GrossWidth = order.GrossWidth;
                Global.procData[i].status = (int)OrderStatus.WORKING;
            }
            uint crc = SystemUnit.getCRC(sendbuf, 0, Global.dataCount * 12 + 7);
            sendbuf[Global.dataCount * 12 + 7] = (byte)(crc / 256);
            sendbuf[Global.dataCount * 12 + 8] = (byte)(crc % 256);
            Global.commHelper.SendControlCmd(sendbuf, Global.dataCount * 12 + 9);
            timerBreak.Enabled = true;
            sb.Append("0)");
            Global.mysqlHelper.ExecuteSql(sb.ToString());
            lblWorkingShowInfo.Text = "订单发送中……";
            lblWorkingShowInfo.ForeColor = Color.Green;
        }

        private void FlushProcData()
        {
            for (int i = 0; i < 30; i++)
            {
                Global.procData[i].flush();
            }
        }
    }
}
