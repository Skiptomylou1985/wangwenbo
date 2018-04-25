namespace OptimalSaw
{
    partial class FormParam
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSetComm = new System.Windows.Forms.Button();
            this.comboParity = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBPS = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboComm = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboLogOpen = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboDataCount = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textSocketPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSetRunParam = new System.Windows.Forms.Button();
            this.comboRestFlag = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSetComm);
            this.groupBox1.Controls.Add(this.comboParity);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBPS);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboComm);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(570, 76);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口设置";
            // 
            // btnSetComm
            // 
            this.btnSetComm.Location = new System.Drawing.Point(475, 26);
            this.btnSetComm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSetComm.Name = "btnSetComm";
            this.btnSetComm.Size = new System.Drawing.Size(85, 29);
            this.btnSetComm.TabIndex = 7;
            this.btnSetComm.Text = "设置";
            this.btnSetComm.UseVisualStyleBackColor = true;
            this.btnSetComm.Click += new System.EventHandler(this.btnSetComm_Click);
            // 
            // comboParity
            // 
            this.comboParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboParity.FormattingEnabled = true;
            this.comboParity.Items.AddRange(new object[] {
            "无校验",
            "奇校验",
            "偶校验",
            "校验为1",
            "校验为0"});
            this.comboParity.Location = new System.Drawing.Point(371, 29);
            this.comboParity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboParity.Name = "comboParity";
            this.comboParity.Size = new System.Drawing.Size(85, 23);
            this.comboParity.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(326, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "校验:";
            // 
            // comboBPS
            // 
            this.comboBPS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBPS.FormattingEnabled = true;
            this.comboBPS.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboBPS.Location = new System.Drawing.Point(235, 28);
            this.comboBPS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBPS.Name = "comboBPS";
            this.comboBPS.Size = new System.Drawing.Size(85, 23);
            this.comboBPS.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "波特率:";
            // 
            // comboComm
            // 
            this.comboComm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboComm.FormattingEnabled = true;
            this.comboComm.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16"});
            this.comboComm.Location = new System.Drawing.Point(91, 29);
            this.comboComm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboComm.Name = "comboComm";
            this.comboComm.Size = new System.Drawing.Size(85, 23);
            this.comboComm.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口号:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboLogOpen);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.comboDataCount);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textSocketPort);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnSetRunParam);
            this.groupBox2.Controls.Add(this.comboRestFlag);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(5, 103);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(570, 116);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "运行参数";
            // 
            // comboLogOpen
            // 
            this.comboLogOpen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLogOpen.FormattingEnabled = true;
            this.comboLogOpen.Items.AddRange(new object[] {
            "不开启",
            "开启"});
            this.comboLogOpen.Location = new System.Drawing.Point(348, 71);
            this.comboLogOpen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboLogOpen.Name = "comboLogOpen";
            this.comboLogOpen.Size = new System.Drawing.Size(85, 23);
            this.comboLogOpen.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(235, 74);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "是否开启日志:";
            // 
            // comboDataCount
            // 
            this.comboDataCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataCount.FormattingEnabled = true;
            this.comboDataCount.Items.AddRange(new object[] {
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.comboDataCount.Location = new System.Drawing.Point(141, 72);
            this.comboDataCount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboDataCount.Name = "comboDataCount";
            this.comboDataCount.Size = new System.Drawing.Size(85, 23);
            this.comboDataCount.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 75);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "单次发送订单数:";
            // 
            // textSocketPort
            // 
            this.textSocketPort.Location = new System.Drawing.Point(348, 28);
            this.textSocketPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textSocketPort.Name = "textSocketPort";
            this.textSocketPort.Size = new System.Drawing.Size(80, 25);
            this.textSocketPort.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "网络服务端口:";
            // 
            // btnSetRunParam
            // 
            this.btnSetRunParam.Location = new System.Drawing.Point(475, 66);
            this.btnSetRunParam.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSetRunParam.Name = "btnSetRunParam";
            this.btnSetRunParam.Size = new System.Drawing.Size(85, 29);
            this.btnSetRunParam.TabIndex = 7;
            this.btnSetRunParam.Text = "设置";
            this.btnSetRunParam.UseVisualStyleBackColor = true;
            this.btnSetRunParam.Click += new System.EventHandler(this.btnSetRunParam_Click);
            // 
            // comboRestFlag
            // 
            this.comboRestFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRestFlag.FormattingEnabled = true;
            this.comboRestFlag.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboRestFlag.Location = new System.Drawing.Point(141, 28);
            this.comboRestFlag.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboRestFlag.Name = "comboRestFlag";
            this.comboRestFlag.Size = new System.Drawing.Size(85, 23);
            this.comboRestFlag.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 34);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "补发提醒阈值:";
            // 
            // FormParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 349);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormParam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormParam";
            this.Load += new System.EventHandler(this.FormParam_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSetComm;
        private System.Windows.Forms.ComboBox comboParity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBPS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboComm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSetRunParam;
        private System.Windows.Forms.ComboBox comboRestFlag;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textSocketPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboDataCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboLogOpen;
        private System.Windows.Forms.Label label7;
    }
}