using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace OptimalSaw
{
    public class WorkOrder
    {
        public WorkOrder(DataRow row)
        {
            this.id = int.Parse(row["id"].ToString());
            this.ProductOrder = row["productorder"].ToString();
            this.Type = row["type"].ToString();
            this.ScheduleDate = DateTime.Parse(row["scheduledate"].ToString());
            this.Length = int.Parse(row["lenth"].ToString());
            this.Width = int.Parse(row["width"].ToString());
            this.Thickness = int.Parse(row["thickness"].ToString());
            this.Gross = int.Parse(row["gross"].ToString());
            this.Done = int.Parse(row["done"].ToString());
            this.Undo = int.Parse(row["undone"].ToString());
            this.Worth = int.Parse(row["worth"].ToString());
            this.Worker = row["worker"].ToString();
            this.MachineCode = row["machinecode"].ToString();
            this.CompleteDate = DateTime.Parse(row["scheduledate"].ToString());
            this.Remark = row["remark"].ToString();
            this.GrossWidth = int.Parse(row["grosswidth"].ToString());


        }
        public WorkOrder() { }

        //主键id
        public int id { get; set; }
        //生产指令单
        public string ProductOrder { get; set; }
        //材质、类型
        public string Type { get; set; }
        //排产日期
        public DateTime ScheduleDate { get; set; }

        //长度
        public int Length { get; set; }
        //单个宽度
        public int Width { get; set; }

        //厚度
        public int Thickness { get; set; }

        //需求数量
        public int Gross { get; set; }

        //已产数量
        public int Done { get; set; }

        //未产数量
        public int Undo { get; set; }

        //完成日期
        public DateTime CompleteDate { get; set; }

        //机器编号
        public string MachineCode { get; set; }

        //操作人员
        public string Worker { get; set; }

        //产值
        public int Worth { get; set; }

        //备注
        public string Remark { get; set; }

        //工单状态  1 未排产  2已取消  3 生产中 4已暂停 5已终止 6已完成 
        public int Status { get; set; }

        //接收日期
        public DateTime ReceiveDate { get; set; }

        //总宽度
        public int GrossWidth { get; set; }
        
        public string InsertSQL()
        {
            String sql = "insert into workorder (productorder,type,scheduledate,lenth,width," +
                         "thickness,gross,done,undone,completedate,machinecode,worker,worth,remark,status,receivedate,grosswidth) " +
                         "values ('{0}','{1}','{2}',{3},{4},{5},{6},{7},{8},'{9}','{10}','{11}',{12},'{13}',{14},'{15}',{16})";
            return String.Format(sql, ProductOrder, Type, ScheduleDate.ToString("yyyy-MM-dd"), Length.ToString(), Width.ToString(),
                Thickness.ToString(),Gross.ToString(),Done.ToString(),Undo.ToString(),CompleteDate.ToString("yyyy-MM-dd"),
                MachineCode,Worker,Worth.ToString(),Remark,Status.ToString(),ReceiveDate.ToString("yyyy-MM-dd HH:mm:ss"), GrossWidth.ToString());
        }
        public string UndateSQL()
        {
            String sql = "update workorder set productorder = '{0}',type = '{1}',scheduledate='{2}',lenth={3},width = {4}," +
                         "thickness={5},gross={6},done={7},undone={8},completedate='{9}',machinecode='{10}',worker='{11}'," +
                         "worth={12},remark='{13}',status={14} ,receivedate = '{15}',grosswidth = {16} where id = {17} ";
            return String.Format(sql, ProductOrder, Type, ScheduleDate.ToString("yyyy-MM-dd"), Length.ToString(), Width.ToString(),
               Thickness.ToString(), Gross.ToString(), Done.ToString(), Undo.ToString(), CompleteDate.ToString("yyyy-MM-dd"),
               MachineCode, Worker, Worth.ToString(), Remark, Status.ToString(), ReceiveDate.ToString("yyyy-MM-dd HH:mm:ss"),
               GrossWidth.ToString(),id.ToString());
        }
    }
}
