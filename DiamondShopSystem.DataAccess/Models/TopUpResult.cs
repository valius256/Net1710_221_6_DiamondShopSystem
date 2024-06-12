namespace DiamondShopSystem.DataAccess.Models
{
    public interface ITopUpResult
    {
        int Status { get; set; }
        string? Message { get; set; }
        object? Data { get; set; }
    }

    public class TopUpResult : ITopUpResult
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }

        public TopUpResult()
        {
            Status = -1;
            Message = "Action fail";
        }

        public TopUpResult(int status, string message)
        {
            Status = status;
            Message = message;
        }

        public TopUpResult(int status, string message, object data)
        {
            Status = status;
            Message = message;
            Data = data;
        }
    }
}
