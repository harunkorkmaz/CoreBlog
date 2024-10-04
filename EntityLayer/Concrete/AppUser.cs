using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic.FileIO;

namespace EntityLayer.Concrete;

public class AppUser : IdentityUser<int>
{
    public string? FullName { get; set; } = null!;
    public string? ImageUrl { get; set; } = null!;
    public string? FileName { get; set; }
    public string? OriginalFileName { get; set; }
    public string? Extension { get; set; }
    public double? FileSizeByte { get; set; }
}
