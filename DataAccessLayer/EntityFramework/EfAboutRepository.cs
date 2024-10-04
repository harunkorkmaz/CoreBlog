using DataAccessLayer.Concrete;
using DataAccessLayer.dto;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfAboutRepository(BlogContext context)
{
    public async Task<ApiResultPagination<AboutResponseDto>> GetListAll(FilterModel model)
    {
        var res = context.Abouts.AsNoTracking().Select(x => new AboutResponseDto
        {
            AboutDetails1 = x.AboutDetails1,
            AboutDetails2 = x.AboutDetails2,
            AboutImage1 = x.AboutImage1,
            AboutImage2 = x.AboutImage2,
            AboutMapLocation = x.AboutMapLocation,
            AboutStatus = x.AboutStatus
        });

        return await res.PaginatedListAsync(model.PageNumber, model.PageNumber);
    }

}
