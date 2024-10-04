using DataAccessLayer.dto;
using DataAccessLayer.dto.Responses;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace DataAccessLayer.EntityFramework;

public class EfUserRepository(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
{
    public async Task<ApiResult> RegisterAsync(UserSignUpViewModel model)
    {
        var user = new AppUser
        {
            UserName = model.UserName,
            Email = model.Mail,
            FullName = model.FullName
        };

        var result = await userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            return ApiResult.Success();
        }

        return ApiError.Fail();
    }

    public async Task<ApiResult> LoginAsync(UserSignInViewModel model)
    {
        var user = await userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            return ApiError.Fail("Kullanıcı bulunamadı");
        }

        var result = await userManager.CheckPasswordAsync(user, model.Password);
        if (!result)
        {
            ApiError.Fail("Şifre hatalı");
        }
        var jwtToken = new JwtTokenDto
        {
            Id = user.Id,
            FirstName = user.FullName,
            Eposta = user.Email,
            Phone = user.PhoneNumber,
        };

        httpContextAccessor?.HttpContext?.Response.Cookies.Append("LogginUser", JsonConvert.SerializeObject(user));
        return ApiResult.Success();
    }

    public async Task<ApiResult> LogoutAsync()
    {
        httpContextAccessor?.HttpContext?.Response.Cookies.Delete("LogginUser");
        return ApiResult.Success();
    }

    public async Task<ApiResult> UpdateAsync(UserUpdateViewModel model)
    {
        var user = await userManager.FindByEmailAsync(model.mail);
        if (user == null)
        {
            return ApiError.Fail("Kullanıcı bulunamadı");
        }

        user.FullName = model.namesurname;
        user.ImageUrl = model.imageurl;

        var result = await userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            return ApiResult.Success();
        }

        return ApiError.Fail();
    }

    public async Task<ApiResult<UserUpdateViewModel>> EditGetUserAsync()
    {
        var user = await userManager.FindByEmailAsync(httpContextAccessor.HttpContext.User.Identity.Name);
        if (user == null)
        {
            return ApiError.Fail();
        }

        var model = new UserUpdateViewModel
        {
            username = user.FullName,
            mail = user.Email,
            imageurl = user.ImageUrl
        };

        return model;
    }

    public async Task<ApiResult> EditUser(UserUpdateViewModel model)
    {
        var user = await userManager.FindByEmailAsync(model.mail);
        if (user == null)
        {
            return ApiError.Fail("Kullanıcı bulunamadı");
        }

        user.FullName = model.username;
        user.ImageUrl = model.imageurl;

        var result = await userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            return ApiResult.Success();
        }

        return ApiError.Fail();
    }
}
