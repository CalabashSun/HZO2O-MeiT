using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MeituanApi.Core.Helper
{
    public class SignHelper
    {
        private static string Key = "40e1ab22b1b4fe662096d2babf9fea2b";
        /// <summary>
        /// 签名
        /// </summary>
        /// <typeparam name="T">泛型类</typeparam>
        /// <param name="t">传入this</param>
        /// <param name="ignorePropertys">忽略哪个属性不签名</param>
        /// <returns></returns>
        public static string Sign<T>(T t,string url, string[] ignorePropertys = null,string keyInfo="")
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            var propertys = t.GetType().GetProperties();
            foreach (var item in propertys)
            {
                if (item.Name.Equals("sig"))
                {
                    continue;// 避免无限循环
                }
                if (item.PropertyType.Namespace.ToLower().Equals("System.Collections.Generic".ToLower()))
                {
                    continue;
                }

                bool ignore = false;

                if (ignorePropertys != null)
                {
                    foreach (var ignoreProperty in ignorePropertys)
                    {
                        if (item.Name.Equals(ignoreProperty))
                        {
                            ignore = true;
                            break;
                        }
                    }
                }
                if (!ignore)
                {
                    var value = item.GetValue(t, null);
                    if (value != null && !string.IsNullOrEmpty(value.ToString()))
                    {
                        dic.Add(item.Name, value.ToString());
                    }
                }
            }
            return Sign(dic,url,keyInfo);
        }


        public static Dictionary<string, string> ToDictionary<T>(T t)
        {
            var dic = new Dictionary<string, string>();
            var propertys = t.GetType().GetProperties();
            foreach (var item in propertys)
            {
                if (item.PropertyType.Namespace.ToLower().Equals("System.Collections.Generic".ToLower()))
                {
                    continue;
                }

                var value = item.GetValue(t, null);
                if (value == null)
                {
                    continue;
                }

                dic.Add(item.Name, value.ToString());
            }

            return dic;
        }

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="dicParams">签名参数</param>
        /// <returns></returns>
        public static string Sign(Dictionary<string, string> dicParams,string url,string keyInfo="")
        {
            if (keyInfo == "")
            {
                keyInfo = Key;
            }
            //将字典中按ASCII码升序排序
            Dictionary<string, string> dicDestSign = new Dictionary<string, string>();
            dicDestSign = AsciiDictionary(dicParams);
            var sb = new StringBuilder();
            foreach (var sA in dicDestSign)//参数名ASCII码从小到大排序（字典序）；
            {
                if (string.IsNullOrEmpty(sA.Value) || string.Compare(sA.Key, "sig", true) == 0)
                {
                    continue;// 参数中为签名的项，不参加计算//参数的值为空不参与签名；
                }
                sb.Append(sA.Key).Append("=").Append(sA.Value).Append("&");
            }
            var string1 = sb.ToString();
            //在stringA最后拼接上key=(API密钥的值)得到stringSignTemp字符串
            var stringSignTemp = string1.Substring(0,string1.Length-1)+keyInfo;
            stringSignTemp = url + "?" + stringSignTemp;
            var sign = MD5(stringSignTemp, "UTF-8").ToLower();//对stringSignTemp进行MD5运算，再将得到的字符串所有字符转换为大写，得到sign值signValue。 
            return sign;
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="encypStr">需要md5加密的字符串</param>
        /// <param name="charset">编码</param>
        /// <returns>返回加密后的MD5字符串</returns>
        public static string MD5(string encypStr, string charset = "UTF-8")
        {
            string retStr = string.Empty;
            MD5CryptoServiceProvider m5 = new MD5CryptoServiceProvider();

            //创建md5对象
            byte[] inputBye;
            byte[] outputBye;

            //使用GB2312编码方式把字符串转化为字节数组．
            try
            {
                inputBye = Encoding.GetEncoding(charset).GetBytes(encypStr);
            }
            catch
            {
                inputBye = Encoding.GetEncoding("GB2312").GetBytes(encypStr);
            }
            outputBye = m5.ComputeHash(inputBye);

            retStr = BitConverter.ToString(outputBye);
            retStr = retStr.Replace("-", "").ToUpper();
            return retStr;
        }

        /// <summary>
        /// 将集合key以ascii码从小到大排序
        /// </summary>
        /// <param name="sArray">源数组</param>
        /// <returns>目标数组</returns>
        public static Dictionary<string, string> AsciiDictionary(Dictionary<string, string> sArray)
        {
            Dictionary<string, string> asciiDic = new Dictionary<string, string>();
            string[] arrKeys = sArray.Keys.ToArray();
            Array.Sort(arrKeys, string.CompareOrdinal);
            foreach (var key in arrKeys)
            {
                string value = sArray[key];
                asciiDic.Add(key, value);
            }
            return asciiDic;
        }
    }
}
