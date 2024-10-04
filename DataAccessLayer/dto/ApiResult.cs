using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Common.Messages;

namespace DataAccessLayer.dto;

public readonly record struct ApiResult<TData>
{
    public bool IsSuccess => Error == null;
    public string Message { get; }
    public ApiError? Error { get; }
    public TData Data { get; } = default;


    private ApiResult(ApiError error)
    {
        Message = error.ErrorMessage;
        Error = error;
    }

    private ApiResult(TData data)
    {
        Data = data;
        Message = Messages.Basarılı;
    }


    public static implicit operator ApiResult<TData>(TData data)
    {
        return new ApiResult<TData>(data);
    }

    public static implicit operator ApiResult<TData>(ApiError error)
    {
        return new ApiResult<TData>(error);
    }

}


public readonly record struct ApiResult
{
    public bool IsSuccess => Error == null;
    public string Message { get; } = Messages.Basarılı;
    public ApiError? Error { get; }

    private ApiResult(ApiError error)
    {
        Message = error.ErrorMessage;
        Error = error;
    }

    public static implicit operator ApiResult(ApiError error)
    {
        return new ApiResult(error);
    }

    public static ApiResult Success()
    {
        return new ApiResult();
    }
}

