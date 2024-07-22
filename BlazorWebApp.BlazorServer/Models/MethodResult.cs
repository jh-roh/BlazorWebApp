namespace BlazorWebApp.BlazorServer.Models
{
    public struct MethodResult
    {
        public bool Status { get; set; }
        public string? ErrorMessage { get; set; }

        public MethodResult(bool status, string? errorMessage = null)
        {
            Status = status;
            ErrorMessage = errorMessage;
        }


        public static MethodResult Success() => new(true);

        public static MethodResult Failure(string errorMessage) => new(false, errorMessage);

    }
}
