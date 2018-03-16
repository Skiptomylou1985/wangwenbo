namespace OptimalSaw
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvWork = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSend = new System.Windows.Forms.Button();
            this.comboThickness = new System.Windows.Forms.ComboBox();
            this.lblSelectWidth = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnParam = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCommStatus = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblWorkingOrders = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblUndoOrders = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMacRunMode = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblMacError = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMacRunStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblShow = new System.Windows.Forms.Label();
            this.timerBreak = new System.Windows.Forms.Timer(this.components);
            this.timerRead = new System.Windows.Forms.Timer(this.components);
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.btnNew = new System.Windows.Forms.Button();
            this.lblWorkingDoneWidth = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblWorkingGrossWidth = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblWorkingRatio = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblWorkingThickness = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioBtnWorking = new System.Windows.Forms.RadioButton();
            this.radioBtnUndo = new System.Windows.Forms.RadioButton();
            this.lblWorkingDoneOrders = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblWorkingShowInfo = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWork)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 730);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Khaki;
            this.panel3.Controls.Add(this.tableLayoutPanel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 113);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1002, 614);
            this.panel3.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.dgvWork, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1002, 614);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dgvWork
            // 
            this.dgvWork.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWork.Location = new System.Drawing.Point(3, 353);
            this.dgvWork.Name = "dgvWork";
            this.dgvWork.RowTemplate.Height = 23;
            this.dgvWork.Size = new System.Drawing.Size(996, 258);
            this.dgvWork.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.lblWorkingShowInfo);
            this.panel4.Controls.Add(this.lblWorkingDoneOrders);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.lblUndoOrders);
            this.panel4.Controls.Add(this.lblWorkingOrders);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.lblTotalOrders);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.radioBtnUndo);
            this.panel4.Controls.Add(this.radioBtnWorking);
            this.panel4.Controls.Add(this.lblWorkingDoneWidth);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.lblWorkingGrossWidth);
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.lblWorkingRatio);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.lblWorkingThickness);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.btnNew);
            this.panel4.Controls.Add(this.btnSend);
            this.panel4.Controls.Add(this.comboThickness);
            this.panel4.Controls.Add(this.lblSelectWidth);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(996, 244);
            this.panel4.TabIndex = 1;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(833, 147);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 34);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "确认发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // comboThickness
            // 
            this.comboThickness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboThickness.FormattingEnabled = true;
            this.comboThickness.Location = new System.Drawing.Point(743, 155);
            this.comboThickness.Name = "comboThickness";
            this.comboThickness.Size = new System.Drawing.Size(84, 20);
            this.comboThickness.TabIndex = 2;
            this.comboThickness.SelectedIndexChanged += new System.EventHandler(this.comboThickness_SelectedIndexChanged);
            // 
            // lblSelectWidth
            // 
            this.lblSelectWidth.AutoSize = true;
            this.lblSelectWidth.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSelectWidth.Location = new System.Drawing.Point(537, 157);
            this.lblSelectWidth.Name = "lblSelectWidth";
            this.lblSelectWidth.Size = new System.Drawing.Size(208, 16);
            this.lblSelectWidth.TabIndex = 11;
            this.lblSelectWidth.Text = "请选择需要加工尺寸(厚度):";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.btnInsert);
            this.panel1.Controls.Add(this.btnTest);
            this.panel1.Controls.Add(this.btnParam);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 34);
            this.panel1.TabIndex = 0;
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(237, 0);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 34);
            this.btnInsert.TabIndex = 3;
            this.btnInsert.Text = "插入数据";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(154, 0);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 34);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "测试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnParam
            // 
            this.btnParam.Location = new System.Drawing.Point(73, 0);
            this.btnParam.Name = "btnParam";
            this.btnParam.Size = new System.Drawing.Size(75, 34);
            this.btnParam.TabIndex = 1;
            this.btnParam.Text = "参数设置";
            this.btnParam.UseVisualStyleBackColor = true;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(-1, 0);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 34);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "工单查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.lblCommStatus);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.lblMacRunMode);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.lblMacError);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lblMacRunStatus);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1002, 64);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // lblCommStatus
            // 
            this.lblCommStatus.AutoSize = true;
            this.lblCommStatus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCommStatus.Location = new System.Drawing.Point(816, 18);
            this.lblCommStatus.Name = "lblCommStatus";
            this.lblCommStatus.Size = new System.Drawing.Size(40, 16);
            this.lblCommStatus.TabIndex = 19;
            this.lblCommStatus.Text = "正常";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(736, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 16);
            this.label12.TabIndex = 18;
            this.label12.Text = "通讯状态:";
            // 
            // lblWorkingOrders
            // 
            this.lblWorkingOrders.AutoSize = true;
            this.lblWorkingOrders.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWorkingOrders.Location = new System.Drawing.Point(429, 56);
            this.lblWorkingOrders.Name = "lblWorkingOrders";
            this.lblWorkingOrders.Size = new System.Drawing.Size(16, 16);
            this.lblWorkingOrders.TabIndex = 17;
            this.lblWorkingOrders.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(301, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 16);
            this.label10.TabIndex = 16;
            this.label10.Text = "当前生产订单数:";
            // 
            // lblUndoOrders
            // 
            this.lblUndoOrders.AutoSize = true;
            this.lblUndoOrders.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUndoOrders.Location = new System.Drawing.Point(434, 14);
            this.lblUndoOrders.Name = "lblUndoOrders";
            this.lblUndoOrders.Size = new System.Drawing.Size(16, 16);
            this.lblUndoOrders.TabIndex = 15;
            this.lblUndoOrders.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(317, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "未加工订单数:";
            // 
            // lblTotalOrders
            // 
            this.lblTotalOrders.AutoSize = true;
            this.lblTotalOrders.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalOrders.Location = new System.Drawing.Point(250, 14);
            this.lblTotalOrders.Name = "lblTotalOrders";
            this.lblTotalOrders.Size = new System.Drawing.Size(16, 16);
            this.lblTotalOrders.TabIndex = 13;
            this.lblTotalOrders.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(169, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "订单总数:";
            // 
            // lblMacRunMode
            // 
            this.lblMacRunMode.AutoSize = true;
            this.lblMacRunMode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMacRunMode.Location = new System.Drawing.Point(628, 18);
            this.lblMacRunMode.Name = "lblMacRunMode";
            this.lblMacRunMode.Size = new System.Drawing.Size(72, 16);
            this.lblMacRunMode.TabIndex = 10;
            this.lblMacRunMode.Text = "远程模式";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(516, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "设备运行模式:";
            // 
            // lblMacError
            // 
            this.lblMacError.AutoSize = true;
            this.lblMacError.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMacError.Location = new System.Drawing.Point(432, 18);
            this.lblMacError.Name = "lblMacError";
            this.lblMacError.Size = new System.Drawing.Size(56, 16);
            this.lblMacError.TabIndex = 8;
            this.lblMacError.Text = "无故障";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(320, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "设备故障状态:";
            // 
            // lblMacRunStatus
            // 
            this.lblMacRunStatus.AutoSize = true;
            this.lblMacRunStatus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMacRunStatus.Location = new System.Drawing.Point(252, 18);
            this.lblMacRunStatus.Name = "lblMacRunStatus";
            this.lblMacRunStatus.Size = new System.Drawing.Size(40, 16);
            this.lblMacRunStatus.TabIndex = 6;
            this.lblMacRunStatus.Text = "停止";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(140, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "设备运行状态:";
            // 
            // lblShow
            // 
            this.lblShow.AutoSize = true;
            this.lblShow.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblShow.Location = new System.Drawing.Point(23, 8);
            this.lblShow.Name = "lblShow";
            this.lblShow.Size = new System.Drawing.Size(85, 19);
            this.lblShow.TabIndex = 3;
            this.lblShow.Text = "设备状态";
            // 
            // timerBreak
            // 
            this.timerBreak.Tick += new System.EventHandler(this.timerBreak_Tick);
            // 
            // timerRead
            // 
            this.timerRead.Tick += new System.EventHandler(this.timerRead_Tick);
            // 
            // timerStatus
            // 
            this.timerStatus.Enabled = true;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(349, 147);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 34);
            this.btnNew.TabIndex = 12;
            this.btnNew.Text = "发送新订单";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lblWorkingDoneWidth
            // 
            this.lblWorkingDoneWidth.AutoSize = true;
            this.lblWorkingDoneWidth.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWorkingDoneWidth.Location = new System.Drawing.Point(430, 87);
            this.lblWorkingDoneWidth.Name = "lblWorkingDoneWidth";
            this.lblWorkingDoneWidth.Size = new System.Drawing.Size(16, 16);
            this.lblWorkingDoneWidth.TabIndex = 34;
            this.lblWorkingDoneWidth.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(333, 87);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(96, 16);
            this.label16.TabIndex = 33;
            this.label16.Text = "已生产宽度:";
            // 
            // lblWorkingGrossWidth
            // 
            this.lblWorkingGrossWidth.AutoSize = true;
            this.lblWorkingGrossWidth.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWorkingGrossWidth.Location = new System.Drawing.Point(253, 87);
            this.lblWorkingGrossWidth.Name = "lblWorkingGrossWidth";
            this.lblWorkingGrossWidth.Size = new System.Drawing.Size(16, 16);
            this.lblWorkingGrossWidth.TabIndex = 32;
            this.lblWorkingGrossWidth.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(124, 86);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(128, 16);
            this.label18.TabIndex = 31;
            this.label18.Text = "当前订单总宽度:";
            // 
            // lblWorkingRatio
            // 
            this.lblWorkingRatio.AutoSize = true;
            this.lblWorkingRatio.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWorkingRatio.Location = new System.Drawing.Point(623, 87);
            this.lblWorkingRatio.Name = "lblWorkingRatio";
            this.lblWorkingRatio.Size = new System.Drawing.Size(16, 16);
            this.lblWorkingRatio.TabIndex = 30;
            this.lblWorkingRatio.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(529, 87);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 16);
            this.label14.TabIndex = 29;
            this.label14.Text = "订单完成率:";
            // 
            // lblWorkingThickness
            // 
            this.lblWorkingThickness.AutoSize = true;
            this.lblWorkingThickness.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWorkingThickness.Location = new System.Drawing.Point(252, 56);
            this.lblWorkingThickness.Name = "lblWorkingThickness";
            this.lblWorkingThickness.Size = new System.Drawing.Size(16, 16);
            this.lblWorkingThickness.TabIndex = 28;
            this.lblWorkingThickness.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(140, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "当前生产厚度:";
            // 
            // radioBtnWorking
            // 
            this.radioBtnWorking.AutoSize = true;
            this.radioBtnWorking.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioBtnWorking.Location = new System.Drawing.Point(18, 158);
            this.radioBtnWorking.Name = "radioBtnWorking";
            this.radioBtnWorking.Size = new System.Drawing.Size(154, 20);
            this.radioBtnWorking.TabIndex = 35;
            this.radioBtnWorking.TabStop = true;
            this.radioBtnWorking.Text = "显示当前生产订单";
            this.radioBtnWorking.UseVisualStyleBackColor = true;
            this.radioBtnWorking.CheckedChanged += new System.EventHandler(this.radioBtnWorking_CheckedChanged);
            // 
            // radioBtnUndo
            // 
            this.radioBtnUndo.AutoSize = true;
            this.radioBtnUndo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioBtnUndo.Location = new System.Drawing.Point(178, 157);
            this.radioBtnUndo.Name = "radioBtnUndo";
            this.radioBtnUndo.Size = new System.Drawing.Size(138, 20);
            this.radioBtnUndo.TabIndex = 36;
            this.radioBtnUndo.TabStop = true;
            this.radioBtnUndo.Text = "显示未生产订单";
            this.radioBtnUndo.UseVisualStyleBackColor = true;
            this.radioBtnUndo.CheckedChanged += new System.EventHandler(this.radioBtnUndo_CheckedChanged);
            // 
            // lblWorkingDoneOrders
            // 
            this.lblWorkingDoneOrders.AutoSize = true;
            this.lblWorkingDoneOrders.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWorkingDoneOrders.Location = new System.Drawing.Point(622, 56);
            this.lblWorkingDoneOrders.Name = "lblWorkingDoneOrders";
            this.lblWorkingDoneOrders.Size = new System.Drawing.Size(16, 16);
            this.lblWorkingDoneOrders.TabIndex = 38;
            this.lblWorkingDoneOrders.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(497, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 16);
            this.label7.TabIndex = 37;
            this.label7.Text = "已完成子订单数:";
            // 
            // lblWorkingShowInfo
            // 
            this.lblWorkingShowInfo.AutoSize = true;
            this.lblWorkingShowInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWorkingShowInfo.Location = new System.Drawing.Point(124, 202);
            this.lblWorkingShowInfo.Name = "lblWorkingShowInfo";
            this.lblWorkingShowInfo.Size = new System.Drawing.Size(72, 16);
            this.lblWorkingShowInfo.TabIndex = 39;
            this.lblWorkingShowInfo.Text = "提示信息";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel5.Controls.Add(this.lblShow);
            this.panel5.Location = new System.Drawing.Point(2, 8);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(121, 36);
            this.panel5.TabIndex = 20;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel6.Controls.Add(this.label5);
            this.panel6.Location = new System.Drawing.Point(0, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(121, 36);
            this.panel6.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(23, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "订单信息";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "优选锯MJD344配方管理软件 V1.0.0.0";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWork)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnParam;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblShow;
        private System.Windows.Forms.ComboBox comboThickness;
        private System.Windows.Forms.Label lblMacError;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMacRunStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblMacRunMode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblSelectWidth;
        private System.Windows.Forms.Label lblCommStatus;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblWorkingOrders;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblUndoOrders;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgvWork;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Timer timerBreak;
        private System.Windows.Forms.Timer timerRead;
        private System.Windows.Forms.Timer timerStatus;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lblWorkingDoneWidth;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblWorkingGrossWidth;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblWorkingRatio;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblWorkingThickness;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioBtnUndo;
        private System.Windows.Forms.RadioButton radioBtnWorking;
        private System.Windows.Forms.Label lblWorkingDoneOrders;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblWorkingShowInfo;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label5;
    }
}

