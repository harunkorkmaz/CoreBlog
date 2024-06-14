using Microsoft.EntityFrameworkCore;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Concrete;

public class BlogContext : IdentityDbContext<AppUser, AppRole, int>
{
    public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var conf = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            string stringUrl = conf.GetConnectionString("local");
            optionsBuilder.UseNpgsql(stringUrl);
        }
    }

    public DbSet<About> Abouts { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<NewsLetter> NewsLetters { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Admin> Admins { get; set; }
}

