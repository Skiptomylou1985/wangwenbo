namespace TransferData
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolbarInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolbarSendIndex = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolbarReadIndex = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolbarReadIndex1223 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.comboUnit = new System.Windows.Forms.ComboBox();
            this.textMulti = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboPort = new System.Windows.Forms.ComboBox();
            this.btnWrite = new System.Windows.Forms.Button();
            this.btnOpenClosePort = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.DGV2 = new System.Windows.Forms.DataGridView();
            this.DGV1 = new System.Windows.Forms.DataGridView();
            this.timerWrite = new System.Windows.Forms.Timer(this.components);
            this.timerRead = new System.Windows.Forms.Timer(this.components);
            this.timerBreak = new System.Windows.Forms.Timer(this.components);
            this.lblImportFile = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbarInfo,
            this.toolStripStatusLabel2,
            this.toolbarSendIndex,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5,
            this.toolbarReadIndex,
            this.toolbarReadIndex1223,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 760);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(1264, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolbarInfo
            // 
            this.toolbarInfo.AutoSize = false;
            this.toolbarInfo.Name = "toolbarInfo";
            this.toolbarInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolbarInfo.Size = new System.Drawing.Size(150, 17);
            this.toolbarInfo.Text = "当前状态";
            this.toolbarInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(28, 17);
            this.toolStripStatusLabel2.Text = "     ";
            // 
            // toolbarSendIndex
            // 
            this.toolbarSendIndex.AutoSize = false;
            this.toolbarSendIndex.Name = "toolbarSendIndex";
            this.toolbarSendIndex.Size = new System.Drawing.Size(15, 17);
            this.toolbarSendIndex.Text = "0";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(80, 17);
            this.toolStripStatusLabel4.Text = "当前发送序号";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(28, 17);
            this.toolStripStatusLabel5.Text = "     ";
            // 
            // toolbarReadIndex
            // 
            this.toolbarReadIndex.AutoSize = false;
            this.toolbarReadIndex.Name = "toolbarReadIndex";
            this.toolbarReadIndex.Size = new System.Drawing.Size(15, 17);
            this.toolbarReadIndex.Text = "0";
            // 
            // toolbarReadIndex1223
            // 
            this.toolbarReadIndex1223.Name = "toolbarReadIndex1223";
            this.toolbarReadIndex1223.Size = new System.Drawing.Size(80, 17);
            this.toolbarReadIndex1223.Text = "当前读取序号";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(28, 17);
            this.toolStripStatusLabel1.Text = "     ";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1264, 760);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.btnRead);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboPort);
            this.panel1.Controls.Add(this.btnWrite);
            this.panel1.Controls.Add(this.btnOpenClosePort);
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1258, 34);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(140, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "当前尺寸计量单位:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // comboUnit
            // 
            this.comboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboUnit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboUnit.ForeColor = System.Drawing.Color.Black;
            this.comboUnit.FormattingEnabled = true;
            this.comboUnit.Items.AddRange(new object[] {
            "毫米",
            "厘米",
            "英寸"});
            this.comboUnit.Location = new System.Drawing.Point(247, 8);
            this.comboUnit.Name = "comboUnit";
            this.comboUnit.Size = new System.Drawing.Size(78, 20);
            this.comboUnit.TabIndex = 12;
            this.comboUnit.SelectedIndexChanged += new System.EventHandler(this.comboUnit_SelectedIndexChanged);
            // 
            // textMulti
            // 
            this.textMulti.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textMulti.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textMulti.ForeColor = System.Drawing.Color.Green;
            this.textMulti.Location = new System.Drawing.Point(46, 4);
            this.textMulti.Name = "textMulti";
            this.textMulti.Size = new System.Drawing.Size(55, 26);
            this.textMulti.TabIndex = 11;
            this.textMulti.Text = "1";
            this.textMulti.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textMulti.TextChanged += new System.EventHandler(this.textMulti_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "套数:";
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(209, 5);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(65, 26);
            this.btnRead.TabIndex = 9;
            this.btnRead.Text = "读取PLC";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(74, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(65, 26);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "导出配方";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(384, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "串口号:";
            // 
            // comboPort
            // 
            this.comboPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPort.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboPort.FormattingEnabled = true;
            this.comboPort.Items.AddRange(new object[] {
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
            "COM16",
            "COM17",
            "COM18",
            "COM19",
            "COM20"});
            this.comboPort.Location = new System.Drawing.Point(433, 7);
            this.comboPort.Name = "comboPort";
            this.comboPort.Size = new System.Drawing.Size(60, 20);
            this.comboPort.TabIndex = 5;
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(141, 5);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(65, 26);
            this.btnWrite.TabIndex = 3;
            this.btnWrite.Text = "写入PLC";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // btnOpenClosePort
            // 
            this.btnOpenClosePort.Location = new System.Drawing.Point(509, 3);
            this.btnOpenClosePort.Name = "btnOpenClosePort";
            this.btnOpenClosePort.Size = new System.Drawing.Size(65, 26);
            this.btnOpenClosePort.TabIndex = 2;
            this.btnOpenClosePort.Text = "打开串口";
            this.btnOpenClosePort.UseVisualStyleBackColor = true;
            this.btnOpenClosePort.Click += new System.EventHandler(this.btnOpenClosePort_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(6, 5);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(65, 26);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "导入配方";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(277, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 26);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存默认";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
            this.tableLayoutPanel2.Controls.Add(this.DGV2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.DGV1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 83);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1258, 674);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // DGV2
            // 
            this.DGV2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DGV2.Location = new System.Drawing.Point(629, 0);
            this.DGV2.Margin = new System.Windows.Forms.Padding(0);
            this.DGV2.Name = "DGV2";
            this.DGV2.RowHeadersVisible = false;
            this.DGV2.RowTemplate.Height = 23;
            this.DGV2.Size = new System.Drawing.Size(629, 674);
            this.DGV2.TabIndex = 1;
            this.DGV2.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV2_CellValueChanged);
            // 
            // DGV1
            // 
            this.DGV1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DGV1.Location = new System.Drawing.Point(0, 0);
            this.DGV1.Margin = new System.Windows.Forms.Padding(0);
            this.DGV1.Name = "DGV1";
            this.DGV1.RowHeadersVisible = false;
            this.DGV1.RowTemplate.Height = 23;
            this.DGV1.Size = new System.Drawing.Size(629, 674);
            this.DGV1.TabIndex = 0;
            this.DGV1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV1_CellValueChanged);
            // 
            // timerWrite
            // 
            this.timerWrite.Tick += new System.EventHandler(this.timerWrite_Tick);
            // 
            // timerRead
            // 
            this.timerRead.Tick += new System.EventHandler(this.timerRead_Tick);
            // 
            // timerBreak
            // 
            this.timerBreak.Tick += new System.EventHandler(this.timerBreak_Tick);
            // 
            // lblImportFile
            // 
            this.lblImportFile.AutoSize = true;
            this.lblImportFile.Location = new System.Drawing.Point(384, 11);
            this.lblImportFile.Name = "lblImportFile";
            this.lblImportFile.Size = new System.Drawing.Size(137, 12);
            this.lblImportFile.TabIndex = 14;
            this.lblImportFile.Text = "当前配方名称：默认配方";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.textMulti);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.comboUnit);
            this.panel2.Controls.Add(this.lblImportFile);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1258, 34);
            this.panel2.TabIndex = 2;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 782);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配方管理软件 V1.1.0.0                                                                  " +
    "                                                                             Cop" +
    "yright@深圳市新群力机械有限公司";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolbarInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView DGV1;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Button btnOpenClosePort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboPort;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolbarSendIndex;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolbarReadIndex;
        private System.Windows.Forms.ToolStripStatusLabel toolbarReadIndex1223;
        private System.Windows.Forms.DataGridView DGV2;
        private System.Windows.Forms.Timer timerWrite;
        private System.Windows.Forms.Timer timerRead;
        private System.Windows.Forms.Timer timerBreak;
        private System.Windows.Forms.TextBox textMulti;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboUnit;
        private System.Windows.Forms.Label lblImportFile;
        private System.Windows.Forms.Panel panel2;
    }
}

