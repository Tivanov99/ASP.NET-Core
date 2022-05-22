using AutoMapper;
using MobileWorld.Core.Models.InputModels;
using MobileWorld.Core.ViewModels;
using MobileWorld.Core.ViewModels.FeatureDetailModels;
using MobileWorld.Infrastructure.Data.Identity;
using MobileWorld.Infrastructure.Data.Models;
using MobileWorld.Infrastructure.Data.QueriesAndSPDtoModels;

namespace MobileWorld.Core
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<OwnerInputModel, ApplicationUser>()
                

            CreateMap<EngineViewModel, Engine>();
            CreateMap<EngineSpModel , EngineViewModel>();
            CreateMap<EngineSpModel, EngineInputModel>();

            CreateMap<CarSpModel, CarViewModel>()
             .ForMember(pts => pts.GearType, opt => opt.MapFrom(ps => ps.GearType));

            CreateMap<CarSpModel, CarInputModel>()
             .ForMember(pts => pts.GearType, opt => opt.MapFrom(ps => ps.GearType));

            CreateMap<CarInputModel, Car>();

            CreateMap<AdInfoSpModel, AdViewModel>();
            CreateMap<AdInfoSpModel, AdInputModel>();
            CreateMap<AdInfoSpModel, OwnerViewModel>();
            CreateMap<AdInfoSpModel, OwnerInputModel>();
            CreateMap<AdInputModel, Ad>();


            CreateMap<AdInfoSpModel, RegionViewModel>()
                .ForMember(pts => pts.Neiborhood, opt => opt.MapFrom(ps => ps.Neiborhood))
                .ForMember(pts => pts.TownName, opt => opt.MapFrom(ps => ps.TownName))
                .ForMember(pts => pts.RegionName, opt => opt.MapFrom(ps => ps.RegionName));

            CreateMap<AdInfoSpModel, RegionInputModel>()
                .ForMember(pts => pts.Neiborhood, opt => opt.MapFrom(ps => ps.Neiborhood))
                .ForMember(pts => pts.TownName, opt => opt.MapFrom(ps => ps.TownName))
                .ForMember(pts => pts.RegionName, opt => opt.MapFrom(ps => ps.RegionName));

            CreateMap<RegionInputModel, Region>()
                .ForMember(pts => pts.Town.TownName, opt => opt.MapFrom(ps => ps.TownName));

            CreateMap<FeatureSpModel, ComfortDetailViewModel>();
            CreateMap<FeatureSpModel, ExteriorDetailViewModel>();
            CreateMap<FeatureSpModel, InteriorDetailViewModel>();
            CreateMap<FeatureSpModel, OthersDetailViewModel>();
            CreateMap<FeatureSpModel, ProtectionDetailViewModel>();
            CreateMap<FeatureSpModel, SafetyDetailViewModel>();


            CreateMap<ComfortDetailViewModel, ComfortDetail>();
            CreateMap<ExteriorDetailViewModel, ExteriorDetail>();
            CreateMap<InteriorDetailViewModel, InteriorDetail>();
            CreateMap<OthersDetailViewModel, OthersDetail>();
            CreateMap<ProtectionDetailViewModel, ProtectionDetail>();
            CreateMap<SafetyDetailViewModel, SafetyDetail>();


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
