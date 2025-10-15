using System.IO.Ports;
using System.Net;

namespace 串口demo1
{
    public partial class Form1 : Form
    {
        private List<string> _comList = new List<string>() { "COM1", "COM2", "COM3", "COM4", "COM5" };

        private SerialPort _serialPort;
        public Form1()
        {
            InitializeComponent();
            InitForm();
        }
        private void InitForm()
        {
            //initSerialPort();
            this.cbb_baudRate.SelectedItem = "9600";
            this.cbb_parityBit.SelectedItem = "无";
            this.cbb_dataBit.SelectedItem = "8";
            this.cbb_stopBit.SelectedItem = "1";

            InitCbbPortNames();
            this.cbb_comList.SelectedIndex = 0;

        }

        private void InitCbbPortNames()
        {
            this.cbb_comList.Items.Clear();
            this.cbb_comList.Items.AddRange(_comList.ToArray()); //添加COM1/2/3/4/5
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
        }


        #region 串口配置

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
                    //this.cbb_comList.SelectedText = _serialPort.PortName + $"-[{_serialPort.BaudRate}-{_serialPort.Parity}-{_serialPort.DataBits}-{_serialPort.StopBits}]";
                    Console.WriteLine(_serialPort);
                }
                else
                {
                    UpdateComList(_serialPort.PortName);
                    this.btn_openSerialPort.Text = "打开串口";
                    _serialPort.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void UpdateComList(string portName)
        {
            int index = _comList.FindIndex(t => t.StartsWith(portName + "-["));
            string comName = "";
            // 如果找到已打开的端口标记，则恢复为普通端口名称
            if (index != -1)
            {
                comName = portName;
                _comList[index] = portName;
            }
            else
            {
                // 查找普通端口名称的位置
                index = _comList.FindIndex(t => t == portName);
                if (index != -1)
                {
                    // 添加端口配置信息标记
                    string configInfo = $"-[{_serialPort.BaudRate}-{_serialPort.Parity}-{_serialPort.DataBits}-{_serialPort.StopBits}]";
                    comName = portName + configInfo;
                    _comList[index] = comName;
                }
            }

            // 重新初始化下拉列表并设置选中项
            InitCbbPortNames();
            this.cbb_comList.SelectedItem = comName;
        }
        #endregion

        #region 状态栏
        private void tsslab_btnClearCount_Click(object sender, EventArgs e)
        {

        }


        #endregion


    }
}
