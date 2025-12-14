namespace MultiTenantNoteApp.Helper
{
    public class ApiResponse<T>
    {
        public string Message { get; set; }

        public int StatusCode { get; set; }
        public T? Data { get; set; }

        public string? Error { get; set; }   
        public bool IsScucces { get; set; } 
        public ApiResponse(string message,int  statuscode, T data,string? error = null)
        {
            Message = message;
            StatusCode = statuscode;
            Error = error;
            Data = data;
            IsScucces = string.IsNullOrEmpty(error);   
            
        }
    }
}
