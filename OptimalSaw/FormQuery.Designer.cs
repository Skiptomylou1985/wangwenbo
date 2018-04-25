namespace OptimalSaw
{
    partial class FormQuery
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkComplete = new System.Windows.Forms.CheckBox();
            this.checkReceive = new System.Windows.Forms.CheckBox();
            this.checkSchedule = new System.Windows.Forms.CheckBox();
            this.comboType = new System.Windows.Forms.ComboBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.comboStatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpCompleteEnd = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpCompleteBegin = new System.Windows.Forms.DateTimePicker();
            this.dtpReceiveEnd = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpReceiveBegin = new System.Windows.Forms.DateTimePicker();
            this.dtpScheduleEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpScheduleBegin = new System.Windows.Forms.DateTimePicker();
            this.textOrder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblGrossWidth = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.lblWorth = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.lblMachineCode = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.lblWorker = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.lblThickness = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lbllength = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.lblUndone = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblDone = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblGross = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblReceive = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblComplete = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblSchedule = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblOrder = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OldLace;
            this.panel1.Controls.Add(this.checkComplete);
            this.panel1.Controls.Add(this.checkReceive);
            this.panel1.Controls.Add(this.checkSchedule);
            this.panel1.Controls.Add(this.comboType);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.comboStatus);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.dtpCompleteEnd);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dtpCompleteBegin);
            this.panel1.Controls.Add(this.dtpReceiveEnd);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtpReceiveBegin);
            this.panel1.Controls.Add(this.dtpScheduleEnd);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtpScheduleBegin);
            this.panel1.Controls.Add(this.textOrder);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 100);
            this.panel1.TabIndex = 0;
            // 
            // checkComplete
            // 
            this.checkComplete.AutoSize = true;
            this.checkComplete.Location = new System.Drawing.Point(158, 38);
            this.checkComplete.Name = "checkComplete";
            this.checkComplete.Size = new System.Drawing.Size(72, 16);
            this.checkComplete.TabIndex = 23;
            this.checkComplete.Text = "完成日期";
            this.checkComplete.UseVisualStyleBackColor = true;
            // 
            // checkReceive
            // 
            this.checkReceive.AutoSize = true;
            this.checkReceive.Location = new System.Drawing.Point(158, 67);
            this.checkReceive.Name = "checkReceive";
            this.checkReceive.Size = new System.Drawing.Size(72, 16);
            this.checkReceive.TabIndex = 22;
            this.checkReceive.Text = "接收日期";
            this.checkReceive.UseVisualStyleBackColor = true;
            // 
            // checkSchedule
            // 
            this.checkSchedule.AutoSize = true;
            this.checkSchedule.Location = new System.Drawing.Point(158, 12);
            this.checkSchedule.Name = "checkSchedule";
            this.checkSchedule.Size = new System.Drawing.Size(72, 16);
            this.checkSchedule.TabIndex = 21;
            this.checkSchedule.Text = "排产日期";
            this.checkSchedule.UseVisualStyleBackColor = true;
            // 
            // comboType
            // 
            this.comboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboType.FormattingEnabled = true;
            this.comboType.Location = new System.Drawing.Point(67, 65);
            this.comboType.Name = "comboType";
            this.comboType.Size = new System.Drawing.Size(83, 20);
            this.comboType.TabIndex = 20;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(673, 22);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 40);
            this.btnExport.TabIndex = 19;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(579, 22);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 40);
            this.btnQuery.TabIndex = 18;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(36, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "材质";
            // 
            // comboStatus
            // 
            this.comboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStatus.FormattingEnabled = true;
            this.comboStatus.Items.AddRange(new object[] {
            "全部",
            "未生产",
            "生产中",
            "已暂停",
            "已取消",
            "已终止",
            "已完成"});
            this.comboStatus.Location = new System.Drawing.Point(67, 10);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(83, 20);
            this.comboStatus.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(13, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "工单状态";
            // 
            // dtpCompleteEnd
            // 
            this.dtpCompleteEnd.Location = new System.Drawing.Point(354, 36);
            this.dtpCompleteEnd.Name = "dtpCompleteEnd";
            this.dtpCompleteEnd.Size = new System.Drawing.Size(106, 21);
            this.dtpCompleteEnd.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(339, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "~";
            // 
            // dtpCompleteBegin
            // 
            this.dtpCompleteBegin.Location = new System.Drawing.Point(231, 36);
            this.dtpCompleteBegin.Name = "dtpCompleteBegin";
            this.dtpCompleteBegin.Size = new System.Drawing.Size(106, 21);
            this.dtpCompleteBegin.TabIndex = 11;
            // 
            // dtpReceiveEnd
            // 
            this.dtpReceiveEnd.Location = new System.Drawing.Point(354, 64);
            this.dtpReceiveEnd.Name = "dtpReceiveEnd";
            this.dtpReceiveEnd.Size = new System.Drawing.Size(106, 21);
            this.dtpReceiveEnd.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(339, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "~";
            // 
            // dtpReceiveBegin
            // 
            this.dtpReceiveBegin.Location = new System.Drawing.Point(231, 64);
            this.dtpReceiveBegin.Name = "dtpReceiveBegin";
            this.dtpReceiveBegin.Size = new System.Drawing.Size(106, 21);
            this.dtpReceiveBegin.TabIndex = 7;
            // 
            // dtpScheduleEnd
            // 
            this.dtpScheduleEnd.Location = new System.Drawing.Point(354, 9);
            this.dtpScheduleEnd.Name = "dtpScheduleEnd";
            this.dtpScheduleEnd.Size = new System.Drawing.Size(106, 21);
            this.dtpScheduleEnd.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(339, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "~";
            // 
            // dtpScheduleBegin
            // 
            this.dtpScheduleBegin.Location = new System.Drawing.Point(231, 9);
            this.dtpScheduleBegin.Name = "dtpScheduleBegin";
            this.dtpScheduleBegin.Size = new System.Drawing.Size(106, 21);
            this.dtpScheduleBegin.TabIndex = 3;
            // 
            // textOrder
            // 
            this.textOrder.Location = new System.Drawing.Point(67, 37);
            this.textOrder.Name = "textOrder";
            this.textOrder.Size = new System.Drawing.Size(83, 21);
            this.textOrder.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(25, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "指令单";
            // 
            // dgvOrder
            // 
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Location = new System.Drawing.Point(12, 118);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.RowTemplate.Height = 23;
            this.dgvOrder.Size = new System.Drawing.Size(760, 257);
            this.dgvOrder.TabIndex = 1;
            this.dgvOrder.SelectionChanged += new System.EventHandler(this.dgvOrder_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.lblGrossWidth);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblRemark);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.lblWorth);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.lblMachineCode);
            this.groupBox1.Controls.Add(this.label35);
            this.groupBox1.Controls.Add(this.lblWorker);
            this.groupBox1.Controls.Add(this.label37);
            this.groupBox1.Controls.Add(this.lblThickness);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.lblWidth);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.lbllength);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.lblUndone);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.lblDone);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.lblGross);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.lblReceive);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.lblComplete);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.lblSchedule);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.lblType);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblOrder);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 391);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 159);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "工单详情";
            // 
            // lblGrossWidth
            // 
            this.lblGrossWidth.AutoSize = true;
            this.lblGrossWidth.Location = new System.Drawing.Point(95, 83);
            this.lblGrossWidth.Name = "lblGrossWidth";
            this.lblGrossWidth.Size = new System.Drawing.Size(0, 12);
            this.lblGrossWidth.TabIndex = 33;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(35, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 32;
            this.label10.Text = "总宽度：";
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(95, 133);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(0, 12);
            this.lblRemark.TabIndex = 31;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(48, 133);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(41, 12);
            this.label31.TabIndex = 30;
            this.label31.Text = "备注：";
            // 
            // lblWorth
            // 
            this.lblWorth.AutoSize = true;
            this.lblWorth.Location = new System.Drawing.Point(664, 83);
            this.lblWorth.Name = "lblWorth";
            this.lblWorth.Size = new System.Drawing.Size(0, 12);
            this.lblWorth.TabIndex = 29;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(617, 83);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(41, 12);
            this.label33.TabIndex = 28;
            this.label33.Text = "产值：";
            // 
            // lblMachineCode
            // 
            this.lblMachineCode.AutoSize = true;
            this.lblMachineCode.Location = new System.Drawing.Point(664, 54);
            this.lblMachineCode.Name = "lblMachineCode";
            this.lblMachineCode.Size = new System.Drawing.Size(0, 12);
            this.lblMachineCode.TabIndex = 27;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(593, 54);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(65, 12);
            this.label35.TabIndex = 26;
            this.label35.Text = "机器编码：";
            // 
            // lblWorker
            // 
            this.lblWorker.AutoSize = true;
            this.lblWorker.Location = new System.Drawing.Point(664, 25);
            this.lblWorker.Name = "lblWorker";
            this.lblWorker.Size = new System.Drawing.Size(0, 12);
            this.lblWorker.TabIndex = 25;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(604, 25);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(53, 12);
            this.label37.TabIndex = 24;
            this.label37.Text = "操作员：";
            // 
            // lblThickness
            // 
            this.lblThickness.AutoSize = true;
            this.lblThickness.Location = new System.Drawing.Point(475, 110);
            this.lblThickness.Name = "lblThickness";
            this.lblThickness.Size = new System.Drawing.Size(0, 12);
            this.lblThickness.TabIndex = 23;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(428, 110);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(41, 12);
            this.label25.TabIndex = 22;
            this.label25.Text = "厚度：";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(284, 110);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(0, 12);
            this.lblWidth.TabIndex = 21;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(237, 110);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(41, 12);
            this.label27.TabIndex = 20;
            this.label27.Text = "宽度：";
            // 
            // lbllength
            // 
            this.lbllength.AutoSize = true;
            this.lbllength.Location = new System.Drawing.Point(95, 110);
            this.lbllength.Name = "lbllength";
            this.lbllength.Size = new System.Drawing.Size(0, 12);
            this.lbllength.TabIndex = 19;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(48, 110);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(41, 12);
            this.label29.TabIndex = 18;
            this.label29.Text = "长度：";
            // 
            // lblUndone
            // 
            this.lblUndone.AutoSize = true;
            this.lblUndone.Location = new System.Drawing.Point(475, 83);
            this.lblUndone.Name = "lblUndone";
            this.lblUndone.Size = new System.Drawing.Size(0, 12);
            this.lblUndone.TabIndex = 17;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(404, 83);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 12);
            this.label19.TabIndex = 16;
            this.label19.Text = "未生产量：";
            // 
            // lblDone
            // 
            this.lblDone.AutoSize = true;
            this.lblDone.Location = new System.Drawing.Point(284, 83);
            this.lblDone.Name = "lblDone";
            this.lblDone.Size = new System.Drawing.Size(0, 12);
            this.lblDone.TabIndex = 15;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(213, 83);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(65, 12);
            this.label21.TabIndex = 14;
            this.label21.Text = "已生产量：";
            // 
            // lblGross
            // 
            this.lblGross.AutoSize = true;
            this.lblGross.Location = new System.Drawing.Point(664, 110);
            this.lblGross.Name = "lblGross";
            this.lblGross.Size = new System.Drawing.Size(0, 12);
            this.lblGross.TabIndex = 13;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(617, 110);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(41, 12);
            this.label23.TabIndex = 12;
            this.label23.Text = "数量：";
            // 
            // lblReceive
            // 
            this.lblReceive.AutoSize = true;
            this.lblReceive.Location = new System.Drawing.Point(475, 54);
            this.lblReceive.Name = "lblReceive";
            this.lblReceive.Size = new System.Drawing.Size(0, 12);
            this.lblReceive.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(404, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 10;
            this.label13.Text = "接收日期：";
            // 
            // lblComplete
            // 
            this.lblComplete.AutoSize = true;
            this.lblComplete.Location = new System.Drawing.Point(284, 54);
            this.lblComplete.Name = "lblComplete";
            this.lblComplete.Size = new System.Drawing.Size(0, 12);
            this.lblComplete.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(213, 54);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 8;
            this.label15.Text = "完成日期：";
            // 
            // lblSchedule
            // 
            this.lblSchedule.AutoSize = true;
            this.lblSchedule.Location = new System.Drawing.Point(95, 54);
            this.lblSchedule.Name = "lblSchedule";
            this.lblSchedule.Size = new System.Drawing.Size(0, 12);
            this.lblSchedule.TabIndex = 7;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(24, 54);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 12);
            this.label17.TabIndex = 6;
            this.label17.Text = "排产日期：";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(475, 25);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(0, 12);
            this.lblType.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(428, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 4;
            this.label11.Text = "材质：";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(284, 25);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 12);
            this.lblStatus.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(213, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "当前状态：";
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Location = new System.Drawing.Point(95, 25);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(0, 12);
            this.lblOrder.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "生产指令单：";
            // 
            // FormQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvOrder);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工单查询";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.TextBox textOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpScheduleEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpScheduleBegin;
        private System.Windows.Forms.DateTimePicker dtpReceiveEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpReceiveBegin;
        private System.Windows.Forms.DateTimePicker dtpCompleteEnd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpCompleteBegin;
        private System.Windows.Forms.ComboBox comboStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ComboBox comboType;
        private System.Windows.Forms.CheckBox checkComplete;
        private System.Windows.Forms.CheckBox checkReceive;
        private System.Windows.Forms.CheckBox checkSchedule;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUndone;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblDone;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblGross;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblReceive;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblComplete;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblSchedule;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblThickness;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lbllength;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label lblWorth;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label lblMachineCode;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label lblWorker;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label lblGrossWidth;
        private System.Windows.Forms.Label label10;
    }
}