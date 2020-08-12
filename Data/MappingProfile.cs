using AutoMapper;
using EelamHeroes.Models.Dto;
using EelamHeroes.Models.Entity;
using EelamHeroes.Models.ViewModel;

namespace EelamHeroes.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Hero, HeroDto>()
                .ForMember(dest => dest.Rank, opts => opts.MapFrom(src => src.Rank.Name));
            CreateMap<Hero, HeroDetailsDto>()
                .ForMember(dest => dest.Rank, opts => opts.MapFrom(src => src.Rank.Name))
                .ForMember(dest => dest.District, opts => opts.MapFrom(src => src.District.Name))
                .ForMember(dest => dest.Division, opts => opts.MapFrom(src => src.Division.Name))
                .ForMember(dest => dest.Gender, opts => opts.MapFrom(src => src.Gender.Name))
                .ForMember(dest => dest.RestingHome, opts => opts.MapFrom(src => src.RestingHome.Name));

            CreateMap<HeroAddOrUpdateViewModel, Hero>().ReverseMap();
            CreateMap<PostAddOrUpdateViewModel, Post>().ReverseMap();
            
            CreateMap<District, GeneralDto>();
            CreateMap<Division, GeneralDto>();
            CreateMap<Gender, GeneralDto>();
            CreateMap<Rank, GeneralDto>();
            CreateMap<RestingHome, GeneralDto>();
        }
    }
}