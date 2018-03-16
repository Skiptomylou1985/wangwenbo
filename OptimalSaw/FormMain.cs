using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OptimalSaw
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

            InitDatabase();
            InitComm();
            InitWorkingData();
            ShowSendBtn(false);

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            FlushComboThickness();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            FormQuery fq = new FormQuery();
            fq.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboThickness_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvWork.DataSource = null;
            btnSend.Enabled = false;
            string sql = "select * from workorder where status = 1";
            if (comboThickness.Text.Trim() != "全部")
            {  
                sql = sql + " and thickness = " + comboThickness.Text.Trim();
                btnSend.Enabled = true;
            }
            sql = sql + " order by id asc";
            dgvWork.DataSource = Global.mysqlHelper.GetDataTable(sql);
            SetDGVWork();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Global.runMode = RunMode.WRITE;
            StringBuilder sb = new StringBuilder();
            sb.Append("update workorder set status = 2 where id in (");

            DataTable dt = Global.mysqlHelper.GetDataTable("select * from workorder where status = 1 and thickness = "
                + comboThickness.Text + " order by id asc");
            byte[] sendbuf = new byte[400];
            int count = dt.Rows.Count;
            Global.isSendAll = true;
            if (count > Global.dataCount)
            {
                Global.isSendAll = false;
                count = Global.dataCount;
            }
            sendbuf[0] = Global.stationAddr;
            sendbuf[1] = Global.writeCmd;
            sendbuf[2] = (byte)(Global.offset/ 256);
            sendbuf[3] = (byte)(Global.offset% 256);
            sendbuf[4] = (byte)(Global.dataCount * 6 / 256);
            sendbuf[5] = (byte)(Global.dataCount * 6 % 256);

            
            sendbuf[6] = (byte)(Global.dataCount*12);

            for (int i =0;i<count;i++)
            {
                WorkOrder order = new WorkOrder(dt.Rows[i]);
                sendbuf[7+12*i] = (byte)((order.Length << 16) >> 24);
                sendbuf[7 + 12 * i+1] = (byte)((order.Length << 24) >> 24);
                sendbuf[7 + 12 * i+2] = (byte)(order.Length >> 24);
                sendbuf[7 + 12 * i+3] = (byte)((order.Length << 8) >> 24);

                sendbuf[7 + 12 * i+4] = (byte)((order.GrossWidth << 16) >> 24);
                sendbuf[7 + 12 * i+5] = (byte)((order.GrossWidth << 24) >> 24);
                sendbuf[7 + 12 * i+6] = (byte)(order.GrossWidth >> 24);
                sendbuf[7 + 12 * i+7] = (byte)((order.GrossWidth << 8) >> 24);

                sendbuf[7 + 12 * i+8] = (byte)((order.Done << 16) >> 24);
                sendbuf[7 + 12 * i+9] = (byte)((order.Done << 24) >> 24);
                sendbuf[7 + 12 * i+10] = (byte)(order.Done >> 24);
                sendbuf[7 + 12 * i+11] = (byte)((order.Done << 8) >> 24);

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

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

            for (int i=0;i<30; i++)
            {
                WorkOrder order = new WorkOrder();
                order.Length = i + 100;
                order.Thickness = 50;
                order.Width = 100+i*10;
                order.Gross = 50;
                order.GrossWidth = order.Width * order.Gross;
                order.Undo = order.GrossWidth;
                order.ScheduleDate = DateTime.Now;
                order.ProductOrder = DateTime.Now.ToString("yyyyMMddHHmmss") + i.ToString();
                order.Status = 1;
                Global.mysqlHelper.ExecuteSql(order.InsertSQL());
            }

            
        }

        private void btnFlushComboThickness_Click(object sender, EventArgs e)
        {
            FlushComboThickness();
        }

        private void timerBreak_Tick(object sender, EventArgs e)
        {
            timerBreak.Interval = 1000;
            Global.breakNum++;
            if (Global.breakNum > Global.timeOut)
            {
                timerBreak.Enabled = false;
                Global.breakNum = 0;
                if (Global.runMode == RunMode.READDATA)
                {
                    lblShow.Text = "读取优选锯数据故障！";
                    lblShow.ForeColor = Color.Red;
                }

                if (Global.runMode == RunMode.WRITE)
                {
                    Global.writeIndex = 0;
                    lblShow.Text = "订单发送失败,发送超时，请重新发送";
                    lblShow.ForeColor = Color.Red;
                }
                Global.runMode = RunMode.NORMAL;

            }
        }

        private void timerRead_Tick(object sender, EventArgs e)
        {
            if (Global.runMode == RunMode.NORMAL)
            {
                Global.runMode = RunMode.READDATA;
                SendReadDataCmd();
            }
            
            
        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            //订单总数
            string sql = "select status ,count(*) as num from workorder GROUP BY status";
            DataTable dt = Global.mysqlHelper.GetDataTable(sql);
            foreach(DataRow dr in dt.Rows)
            {
                OrderStatus os = (OrderStatus)Enum.Parse(typeof(OrderStatus),dr["status"].ToString());
                switch(os)
                {
                    case OrderStatus.WORKING:
                        Global.workingOrders = int.Parse(dr["num"].ToString());
                        break;
                    case OrderStatus.CANCELED:
                        Global.cacelOrders = int.Parse(dr["num"].ToString());
                        break;
                    case OrderStatus.UNDO:
                        Global.undoOrders = int.Parse(dr["num"].ToString());
                        break;
                    case OrderStatus.TERMINATED:
                        Global.terminateOrders = int.Parse(dr["num"].ToString());
                        break;
                    case OrderStatus.COMPLETED:
                        Global.completeOrders = int.Parse(dr["num"].ToString());
                        break;
                    default:
                        break;
                }
            }
            Global.totalOrders = Global.undoOrders + Global.workingOrders + Global.cacelOrders +
                                   Global.completeOrders + Global.terminateOrders;

            lblTotalOrders.Text = Global.totalOrders.ToString();
            lblUndoOrders.Text = Global.undoOrders.ToString();
            lblWorkingOrders.Text = Global.workingOrders.ToString();
            lblWorkingThickness.Text = Global.procData[0].Thickness.ToString();

            Global.workingGrossWidth = 0;
            Global.workingDone = 0;
            Global.workingDoneRatio = 0;
            Global.workingDoneOrders = 0;
            for (int i =0;i<Global.procData.Length;i++)
            {
                Global.workingGrossWidth += Global.procData[i].GrossWidth;
                Global.workingDone += Global.procData[i].Done;
                if (Global.procData[i].GrossWidth == Global.procData[i].Done)
                {
                    Global.workingDoneOrders +=1;
                }
            }
            Global.workingDoneRatio = 100 * Global.workingDone / Global.workingGrossWidth;
            lblWorkingGrossWidth.Text = Global.workingGrossWidth.ToString();
            lblWorkingDoneWidth.Text = Global.workingDone.ToString();
            lblWorkingDoneOrders.Text = Global.workingDoneOrders.ToString();
            lblWorkingRatio.Text = Global.workingDoneRatio.ToString()+"%";


            FlushMacStatus();

            if (Global.runMode == RunMode.NORMAL)
            {
                Global.runMode = RunMode.READSTATUS;
                SendReadStatusCmd();
            }


        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (Global.macRunStatus == 1)
            {
                lblWorkingShowInfo.Text = "无法在设备运行时发送新订单，请先将设备停止运行！";
                lblWorkingShowInfo.ForeColor = Color.Red;
            }
            else
            {
                ShowSendBtn(true);
            }
            
        }

        private void radioBtnWorking_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnWorking.Checked)
            {
                radioBtnWorking.ForeColor = Color.Green;
                flushWorkingData();
            }
            else
            {
                radioBtnWorking.ForeColor = SystemColors.ControlText;
            }

        }

        private void radioBtnUndo_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnUndo.Checked)
            {
                radioBtnUndo.ForeColor = Color.Green;
                flushUndoData();
            }
            else
            {
                radioBtnUndo.ForeColor = SystemColors.ControlText;
            }
        }

        
    }
}
