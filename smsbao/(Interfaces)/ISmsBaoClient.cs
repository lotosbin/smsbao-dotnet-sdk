namespace smsbao
{
    public interface ISmsBaoClient
    {
        SendResult SendSms(string mobile, string content);
        SendResult SendSms(string username, string password, string mobile, string content);
        QueryResult Query(string username, string password);
        QueryResult Query();
    }
}