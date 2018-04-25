using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OptimalSaw
{
    public partial class FormQuery : Form
    {
        public FormQuery()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from workorder where 1 = 1 ");


            if (comboStatus.SelectedIndex > 0)
            {
                sb.Append(" and status = " + comboStatus.SelectedIndex.ToString());
            }

            if (checkSchedule.Checked)
            {
                sb.Append(" and scheduledate between " + dtpScheduleBegin.Value +
                    " and " + dtpScheduleEnd.Value);
            }
            if (checkReceive.Checked)
            {
                sb.Append(" and receivedate between " + dtpReceiveBegin.Value +
                    " and " + dtpReceiveEnd.Value);
            }
            if (checkComplete.Checked)
            {
                sb.Append(" and completedate between " + dtpCompleteBegin.Value +
                    " and " + dtpCompleteEnd.Value);
            }

            if (textOrder.Text.Trim().Length > 0)
            {
                sb.Append(" and productorder like '%" + textOrder.Text.Trim() + "%'");
            }

            if (comboType.SelectedIndex > 0)
            {
                sb.Append(" and type = '" + comboType.Text + "'");
            }

            sb.Append(" order by id asc");

            dgvOrder.DataSource = Global.mysqlHelper.GetDataTable(sb.ToString());

            if (dgvOrder.DataSource != null)
            {
                SetDGVOrder();
            }
            else
            {
                MessageBox.Show("没有符合条件的订单信息！");
            }
            

        }
        private void SetDGVOrder()
        {
            dgvOrder.Columns[0].HeaderText = "序号";
            dgvOrder.Columns[1].HeaderText = "生产指令单";
            dgvOrder.Columns[2].HeaderText = "材料类型";
            dgvOrder.Columns[3].HeaderText = "排产日期";
            dgvOrder.Columns[4].HeaderText = "长度";
            dgvOrder.Columns[5].HeaderText = "宽度";
            dgvOrder.Columns[6].HeaderText = "厚度";
            dgvOrder.Columns[7].HeaderText = "数量";
            dgvOrder.Columns[8].HeaderText = "已生产";
            dgvOrder.Columns[9].HeaderText = "未生产";
            dgvOrder.Columns[10].HeaderText = "完成日期";
            dgvOrder.Columns[11].HeaderText = "设备编码";
            dgvOrder.Columns[12].HeaderText = "操作员";
            dgvOrder.Columns[13].HeaderText = "产值";
            dgvOrder.Columns[14].HeaderText = "备注";
            dgvOrder.Columns[14].Visible = false;
            dgvOrder.Columns[15].HeaderText = "订单状态";
            dgvOrder.Columns[15].Visible = false;
            dgvOrder.Columns[16].HeaderText = "接收日期";
            dgvOrder.Columns[17].HeaderText = "总宽度";
            dgvOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dgvOrder.AllowUserToAddRows = false;
            dgvOrder.AllowUserToResizeRows = false;
            dgvOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dgv.AllowUserToAddRows = false;
            //dgv.AllowUserToResizeRows = false;
            dgvOrder.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn item in dgvOrder.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.ReadOnly = true;
            }
        }

        private void dgvOrder_SelectionChanged(object sender, EventArgs e)
        {
            int cur = 0;
            if (dgvOrder.CurrentCell != null)    //过车时刷新，当前单元格为空，选中首行
                cur = dgvOrder.CurrentCell.RowIndex;
            try
            {
                lblOrder.Text = dgvOrder.Rows[cur].Cells["productorder"].Value.ToString();
                lblType.Text = dgvOrder.Rows[cur].Cells["type"].Value.ToString();
                lblStatus.Text = dgvOrder.Rows[cur].Cells["status"].Value.ToString();
                lblWorker.Text = dgvOrder.Rows[cur].Cells["worker"].Value.ToString();
                lblSchedule.Text = dgvOrder.Rows[cur].Cells["scheduledate"].Value.ToString();
                lblReceive.Text = dgvOrder.Rows[cur].Cells["receivedate"].Value.ToString();
                lblComplete.Text = dgvOrder.Rows[cur].Cells["completedate"].Value.ToString();
                lblMachineCode.Text = dgvOrder.Rows[cur].Cells["machinecode"].Value.ToString();
                lblGrossWidth.Text = dgvOrder.Rows[cur].Cells["grosswidth"].Value.ToString();
                lblUndone.Text = dgvOrder.Rows[cur].Cells["undone"].Value.ToString();
                lblDone.Text = dgvOrder.Rows[cur].Cells["done"].Value.ToString();
                lblWorth.Text = dgvOrder.Rows[cur].Cells["worth"].Value.ToString();
                lbllength.Text = dgvOrder.Rows[cur].Cells["lenth"].Value.ToString();
                lblThickness.Text = dgvOrder.Rows[cur].Cells["thickness"].Value.ToString();
                lblWidth.Text = dgvOrder.Rows[cur].Cells["width"].Value.ToString();
                lblGross.Text = dgvOrder.Rows[cur].Cells["gross"].Value.ToString();
                lblRemark.Text = dgvOrder.Rows[cur].Cells["remark"].Value.ToString();
            }
            catch (System.Exception ex)
            {

            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (DialogResult.OK == folder.ShowDialog())
            {

            }
        }
    }
}
