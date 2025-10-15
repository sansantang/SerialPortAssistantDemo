namespace 串口demo1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            cbb_comList = new ComboBox();
            rtb_sendTxt = new RichTextBox();
            rtb_receiveTxt = new RichTextBox();
            btn_openSerialPort = new Button();
            groupBox1 = new GroupBox();
            chb_DTR = new CheckBox();
            chb_RTS = new CheckBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            cbb_baudRate = new ComboBox();
            cbb_parityBit = new ComboBox();
            cbb_dataBit = new ComboBox();
            cbb_stopBit = new ComboBox();
            groupBox2 = new GroupBox();
            txt_receiveConfig_path = new TextBox();
            btn_receiveConfig_stop = new Button();
            btn_receiveConfig_handClear = new Button();
            btn_receiveConfig_saveData = new Button();
            btn_receiveConfig_SelectPath = new Button();
            chb_receiveConfig_hexadecimal = new CheckBox();
            chb_receiveConfig_autoClear = new CheckBox();
            groupBox3 = new GroupBox();
            textBox3 = new TextBox();
            label8 = new Label();
            txt_sendConfig_path = new TextBox();
            btn_sendConfig_clearSend = new Button();
            btn_sendConfig_handSend = new Button();
            chb__sendConfig_autoSend = new CheckBox();
            btn_sendConfig_senFile = new Button();
            chb_sendConfig_hexidecimal = new CheckBox();
            btn_sendConfig_openFile = new Button();
            groupBox4 = new GroupBox();
            groupBox5 = new GroupBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            tsslab_status = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            tsslab_sendCount = new ToolStripStatusLabel();
            toolStripStatusLabel5 = new ToolStripStatusLabel();
            tsslab_receiveCount = new ToolStripStatusLabel();
            tsslab_btnClearCount = new ToolStripStatusLabel();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(343, 219);
            label1.Name = "label1";
            label1.Size = new Size(44, 17);
            label1.TabIndex = 0;
            label1.Text = "发送框";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(634, 219);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 1;
            label2.Text = "接收框";
            // 
            // cbb_comList
            // 
            cbb_comList.FormattingEnabled = true;
            cbb_comList.Location = new Point(120, 22);
            cbb_comList.Name = "cbb_comList";
            cbb_comList.Size = new Size(121, 25);
            cbb_comList.TabIndex = 2;
            // 
            // rtb_sendTxt
            // 
            rtb_sendTxt.BackColor = SystemColors.ButtonFace;
            rtb_sendTxt.Dock = DockStyle.Fill;
            rtb_sendTxt.Location = new Point(3, 19);
            rtb_sendTxt.Name = "rtb_sendTxt";
            rtb_sendTxt.ReadOnly = true;
            rtb_sendTxt.Size = new Size(510, 339);
            rtb_sendTxt.TabIndex = 3;
            rtb_sendTxt.Text = "";
            // 
            // rtb_receiveTxt
            // 
            rtb_receiveTxt.Dock = DockStyle.Fill;
            rtb_receiveTxt.Location = new Point(3, 19);
            rtb_receiveTxt.Name = "rtb_receiveTxt";
            rtb_receiveTxt.Size = new Size(510, 200);
            rtb_receiveTxt.TabIndex = 4;
            rtb_receiveTxt.Text = "";
            // 
            // btn_openSerialPort
            // 
            btn_openSerialPort.Location = new Point(120, 177);
            btn_openSerialPort.Name = "btn_openSerialPort";
            btn_openSerialPort.Size = new Size(121, 48);
            btn_openSerialPort.TabIndex = 5;
            btn_openSerialPort.Text = "打开串口";
            btn_openSerialPort.UseVisualStyleBackColor = true;
            btn_openSerialPort.Click += btn_openSerialPort_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_openSerialPort);
            groupBox1.Controls.Add(chb_DTR);
            groupBox1.Controls.Add(chb_RTS);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cbb_baudRate);
            groupBox1.Controls.Add(cbb_parityBit);
            groupBox1.Controls.Add(cbb_dataBit);
            groupBox1.Controls.Add(cbb_stopBit);
            groupBox1.Controls.Add(cbb_comList);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(247, 234);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "串口配置";
            // 
            // chb_DTR
            // 
            chb_DTR.AutoSize = true;
            chb_DTR.Location = new Point(16, 204);
            chb_DTR.Name = "chb_DTR";
            chb_DTR.Size = new Size(51, 21);
            chb_DTR.TabIndex = 14;
            chb_DTR.Text = "DTR";
            chb_DTR.TextAlign = ContentAlignment.MiddleRight;
            chb_DTR.UseVisualStyleBackColor = true;
            // 
            // chb_RTS
            // 
            chb_RTS.AutoSize = true;
            chb_RTS.Location = new Point(16, 177);
            chb_RTS.Name = "chb_RTS";
            chb_RTS.Size = new Size(49, 21);
            chb_RTS.TabIndex = 13;
            chb_RTS.Text = "RTS";
            chb_RTS.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 149);
            label7.Name = "label7";
            label7.Size = new Size(44, 17);
            label7.TabIndex = 12;
            label7.Text = "停止位";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 118);
            label6.Name = "label6";
            label6.Size = new Size(44, 17);
            label6.TabIndex = 11;
            label6.Text = "数据位";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 87);
            label5.Name = "label5";
            label5.Size = new Size(44, 17);
            label5.TabIndex = 10;
            label5.Text = "校验位";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 56);
            label4.Name = "label4";
            label4.Size = new Size(44, 17);
            label4.TabIndex = 9;
            label4.Text = "波特率";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 25);
            label3.Name = "label3";
            label3.Size = new Size(44, 17);
            label3.TabIndex = 8;
            label3.Text = "端口号";
            // 
            // cbb_baudRate
            // 
            cbb_baudRate.FormattingEnabled = true;
            cbb_baudRate.Items.AddRange(new object[] { "4800", "9600", "115200" });
            cbb_baudRate.Location = new Point(120, 53);
            cbb_baudRate.Name = "cbb_baudRate";
            cbb_baudRate.Size = new Size(121, 25);
            cbb_baudRate.TabIndex = 7;
            // 
            // cbb_parityBit
            // 
            cbb_parityBit.FormattingEnabled = true;
            cbb_parityBit.Items.AddRange(new object[] { "奇", "偶", "无" });
            cbb_parityBit.Location = new Point(120, 84);
            cbb_parityBit.Name = "cbb_parityBit";
            cbb_parityBit.Size = new Size(121, 25);
            cbb_parityBit.TabIndex = 6;
            // 
            // cbb_dataBit
            // 
            cbb_dataBit.FormattingEnabled = true;
            cbb_dataBit.Items.AddRange(new object[] { "4", "5", "6", "7", "8" });
            cbb_dataBit.Location = new Point(120, 115);
            cbb_dataBit.Name = "cbb_dataBit";
            cbb_dataBit.Size = new Size(121, 25);
            cbb_dataBit.TabIndex = 5;
            // 
            // cbb_stopBit
            // 
            cbb_stopBit.FormattingEnabled = true;
            cbb_stopBit.Items.AddRange(new object[] { "1", "1.5", "2" });
            cbb_stopBit.Location = new Point(120, 146);
            cbb_stopBit.Name = "cbb_stopBit";
            cbb_stopBit.Size = new Size(121, 25);
            cbb_stopBit.TabIndex = 4;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txt_receiveConfig_path);
            groupBox2.Controls.Add(btn_receiveConfig_stop);
            groupBox2.Controls.Add(btn_receiveConfig_handClear);
            groupBox2.Controls.Add(btn_receiveConfig_saveData);
            groupBox2.Controls.Add(btn_receiveConfig_SelectPath);
            groupBox2.Controls.Add(chb_receiveConfig_hexadecimal);
            groupBox2.Controls.Add(chb_receiveConfig_autoClear);
            groupBox2.Location = new Point(12, 252);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(241, 150);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "接收配置";
            // 
            // txt_receiveConfig_path
            // 
            txt_receiveConfig_path.Location = new Point(6, 109);
            txt_receiveConfig_path.Name = "txt_receiveConfig_path";
            txt_receiveConfig_path.Size = new Size(235, 23);
            txt_receiveConfig_path.TabIndex = 20;
            // 
            // btn_receiveConfig_stop
            // 
            btn_receiveConfig_stop.Location = new Point(120, 51);
            btn_receiveConfig_stop.Name = "btn_receiveConfig_stop";
            btn_receiveConfig_stop.Size = new Size(75, 23);
            btn_receiveConfig_stop.TabIndex = 19;
            btn_receiveConfig_stop.Text = "暂停";
            btn_receiveConfig_stop.UseVisualStyleBackColor = true;
            // 
            // btn_receiveConfig_handClear
            // 
            btn_receiveConfig_handClear.Location = new Point(120, 24);
            btn_receiveConfig_handClear.Name = "btn_receiveConfig_handClear";
            btn_receiveConfig_handClear.Size = new Size(75, 23);
            btn_receiveConfig_handClear.TabIndex = 18;
            btn_receiveConfig_handClear.Text = "手动清空";
            btn_receiveConfig_handClear.UseVisualStyleBackColor = true;
            // 
            // btn_receiveConfig_saveData
            // 
            btn_receiveConfig_saveData.Location = new Point(120, 80);
            btn_receiveConfig_saveData.Name = "btn_receiveConfig_saveData";
            btn_receiveConfig_saveData.Size = new Size(75, 23);
            btn_receiveConfig_saveData.TabIndex = 17;
            btn_receiveConfig_saveData.Text = "保存数据";
            btn_receiveConfig_saveData.UseVisualStyleBackColor = true;
            // 
            // btn_receiveConfig_SelectPath
            // 
            btn_receiveConfig_SelectPath.Location = new Point(16, 80);
            btn_receiveConfig_SelectPath.Name = "btn_receiveConfig_SelectPath";
            btn_receiveConfig_SelectPath.Size = new Size(75, 23);
            btn_receiveConfig_SelectPath.TabIndex = 9;
            btn_receiveConfig_SelectPath.Text = "选择路径";
            btn_receiveConfig_SelectPath.UseVisualStyleBackColor = true;
            // 
            // chb_receiveConfig_hexadecimal
            // 
            chb_receiveConfig_hexadecimal.AutoSize = true;
            chb_receiveConfig_hexadecimal.Location = new Point(16, 53);
            chb_receiveConfig_hexadecimal.Name = "chb_receiveConfig_hexadecimal";
            chb_receiveConfig_hexadecimal.Size = new Size(75, 21);
            chb_receiveConfig_hexadecimal.TabIndex = 16;
            chb_receiveConfig_hexadecimal.Text = "十六进制";
            chb_receiveConfig_hexadecimal.UseVisualStyleBackColor = true;
            // 
            // chb_receiveConfig_autoClear
            // 
            chb_receiveConfig_autoClear.AutoSize = true;
            chb_receiveConfig_autoClear.Location = new Point(16, 26);
            chb_receiveConfig_autoClear.Name = "chb_receiveConfig_autoClear";
            chb_receiveConfig_autoClear.Size = new Size(75, 21);
            chb_receiveConfig_autoClear.TabIndex = 15;
            chb_receiveConfig_autoClear.Text = "自动清空";
            chb_receiveConfig_autoClear.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBox3);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(txt_sendConfig_path);
            groupBox3.Controls.Add(btn_sendConfig_clearSend);
            groupBox3.Controls.Add(btn_sendConfig_handSend);
            groupBox3.Controls.Add(chb__sendConfig_autoSend);
            groupBox3.Controls.Add(btn_sendConfig_senFile);
            groupBox3.Controls.Add(chb_sendConfig_hexidecimal);
            groupBox3.Controls.Add(btn_sendConfig_openFile);
            groupBox3.Location = new Point(12, 408);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(247, 202);
            groupBox3.TabIndex = 8;
            groupBox3.TabStop = false;
            groupBox3.Text = "发送配置";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(141, 149);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 29;
            textBox3.Text = "1000";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(7, 152);
            label8.Name = "label8";
            label8.Size = new Size(108, 17);
            label8.TabIndex = 28;
            label8.Text = "自动发送周期(ms):";
            // 
            // txt_sendConfig_path
            // 
            txt_sendConfig_path.Location = new Point(6, 117);
            txt_sendConfig_path.Name = "txt_sendConfig_path";
            txt_sendConfig_path.Size = new Size(235, 23);
            txt_sendConfig_path.TabIndex = 27;
            // 
            // btn_sendConfig_clearSend
            // 
            btn_sendConfig_clearSend.Location = new Point(120, 55);
            btn_sendConfig_clearSend.Name = "btn_sendConfig_clearSend";
            btn_sendConfig_clearSend.Size = new Size(75, 23);
            btn_sendConfig_clearSend.TabIndex = 26;
            btn_sendConfig_clearSend.Text = "清空发送";
            btn_sendConfig_clearSend.UseVisualStyleBackColor = true;
            // 
            // btn_sendConfig_handSend
            // 
            btn_sendConfig_handSend.Location = new Point(120, 28);
            btn_sendConfig_handSend.Name = "btn_sendConfig_handSend";
            btn_sendConfig_handSend.Size = new Size(75, 23);
            btn_sendConfig_handSend.TabIndex = 25;
            btn_sendConfig_handSend.Text = "手动发送";
            btn_sendConfig_handSend.UseVisualStyleBackColor = true;
            // 
            // chb__sendConfig_autoSend
            // 
            chb__sendConfig_autoSend.AutoSize = true;
            chb__sendConfig_autoSend.Location = new Point(16, 30);
            chb__sendConfig_autoSend.Name = "chb__sendConfig_autoSend";
            chb__sendConfig_autoSend.Size = new Size(75, 21);
            chb__sendConfig_autoSend.TabIndex = 22;
            chb__sendConfig_autoSend.Text = "自动发送";
            chb__sendConfig_autoSend.UseVisualStyleBackColor = true;
            // 
            // btn_sendConfig_senFile
            // 
            btn_sendConfig_senFile.Location = new Point(120, 84);
            btn_sendConfig_senFile.Name = "btn_sendConfig_senFile";
            btn_sendConfig_senFile.Size = new Size(75, 23);
            btn_sendConfig_senFile.TabIndex = 24;
            btn_sendConfig_senFile.Text = "发送文件";
            btn_sendConfig_senFile.UseVisualStyleBackColor = true;
            // 
            // chb_sendConfig_hexidecimal
            // 
            chb_sendConfig_hexidecimal.AutoSize = true;
            chb_sendConfig_hexidecimal.Location = new Point(16, 57);
            chb_sendConfig_hexidecimal.Name = "chb_sendConfig_hexidecimal";
            chb_sendConfig_hexidecimal.Size = new Size(75, 21);
            chb_sendConfig_hexidecimal.TabIndex = 23;
            chb_sendConfig_hexidecimal.Text = "十六进制";
            chb_sendConfig_hexidecimal.UseVisualStyleBackColor = true;
            // 
            // btn_sendConfig_openFile
            // 
            btn_sendConfig_openFile.Location = new Point(16, 84);
            btn_sendConfig_openFile.Name = "btn_sendConfig_openFile";
            btn_sendConfig_openFile.Size = new Size(75, 23);
            btn_sendConfig_openFile.TabIndex = 21;
            btn_sendConfig_openFile.Text = "打开文件";
            btn_sendConfig_openFile.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(rtb_receiveTxt);
            groupBox4.Location = new Point(300, 388);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(516, 222);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            groupBox4.Text = "发送区";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(rtb_sendTxt);
            groupBox5.Location = new Point(300, 21);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(516, 361);
            groupBox5.TabIndex = 8;
            groupBox5.TabStop = false;
            groupBox5.Text = "接收区";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, tsslab_status, toolStripStatusLabel3, tsslab_sendCount, toolStripStatusLabel5, tsslab_receiveCount, tsslab_btnClearCount });
            statusStrip1.Location = new Point(0, 617);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(826, 22);
            statusStrip1.TabIndex = 9;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(44, 17);
            toolStripStatusLabel1.Text = "状态：";
            // 
            // tsslab_status
            // 
            tsslab_status.AutoSize = false;
            tsslab_status.Name = "tsslab_status";
            tsslab_status.Size = new Size(200, 17);
            tsslab_status.Text = "初始化正常！";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(68, 17);
            toolStripStatusLabel3.Text = "发送计数：";
            // 
            // tsslab_sendCount
            // 
            tsslab_sendCount.AutoSize = false;
            tsslab_sendCount.Name = "tsslab_sendCount";
            tsslab_sendCount.Size = new Size(50, 17);
            tsslab_sendCount.Text = "0";
            // 
            // toolStripStatusLabel5
            // 
            toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            toolStripStatusLabel5.Size = new Size(68, 17);
            toolStripStatusLabel5.Text = "接收计数：";
            // 
            // tsslab_receiveCount
            // 
            tsslab_receiveCount.AutoSize = false;
            tsslab_receiveCount.Name = "tsslab_receiveCount";
            tsslab_receiveCount.Size = new Size(50, 17);
            tsslab_receiveCount.Text = "0";
            // 
            // tsslab_btnClearCount
            // 
            tsslab_btnClearCount.Name = "tsslab_btnClearCount";
            tsslab_btnClearCount.Size = new Size(56, 17);
            tsslab_btnClearCount.Text = "清空计数";
            tsslab_btnClearCount.Click += tsslab_btnClearCount_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(826, 639);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(statusStrip1);
            Name = "Form1";
            Text = "串口助手";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cbb_comList;
        private RichTextBox rtb_sendTxt;
        private RichTextBox rtb_receiveTxt;
        private Button btn_openSerialPort;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private StatusStrip statusStrip1;
        private ComboBox cbb_baudRate;
        private ComboBox cbb_parityBit;
        private ComboBox cbb_dataBit;
        private ComboBox cbb_stopBit;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private CheckBox chb_RTS;
        private CheckBox chb_DTR;
        private CheckBox chb_receiveConfig_hexadecimal;
        private CheckBox chb_receiveConfig_autoClear;
        private Button btn_receiveConfig_SelectPath;
        private Button btn_receiveConfig_saveData;
        private Button btn_receiveConfig_handClear;
        private Button btn_receiveConfig_stop;
        private TextBox txt_receiveConfig_path;
        private TextBox txt_sendConfig_path;
        private Button btn_sendConfig_clearSend;
        private Button btn_sendConfig_handSend;
        private CheckBox chb__sendConfig_autoSend;
        private Button btn_sendConfig_senFile;
        private CheckBox chb_sendConfig_hexidecimal;
        private Button btn_sendConfig_openFile;
        private Label label8;
        private TextBox textBox3;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel tsslab_status;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripStatusLabel tsslab_sendCount;
        private ToolStripStatusLabel toolStripStatusLabel5;
        private ToolStripStatusLabel tsslab_receiveCount;
        private ToolStripStatusLabel tsslab_btnClearCount;
    }
}
