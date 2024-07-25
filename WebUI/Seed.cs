
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

public static class Seeder
{
    public static async Task SeedAsync(BlogContext context, UserManager<AppUser> userManager)
    {
        if (!context.Users.Any())
        {
            var user = new AppUser
            {
                UserName = "karun",
                Email = "1harunkorkmaz@gmail.com",
                FullName = "harun korkmaz",
                ImageUrl = "",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
            };

            await userManager.CreateAsync(user, "Password123!");
        }

        if (!context.Tags.Any())
        {
            var tags = new List<Tag>
            {
                new() { Name = "C#" },
                new() { Name = "C" },
                new() { Name = "Python" },
                new() { Name = "Javascript" },
                new() { Name = "Go" },
                new() { Name = "Linux" },
                new() { Name = "Kocaeli Üniversitesi" },
                new() { Name = "Raspberry Pi" },
                new() { Name = "Dev Ops" },
                new() { Name = "İş" },
                new() { Name = "Bitirme" },
                new() { Name = "Rust" }
            };

            await context.Tags.AddRangeAsync(tags);
            await context.SaveChangesAsync();
        }

        if (!context.Blogs.Any())
        {
            var blog = new Blog
            {
                Title = "Blog Title",
                Content = "Blog Content",
                BlogImage = "",
                UserId = context.Users.FirstOrDefault().Id,
                User = context.Users.FirstOrDefault(),
                Tags = [.. context.Tags]
            };

            await context.Blogs.AddAsync(blog);
            await context.SaveChangesAsync();
        }
        
    }
}
