using Microsoft.Win32;
using System.Diagnostics;
using System.IO.Ports;
using System.Net;
using System.Text;

namespace 串口demo1
{
    public partial class Form1 : Form
    {
        private class SerialPortList
        {
            public string portName { get; set; }
            public bool isOpen { get; set; } = false;
        }

        private List<SerialPortList> _comList = new List<SerialPortList>()
        {
            //new { portName = "COM1", isOpen = false },
            //new { portName = "COM2", isOpen = false },
            //new { portName = "COM3", isOpen = false },
        };

        private SerialPort _serialPort;

        private List<byte> receiveBuffer = new List<byte>();

        private int receiveCount = 0;
        public Form1()
        {
            InitializeComponent();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            InitForm();
            Control.CheckForIllegalCrossThreadCalls = false;

        }
        private void InitForm()
        {
            SerialLoad();

            this.cbb_baudRate.SelectedItem = "9600";
            this.cbb_parityBit.SelectedItem = "无";
            this.cbb_dataBit.SelectedItem = "8";
            this.cbb_stopBit.SelectedItem = "1";

            InitCbbPortNames();
            this.cbb_comList.SelectedIndex = 2;

        }


        private void initSerialPort()
        {
            _serialPort = new SerialPort();
            _serialPort.PortName = this.cbb_comList.Text;
            _serialPort.BaudRate = int.Parse(this.cbb_baudRate.Text);
            /**
             * 奇
               偶
               无
               标志
               空格
             * 
             */
            switch (this.cbb_parityBit.Text)
            {
                case "奇":
                    _serialPort.Parity = Parity.Odd;
                    break;
                case "偶":
                    _serialPort.Parity = Parity.Even;
                    break;
                case "无":
                    _serialPort.Parity = Parity.None;
                    break;
                default:
                    break;
            }

            /*
             * 4
                5
                6
                7
                8
             */
            _serialPort.DataBits = int.Parse(this.cbb_dataBit.Text);
            // 1,   1.5,  2
            switch (this.cbb_stopBit.Text)
            {
                case "1":
                    _serialPort.StopBits = StopBits.One;
                    break;
                case "1.5":
                    _serialPort.StopBits = StopBits.OnePointFive;
                    break;
                case "2":
                    _serialPort.StopBits = StopBits.Two;
                    break;
                default:
                    break;

            }
            _serialPort.DataReceived += _serialPort_DataReceived;


        }


        #region 串口配置

        /// <summary>
        /// 串口配置 - 获取设备的串口
        /// </summary>
        private void SerialLoad()
        {
            // 打开Windows注册表中的串口设备映射位置
            RegistryKey keyCon = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DEVICEMAP\SERIALCOMM");

            // 获取所有串口设备的值名称数组
            string[] serialComms = keyCon.GetValueNames();

            // 遍历每个串口设备
            foreach (var item in serialComms)
            {
                // 从注册表中获取具体的串口名称（如COM1, COM2等）
                string name = (string)keyCon.GetValue(item);

                // 将串口名称添加到_comList中，并设置isOpen属性为false
                _comList.Add(new SerialPortList() { portName = name, isOpen = false });
            }
        }


        /// <summary>
        /// 串口配置 - 虚拟端口载入列表
        /// </summary>
        private void InitCbbPortNames()
        {
            this.cbb_comList.Items.Clear();
            foreach (var item in _comList)
            {
                this.cbb_comList.Items.Add(item.portName);
            }
        }


