using System;
using System.Collections.Generic;
using System.Web;
using Binbin.HttpHelper;

namespace smsbao
{
    /// <summary>
    ///     http://www.smsbao.com/
    ///     http://smsbao.com/openapi
    ///     错误代码表
    ///     30：密码错误
    ///     40：账号不存在
    ///     41：余额不足
    ///     42：帐号过期
    ///     43：IP地址限制
    ///     50：内容含有敏感词
    ///     51：手机号码不正确
    /// </summary>
    public class SmsBaoClient : ISmsBaoClient
    {
        #region send sms

        public SendResult SendSms(string mobile, string content)
        {
            var username = Config.GetUserName();
            var password = Config.GetPassword();
            return SendSms(username, password, mobile, content);
        }

        public SendResult SendSms(string username, string password, string mobile, string content)
        {
            const string url = "http://www.smsbao.com/sms";
            var request = new SyncHttpRequest();
            var get = request.HttpGet(url, new List<APIParameter>
            {
                new APIParameter("u", username),
                new APIParameter("p", Util.MD5Encoding(password)),
                new APIParameter("m", mobile),
                new APIParameter("c", HttpUtility.UrlEncode(content))
            });
            return new SendResult(int.Parse(get));
        }

        #endregion

        #region New region

        /*
         http://www.smsbao.com/query?u=USERNAME&p=PASSWORD 
USERNAME：在本短信平台注册的用户名 
PASSWORD：平台登录密码MD5后的值 

第一行返回 '0' 视为发送成功，其他内容为错误提示内容
如果第一行返回成功，则第二行返回 '发送条数,剩余条数'
         */

        public QueryResult Query(string username, string password)
        {
            var url = "http://www.smsbao.com/query?u=USERNAME&p=PASSWORD";
            var request = new SyncHttpRequest();
            var get = request.HttpGet(url, new List<APIParameter>
            {
                new APIParameter("u", username),
                new APIParameter("p", Util.MD5Encoding(password))
            });
            if (get[0] == '0')
            {
                var split = get.Split(new[] {"\n"}, StringSplitOptions.RemoveEmptyEntries);
                var strings = split[1].Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
                return new QueryResult
                {
                    SendCount = Convert.ToInt32(strings[0]),
                    RemainCount = Convert.ToInt32(strings[1])
                };
            }
            throw new Exception(get);
        }

        public QueryResult Query()
        {
            return Query(Config.GetUserName(), Config.GetPassword());
        }

        #endregion
    }
}