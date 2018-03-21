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
            InitMainParam();
            InitWorkingData();
            ShowSendBtn(false);
            btnSendRest.Visible = false;
            timerStatus.Enabled = true;

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
            sendNewOrders(int.Parse(comboThickness.Text));
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
            timerBreak.Interval = 300;
            Global.breakNum++;
            if (Global.breakNum > Global.timeOut)
            {
                timerBreak.Enabled = false;
                Global.breakNum = 0;
                if (Global.runMode == RunMode.READDATA)
                {
                    lblWorkingShowInfo.Text = "读取优选锯数据故障！";
                    lblWorkingShowInfo.ForeColor = Color.Red;
                }

                if (Global.runMode == RunMode.WRITE)
                {
                    string sql = "update workorder a, working b set a.status = 1 where a.id = b.id";
                    Global.mysqlHelper.ExecuteSql(sql);
                    sql = "truncate table working";
                    Global.mysqlHelper.ExecuteSql(sql);
                    FlushProcData();
                    lblWorkingShowInfo.Text = "订单发送失败,发送超时，请重新发送";
                    lblWorkingShowInfo.ForeColor = Color.Red;
                }
                Global.runMode = RunMode.NORMAL;

            }
        }

        private void timerRead_Tick(object sender, EventArgs e)
        {
            if (Global.runMode == RunMode.NORMAL && Global.readDataDone)
            {
                Global.runMode = RunMode.READDATA;
                if (Global.workingOrders > Global.dataCount)
                {
                    Global.readDataDone = false;
                }
                SendReadDataCmd(Global.offset,Global.dataCount);
                timerBreak.Enabled = true;
            }
            
            
        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            //return;
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
            lblQueueOrders.Text = Global.queueOrders.ToString();
            lblWorkingThickness.Text = Global.procData[0].Thickness.ToString();

            Global.workingGrossWidth = 0;
            Global.workingDone = 0;
            Global.workingDoneRatio = 0;
            Global.workingDoneOrders = 0;
            for (int i =0;i<Global.procData.Length;i++)
            {
                Global.workingGrossWidth += Global.procData[i].GrossWidth;
                Global.workingDone += Global.procData[i].Done;
                if (Global.procData[i].GrossWidth == Global.procData[i].Done &&
                    Global.procData[i].GrossWidth != 0)
                {
                    Global.workingDoneOrders +=1;
                }
            }
            if (Global.workingGrossWidth > 0)
                Global.workingDoneRatio = 100 * Global.workingDone / Global.workingGrossWidth;
            else
                Global.workingDoneRatio = 0;
            lblWorkingGrossWidth.Text = Global.workingGrossWidth.ToString();
            lblWorkingDoneWidth.Text = Global.workingDone.ToString();
            lblWorkingDoneOrders.Text = Global.workingDoneOrders.ToString();
            lblWorkingRatio.Text = Global.workingDoneRatio.ToString()+"%";

            if (Global.queueOrders > 0 && Global.workingDoneOrders > Global.nRestFlag)
            {
                btnSendRest.Visible = true;
                lblWorkingShowInfo.Text = "当前厚度订单已有" + Global.nRestFlag + "完成生产，可在停机之后点击【订单补发】发送剩余未加工订单";
                lblWorkingShowInfo.ForeColor = Color.Red;
            }


            FlushMacStatus();

            if (Global.dataIsChanged)
            {
                FlushWorkingData();
                Global.dataIsChanged = false;
            }

            if (Global.runMode == RunMode.NORMAL)
            {
                Global.runMode = RunMode.READSTATUS;
                SendReadStatusCmd();
                timerBreak.Enabled = true;
            }


        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            
            if (Global.workingOrders > 0)
            {
                lblWorkingShowInfo.Text = "当前订单还未生产完毕，无法发送新订单！";
                lblWorkingShowInfo.ForeColor = Color.Red;
            }
            else if (Global.macRunStatus == 1)
            {
                lblWorkingShowInfo.Text = "无法在设备运行时发送新订单，请先将设备停止运行！";
                lblWorkingShowInfo.ForeColor = Color.Red;
            }
            else
            {
                lblWorkingShowInfo.Text = "请在【订单列表】中选择要发送的订单类型，并确认发送！";
                lblWorkingShowInfo.ForeColor = Color.Red;
                ShowSendBtn(true);
            }
            
        }

        private void radioBtnWorking_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnWorking.Checked)
            {
                radioBtnWorking.ForeColor = Color.Green;
                FlushWorkingData();
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
                FlushUndoData();
            }
            else
            {
                radioBtnUndo.ForeColor = SystemColors.ControlText;
            }
        }

        private void btnParam_Click(object sender, EventArgs e)
        {

        }

        private void btnSendRest_Click(object sender, EventArgs e)
        {
            if (Global.macRunStatus == 1)
            {
                lblWorkingShowInfo.Text = "设备正在运行，请先停机后再补发订单！";
                lblWorkingShowInfo.ForeColor = Color.Red;
                return;
            }
            string sql = "update workorder set status = 1 where status = 2";
            Global.mysqlHelper.ExecuteSql(sql);
            int thickeness = Global.procData[0].Thickness;
            sendNewOrders(thickeness);
        }

        private void btnTest_Click_1(object sender, EventArgs e)
        {
            string sql = "update workorder set done = 123 where id = 3";
            Global.mysqlHelper.ExecuteSql(sql);
            //SendReadDataCmd(Global.offset, Global.dataCount);
        }
    }
}
