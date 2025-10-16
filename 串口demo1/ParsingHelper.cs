using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 串口demo1
{
    public static class ParsingHelper
    {

        /// <summary>
        ///  * 解析数据
        /// 字节位置 | 十六进制值    |	含义
        ///        0	| 7F            |	帧头（起始标志）
        ///        1	| 04            | 	数据长度（有效数据字节数）
        ///      2-5	| 31 32 33 34   |	有效数据（负载）
        ///      6-7	| DE 10         |	校验码（如 CRC16）
        ///
        /// @param dataTemp 待解析数据
        /// @param bufferQueue 缓存队列
        /// @param frameHeader 帧头
        /// @return 解析后的数据
        /// </summary>
        /// <param name="dataTemp"></param>
        /// <param name="bufferQueue"></param>
        /// <param name="frameHeader"></param>
        /// <returns></returns>
        public static byte[] ParsingData(byte[] dataTemp, Queue<byte> bufferQueue, byte[] frameHeader)
        {
            if (frameHeader == null)
            {
                frameHeader = new byte[] { 0x7F };
            }

            bool isHeadRecive = false;
            int frameLength = 0;
            // 解析数据 queue

            foreach (byte item in dataTemp)
            {
                // 入列
                bufferQueue.Enqueue(item);
            }

            // 1.解析获取帧头
            if (isHeadRecive == false)
            {
                while (bufferQueue.Count >= frameHeader.Length)
                {
                    // 检查是否匹配帧头
                    bool headerMatch = true;
                    var queueArray = bufferQueue.ToArray();

                    for (int i = 0; i < frameHeader.Length; i++)
                    {
                        if (queueArray[i] != frameHeader[i])
                        {
                            headerMatch = false;
                            break;
                        }
                    }

                    if (headerMatch)
                    {
                        isHeadRecive = true;
                        Debug.WriteLine($"{BitConverter.ToString(frameHeader)} is received !!");
                        break;
                    }
                    else
                    {
                        // 不匹配则移除第一个字节继续查找
                        bufferQueue.Dequeue();
                        Debug.WriteLine($"Header mismatch, Dequeue !!");
                    }
                }
            }

            if (isHeadRecive)
            {
                // 计算需要的最小长度: 帧头长度 + 长度字段(1字节) 
                int minLength = frameHeader.Length + 1;

                if (bufferQueue.Count >= minLength)
                {
                    var queueArray = bufferQueue.ToArray();
                    // 获取数据长度字段（在帧头之后）
                    frameLength = queueArray[frameHeader.Length];

                    Debug.WriteLine(DateTime.Now.ToLongTimeString());
                    Debug.WriteLine($"show the data in bufferQueue{HexHelper.BytesToHexString(queueArray)}");
                    Debug.WriteLine($"frame length ={String.Format("{0:X2}", frameLength)}");

                    // 计算完整帧长度: 帧头 + 长度字段 + 数据 + 校验(2字节)
                    int fullFrameLength = frameHeader.Length + 1 + frameLength + 2;

                    if (bufferQueue.Count >= fullFrameLength)
                    {
                        byte[] frameBuffer = new byte[fullFrameLength];
                        Array.Copy(queueArray, 0, frameBuffer, 0, fullFrameLength);

                        // CRC校验配置
                        CrcConfig crcConfig = new CrcConfig()
                        {
                            Type = CrcType.CRC16_CCITT,
                            ByteOrder = DataCheck.BigOrLittle.BigEndian,
                            CrcByteCount = 2,
                            CrcPosition = -1
                        };

                        // CRC校验
                        if (crc_check(frameBuffer, crcConfig))
                        {
                            Debug.WriteLine("frame is check ok, pick it");

                            // 移除已处理的数据
                            for (int i = 0; i < fullFrameLength; i++)
                            {
                                bufferQueue.Dequeue();
                            }

                            return frameBuffer;
                        }
                        else
                        {
                            // CRC校验失败，移除帧头继续查找
                            Debug.WriteLine("bad frame, drop it");
                            bufferQueue.Dequeue(); // 只移除第一个字节继续查找
                        }
                    }
                }
            }
            return new byte[0];
        }

        /// <summary>
        /// 针对当前项目快捷写法
        /// </summary>
        /// <param name="frameBuffer"></param>
        /// <returns></returns>
        private static bool crc_check(byte[] frameBuffer)
        {
            /*大端模式: 是指数据的高字节保存在内存的低地址中，
             * 而数据的低字节保存在内存的高地址中，这样的存储
             * 模式有点儿类似于把数据当作字符串顺序处理：地址
             * 由小向大增加，而数据从高位往低位放；这和我们的
             * 阅读习惯一致。
             * 
             * 小端模式: 是指数据的高字节保存在内存的高地址中，
             * 而数据的低字节保存在内存的低地址中，这种存储模
             * 式将地址的高低和数据位权有效地结合起来，高地址
             * 部分权值高，低地址部分权值低。
             */
            bool ret = false;

            byte[] temp = new byte[frameBuffer.Length - 2];
            Array.Copy(frameBuffer, 0, temp, 0, temp.Length);
            byte[] crcdata = DataCheck.DataCrc16_Ccitt(temp, DataCheck.BigOrLittle.BigEndian);
            if (crcdata[0] == frameBuffer[frameBuffer.Length - 2] &&
                crcdata[1] == frameBuffer[frameBuffer.Length - 1])
            {
                // check ok
                ret = true;
            }

            return ret;
        }

        #region CRC校验

        public enum CrcType
        {
            CRC16_CCITT,
            CRC16_MODBUS,
            CRC16_IBM,
            CRC32,
            // 可扩展更多类型
        }

        public class CrcConfig
        {
            public CrcType Type { get; set; }
            public DataCheck.BigOrLittle ByteOrder { get; set; }
            public int CrcByteCount { get; set; } = 2; // CRC字节数
            public int CrcPosition { get; set; } = -1; // -1表示在末尾
        }

        /// <summary>
        ///  针对当前项目通用配置写法
        /// </summary>
        /// <param name="frameBuffer"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        private static bool crc_check(byte[] frameBuffer, CrcConfig config = null)
        {
            if (config == null)
            {
                // 默认配置
                config = new CrcConfig
                {
                    Type = CrcType.CRC16_CCITT,
                    ByteOrder = DataCheck.BigOrLittle.BigEndian,
                    CrcByteCount = 2
                };
            }

            // 确定CRC在帧中的位置
            int crcStartIndex = config.CrcPosition;
            if (crcStartIndex == -1)
            {
                crcStartIndex = frameBuffer.Length - config.CrcByteCount;
            }

            // 提取数据部分（除去CRC）
            byte[] dataPart = new byte[crcStartIndex];
            Array.Copy(frameBuffer, 0, dataPart, 0, dataPart.Length);

            // 计算CRC
            byte[] calculatedCrc = null;
            switch (config.Type)
            {
                case CrcType.CRC16_CCITT:
                    calculatedCrc = DataCheck.DataCrc16_Ccitt(dataPart, config.ByteOrder);
                    break;
                case CrcType.CRC16_MODBUS:
                    calculatedCrc = DataCheck.DataCrc16_Modbus(dataPart, config.ByteOrder);
                    break;
                    // 其他CRC类型...
            }

            // 提取帧中的CRC
            byte[] frameCrc = new byte[config.CrcByteCount];
            Array.Copy(frameBuffer, crcStartIndex, frameCrc, 0, config.CrcByteCount);

            // 比较CRC
            return calculatedCrc.SequenceEqual(frameCrc);
        }

        #endregion
    }
}
