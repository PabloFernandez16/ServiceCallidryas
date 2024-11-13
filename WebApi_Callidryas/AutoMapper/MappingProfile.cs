
using AutoMapper;
using WebApi_Callidryas.Models;
using WebApi_Callidryas.Models.DTO;

namespace WebApi_Callidryas
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Configura el mapeo entre Driver y DriverDTO
            CreateMap<Driver, DriverDTO>()
                .ForMember(dest => dest.DriverName, opt => opt.MapFrom(src => src.DriverName))
                .ForMember(dest => dest.DriverLastName, opt => opt.MapFrom(src => src.DriverLastName));

            // Configura el mapeo inverso
            CreateMap<DriverDTO, Driver>()
                .ForMember(dest => dest.DriverName, opt => opt.MapFrom(src => src.DriverName))
                .ForMember(dest => dest.DriverLastName, opt => opt.MapFrom(src => src.DriverLastName));

                // Configura el mapeo entre Driver y DriverDTO
            CreateMap<Micro, MicroDTO>()
                .ForMember(dest => dest.PlateNumber, opt => opt.MapFrom(src => src.PlateNumber))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model));

            // Configura el mapeo inverso
            CreateMap<Micro, MicroDTO>()
                .ForMember(dest => dest.PlateNumber, opt => opt.MapFrom(src => src.PlateNumber))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model));
        }
    }
}
