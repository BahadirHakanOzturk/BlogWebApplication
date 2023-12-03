using Blog.Application.ViewModels;
using Blog.Entities.Concrete;
using AutoMapper;
using Blog.Entities.Concrete.User;

namespace Blog.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {       
        CreateMap<Category, CategoryAddVM>().ReverseMap();
        CreateMap<AppRole, RoleVM>().ReverseMap();
        CreateMap<AppRole, RoleUpdateVM>().ReverseMap();
        CreateMap<AppUser, UserSignUpVM>().ReverseMap();
        CreateMap<Comment, CommentVM>().ReverseMap();
    }
}
