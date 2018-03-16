using System;
using System.Collections.Generic;
using System.Text;

namespace JsonDemo
{
    public class WorkOrder
    {

        public string text { get; set; }
        //生产指令单
        public string ProductOrder { get; set; }
        //材质、类型
        public string Type { get; set; }
        //排产日期
        public DateTime ScheduleDate { get; set; }
        
        //长度
        public int Length { get; set; }
        //宽度
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
        
    }
}
