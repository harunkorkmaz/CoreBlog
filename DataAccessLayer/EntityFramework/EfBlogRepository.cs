
using DataAccessLayer.Concrete;
using DataAccessLayer.dto;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace DataAccessLayer.EntityFramework;

public class EfBlogRepository(BlogContext context, UserManager<AppUser> _userManager)
{
    private readonly BlogContext blogContext = context;

    public async Task<ApiResultPagination<Blog>> GetAll(FilterModel model)
    {
        var list = blogContext.Blogs
            .AsNoTracking()
            .Include(x => x.Tags)
            .Where(x => !x.IsDeleted);

        return await list.PaginatedListAsync(model.PageNumber, model.PageSize);
    }

    public async Task<ApiResultPagination<Blog>> GetAll(FilterModel model, int writerId)
    {
        var list = blogContext.Blogs
            .AsNoTracking()
            .Include(x => x.Tags)
            .Where(x => !x.IsDeleted && x.UserId == writerId);

        return await list.PaginatedListAsync(model.PageNumber, model.PageSize);
    }

    public async Task<ApiResult> DeleteAsync(int id)
    {
        var item = blogContext.Blogs.Where(x => x.Id == id && !x.IsDeleted).FirstOrDefault();
        if (item != null)
        {
            item.IsDeleted = true;
            await blogContext.SaveChangesAsync();
        }
        return ApiResult.Success();
    }

    public async Task<ApiResult> Insert(Blog item)
    {
        blogContext.Blogs.Add(item);
        blogContext.SaveChanges();
        return ApiResult.Success();
    }

    public Blog GetById(int id)
    {
        return blogContext.Blogs
            .Include(x => x.Tags)
            .Where(x => x.Id == id && !x.IsDeleted)
            .FirstOrDefault();
    }
}
