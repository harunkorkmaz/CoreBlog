using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace WebUI.Helpers;

public static class IdentityHelpers
{
    public static string GetUserId(this IHttpContextAccessor httpContextAccessor)
    {
        return httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }

    public static string GetUserName(this IHttpContextAccessor httpContextAccessor)
    {
        return httpContextAccessor.HttpContext.User.Identity.Name;
    }

    public static string GetUserEmail(this IHttpContextAccessor httpContextAccessor)
    {
        return httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
    }

    public static string GetUserRole(this IHttpContextAccessor httpContextAccessor)
    {
        return httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role).Value;
    }

    public static string GetUserFullName(this IHttpContextAccessor httpContextAccessor)
    {
        return httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.GivenName).Value;
    }

    public static string GetUserLastName(this IHttpContextAccessor httpContextAccessor)
    {
        return httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Surname).Value;
    }
}


