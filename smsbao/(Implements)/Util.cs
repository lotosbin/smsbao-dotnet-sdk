using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace smsbao
{
    internal static class Util
    {
        /// <summary>
        ///     MD5 加密字符串
        /// </summary>
        /// <param name="rawPass">源字符串</param>
        /// <returns>加密后字符串</returns>
        internal static string MD5Encoding(string rawPass)
        {
            // 创建MD5类的默认实例：MD5CryptoServiceProvider
            var md5 = MD5.Create();
            var bs = Encoding.UTF8.GetBytes(rawPass);
            var hs = md5.ComputeHash(bs);
            var sb = new StringBuilder();
            foreach (var b in hs)
            {
                // 以十六进制格式格式化
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        /// <summary>
        ///     30：密码错误
        ///     40：账号不存在
        ///     41：余额不足
        ///     42：帐号过期
        ///     43：IP地址限制
        ///     50：内容含有敏感词
        ///     51：手机号码不正确
        /// </summary>
        /// <returns></returns>
        public static string ErrorCodeToMessage(this int code)
        {
            var dictionary = new Dictionary<int, string>
            {
                {0, ""},
                {30, "密码错误"},
                {40, "账号不存在"},
                {41, "余额不足"},
                {42, "帐号过期"},
                {43, "IP地址限制"},
                {50, "内容含有敏感词"},
                {51, "手机号码不正确"}
            };
            if (dictionary.ContainsKey(code))
            {
                return dictionary[code];
            }
            return "未知错误";
        }
    }
}