﻿using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Data.OleDb;
using System.Data;

namespace TransferData
{
    class SystemUnit
    {
        [DllImport("user32.dll")]
        static extern int RegisterWindowMessage(string lpString);
        public static int WM_READSIZEBACK = RegisterWindowMessage("PLCREADSIZEBACK");
        public static int WM_WRITESIZEBACK = RegisterWindowMessage("PLCWRITESIZEBACK");
        public static int WM_READPLANBACK = RegisterWindowMessage("PLCREADPLANBACK");
        public static int WM_WRITEPLANBACK = RegisterWindowMessage("PLCWRITEPLANBACK");
        [DllImport("kernel32.dll", EntryPoint = "SetLocaleInfoA")]
        public static extern int SetLocaleInfo(int Locale, int LCType, string lpLCData);
        [DllImport("user32.dll", EntryPoint = "SendMessageTimeout")]
        public static extern long SendMessageTimeout(int hWnd, int Msg, int wParam, int lParam, int fuFlags, int uTimeout, ref int lpdwResult);
        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern int PostMessage(
            int hWnd,        // handle to destination window
            int Msg,            // message
            int wParam,         // first message parameter
            int lParam          // second message parameter
            );
        //[DllImport("user32.dll ", CharSet = CharSet.Unicode)]
        //public static extern IntPtr PostMessage(IntPtr hwnd, int wMsg, IntPtr wParam, string lParam);

        public const int LOCALE_USER_DEFAULT = 0x0400;
        public const int LOCALE_SYSTEM_DEFAULT = 0x0800;
        public const int LOCALE_SSHORTDATE = 0x1F;
        public const int LOCALE_STIMEFORMAT = 0x1003;
        public const int HWND_BROADCAST = 0xFFFF;
        public const int WM_SETTINGCHANGE = 0x001A;
        public const int SMTO_ABORTIFHUNG = 2;

        // MD5加密函数
        public static string MD5Encrypt(string strText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(strText));
            return BitConverter.ToString(result).Replace("-", "");
        } 

        // 设置日期时间格式
        public static void SetDateTimeFormat()
        {
            int val = 0;
            try
            {
                SetLocaleInfo(LOCALE_USER_DEFAULT, LOCALE_SSHORTDATE, "yyyy-MM-dd");
                SetLocaleInfo(LOCALE_USER_DEFAULT, LOCALE_STIMEFORMAT, "HH:mm:ss");
                if (0 == SendMessageTimeout(HWND_BROADCAST, WM_SETTINGCHANGE, 0, 0, SMTO_ABORTIFHUNG, 10, ref val))
                    Log.WriteLog("SystemUnit", "Error", "SendMessageTimeout失败");
            }
            catch (Exception ex)
            {
                Log.WriteLog("SystemUnit", "Error", "设置日期时间格式失败,错误信息:" + ex.Message);
            }
        }

        // 获取指定路径磁盘剩余空间大小，以Mb为单位
        public static float GetVolumeFreeSize(string path)
        {
            System.IO.DriveInfo di = new System.IO.DriveInfo(path[0].ToString());
            float freeSize = (float)di.TotalFreeSpace / 1024;
            return freeSize;
        }

        // 获取指定路径磁盘已用空间比例
        public static float GetVolumeUseScale(string path)
        {
            System.IO.DriveInfo di = new System.IO.DriveInfo(path[0].ToString());
            float Scale = (1 - (float)di.TotalFreeSpace / di.TotalSize) * 100;
            return Scale;
        }

        // 延时函数
        public static void TimeDelay(int iInterval)
        {
            DateTime now = DateTime.Now;
            while (now.AddMilliseconds(iInterval) > DateTime.Now)
            {
                Application.DoEvents();
            }
            return;
        }

