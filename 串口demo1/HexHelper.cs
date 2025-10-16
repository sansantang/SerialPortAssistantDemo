using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 串口demo1
{
    public static class HexHelper
    {
        /// <summary>
        /// 将字节数组转换为16进制字符串
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="spaceMark">间隔符</param>
        /// <returns>16进制字符串</returns>
        public static string BytesToHexString(byte[] bytes, string spaceMark=" ")
        {
            if (bytes == null || bytes.Length == 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                // 格式化为两位16进制，不足两位前面补0
                sb.Append(b.ToString("X2"));
                sb.Append(spaceMark);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 将16进制字符串转换为字节数组
        /// </summary>
        /// <param name="hexString">16进制字符串</param>
        /// <returns>字节数组</returns>
        public static byte[] HexStringToBytes(string hexString)
        {
            if (string.IsNullOrEmpty(hexString))
                return new byte[0];

            // 移除字符串中的空格
            hexString = hexString.Replace(" ", "");

            // 如果长度为奇数，在前面补0
            if (hexString.Length % 2 != 0)
                hexString = "0" + hexString;

            byte[] bytes = new byte[hexString.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                string hex = hexString.Substring(i * 2, 2);
                bytes[i] = Convert.ToByte(hex, 16);
            }
            return bytes;
        }

        /// <summary>
        /// 将字符串通过指定编码转换为16进制字符串
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>16进制字符串</returns>
        public static string StringToHexString(string str, Encoding encoding)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            byte[] bytes = encoding.GetBytes(str);
            return BytesToHexString(bytes);
        }

        /// <summary>
        /// 将16进制字符串通过指定编码转换为原始字符串
        /// </summary>
        /// <param name="hexString">16进制字符串</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>原始字符串</returns>
        public static string HexStringToString(string hexString, Encoding encoding)
        {
            byte[] bytes = HexStringToBytes(hexString);
            return encoding.GetString(bytes);
        }

        /// <summary>
        /// 检查字符串是否为有效的16进制格式
        /// </summary>
        /// <param name="hexString">待检查的字符串</param>
        /// <returns>是否有效的16进制字符串</returns>
        public static bool IsValidHexString(string hexString)
        {
            if (string.IsNullOrEmpty(hexString))
                return false;

            // 移除所有空格后检查
            hexString = hexString.Replace(" ", "");

            foreach (char c in hexString)
            {
                if (!IsHexChar(c))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 检查字符是否为16进制字符
        /// </summary>
        private static bool IsHexChar(char c)
        {
            return (c >= '0' && c <= '9') ||
                   (c >= 'A' && c <= 'F') ||
                   (c >= 'a' && c <= 'f');
        }
    }
}