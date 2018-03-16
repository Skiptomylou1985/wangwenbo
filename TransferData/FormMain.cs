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
namespace TransferData
{
    public partial class FormMain : Form
    {
       
        private CommPort comm = new CommPort();
       
        public FormMain()
        {
            InitializeComponent();
            appInit();

        }
      
        private void btnSave_Click(object sender, EventArgs e)
        {
            if ( exportData(Global.defaultPath))
                showInfo("默认数据保存成功", true,true);
            else
                showInfo("默认数据保存失败", true,false);
        }
        
        private void btnOpenClosePort_Click(object sender, EventArgs e)
        {
           if(btnOpenClosePort.Text == "打开串口")
            {
                if (comm.comOpen(comboPort.Text, int.Parse(comboBPS.Text), false))
                {
                    Global.comPort = comboPort.Text;
                    Global.comBPS = int.Parse(comboBPS.Text);
                    XMLUnit.XMLSetValue(Global.xmlPath, "transferdata", "normal", "comport", comboPort.Text);
                    XMLUnit.XMLSetValue(Global.xmlPath, "transferdata", "normal", "combps", comboBPS.Text);
                    setFormStatus(1);
                    showInfo("串口打开成功", false,true);
                }
                else
                {
                    showInfo("串口打开失败", true,false);
                }
            }
           else if(btnOpenClosePort.Text == "关闭串口")
            {
                if (comm.comClose())
                {
                    setFormStatus(0);
                    showInfo("串口关闭成功", false,true);
                }
                else
                {
                    showInfo("串口关闭失败", true,false);
                }
            }
          
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
           
            Global.writeIndex = 0;
            timerWrite.Enabled = true;
            timerBreak.Enabled = true;
        }
        
        private void btnRead_Click(object sender, EventArgs e)
        {
            Global.readIndex = 0;
            timerRead.Enabled = true;
            timerBreak.Enabled = true;
        }
        
        private void btnImport_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            OpenFileDialog folder = new OpenFileDialog();
            if(folder.ShowDialog() == DialogResult.OK)
            {

                String path = folder.FileName;
                dt = SystemUnit.importData(path);
            }
            else
             return; 
            if(null == dt)
            {
                showInfo("导入数据失败", true,false);
                return;
            }
           
            DataTable[] dts = DBHelp.devideTable(dt);
            DGV1.DataSource = dts[0];
            DGV2.DataSource = dts[1];
            setDGV(DGV1);
            setDGV(DGV2);
            
            showInfo("导入数据成功", true,true);
            toolImportFile.Text = "数据来源：" + folder.SafeFileName;
            toolImportFile.ForeColor = toolbarReadIndex.ForeColor;
        }
       
        private void btnExport_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (DialogResult.OK == folder.ShowDialog())
            {
                String path = folder.SelectedPath + "\\优选锯配方" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                if (exportData(path))
                {
                    showInfo("导出数据成功,导出文件：" + path, true, true);
                    toolbarInfo.Text = "导出数据成功";
                }
                else
                    showInfo("导出数据失败", true,false);

            }
        }
       
        private void timerWrite_Tick(object sender, EventArgs e)
        {
            if (Global.writeIndex == 0 && Global.runMode == RunMode.NORMAL)
            {
                for (int i = 0; i < Global.dataCount; i++)
                {
                    Global.procData[i].flush();
                }
                Global.runMode = RunMode.WRITE;
                readProcDataFromDGV();
                showInfo("数据发送中", false,true);
                setFormStatus(2);
            }
            toolbarSendIndex.Text = (Global.writeIndex + 1).ToString();
           // writeSingleData2(Global.writeIndex);
            writeSingleData(Global.writeIndex);
            timerWrite.Enabled = false;
        }

        private void timerRead_Tick(object sender, EventArgs e)
        {
            if(Global.readIndex == 0 && Global.runMode == RunMode.NORMAL)
            {
                for (int i = 0; i < Global.dataCount; i++)
                {
                    Global.procData[i].flush();
                }
                Global.runMode = RunMode.READ;
                showInfo("数据读取中", false,true);
                setFormStatus(2);
            }
            
            toolbarReadIndex.Text = (Global.readIndex + 1).ToString();
            readSingleData(Global.readIndex);
            timerRead.Enabled = false;
        }

        private void timerBreak_Tick(object sender, EventArgs e)
        {
            timerBreak.Interval = 1000;
            Global.breakNum++;
            if (Global.breakNum > Global.timeOut)
            {
                timerBreak.Enabled = false;
                Global.breakNum = 0;
                if (Global.runMode == RunMode.READ)
                {
                    Global.readIndex = 0;
                    toolbarReadIndex.Text = "0";
                    showInfo("读取数据失败，PLC无响应", true,false);
                    setFormStatus(1);
                }

                if (Global.runMode == RunMode.WRITE)
                {
                    Global.writeIndex = 0;
                    toolbarSendIndex.Text = "0";
                    showInfo("写入数据失败，PLC无响应", true,false);
                    setFormStatus(1);
                }
                Global.runMode = RunMode.NORMAL;
                
            }
            
        }

        private void textMulti_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int a = Convert.ToInt32(textMulti.Text);
                Global.multiple = a;
                showInfo("正在输入套数", false, true);
                textMulti.ForeColor = Color.Green;
            }
            catch (Exception)
            {
                textMulti.ForeColor = Color.Red;
                showInfo("套数输入错误，请重新输入", false, false);
            }
        }



        private void DGV2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            int index = toolImportFile.Text.IndexOf("已被编辑");
            if (index > -1)
                return;
            else
            {
                toolImportFile.Text += "-已被编辑";
                toolImportFile.ForeColor = Color.Blue;
            }
        }
                
    }
}