        /// <summary>
        /// 串口配置 - 打开串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_openSerialPort_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.btn_openSerialPort.Text == "打开串口")
                {
                    initSerialPort();
                    _serialPort.Open();
                    this.btn_openSerialPort.Text = "关闭串口";
                    UpdateComList(_serialPort.PortName);
                    Console.WriteLine(_serialPort);
                }
                else
                {
                    _serialPort.Close();
                    UpdateComList(_serialPort.PortName);
                    this.btn_openSerialPort.Text = "打开串口";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 串口配置 - 更新串口号
        /// </summary>
        /// <param name="portName"></param>
        private void UpdateComList(string portName)
        {
            string comName = string.Empty;
            // 先查找是否已有带配置信息的端口名（表示该端口曾被打开）
            int index = _comList.FindIndex(t => t.portName.StartsWith(portName + "-["));

            if (index != -1)
            {
                // 当前是打开状态，要关闭，需恢复为纯端口名
                if (!_serialPort.IsOpen && _comList[index].isOpen)
                {
                    _comList[index] = new SerialPortList() { portName = portName, isOpen = false };
                    comName = portName;
                }
            }
            else
            {
                // 查找原始端口名
                index = _comList.FindIndex(t => t.portName == portName);
                if (index != -1)
                {
                    // 当前是关闭状态，要打开，需加上配置信息
                    if (_serialPort.IsOpen && !_comList[index].isOpen)
                    {
                        string configInfo = $"-[{_serialPort.BaudRate}-{_serialPort.Parity}-{_serialPort.DataBits}-{_serialPort.StopBits}]";
                        comName = portName + configInfo;
                        _comList[index] = new SerialPortList() { portName = comName, isOpen = true };
                    }
                }
            }

            // 重新加载下拉框
            InitCbbPortNames();
            this.cbb_comList.SelectedItem = comName;
        }

        /// <summary>
        /// 串口配置 - 串口 COM 的端口变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbb_comList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cbb_comList.SelectedItem is null)
            {
                return;
            }
            int index = _comList.FindIndex(t => t.portName.StartsWith(this.cbb_comList.SelectedItem.ToString()));
            if (_comList[index].isOpen)
            {
                this.btn_openSerialPort.Text = "关闭串口";
            }
            else
            {
                this.btn_openSerialPort.Text = "打开串口";
            }
        }
        #endregion


        #region 接收配置
        /// <summary>
        /// 接收配置 - 清空接收区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_receiveConfig_handClear_Click(object sender, EventArgs e)
        {
            this.receiveBuffer.Clear();
            this.rtb_receiveTxt.Text = string.Empty;
        }

        /// <summary>
        /// 接收配置 - 切换16进制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chb_receiveConfig_hexadecimal_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chb_receiveConfig_hexadecimal.Checked)
            {
                this.rtb_receiveTxt.Text = BitConverter.ToString(receiveBuffer.ToArray()).Replace("-", " ");
            }
            else
            {
                this.rtb_receiveTxt.Text = Encoding.GetEncoding("gb2312").GetString(receiveBuffer.ToArray()).Replace("\0", "\\0");
            }
        }

        #endregion



        #region 发送消息
        /// <summary>
        /// 手动发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_sendConfig_handSend_Click(object sender, EventArgs e)
        {
            this._serialPort.Write(this.rtb_receiveTxt.Text);
        }
        #endregion

        #region 状态栏
        private void tsslab_btnClearCount_Click(object sender, EventArgs e)
        {

        }
        #endregion


        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                byte[] dataTemp = new byte[_serialPort.BytesToRead];

                _serialPort.Read(dataTemp, 0, dataTemp.Length);

                receiveBuffer.AddRange(dataTemp);

                receiveCount += dataTemp.Length;

                this.Invoke(new Action(() =>
                {
                    string str = string.Empty;

                    if (this.chb_receiveConfig_hexadecimal.Checked)
                    {
                        // 转换为十六进制字符串显示，结果示例："00-01"
                        string hexDisplay = BitConverter.ToString(dataTemp);
                        str = hexDisplay.Replace("-", " ");
                    }
                    else
                    {
                        //直接获取文本
                        str = Encoding.GetEncoding("gb2312").GetString(dataTemp);
                        str = str.Replace("\0", "\\0"); //处理0
                    }

                    this.rtb_receiveTxt.AppendText(str);
                }));
            }
            catch (Exception ex)
            {
                // 异常处理
                Console.WriteLine("Error in _serialPort_DataReceived: " + ex.Message);
            }
        }
    }
}