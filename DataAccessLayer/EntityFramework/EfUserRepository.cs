using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositores;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;

namespace DataAccessLayer.EntityFramework;

public class EfUserRepository(IHttpContextAccessor httpContext, UserManager<AppUser> userManager): IUserDal
{

    public int GetCurrentUserId(string userName)
    {
        var user = userManager.Users.Where(x => x.UserName == userName).FirstOrDefault();
        return user.Id;
    }

    public ApiResult<AppUser> GetLoggedUser()
    {
        var user = httpContext.HttpContext.User;
        var id = user.Claims.FirstOrDefault();
        if (id == null)
            return new ApiResult<AppUser> { Message = "Kullanıcı bulunamadı", IsSuccess = false };
        
        var loggedInUser = userManager.Users.Where(x => x.Id.ToString() == id.Value).FirstOrDefault();
        if (loggedInUser == null)
            return new ApiResult<AppUser> { Message = "Kullanıcı bulunamadı", };
        return new ApiResult<AppUser> { Data = loggedInUser, Message = "Kullanıcı bulundu", };
    }
}
