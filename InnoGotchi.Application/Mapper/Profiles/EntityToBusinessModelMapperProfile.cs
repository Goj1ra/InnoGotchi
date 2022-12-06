using AutoMapper;
using InnoGotchi.Application.Models;
using InnoGotchi.Core.Entities;

namespace InnoGotchi.Application.Mapper.Profiles
{
    public class EntityToBusinessModelMapperProfile : Profile
    {
        public EntityToBusinessModelMapperProfile()
        {
            CreateMap<User, UserModel>()
                .ReverseMap();

            CreateMap<Pet, PetModel>()
                .ReverseMap();

            CreateMap<Farm, FarmModel>()
                .ReverseMap();

            CreateMap<Role, RoleModel>()
                .ReverseMap();

            CreateMap<PetsBody, PetsBodyModel>()
                .ReverseMap();

            CreateMap<UserStatistics, UserStatisticsModel>()
                .ReverseMap();
        }
    }
}
