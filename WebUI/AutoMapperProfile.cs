using AutoMapper;
using EntityLayer.Dto;
using EntityLayer.Concrete;
using DocumentFormat.OpenXml.Bibliography;

namespace WebUI;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<RegisterDto, Writer>();
        CreateMap<Writer, RegisterDto>();
        CreateMap<Comment, CommentDto>();
    }
}
