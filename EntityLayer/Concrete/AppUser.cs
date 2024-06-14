using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Concrete;

public class AppUser : IdentityUser<int>
{
    public string FullName { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
}

