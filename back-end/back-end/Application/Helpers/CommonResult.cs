namespace back_end.Application.Helpers
{
    public class CommonResult<T>
    {
        public bool IsSuccess { get; init; }
        public T? Value { get; init; }
        public string? Error { get; init; }
        public int? StatusCode { get; init; }

        public static CommonResult<T> Success(T value) =>
            new() { IsSuccess = true, Value = value, StatusCode = 200 };

        public static CommonResult<T> Fail(string error, int statusCode = 400) =>
            new() { IsSuccess = false, Error = error, StatusCode = statusCode };
    }
}
