smsbao
======

smsbao c# sdk

# ��װ Install
PM> Install-Package smsbao-dotnet-sdk

# ���� Config
  <appSettings>
    <add key="smsbao_username" value="username"/>
    <add key="smsbao_password" value="password"/>
  </appSettings>

# ʹ�� Usage
var client = new SmsBaoClient();
client.SendSms("[phonenumber]", "[message]");

# �ʴ� Q&A
- �滻ǩ��
    ǰ������Լ���ǩ�����ɡ�

