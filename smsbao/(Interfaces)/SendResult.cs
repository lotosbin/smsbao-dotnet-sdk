namespace smsbao
{
    public class SendResult
    {
        public SendResult(int code)
        {
            ErrorCode = code;
            Success = code == 0;
            Message = code.ErrorCodeToMessage();
        }

        public bool Success { get; set; }
        public int ErrorCode { get; set; }
        public string Message { get; set; }
    }
}