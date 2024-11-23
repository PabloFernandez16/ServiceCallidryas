
using AutoMapper;
using WebApi_Callidryas.Models;
using WebApi_Callidryas.Models.DTO;

namespace WebApi_Callidryas
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DriverDTO, Driver>();


            // // Configura el mapeo entre Driver y DriverDTO
            // CreateMap<Driver, DriverDTO>()
            //     .ForMember(dest => dest.DriverName, opt => opt.MapFrom(src => src.DriverName))
            //     .ForMember(dest => dest.DriverLastName, opt => opt.MapFrom(src => src.DriverLastName));

            // // Configura el mapeo inverso
            // CreateMap<DriverDTO, Driver>()
            //     .ForMember(dest => dest.DriverName, opt => opt.MapFrom(src => src.DriverName))
            //     .ForMember(dest => dest.DriverLastName, opt => opt.MapFrom(src => src.DriverLastName));

                // Configura el mapeo entre Micro y MicroDTO
            CreateMap<Micro, MicroDTO>()
                .ForMember(dest => dest.PlateNumber, opt => opt.MapFrom(src => src.PlateNumber))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model));

            // Configura el mapeo inverso para MicroDTO a Micro
            CreateMap<MicroDTO, Micro>()
                .ForMember(dest => dest.PlateNumber, opt => opt.MapFrom(src => src.PlateNumber))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model));


            // Mapeo entre DriverVehicleCheck y DriverVehicleCheckDTO
            CreateMap<DriverVehicleCheck, DriverVehicleCheckDTO>()
                .ForMember(dest => dest.DriverId, opt => opt.MapFrom(src => src.DriverId))
                .ForMember(dest => dest.MicroId, opt => opt.MapFrom(src => src.MicroId))
                .ForMember(dest => dest.InitialMileage, opt => opt.MapFrom(src => src.InitialMileage))
                .ForMember(dest => dest.ReviewDate, opt => opt.MapFrom(src => src.ReviewDate))
                .ForMember(dest => dest.WaterLevel, opt => opt.MapFrom(src => src.WaterLevel))
                .ForMember(dest => dest.Clarkson, opt => opt.MapFrom(src => src.Clarkson))
                .ForMember(dest => dest.EngineOilLevel, opt => opt.MapFrom(src => src.EngineOilLevel))
                .ForMember(dest => dest.SteeringOilLevel, opt => opt.MapFrom(src => src.SteeringOilLevel))
                .ForMember(dest => dest.BrakeFluidLevel, opt => opt.MapFrom(src => src.BrakeFluidLevel))
                .ForMember(dest => dest.BodyCondition, opt => opt.MapFrom(src => src.BodyCondition))
                .ForMember(dest => dest.RearviewMirrors, opt => opt.MapFrom(src => src.RearviewMirrors))
                .ForMember(dest => dest.TirePressure, opt => opt.MapFrom(src => src.TirePressure))
                .ForMember(dest => dest.FirstAidKit, opt => opt.MapFrom(src => src.FirstAidKit))
                .ForMember(dest => dest.Trash, opt => opt.MapFrom(src => src.Trash))
                .ForMember(dest => dest.HydraulicJack, opt => opt.MapFrom(src => src.HydraulicJack))
                .ForMember(dest => dest.JackRod, opt => opt.MapFrom(src => src.JackRod))
                .ForMember(dest => dest.ReflectiveVest, opt => opt.MapFrom(src => src.ReflectiveVest))
                .ForMember(dest => dest.FireExtinguisher, opt => opt.MapFrom(src => src.FireExtinguisher))
                .ForMember(dest => dest.Cleanliness, opt => opt.MapFrom(src => src.Cleanliness))
                .ForMember(dest => dest.Remarks, opt => opt.MapFrom(src => src.Remarks));

            // Mapeo inverso de DriverVehicleCheckDTO a DriverVehicleCheck
            CreateMap<DriverVehicleCheckDTO, DriverVehicleCheck>()
                .ForMember(dest => dest.DriverId, opt => opt.MapFrom(src => src.DriverId))
                .ForMember(dest => dest.MicroId, opt => opt.MapFrom(src => src.MicroId))
                .ForMember(dest => dest.InitialMileage, opt => opt.MapFrom(src => src.InitialMileage))
                .ForMember(dest => dest.ReviewDate, opt => opt.MapFrom(src => src.ReviewDate))
                .ForMember(dest => dest.WaterLevel, opt => opt.MapFrom(src => src.WaterLevel))
                .ForMember(dest => dest.Clarkson, opt => opt.MapFrom(src => src.Clarkson))
                .ForMember(dest => dest.EngineOilLevel, opt => opt.MapFrom(src => src.EngineOilLevel))
                .ForMember(dest => dest.SteeringOilLevel, opt => opt.MapFrom(src => src.SteeringOilLevel))
                .ForMember(dest => dest.BrakeFluidLevel, opt => opt.MapFrom(src => src.BrakeFluidLevel))
                .ForMember(dest => dest.BodyCondition, opt => opt.MapFrom(src => src.BodyCondition))
                .ForMember(dest => dest.RearviewMirrors, opt => opt.MapFrom(src => src.RearviewMirrors))
                .ForMember(dest => dest.TirePressure, opt => opt.MapFrom(src => src.TirePressure))
                .ForMember(dest => dest.FirstAidKit, opt => opt.MapFrom(src => src.FirstAidKit))
                .ForMember(dest => dest.Trash, opt => opt.MapFrom(src => src.Trash))
                .ForMember(dest => dest.HydraulicJack, opt => opt.MapFrom(src => src.HydraulicJack))
                .ForMember(dest => dest.JackRod, opt => opt.MapFrom(src => src.JackRod))
                .ForMember(dest => dest.ReflectiveVest, opt => opt.MapFrom(src => src.ReflectiveVest))
                .ForMember(dest => dest.FireExtinguisher, opt => opt.MapFrom(src => src.FireExtinguisher))
                .ForMember(dest => dest.Cleanliness, opt => opt.MapFrom(src => src.Cleanliness))
                .ForMember(dest => dest.Remarks, opt => opt.MapFrom(src => src.Remarks));
        
       }
    }

}
