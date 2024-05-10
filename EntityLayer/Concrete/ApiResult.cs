
public class ApiResult : ApiResult<object>
{

}

public class ApiResult<T>
{
    public ApiResult(bool isSuccess = true, object message = null)
    {
        IsSuccess = isSuccess;
        Message = message;
    }
    public bool IsSuccess { get; set; }
    public T Data { get; set; }
    public object Message { get; set; }

}
