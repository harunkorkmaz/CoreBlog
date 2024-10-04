using DataAccessLayer.Abstract;
using DataAccessLayer.dto.Responses;
using DataAccessLayer.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    public int Id => httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == "LoggedInUser")?.Value.ToDeCryptoText().FromJson<JwtTokenDto>().Id ?? 0;
    public string LastName => httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == "LoggedInUser")?.Value.ToDeCryptoText().FromJson<JwtTokenDto>().LastName ?? string.Empty;
    public string ConcurrencyStamp => httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == "LoggedInUser")?.Value.ToDeCryptoText().FromJson<JwtTokenDto>().ConcurrencyStamp ?? string.Empty;
    public string FirstName => httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == "LoggedInUser")?.Value.ToDeCryptoText().FromJson<JwtTokenDto>().FirstName ?? string.Empty;
    public string Phone => httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == "LoggedInUser")?.Value.ToDeCryptoText().FromJson<JwtTokenDto>().Phone ?? string.Empty;
    public string Eposta => httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == "LoggedInUser")?.Value.ToDeCryptoText().FromJson<JwtTokenDto>().Eposta ?? string.Empty;
}
