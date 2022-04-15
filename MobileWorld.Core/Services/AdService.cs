using Microsoft.EntityFrameworkCore;
using MobileWorld.Core.Contracts;
using MobileWorld.Core.Dto;
using MobileWorld.Core.Models;
using MobileWorld.Core.ViewModels;
using MobileWorld.Infrastructure.Data.Common;
using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Core.Services
{
    public class AdService : IAdService
    {
        private readonly IUnitOfWork unitOfWork;
        public AdService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        public AdViewModel GetAdById(string adId)
        {
            var ad = AdProjection(adId);
            return ad;
        }

        public List<AdCardViewModel> GetAdsByBaseCriteria(BaseSearchCarModel model)
        {
            List<PropertyDto> properties = GetBaseSearchCriteria(model);

            return new List<AdCardViewModel>();
        }

        public List<AdCardViewModel> GetAdsByAdvancedCriteria(AdvancedSearchCarModel model)
        {
            List<PropertyDto> defaultSearchCriteria = GetBaseSearchCriteria(model);

            Dictionary<string, List<string>> featuresSearchCriteria = new();

            GetSelectedFeatures(model.Features.EngineDetails, featuresSearchCriteria);
            GetSelectedFeatures(model.Features.SafetyDetails, featuresSearchCriteria);
            GetSelectedFeatures(model.Features.ComfortDetails, featuresSearchCriteria);
            GetSelectedFeatures(model.Features.OthersDetails, featuresSearchCriteria);
            GetSelectedFeatures(model.Features.ExteriorDetails, featuresSearchCriteria);
            GetSelectedFeatures(model.Features.ProtectionDetails, featuresSearchCriteria);
            GetSelectedFeatures(model.Features.InteriorDetails, featuresSearchCriteria);

            string queryString = ConfigurateSqlCommand
                (defaultSearchCriteria, featuresSearchCriteria);


            return null;
        }

        public List<AdCardViewModel> GetIndexAds()
        {
            var cars = this.unitOfWork.AdRepository
               .GetAllAsQueryable()
               .AsNoTracking()
               .Include(a => a.Images)
                .Select(a => new AdCardViewModel()
                {
                    AdId = a.Id,
                    Description = a.Description,
                    Price = a.Price,
                    Title = a.Title,
                    ImageData = a.Images[0].ImageData
                })
               .Take(6)
               .ToList();

            return cars;
        }

        public void CreateAd(AdInputModel model, List<Image> images, string ownerId)
        {
            try
            {
                int townId = this.GetTownIdByName(model.Region.TownName);

                //TODO : Add seed to Db all Towns

                Car car = CreateCarEntity(model.Car, model.Features);

                MatchInputFeaturesToFeatureModel(model.Features.SafetyDetails, car.Feature.SafetyDetails);
                MatchInputFeaturesToFeatureModel(model.Features.ComfortDetails, car.Feature.ComfortDetails);
                MatchInputFeaturesToFeatureModel(model.Features.InteriorDetails, car.Feature.InteriorDetails);
                MatchInputFeaturesToFeatureModel(model.Features.ExteriorDetails, car.Feature.ExteriorDetails);
                MatchInputFeaturesToFeatureModel(model.Features.OthersDetails, car.Feature.OthersDetails);
                MatchInputFeaturesToFeatureModel(model.Features.ProtectionDetails, car.Feature.ProtectionDetails);

                Region region = CreateRegionEntity(model.Region, townId);

                Ad newAd = CreaAdEntity(model, images, ownerId, car, region);

                car.AdId = newAd.Id;
                car.Ad = newAd;
                try
                {
                    this.unitOfWork.AdRepository.Insert(newAd);
                    this.unitOfWork.Save();
                }
                catch (Exception)
                {
                    //TODO: what if transaction throws ?
                }
            }
            catch (Exception)
            {
                
            }
        }

        public void Delete(string adId)
        {
            Ad ad = this.unitOfWork
                .AdRepository
                .GetAllAsQueryable()
                .AsNoTracking()
                .Include(a => a.Images)
                .Include(a => a.Car)
                .ThenInclude(c => c.Engine)
                .Include(a => a.Car.Feature)
                .Where(ad => ad.Id == adId)
                .First();

            if (ad != null)
            {
                this.unitOfWork
                .AdRepository
                .Delete(ad);

                this.unitOfWork.Save();
            }
        }

        public bool Update(string adId, AdViewModel updatedModel)
        {
            Ad? ad = this.unitOfWork
                .AdRepository
            .GetAllAsQueryable()
            .AsNoTracking()
            .Where(a => a.Id == adId)
            .Include(a => a.Region)
            .Include(a => a.Car)
                .ThenInclude(c => c.Feature)
            .Include(a => a.Car.Engine)
            .FirstOrDefault();


            int townId = GetTownIdByName(updatedModel.Region.TownName);

            if (ad != null)
            {
                try
                {
                    //ad.Car.Engine = updatedModel.Car.Engine;
                    //ad.Car.SeatsCount = updatedModel.Car.SeatsCount;
                    //ad.Car.Feature = updatedModel.Car.Features;
                    //ad.Car.GearType = updatedModel.Car.GearType;
                    //ad.Car.Year = updatedModel.Car.Year;
                    ////ad.Car.Model = updatedModel.Car.Model;
                    //ad.Car.Color = updatedModel.Car.Color;
                    //ad.Car.Make = updatedModel.Car.Make;
                    //ad.Car.Mileage = updatedModel.Car.Mileage;

                    ////ad.Images.ForEach(i=>i.ImageData=updatedModel.Car.Images[i]);
                    //ad.Title = updatedModel.Title;
                    //ad.Price = updatedModel.Price;
                    //ad.PhoneNumber = updatedModel.PhoneNumber;
                    //ad.Region.TownId = townId;
                    //ad.Region.RegionName = updatedModel.Region.RegionName;
                    //ad.Region.Neiborhood = updatedModel.Region.Neiborhood;


                    this.unitOfWork.AdRepository.Update(ad);
                    this.unitOfWork.Save();
                    return true;
                }
                catch (Exception)
                {

                }
            }
            return false;
        }

        private List<PropertyDto> GetBaseSearchCriteria(object model)
        {
            Type type = model.GetType();

            string featuresType = typeof(FeaturesModel).Name;

            var propertyInfos = type
                .GetProperties()
                .Where(x => x.GetValue(model) != null &&
                        x.PropertyType.Name != featuresType)
                .Select(x => new PropertyDto(x.Name, x.GetValue(model)))
                .ToList();

            return propertyInfos;
        }

        private void GetSelectedFeatures(object model, Dictionary<string, List<string>> currentCriteria)
        {
            Type type = model
                .GetType();

            string categoryName = model.GetType().Name;

            var features = type
                .GetProperties()
                .Where(x => x.Name != "Id" && (bool)x.GetValue(model) == true)
                .Select(x => x.Name)
                .ToList();

            var test = type.GetProperties()
                .Where(p => features.Contains(p.Name))
                .ToList();

            foreach (var item in test)
            {
                item.SetValue(null, true);
            }

                

            if (features.Any())
            {
                currentCriteria.Add(categoryName, features);
            }
        }

        private string ConfigurateSqlCommand
            (List<PropertyDto> defaultSearchCriteria, Dictionary<string, List<string>> featuresSearchCriteria)
        {
            string queryString = "Select * From";

            return queryString;
        }

        private int GetTownIdByName(string townName)
        {
            var result = this.unitOfWork.TownRepository
                .GetAll()
                .Where(t => t.Name == townName)
                .Select(t => t.Id)
                .FirstOrDefault();

            return result;
        }

        private Car CreateCarEntity(CarModel car, FeaturesModel features)
        => new Car()
        {
            Color = car.Color,
            SeatsCount = car.SeatsCount,
            Mileage = car.Mileage,
            Engine = CreateEngineEntity(car.Engine),
            Feature = CreateFeatureEntity(features),
            Model = "e46",
            Make = car.Make,
            Year = car.Year,
        };

        private Region CreateRegionEntity(RegionModel region, int townId)
            => new Region()
            {
                TownId = townId,
                RegionName = region.RegionName,
                Neiborhood = region.Neiborhood,
            };

        private Engine CreateEngineEntity(EngineModel model)
        => new Engine()
        {
            FuelConsuption = model.FuelConsuption,
            FuelType = model.FuelType,
            CubicCapacity = model.CubicCapacity,
            HorsePower = model.HorsePower,
            NewtonMeter = model.NewtonMeter,
            EcoLevel = model.EcoLevel,
            Hybrid = model.Hybrid,
            AutoGas = model.AutoGas,
        };

        private Feature CreateFeatureEntity(FeaturesModel features)
        => new Feature()
        {
            //SafetyDetails = features.SafetyDetails,
            //ProtectionDetails = features.ProtectionDetails,
            //ComfortDetails = features.ComfortDetails,
            //ExteriorDetails = features.ExteriorDetails,
            //OthersDetails = features.OthersDetails,
            //InteriorDetails = features.InteriorDetails,
        };

        private void MatchInputFeaturesToFeatureModel(object inputFeature, object featureModel)
        {
            Type inputFeatureType = inputFeature
                .GetType();

            string categoryName = inputFeature.GetType().Name;

            var inputFeaturePoperties = inputFeatureType
                .GetProperties()
                .Where(x =>(bool)x.GetValue(inputFeature) == true)
                .Select(x => x.Name)
                .ToList();

            Type featureModelType = featureModel
               .GetType();

            var test = featureModelType.GetProperties()
                .Where(p => inputFeaturePoperties.Contains(p.Name))
                .ToList();



            foreach (var item in test)
            {
                item.SetValue(featureModel,true);
            }
        }


        private Ad CreaAdEntity(AdInputModel model, List<Image> images, string ownerId, Car car, Region region)
             => new Ad()
             {
                 Id = Guid.NewGuid().ToString(),
                 Title = model.Title,
                 PhoneNumber = model.PhoneNumber,
                 Price = model.Price,
                 Description = model.Description,
                 Car = car,
                 Images = images,
                 CreatedOn = DateTime.Now,
                 Region = region,
                 OwnerId = ownerId,
             };

        private AdViewModel? AdProjection(string adId)
            => this.unitOfWork.AdRepository.GetAllAsQueryable()
                  .AsNoTracking()
                  .Where(a => a.Id == adId)
                  .Include(a => a.Car)
                        .ThenInclude(c => c.Engine)
                  .Include(c => c.Car.Feature)
                  .Include(a => a.Images)
                  .Select(a => new AdViewModel()
                  {
                      Id = a.Id,
                      Title = a.Title,
                      Price = a.Price,
                      Description = a.Description,
                      Region = new RegionModel()
                      {
                          RegionName = a.Region.RegionName,
                          Neiborhood = a.Region.Neiborhood,
                          TownName = a.Region.Town.Name,
                      },
                      Car = new CarModel()
                      {
                          SeatsCount = a.Car.SeatsCount,
                          Year = a.Car.Year,
                          Make = a.Car.Make,
                          //Model = a.Car.Model,
                          GearType = a.Car.GearType,
                          Color = a.Car.Color,
                          Mileage = a.Car.Mileage,
                          Images = a.Images.Select(x => x.ImageData).ToList(),
                          Engine = new EngineModel()
                          {
                              FuelConsuption = a.Car.Engine.FuelConsuption,
                              FuelType = a.Car.Engine.FuelType,
                              EcoLevel = a.Car.Engine.EcoLevel,
                              CubicCapacity = a.Car.Engine.CubicCapacity,
                              NewtonMeter = a.Car.Engine.NewtonMeter,
                              HorsePower = a.Car.Engine.HorsePower,
                              AutoGas = a.Car.Engine.AutoGas,
                              Hybrid = a.Car.Engine.Hybrid,
                          },
                          Features = new FeaturesModel()
                          {
                              //OthersDetails = a.Car.Feature.OthersDetails,
                              //ComfortDetails = a.Car.Feature.ComfortDetails,
                              //SafetyDetails = a.Car.Feature.SafetyDetails,
                              //ExteriorDetails = a.Car.Feature.ExteriorDetails,
                              //ProtectionDetails = a.Car.Feature.ProtectionDetails,
                              //InteriorDetails = a.Car.Feature.InteriorDetails,
                          }
                      },
                      Owner = new OwnerModel()
                      {
                          OwnerId = a.OwnerId,
                      },
                  })
                .FirstOrDefault();
    }
}
