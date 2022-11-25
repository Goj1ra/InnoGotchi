using AutoMapper;
using InnoGotchi.API.ViewModels;
using InnoGotchi.Application.Models;

namespace InnoGotchi.API.Mapper.Profiles
{
    public class ApiToBusinessModelMapperProfile : Profile
    {
        public ApiToBusinessModelMapperProfile()
        {
            CreateMap<UserModel, UserLoginViewModel>()
                .ReverseMap();

            CreateMap<UserModel, UserRegisterViewModel>()
                .ReverseMap();

            CreateMap<UserModel, UserViewModel>()
                .ReverseMap();

            CreateMap<UserModel, UserUpdateViewModel>()
                .ReverseMap();

            CreateMap<FarmModel, FarmViewModel>()
                .ReverseMap();
        }
    }
}
