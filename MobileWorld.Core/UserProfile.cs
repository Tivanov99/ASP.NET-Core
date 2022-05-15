using AutoMapper;
using MobileWorld.Core.ViewModels;
using MobileWorld.Infrastructure.Data.QueriesAndSPDtoModels;

namespace MobileWorld.Core
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<EngineSpModel , EngineViewModel>();
            CreateMap<CarSpModel,CarViewModel>();
            CreateMap<AdInfoSpModel, AdViewModel>();
            //CreateMap<AdSpModel, AdViewModel>()
            //    .ForMember(pts => pts.Car, opt => opt.MapFrom(ps => ps.Car))
            //    .ForMember(pts => pts.Car.Engine, opt => opt.MapFrom(ps => ps.Engine))
            //    .ForMember(pts => pts.PhoneNumber, opt => opt.MapFrom(ps => ps.AdInfo.PhoneNumber))
            //    .ForMember(pts => pts.Title, opt => opt.MapFrom(ps => ps.AdInfo.Title))
            //    .ForMember(pts => pts.Price, opt => opt.MapFrom(ps => ps.AdInfo.Price))
            //    .ForMember(pts => pts.CreatedOn, opt => opt.MapFrom(ps => ps.AdInfo.CreatedOn))
            //    .ForMember(pts => pts.Description, opt => opt.MapFrom(ps => ps.AdInfo.Description))
            //    .ForMember(pts => pts.Id, opt => opt.MapFrom(ps => ps.AdInfo.Id));


            //CreateMap<AdInfoSpModel, AdViewModel>()
            //    .ForPath(pts => pts.Car.Color, opt => opt.MapFrom(ps => ps.Color))
            //    .ForPath(pts => pts.Car.GearType, opt => opt.MapFrom(ps => ps.GearType))
            //    .ForPath(pts => pts.Car.Make, opt => opt.MapFrom(ps => ps.Make))
            //    .ForPath(pts => pts.Car.Mileage, opt => opt.MapFrom(ps => ps.Mileage))
            //    .ForPath(pts => pts.Car.SeatsCount, opt => opt.MapFrom(ps => ps.SeatsCount))
            //    .ForPath(pts => pts.Car.Year, opt => opt.MapFrom(ps => ps.Year))
            //    .ForPath(pts => pts.Car.Engine.FuelType, opt => opt.MapFrom(ps => ps.FuelType))
            //    .ForPath(pts => pts.Car.Engine.CubicCapacity, opt => opt.MapFrom(ps => ps.CubicCapacity))
            //    .ForPath(pts => pts.Car.Engine.NewtonMeter, opt => opt.MapFrom(ps => ps.NewtonMeter))
            //    .ForPath(pts => pts.Car.Engine.EcoLevel, opt => opt.MapFrom(ps => ps.EcoLevel))
            //    .ForPath(pts => pts.Car.Engine.FuelConsuption, opt => opt.MapFrom(ps => ps.FuelConsuption))
            //    .ForPath(pts => pts.Car.Engine.HorsePower, opt => opt.MapFrom(ps => ps.HorsePower));

        }
    }
}
