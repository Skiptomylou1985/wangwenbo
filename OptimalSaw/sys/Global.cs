using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace OptimalSaw
{
    class Global
    {
        public static RunMode runMode = RunMode.NORMAL;  //当前运行模式
       // public static int writeIndex = 0;  //写序号
       // public static int readIndex = 0;  //读序号
        public static DataFormat[] procData =  new DataFormat[30];  //
        public static int socketPort = 6700;  //网络监听端口
        public static int dataCount = 20;  //单次发送最长数据长度
        public static bool isSendAll = true;  //是否一次发完
        public static bool isDataOver = true;  //是否超过30最大处理量
        public static byte stationAddr = 0x01; //站地址
        public static byte readCmd = 0x03;    //读数据命令号
        public static byte writeCmd = 0x10;   //写数据命令号
        public static int offset = 6000;      //尺寸和数量数据起始偏移地址
        public static int runStatusOffset = 27; //运行状态查询偏移地址
        public static int pinOffset = 6800;   //管脚数据起始偏移地址
        public static int alertOffset = 32;   //提示补发订单命令偏移地址
        public static string defaultPath = Application.StartupPath + "\\default.xlsx";   //默认数据路径及文件名
        public static int regCount = 2;     //寄存器所占字节数
        public static int breakNum = 0;
        public static int sizeDistance = 6;
        public static bool bLogOpen = true;
        public static int timeOut = 3;
        public static Parity parity = Parity.Even;
        //public static int multiple = 1;
        public static DBInfo dbInfo;
        public static MysqlHelper mysqlHelper;
        //public static SerialPort comm;
        public static CommHelper commHelper;

        public static bool dataIsChanged = false;
        public static bool readDataDone = true;
        public static int nRestFlag = 5;
        
        public static int totalOrders = 0;
        public static int workingOrders = 0;
        public static int queueOrders = 0;
        public static int cacelOrders = 0;
        public static int terminateOrders = 0;
        public static int completeOrders = 0;
        public static int undoOrders = 0;

        public static int workingGrossWidth = 0;
        public static int workingThickness = 0;
        public static int workingDone = 0;
        public static int workingDoneRatio = 0;
        public static int workingDoneOrders = 0;

        public static int macRunStatus = 0; //设备运行状态  1 运行  0 停止
        public static int macErrorStatus = 0; //设备故障状态  1 故障  0 无故障
        public static int macRunMode = 1;   //设备运行模式  1 远程模式  0 本地模式
        public static int macCommStatus = 1; //设备通讯状态 1正常  0 通讯故障 


       
        
    }
    struct DataFormat
    {
        public int id;
        public int Lenth;
        public int Thickness;
        public int GrossWidth;
        public int Done;
        public int status;
        public Int16 pin;
        public void flush()
        {
            this.id = 0;
            this.Lenth = 0;
            this.GrossWidth = 0;
            this.Done = 0;
            this.status = 0;
            this.pin = 0;
            this.Thickness = 0;
        }
    }
    public enum RunMode
    {
        NORMAL = 0,
        WRITE = 1,
        READDATA = 2,
        READSTATUS=3
    }

    public enum ReturnResult
    {
        SUCCESS = 1,
        FAIL = 0
    }

    public enum DataType
    {
        WRITEDONE = 1,
        WRITECONTINUE=2,
        STATUS = 3,
        PIN = 4,
        READDONE = 5,
        READCONTINUE = 6
    }

    public enum OrderStatus
    {
        NONE = 0,
        UNDO = 1,
        WORKING = 2,
        PAUSED = 3,
        CANCELED = 4,
        TERMINATED = 5,
        COMPLETED = 6
    }
    
}
