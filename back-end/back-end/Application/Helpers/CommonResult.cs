namespace back_end.Application.Helpers
{
    public class CommonResult<T>
    {
        public bool IsSuccess { get; init; }
        public T? Data { get; init; }
        public string? Error { get; init; }
        public int? StatusCode { get; init; }

        public static CommonResult<T> Success(T data) =>
            new() { IsSuccess = true, Data = data, StatusCode = 200 };

        public static CommonResult<T> Fail(string error, int statusCode = 400) =>
            new() { IsSuccess = false, Error = error, StatusCode = statusCode };
    }
}
