using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositores;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;

namespace DataAccessLayer.EntityFramework
{
    public class EfUserRepository(IHttpContextAccessor httpContext, UserManager<AppUser> userManager) : GenericRepository<AppUser>, IUserDal
    {
        private readonly IHttpContextAccessor _httpContext = httpContext;
        private readonly UserManager<AppUser> _userManager = userManager;

        public int GetCurrentUserId(string userName)
        {
            var user = _userManager.Users.Where(x => x.UserName == userName).FirstOrDefault();
            return user.Id;
        }

        public ApiResult<AppUser> GetLoggedUser()
        {
            var _context = new BlogContext();

            var user = _httpContext.HttpContext.User;
            var id = user.Claims.FirstOrDefault();
            if (id == null)
                return new ApiResult<AppUser> { Message = "Kullanıcı bulunamadı", };
            
            var loggedInUser = _userManager.Users.Where(x => x.Id.ToString() == id.Value).FirstOrDefault();
            if (loggedInUser == null)
                return new ApiResult<AppUser> { Message = "Kullanıcı bulunamadı", };
            return new ApiResult<AppUser> { Data = loggedInUser, Message = "Kullanıcı bulundu", };
        }
    }
}
