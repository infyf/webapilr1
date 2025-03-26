namespace lab5.Services
{
    public class ApiResponse<T>
    {
        public string Message { get; set; } = "Success";
        public int StatusCode { get; set; }
        public List<T> Data { get; set; } = new List<T>();
    }
}

