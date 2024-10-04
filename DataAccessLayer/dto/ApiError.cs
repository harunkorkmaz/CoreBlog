using DataAccessLayer.Common.Messages;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccessLayer.dto;


public readonly record struct ApiError
{
    public HttpStatusCode? Code { get; } = HttpStatusCode.InternalServerError;

    [JsonIgnore]
    public string ErrorMessage { get; }

    private ApiError(string message, HttpStatusCode? code)
    {
        ErrorMessage = message;
    }

    public static ApiError Fail(string message = null, HttpStatusCode? code = HttpStatusCode.InternalServerError)
    {
        return new ApiError(message ??= Messages.Basarısız, code);
    }

}