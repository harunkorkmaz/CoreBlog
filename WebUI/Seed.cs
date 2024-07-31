
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
            };

            await context.Tags.AddRangeAsync(tags);
            await context.SaveChangesAsync();
        }

        if (!context.Blogs.Any())
        {
            var listBlogs = new List<Blog> {
                new() {
                    BlogImage = "/CoreBlogTema/images/2.jpg",
                    Title = "Lorem ipsum dolor sit amet",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec at quam nec ex suscipit tincidunt id eget ante. In tincidunt lorem in ex feugiat dignissim. Vestibulum vulputate accumsan est, ut iaculis lacus sagittis nec. Fusce risus sem, ultrices vitae vehicula ac, blandit in lacus. Fusce ac mauris laoreet ex maximus viverra at eget mauris. Nulla aliquet neque non porttitor aliquam. Aenean a ultrices tortor, a posuere eros. Suspendisse tincidunt efficitur nunc, et sollicitudin lacus commodo pharetra. Proin euismod sodales erat, non mollis ligula. Sed ligula quam, malesuada aliquam mollis id, cursus eu justo. Cras ac massa accumsan, gravida sem ut, convallis orci. Ut leo felis, faucibus in posuere vel, vulputate eget ex. Vivamus hendrerit orci tellus, sed mollis augue gravida ac. Suspendisse rutrum lobortis orci, nec malesuada nisl congue sed. Morbi tristique est sed nisi gravida congue. Nulla egestas lorem in finibus volutpat.\r\n\r\nNulla id porttitor libero, eu efficitur nisi. Praesent lobortis quam in purus placerat viverra. Donec nec nibh efficitur, rhoncus enim quis, tincidunt nibh. Etiam tincidunt purus non elit elementum viverra. Cras sit amet maximus ligula. Quisque vestibulum diam congue ornare ornare. Quisque est risus, bibendum sed elit eget, condimentum imperdiet nisl. Nulla id faucibus urna. Nam mollis, dui eu iaculis pharetra, velit ex consectetur felis, ut lacinia lacus nibh id massa. Cras feugiat metus lorem. Praesent a leo bibendum, consequat magna et, dictum leo.\r\n\r\nDonec eu ante non metus auctor posuere ut a ex. Fusce sit amet ligula egestas augue viverra laoreet. Aliquam vitae augue lectus. Mauris placerat feugiat nibh, vitae tincidunt risus euismod non. Cras fringilla orci odio, vitae facilisis dui luctus non. Aenean leo tellus, pulvinar eu semper ut, aliquam sed nisl. Sed egestas et felis vel vestibulum. Quisque fringilla tempor est eget pretium. Morbi facilisis erat vel eros elementum efficitur. Nullam sodales viverra massa auctor faucibus. Nullam laoreet non diam ut condimentum. Integer commodo velit non mauris tempus feugiat. Duis ex massa, pellentesque non risus et, interdum vehicula libero. Morbi congue, nibh vitae aliquam vehicula, tortor felis scelerisque tortor, in pretium metus ipsum eu mi.\r\n\r\nCras congue condimentum nisi, eget eleifend diam vehicula ut. Aenean congue mi erat, a eleifend lorem efficitur vitae. Sed pellentesque elementum nulla, id euismod turpis tempor vitae. Aliquam mattis vulputate mi ut tempus. Proin fermentum urna sed mollis congue. Ut mattis ultrices purus, a bibendum felis feugiat et. Nullam porta ipsum tortor, sit amet consequat ipsum dictum eget. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Suspendisse potenti. Nunc non dolor sit amet ante aliquet semper at eu tellus. Integer venenatis pellentesque mauris, in ullamcorper libero accumsan ut. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec tempus quis augue vitae finibus. Integer vitae congue elit, quis malesuada nulla. ",
                    UserId = context.Users.FirstOrDefault().Id,
                    Tags = [.. context.Tags],
                },
                new() {
                    BlogImage = "/CoreBlogTema/images/3.jpg",
                    Title = "Lorem ipsum dolor sit amet",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec at quam nec ex suscipit tincidunt id eget ante. In tincidunt lorem in ex feugiat dignissim. Vestibulum vulputate accumsan est, ut iaculis lacus sagittis nec. Fusce risus sem, ultrices vitae vehicula ac, blandit in lacus. Fusce ac mauris laoreet ex maximus viverra at eget mauris. Nulla aliquet neque non porttitor aliquam. Aenean a ultrices tortor, a posuere eros. Suspendisse tincidunt efficitur nunc, et sollicitudin lacus commodo pharetra. Proin euismod sodales erat, non mollis ligula. Sed ligula quam, malesuada aliquam mollis id, cursus eu justo. Cras ac massa accumsan, gravida sem ut, convallis orci. Ut leo felis, faucibus in posuere vel, vulputate eget ex. Vivamus hendrerit orci tellus, sed mollis augue gravida ac. Suspendisse rutrum lobortis orci, nec malesuada nisl congue sed. Morbi tristique est sed nisi gravida congue. Nulla egestas lorem in finibus volutpat.\r\n\r\nNulla id porttitor libero, eu efficitur nisi. Praesent lobortis quam in purus placerat viverra. Donec nec nibh efficitur, rhoncus enim quis, tincidunt nibh. Etiam tincidunt purus non elit elementum viverra. Cras sit amet maximus ligula. Quisque vestibulum diam congue ornare ornare. Quisque est risus, bibendum sed elit eget, condimentum imperdiet nisl. Nulla id faucibus urna. Nam mollis, dui eu iaculis pharetra, velit ex consectetur felis, ut lacinia lacus nibh id massa. Cras feugiat metus lorem. Praesent a leo bibendum, consequat magna et, dictum leo.\r\n\r\nDonec eu ante non metus auctor posuere ut a ex. Fusce sit amet ligula egestas augue viverra laoreet. Aliquam vitae augue lectus. Mauris placerat feugiat nibh, vitae tincidunt risus euismod non. Cras fringilla orci odio, vitae facilisis dui luctus non. Aenean leo tellus, pulvinar eu semper ut, aliquam sed nisl. Sed egestas et felis vel vestibulum. Quisque fringilla tempor est eget pretium. Morbi facilisis erat vel eros elementum efficitur. Nullam sodales viverra massa auctor faucibus. Nullam laoreet non diam ut condimentum. Integer commodo velit non mauris tempus feugiat. Duis ex massa, pellentesque non risus et, interdum vehicula libero. Morbi congue, nibh vitae aliquam vehicula, tortor felis scelerisque tortor, in pretium metus ipsum eu mi.\r\n\r\nCras congue condimentum nisi, eget eleifend diam vehicula ut. Aenean congue mi erat, a eleifend lorem efficitur vitae. Sed pellentesque elementum nulla, id euismod turpis tempor vitae. Aliquam mattis vulputate mi ut tempus. Proin fermentum urna sed mollis congue. Ut mattis ultrices purus, a bibendum felis feugiat et. Nullam porta ipsum tortor, sit amet consequat ipsum dictum eget. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Suspendisse potenti. Nunc non dolor sit amet ante aliquet semper at eu tellus. Integer venenatis pellentesque mauris, in ullamcorper libero accumsan ut. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec tempus quis augue vitae finibus. Integer vitae congue elit, quis malesuada nulla. ",
                    UserId = context.Users.FirstOrDefault().Id,
                    Tags = [.. context.Tags.Take(3)],
                },
                new() {
                    BlogImage = "/CoreBlogTema/images/3.jpg",
                    Title = "Lorem ipsum dolor sit amet",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec at quam nec ex suscipit tincidunt id eget ante. In tincidunt lorem in ex feugiat dignissim. Vestibulum vulputate accumsan est, ut iaculis lacus sagittis nec. Fusce risus sem, ultrices vitae vehicula ac, blandit in lacus. Fusce ac mauris laoreet ex maximus viverra at eget mauris. Nulla aliquet neque non porttitor aliquam. Aenean a ultrices tortor, a posuere eros. Suspendisse tincidunt efficitur nunc, et sollicitudin lacus commodo pharetra. Proin euismod sodales erat, non mollis ligula. Sed ligula quam, malesuada aliquam mollis id, cursus eu justo. Cras ac massa accumsan, gravida sem ut, convallis orci. Ut leo felis, faucibus in posuere vel, vulputate eget ex. Vivamus hendrerit orci tellus, sed mollis augue gravida ac. Suspendisse rutrum lobortis orci, nec malesuada nisl congue sed. Morbi tristique est sed nisi gravida congue. Nulla egestas lorem in finibus volutpat.\r\n\r\nNulla id porttitor libero, eu efficitur nisi. Praesent lobortis quam in purus placerat viverra. Donec nec nibh efficitur, rhoncus enim quis, tincidunt nibh. Etiam tincidunt purus non elit elementum viverra. Cras sit amet maximus ligula. Quisque vestibulum diam congue ornare ornare. Quisque est risus, bibendum sed elit eget, condimentum imperdiet nisl. Nulla id faucibus urna. Nam mollis, dui eu iaculis pharetra, velit ex consectetur felis, ut lacinia lacus nibh id massa. Cras feugiat metus lorem. Praesent a leo bibendum, consequat magna et, dictum leo.\r\n\r\nDonec eu ante non metus auctor posuere ut a ex. Fusce sit amet ligula egestas augue viverra laoreet. Aliquam vitae augue lectus. Mauris placerat feugiat nibh, vitae tincidunt risus euismod non. Cras fringilla orci odio, vitae facilisis dui luctus non. Aenean leo tellus, pulvinar eu semper ut, aliquam sed nisl. Sed egestas et felis vel vestibulum. Quisque fringilla tempor est eget pretium. Morbi facilisis erat vel eros elementum efficitur. Nullam sodales viverra massa auctor faucibus. Nullam laoreet non diam ut condimentum. Integer commodo velit non mauris tempus feugiat. Duis ex massa, pellentesque non risus et, interdum vehicula libero. Morbi congue, nibh vitae aliquam vehicula, tortor felis scelerisque tortor, in pretium metus ipsum eu mi.\r\n\r\nCras congue condimentum nisi, eget eleifend diam vehicula ut. Aenean congue mi erat, a eleifend lorem efficitur vitae. Sed pellentesque elementum nulla, id euismod turpis tempor vitae. Aliquam mattis vulputate mi ut tempus. Proin fermentum urna sed mollis congue. Ut mattis ultrices purus, a bibendum felis feugiat et. Nullam porta ipsum tortor, sit amet consequat ipsum dictum eget. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Suspendisse potenti. Nunc non dolor sit amet ante aliquet semper at eu tellus. Integer venenatis pellentesque mauris, in ullamcorper libero accumsan ut. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec tempus quis augue vitae finibus. Integer vitae congue elit, quis malesuada nulla. ",
                    UserId = context.Users.FirstOrDefault().Id,
                    Tags = [.. context.Tags],
                },
                new()
                {
                    Title = "Lorem ipsum dolor sit amet",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec at quam nec ex suscipit tincidunt id eget ante. In tincidunt lorem in ex feugiat dignissim. Vestibulum vulputate accumsan est, ut iaculis lacus sagittis nec. Fusce risus sem, ultrices vitae vehicula ac, blandit in lacus. Fusce ac mauris laoreet ex maximus viverra at eget mauris. Nulla aliquet neque non porttitor aliquam. Aenean a ultrices tortor, a posuere eros. Suspendisse tincidunt efficitur nunc, et sollicitudin lacus commodo pharetra. Proin euismod sodales erat, non mollis ligula. Sed ligula quam, malesuada aliquam mollis id, cursus eu justo. Cras ac massa accumsan, gravida sem ut, convallis orci. Ut leo felis, faucibus in posuere vel, vulputate eget ex. Vivamus hendrerit orci tellus, sed mollis augue gravida ac. Suspendisse rutrum lobortis orci, nec malesuada nisl congue sed. Morbi tristique est sed nisi gravida congue. Nulla egestas lorem in finibus volutpat.\r\n\r\nNulla id porttitor libero, eu efficitur nisi. Praesent lobortis quam in purus placerat viverra. Donec nec nibh efficitur, rhoncus enim quis, tincidunt nibh. Etiam tincidunt purus non elit elementum viverra. Cras sit amet maximus ligula. Quisque vestibulum diam congue ornare ornare. Quisque est risus, bibendum sed elit eget, condimentum imperdiet nisl. Nulla id faucibus urna. Nam mollis, dui eu iaculis pharetra, velit ex consectetur felis, ut lacinia lacus nibh id massa. Cras feugiat metus lorem. Praesent a leo bibendum, consequat magna et, dictum leo.\r\n\r\nDonec eu ante non metus auctor posuere ut a ex. Fusce sit amet ligula egestas augue viverra laoreet. Aliquam vitae augue lectus. Mauris placerat feugiat nibh, vitae tincidunt risus euismod non. Cras fringilla orci odio, vitae facilisis dui luctus non. Aenean leo tellus, pulvinar eu semper ut, aliquam sed nisl. Sed egestas et felis vel vestibulum. Quisque fringilla tempor est eget pretium. Morbi facilisis erat vel eros elementum efficitur. Nullam sodales viverra massa auctor faucibus. Nullam laoreet non diam ut condimentum. Integer commodo velit non mauris tempus feugiat. Duis ex massa, pellentesque non risus et, interdum vehicula libero. Morbi congue, nibh vitae aliquam vehicula, tortor felis scelerisque tortor, in pretium metus ipsum eu mi.\r\n\r\nCras congue condimentum nisi, eget eleifend diam vehicula ut. Aenean congue mi erat, a eleifend lorem efficitur vitae. Sed pellentesque elementum nulla, id euismod turpis tempor vitae. Aliquam mattis vulputate mi ut tempus. Proin fermentum urna sed mollis congue. Ut mattis ultrices purus, a bibendum felis feugiat et. Nullam porta ipsum tortor, sit amet consequat ipsum dictum eget. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Suspendisse potenti. Nunc non dolor sit amet ante aliquet semper at eu tellus. Integer venenatis pellentesque mauris, in ullamcorper libero accumsan ut. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec tempus quis augue vitae finibus. Integer vitae congue elit, quis malesuada nulla. ",
                    BlogImage = "/CoreBlogTema/images/4.jpg",
                    UserId = context.Users.FirstOrDefault().Id,
                    Tags = [.. context.Tags],
                }
            };

            await context.Blogs.AddRangeAsync(listBlogs);
            await context.SaveChangesAsync();
        }
    }
}
