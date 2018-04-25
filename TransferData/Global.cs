using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace TransferData
{
    class Global
    {
        public static RunMode runMode = RunMode.NORMAL;  //当前运行模式
        public static int writeIndex = 0;  //写序号
        public static int readIndex = 0;  //读序号
        public static DataFormat[] procData = null;  //
        public static int dataCount = 40;  //数据长度
        public static byte stationAddr = 0x01; //站地址
        public static byte readCmd = 0x03;    //读数据命令号
        public static byte writeCmd = 0x10;   //写数据命令号
        public static int offset = 6000;      //尺寸和数量数据起始偏移地址
        public static int pinOffset = 6800;   //管脚数据起始偏移地址
        public static string defaultPath = Application.StartupPath + "\\default.xlsx";   //默认数据路径及文件名
        public static string xmlPath = Application.StartupPath + "\\config.xml";
        public static String comPort = "COM1";  
        public static Int32 comBPS = 19200;
        public static int comTimeout = 100;
        public static int regCount = 2;     //寄存器所占字节数
        public static int breakNum = 0;
        public static int sizeDistance = 6;
        public static bool bLogOpen = false;
        public static int timeOut = 3;
        public static Parity parity = Parity.Even;
        public static int multiple = 1;
    }
    struct DataFormat
    {
        public Int32 size;
        public Int32 planCount;
        public Int16 pin;
        public bool isSended;
        public bool isReaded;
        public void flush()
        {
            this.size = 0;
            this.planCount = 0;
            this.pin = 0;
            this.isSended = false;
            this.isReaded = false;
        }
    }
    public enum RunMode
    {
        NORMAL = 0,
        WRITE = 1,
        READ = 2,
    }

    public enum ReturnResult
    {
        SUCCESS = 1,
        FAIL = 0
    }

    public enum DataType
    {
        SIZEANDPLAN = 1,
        PIN =2
    }
    
}
