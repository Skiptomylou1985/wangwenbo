using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TransferData
{
    class DBHelp
    {
        public static DataTable mergeTable(DataTable[] dts)
        {
            DataTable mergeDT = getNewDataTable();
            foreach (DataTable dt in dts)
            {
                foreach(DataRow row in dt.Rows)
                {
                    object[] objs = { row[0], row[1], row[2]};
                    objs[2] = (object)(Convert.ToInt32(objs[2]) * Global.multiple);
                    DataRow dr = mergeDT.NewRow();
                    dr.ItemArray = objs;
                    mergeDT.Rows.Add(dr);
                }
            }
            if (mergeDT.Rows.Count != Global.dataCount)
                mergeDT = null;
            return mergeDT;
        }
        public static DataTable[] devideTable(DataTable dt)
        {
            DataTable[] dts = new DataTable[2];
            dts[0] = getNewDataTable();
            dts[1] = getNewDataTable();
            foreach (DataRow row in dt.Rows)
            {
                try
                {

                    object[] objs = { row[0], row[1], row[2] };
                    if (int.Parse(row[0].ToString()) < Global.dataCount/2+ Global.dataCount%2+1)
                    {
                        DataRow dr = dts[0].NewRow();
                        dr.ItemArray = objs;
                        dts[0].Rows.Add(dr);
                    }
                    else if (int.Parse(row[0].ToString()) <= Global.dataCount)
                    {
                        DataRow dr = dts[1].NewRow();
                        dr.ItemArray = objs;
                        dts[1].Rows.Add(dr);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return dts;
        }
        public static  DataTable getNewDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("序号");
            dt.Columns.Add("尺寸(mm)");
            dt.Columns.Add("计划数量");
            return dt;
        }
    }
}