        // 将Image转换为byte[]
        public static byte[] ImageToBuffer(Image Image, System.Drawing.Imaging.ImageFormat imageFormat) 
        {
            if (Image == null) { return null; }
            byte[] data = null;
            try
            {
                using (MemoryStream oMemoryStream = new MemoryStream())
                {
                    using (Bitmap oBitmap = new Bitmap(Image))
                    {
                        oBitmap.Save(oMemoryStream, imageFormat);
                        oMemoryStream.Position = 0;
                        data = new byte[oMemoryStream.Length];
                        oMemoryStream.Read(data, 0, Convert.ToInt32(oMemoryStream.Length));
                        oMemoryStream.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("SystemUnit", "Error", "转换图像时错误,错误信息:" + ex.Message);
            }
            return data;
        }

        // 将byte[]转换为Image     
        public static Image BufferToImage(byte[] Buffer)
        {
            if (Buffer == null || Buffer.Length == 0) { return null; }
            MemoryStream oMemoryStream = null;
            byte[] data = null;
            Image oImage = null;
            Bitmap oBitmap = null;
            data = (byte[])Buffer.Clone();
            try
            {
                oMemoryStream = new MemoryStream(Buffer);
                oMemoryStream.Position = 0;
                oImage = System.Drawing.Image.FromStream(oMemoryStream);
                oBitmap = new Bitmap(oImage);
            }
            catch (Exception ex)
            {
                Log.WriteLog("SystemUnit", "Error", "转换图像时错误,错误信息:" + ex.Message);
            }
            finally
            {
                oMemoryStream.Dispose();
            }
            return oBitmap;
        }

        // 将Struct转换为byte[]
        public static byte[] StrutsToBytesArray(object structObj)
        {
            //得到结构体的大小
            int size = Marshal.SizeOf(structObj);
            //创建byte数组
            byte[] bytes = new byte[size];
            //分配结构体大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将结构体拷到分配好的内存空间
            Marshal.StructureToPtr(structObj, structPtr, false);
            //从内存空间拷到byte数组
            Marshal.Copy(structPtr, bytes, 0, size);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            //返回byte数组
            return bytes;
        }

        // 将byte[]转换为struct
        public static object BytesToStruts(byte[] bytes, Type type)
        {
            //得到结构体的大小
            int size = Marshal.SizeOf(type);
            //byte数组长度小于结构体的大小
            if (size > bytes.Length)
            {
                //返回空
                return null;
            }
            //分配结构体大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将byte数组拷到分配好的内存空间
            Marshal.Copy(bytes, 0, structPtr, size);
            //将内存空间转换为目标结构体
            object obj = Marshal.PtrToStructure(structPtr, type);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            //返回结构体
            return obj;
        }
        public static void KillProcess(String appName)
        {
            try
            {
                System.Diagnostics.Process[] myProcesses = System.Diagnostics.Process.GetProcesses();
                foreach (System.Diagnostics.Process myProcess in myProcesses)
                {
                    if (appName == myProcess.ProcessName)
                        myProcess.Kill();
                }
            }
            catch (Exception ee)
            { }
        }
        public static string ToHexString(byte[] bytes) //

        {
            string hexString = string.Empty;

            if (bytes != null)

            {

                StringBuilder strB = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)

                {

                    strB.Append(bytes[i].ToString("X2") + " ");

                }

                hexString = strB.ToString();

            }
            return hexString;

        }
        public static DataTable importData(string Path)
        {
            DataSet ds = null;
            string strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "Data Source=" + Path + ";" + "Extended Properties='Excel 12.0; HDR=NO; IMEX=1'";
            OleDbConnection conn = new OleDbConnection(strConn);
            try
            {
                conn.Open();
                string strExcel = "";
                OleDbDataAdapter myCommand = null;

                strExcel = "select * from [sheet1$A:C]";
                myCommand = new OleDbDataAdapter(strExcel, strConn);
                ds = new DataSet();
                myCommand.Fill(ds, "table1");
            }
            catch (Exception ex)
            {
                Log.WriteLog("MainForm", "ERROR", "【importData】 " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
            return ds.Tables[0];


        }
        public static bool ExportDataToExcel(System.Data.DataTable srcDataTable, string excelFilePath)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            object missing = System.Reflection.Missing.Value;

            //导出到execl   
            try
            {
                if (xlApp == null)
                {
                    MessageBox.Show("无法创建Excel对象，可能您的电脑未安装Excel!");
                    return false;
                }

                Microsoft.Office.Interop.Excel.Workbooks xlBooks = xlApp.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook xlBook = xlBooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet xlSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlBook.Worksheets[1];

                //让后台执行设置为不可见，为true的话会看到打开一个Excel，然后数据在往里写  
                xlApp.Visible = false;

                object[,] objData = new object[srcDataTable.Rows.Count + 1, srcDataTable.Columns.Count];
                //首先将数据写入到一个二维数组中  
                for (int i = 0; i < srcDataTable.Columns.Count; i++)
                {
                    objData[0, i] = srcDataTable.Columns[i].ColumnName;
                }
                if (srcDataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < srcDataTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < srcDataTable.Columns.Count; j++)
                        {
                            objData[i + 1, j] = srcDataTable.Rows[i][j];
                        }
                    }
                }

                string startCol = "A";
                int iCnt = (srcDataTable.Columns.Count / 26);
                string endColSignal = (iCnt == 0 ? "" : ((char)('A' + (iCnt - 1))).ToString());
                string endCol = endColSignal + ((char)('A' + srcDataTable.Columns.Count - iCnt * 26 - 1)).ToString();
                Microsoft.Office.Interop.Excel.Range range = xlSheet.get_Range(startCol + "1", endCol + (srcDataTable.Rows.Count - iCnt * 26 + 1).ToString());

                range.Value = objData; //给Exccel中的Range整体赋值  
                range.EntireColumn.AutoFit(); //设定Excel列宽度自适应  
                xlSheet.get_Range(startCol + "1", endCol + "1").Font.Bold = 1;//Excel文件列名 字体设定为Bold  

                //设置禁止弹出保存和覆盖的询问提示框  
                xlApp.DisplayAlerts = false;
                xlApp.AlertBeforeOverwriting = false;
                //if (File.Exists(excelFilePath))
                //    File.Delete(excelFilePath);

                if (xlSheet != null)
                {
                    xlSheet.SaveAs(excelFilePath, missing, missing, missing, missing, missing, missing, missing, missing, missing);
                    xlApp.Quit();
                    //KillProcess(xlApp);
                    //SystemUnit.KillProcess(xlApp);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("SystemUnit", "ERROR", "【ExportDataToExcel】 " + ex.Message);
                xlApp.Quit();
                //KillProcess(xlApp);
                //throw ex;
                return false;
            }
            return true;
        }


        #region 窗体圆角
        public static void SetWindowRegion(Form frm)
        {
            GraphicsPath FormPath;
            Rectangle rect;
            FormPath = new System.Drawing.Drawing2D.GraphicsPath();
            if (frm.WindowState == FormWindowState.Normal)
                rect = new Rectangle(-1, -1, frm.Width + 1, frm.Height);
            else if (frm.WindowState == FormWindowState.Maximized)
                rect = new Rectangle(-1, -1, Screen.PrimaryScreen.Bounds.Width + 1, Screen.PrimaryScreen.Bounds.Height);
            else
                rect = new Rectangle(-1, -1, frm.Width + 1, frm.Height);
            FormPath = GetRoundedRectPath(rect, 24);
            frm.Region = new Region(FormPath);
        }

        //窗体圆角
        private static GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();
            // 左上角
            path.AddArc(arcRect, 185, 90);
            // 右上角
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 275, 90);
            // 右下角
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 356, 90);
            // 左下角
            arcRect.X = rect.Left;
            arcRect.Width += 2;
            arcRect.Height += 2;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }
        #endregion

        #region 按钮圆角
        public static void SetButtonRegion(Button btn, int radius)
        {
            GraphicsPath BtnPath;
            BtnPath = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(-1, -1, btn.Width + 1, btn.Height);
            BtnPath = GetRoundedRectPath(rect, radius);
            btn.Region = new Region(BtnPath);
        }
        #endregion

        public static ushort getCRC(byte[] buff,int index,int len)
        {
            byte uchCRCHi = 0xFF;
            byte uchCRCLo = 0xFF;
            int uIndex = 0;
            int j = 0;
            int length = len;
            while (length-- > 0)
            {
                uIndex = uchCRCHi ^ buff[index+j++]; /* 计算CRC */
                uchCRCHi = (byte)(uchCRCLo ^ auchCRCHi[uIndex]);
                uchCRCLo = (byte)auchCRCLo[uIndex];
            }
            ushort ret = (ushort)(uchCRCHi<< 8 |uchCRCLo);
            return ret;
        }
        static byte[] auchCRCHi = {
                0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
                0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
                0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
                0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
                0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1,
                0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
                0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1,
                0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
                0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
                0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40,
                0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1,
                0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
                0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
                0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40,
                0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
                0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
                0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
                0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
                0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
                0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
                0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
                0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40,
                0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1,
                0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
                0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
                0x80, 0x41, 0x00, 0xC1, 0x81, 0x40
                };
        static byte[] auchCRCLo = {
                0x00, 0xC0, 0xC1, 0x01, 0xC3, 0x03, 0x02, 0xC2, 0xC6, 0x06,
                0x07, 0xC7, 0x05, 0xC5, 0xC4, 0x04, 0xCC, 0x0C, 0x0D, 0xCD,
                0x0F, 0xCF, 0xCE, 0x0E, 0x0A, 0xCA, 0xCB, 0x0B, 0xC9, 0x09,
                0x08, 0xC8, 0xD8, 0x18, 0x19, 0xD9, 0x1B, 0xDB, 0xDA, 0x1A,
                0x1E, 0xDE, 0xDF, 0x1F, 0xDD, 0x1D, 0x1C, 0xDC, 0x14, 0xD4,
                0xD5, 0x15, 0xD7, 0x17, 0x16, 0xD6, 0xD2, 0x12, 0x13, 0xD3,
                0x11, 0xD1, 0xD0, 0x10, 0xF0, 0x30, 0x31, 0xF1, 0x33, 0xF3,
                0xF2, 0x32, 0x36, 0xF6, 0xF7, 0x37, 0xF5, 0x35, 0x34, 0xF4,
                0x3C, 0xFC, 0xFD, 0x3D, 0xFF, 0x3F, 0x3E, 0xFE, 0xFA, 0x3A,
                0x3B, 0xFB, 0x39, 0xF9, 0xF8, 0x38, 0x28, 0xE8, 0xE9, 0x29,
                0xEB, 0x2B, 0x2A, 0xEA, 0xEE, 0x2E, 0x2F, 0xEF, 0x2D, 0xED,
                0xEC, 0x2C, 0xE4, 0x24, 0x25, 0xE5, 0x27, 0xE7, 0xE6, 0x26,
                0x22, 0xE2, 0xE3, 0x23, 0xE1, 0x21, 0x20, 0xE0, 0xA0, 0x60,
                0x61, 0xA1, 0x63, 0xA3, 0xA2, 0x62, 0x66, 0xA6, 0xA7, 0x67,
                0xA5, 0x65, 0x64, 0xA4, 0x6C, 0xAC, 0xAD, 0x6D, 0xAF, 0x6F,
                0x6E, 0xAE, 0xAA, 0x6A, 0x6B, 0xAB, 0x69, 0xA9, 0xA8, 0x68,
                0x78, 0xB8, 0xB9, 0x79, 0xBB, 0x7B, 0x7A, 0xBA, 0xBE, 0x7E,
                0x7F, 0xBF, 0x7D, 0xBD, 0xBC, 0x7C, 0xB4, 0x74, 0x75, 0xB5,
                0x77, 0xB7, 0xB6, 0x76, 0x72, 0xB2, 0xB3, 0x73, 0xB1, 0x71,
                0x70, 0xB0, 0x50, 0x90, 0x91, 0x51, 0x93, 0x53, 0x52, 0x92,
                0x96, 0x56, 0x57, 0x97, 0x55, 0x95, 0x94, 0x54, 0x9C, 0x5C,
                0x5D, 0x9D, 0x5F, 0x9F, 0x9E, 0x5E, 0x5A, 0x9A, 0x9B, 0x5B,
                0x99, 0x59, 0x58, 0x98, 0x88, 0x48, 0x49, 0x89, 0x4B, 0x8B,
                0x8A, 0x4A, 0x4E, 0x8E, 0x8F, 0x4F, 0x8D, 0x4D, 0x4C, 0x8C,
                0x44, 0x84, 0x85, 0x45, 0x87, 0x47, 0x46, 0x86, 0x82, 0x42,
                0x43, 0x83, 0x41, 0x81, 0x80, 0x40
                };
       
    }
}
