namespace JsonDemo
{
    partial class Form1
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
            this.btn_test = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_connect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textOrder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpSchedule = new System.Windows.Forms.DateTimePicker();
            this.textLength = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textWidth = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textThickness = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textUndo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textDone = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textGross = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpComplete = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.textCode = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textWorth = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textWorker = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textRemark = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(304, 35);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(75, 21);
            this.btn_test.TabIndex = 0;
            this.btn_test.Text = "发送";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "服务IP：";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(57, 22);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(86, 21);
            this.txtIP.TabIndex = 2;
            this.txtIP.Text = "127.0.0.1";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(191, 22);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(45, 21);
            this.txtPort.TabIndex = 4;
            this.txtPort.Text = "6789";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "端口：";
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(316, 20);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(75, 23);
            this.btn_connect.TabIndex = 5;
            this.btn_connect.Text = "连接";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textRemark);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.textWorth);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.textWorker);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.textCode);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.dtpComplete);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.textUndo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textDone);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textGross);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.textThickness);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textWidth);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textLength);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpSchedule);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textOrder);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btn_test);
            this.groupBox1.Location = new System.Drawing.Point(12, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 269);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "订单数据";
            // 
            // textOrder
            // 
            this.textOrder.Location = new System.Drawing.Point(79, 35);
            this.textOrder.Name = "textOrder";
            this.textOrder.Size = new System.Drawing.Size(196, 21);
            this.textOrder.TabIndex = 4;
            this.textOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "生产指令单:";
            // 
            // textType
            // 
            this.textType.Location = new System.Drawing.Point(79, 62);
            this.textType.Name = "textType";
            this.textType.Size = new System.Drawing.Size(87, 21);
            this.textType.TabIndex = 6;
            this.textType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "材质、类型:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(229, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "排产日期:";
            // 
            // dtpSchedule
            // 
            this.dtpSchedule.Location = new System.Drawing.Point(287, 62);
            this.dtpSchedule.Name = "dtpSchedule";
            this.dtpSchedule.Size = new System.Drawing.Size(127, 21);
            this.dtpSchedule.TabIndex = 8;
            // 
            // textLength
            // 
            this.textLength.Location = new System.Drawing.Point(80, 115);
            this.textLength.Name = "textLength";
            this.textLength.Size = new System.Drawing.Size(86, 21);
            this.textLength.TabIndex = 10;
            this.textLength.Text = "0";
            this.textLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "长度:";
            // 
            // textWidth
            // 
            this.textWidth.Location = new System.Drawing.Point(80, 145);
            this.textWidth.Name = "textWidth";
            this.textWidth.Size = new System.Drawing.Size(86, 21);
            this.textWidth.TabIndex = 12;
            this.textWidth.Text = "0";
            this.textWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "宽度:";
            // 
            // textThickness
            // 
            this.textThickness.Location = new System.Drawing.Point(80, 172);
            this.textThickness.Name = "textThickness";
            this.textThickness.Size = new System.Drawing.Size(86, 21);
            this.textThickness.TabIndex = 14;
            this.textThickness.Text = "0";
            this.textThickness.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "厚度:";
            // 
            // textUndo
            // 
            this.textUndo.Location = new System.Drawing.Point(287, 172);
            this.textUndo.Name = "textUndo";
            this.textUndo.Size = new System.Drawing.Size(75, 21);
            this.textUndo.TabIndex = 20;
            this.textUndo.Text = "0";
            this.textUndo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(252, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "未产:";
            // 
            // textDone
            // 
            this.textDone.Location = new System.Drawing.Point(287, 145);
            this.textDone.Name = "textDone";
            this.textDone.Size = new System.Drawing.Size(75, 21);
            this.textDone.TabIndex = 18;
            this.textDone.Text = "0";
            this.textDone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(252, 148);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "已产:";
            // 
            // textGross
            // 
            this.textGross.Location = new System.Drawing.Point(287, 115);
            this.textGross.Name = "textGross";
            this.textGross.Size = new System.Drawing.Size(75, 21);
            this.textGross.TabIndex = 16;
            this.textGross.Text = "0";
            this.textGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(252, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 15;
            this.label11.Text = "总量:";
            // 
            // dtpComplete
            // 
            this.dtpComplete.Location = new System.Drawing.Point(287, 90);
            this.dtpComplete.Name = "dtpComplete";
            this.dtpComplete.Size = new System.Drawing.Size(127, 21);
            this.dtpComplete.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(228, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 21;
            this.label12.Text = "完成日期:";
            // 
            // textCode
            // 
            this.textCode.Location = new System.Drawing.Point(79, 90);
            this.textCode.Name = "textCode";
            this.textCode.Size = new System.Drawing.Size(87, 21);
            this.textCode.TabIndex = 24;
            this.textCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 93);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 12);
            this.label13.TabIndex = 23;
            this.label13.Text = "机器编码:";
            // 
            // textWorth
            // 
            this.textWorth.Location = new System.Drawing.Point(287, 199);
            this.textWorth.Name = "textWorth";
            this.textWorth.Size = new System.Drawing.Size(75, 21);
            this.textWorth.TabIndex = 28;
            this.textWorth.Text = "0";
            this.textWorth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(252, 202);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 12);
            this.label14.TabIndex = 27;
            this.label14.Text = "产值:";
            // 
            // textWorker
            // 
            this.textWorker.Location = new System.Drawing.Point(80, 199);
            this.textWorker.Name = "textWorker";
            this.textWorker.Size = new System.Drawing.Size(86, 21);
            this.textWorker.TabIndex = 26;
            this.textWorker.Text = "0";
            this.textWorker.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(34, 202);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 12);
            this.label15.TabIndex = 25;
            this.label15.Text = "操作员:";
            // 
            // textRemark
            // 
            this.textRemark.Location = new System.Drawing.Point(80, 226);
            this.textRemark.Name = "textRemark";
            this.textRemark.Size = new System.Drawing.Size(334, 21);
            this.textRemark.TabIndex = 30;
            this.textRemark.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(46, 229);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 12);
            this.label16.TabIndex = 29;
            this.label16.Text = "备注:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 340);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textOrder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpSchedule;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textThickness;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textLength;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textUndo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textDone;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textGross;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpComplete;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textCode;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textWorth;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textWorker;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textRemark;
        private System.Windows.Forms.Label label16;
    }
}

