smsbao
======

smsbao c# sdk

# 安装 Install
PM> Install-Package smsbao-dotnet-sdk

# 配置 Config
  <appSettings>
    <add key="smsbao_username" value="username"/>
    <add key="smsbao_password" value="password"/>
  </appSettings>

# 使用 Usage
var client = new SmsBaoClient();
client.SendSms("[phonenumber]", "[message]");

# 问答 Q&A
- 替换签名
    前面添加自己的签名即可。

