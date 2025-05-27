using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers;
public class RegisterRequestMappingProfile : Profile
{
    public RegisterRequestMappingProfile()
    {
        CreateMap<RegisterRequest, ApplicationUser>()
            .ForMember(Dest => Dest.Email, Opt => Opt.MapFrom(src => src.Email))
            .ForMember(Dest => Dest.Password, Opt => Opt.MapFrom(src => src.Password))
            .ForMember(Dest => Dest.PersonName, Opt => Opt.MapFrom(src => src.PersonName))
            .ForMember(Dest => Dest.Gender, Opt => Opt.MapFrom(src => src.PersonName))
            .ReverseMap();

        //.ForMember(Dest => Dest.UserId, Opt => Opt.Ignore());
    }
}

