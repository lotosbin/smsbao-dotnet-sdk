using System;
using System.Configuration;

namespace smsbao
{
    class Config
    {
        internal static string GetPassword()
        {
            var password = ConfigurationManager.AppSettings["smsbao_password"];
            if (String.IsNullOrEmpty(password))
            {
                throw new ConfigurationErrorsException("smsbao_password");
            }
            return password;
        }

        internal static string GetUserName()
        {
            var username = ConfigurationManager.AppSettings["smsbao_username"];
            if (String.IsNullOrEmpty(username))
            {
                throw new ConfigurationErrorsException("smsbao_username");
            }
            return username;
        }
    }
}