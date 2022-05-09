﻿using Microsoft.EntityFrameworkCore;
using MobileWorld.Core.Contracts;
using System.Data;
using MobileWorld.Core.Dto;
using MobileWorld.Core.Models;
using MobileWorld.Core.Models.InputModels;
using MobileWorld.Core.ViewModels;
using MobileWorld.Infrastructure.Data.Models;
using MobileWorld.Infrastructure.Data.Common;
using MobileWorld.Infrastructure.Data.QueriesAndSP.Sp.Contracts;

namespace MobileWorld.Core.Services
{
    public class AdService : IAdService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStoredProdecuresCollection _storedProdecuresCollection;

        public AdService(IUnitOfWork unit,
            IStoredProdecuresCollection storedProdecuresCollection)
        {
            this._unitOfWork = unit;
            _storedProdecuresCollection = storedProdecuresCollection;
        }

        public Task<List<AdCardViewModel>> GetAllAds()
        {
            var cars = this._unitOfWork
                .AdRepository
                .GetAsQueryable()
                .AsNoTracking()
                .Include(a => a.Images)
                 .Select(a => new AdCardViewModel()
                 {
                     AdId = a.Id,
                     Description = a.Description,
                     Price = a.Price,
                     Title = a.Title,
                     ImageTitle = a.Images[0].ImageTitle,
                     //ImagePath = a.Images[0].ImagePath + @"\",
                 })
                 .Take(6)
                .ToListAsync();

            return cars;
        }


        public async Task<AdViewModel> GetAdById(string adId)
        {
            var ad = await AdProjection(adId);
            return ad;
        }

        //public List<AdCardViewModel> GetAdsByBaseCriteria(BaseSearchCarModel model)
        //{
        //    List<PropertyDto> properties = GetBaseSearchCriteria(model);

        //    if (properties.Count == 0)
        //    {
        //        return this.GetAllAds();
        //    }

        //    //decimal? price = model.Price != null ? model.Price : 0;

        //    //var ads = this.unitOfWork.AdRepository
        //    //    .GetAllAsQueryable()
        //    //    .Include(a => a.Car)
        //    //    .ThenInclude(c => c.Engine)
        //    //    .Include(a => a.Region)
        //    //    .Include(a => a.Images)
        //    //    .Where(x => x.Price>=price && )
        //    //    .ToList();




        //    using (SqlConnection connection = new SqlConnection(GlobalConstants.sqlConnection))
        //    {
        //        connection.Open();

        //        SqlCommand command = new SqlCommand(
        //            "SELECT a.Id, a.Title, a.Description, a.Price, i.ImageData  FROM[Cars] AS[c]"
        //             + "LEFT JOIN[Ads] AS[a] ON a.Id = c.AdId"
        //             + "LEFT JOIN[Images] AS[i] ON a.Id = i.AdId"
        //             + "LEFT JOIN[Regions] AS[r] ON a.RegionId = r.Id"
        //             + "LEFT JOIN[Towns] AS[t] ON r.TownId = t.Id"
        //             + "LEFT JOIN[Engines] AS[e] ON e.CarId = c.Id"
        //            , connection
        //            );

        //        Type modeltype = model.GetType();

        //        var modelProperties = modeltype.GetProperties().Select(x => x).ToList();

        //        string where = " Where";
        //        int count = properties.Count();
        //        foreach (var prop in properties)
        //        {
        //            count--;
        //            where += $" {prop.Name} = @{prop.Name}";
        //            if (count > 0)
        //            {
        //                where += " AND ";
        //            }
        //        }
        //        command.CommandText += where;

        //        foreach (var prop in properties)
        //        {
        //            var value = modelProperties.Where(x => x.Name == prop.Name).Select(x => x.GetValue(model)).First();
        //            command.Parameters.Add(new SqlParameter($"@{prop.Name}", value));
        //        }

        //        using (command)
        //        {
        //            List<AdCardViewModel> result = new();
        //            SqlDataReader reader = command.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                byte[] bytes = new byte[byte.MaxValue];
        //                reader.GetBytes(4, 0, bytes, 0, bytes.Length); ;
        //                result.Add(new AdCardViewModel()
        //                {
        //                    AdId = reader.GetString(0),
        //                    Title = reader.GetString(1),
        //                    Description = reader.GetString(2),
        //                    Price = reader.GetDecimal(3),
        //                    ImageData = bytes
        //                });
        //            }
        //        }
        //    }
        //    return new List<AdCardViewModel>();
        //}

        public List<AdCardViewModel> GetAdsByAdvancedCriteria(AdvancedSearchCarModel model)
        {
            List<PropertyDto> defaultSearchCriteria = GetBaseSearchCriteria(model);

            Dictionary<string, List<string>> featuresSearchCriteria = new();

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

        public async Task<List<AdCardViewModel>> GetIndexAds()
        {
            var cars = await this._unitOfWork
                .AdRepository
               .GetAsQueryable()
               .AsNoTracking()
               .Include(a => a.Images)
                .Select(a => new AdCardViewModel()
                {
                    AdId = a.Id,
                    Description = a.Description,
                    Price = a.Price,
                    Title = a.Title,
                    ImageTitle = a.Images[0].ImageTitle,
                    //ImagePath = a.Images[0].ImagePath + @"\",
                })
               .Take(6)
               .ToListAsync();
            return cars;
        }

        public bool CreateAd(AdInputModel model, string ownerId, List<Image> images)
        {
            //TODO : Add seed to Db all Towns
            try
            {
                var result = _storedProdecuresCollection
                    .GetTownIdByTownName(model.Region.TownName);

                _unitOfWork
                    .TownRepository
                    .UserStoredProdecude(result.Item1, result.Item2);

                int townId = Convert
                    .ToInt32(Convert
                                    .ToString(result.Item2[1].Value)
                            );

                if (townId == 0)
                {
                    return false;
                }


                Car car = CreateCarEntity(model.Car);

                MatchFeatures(car.Feature, model.Features);

                Region region = CreateRegionEntity(model.Region, 1);

                Ad newAd = CreaAdEntity(model, images, ownerId, car, region);
                car.AdId = newAd.Id;
                car.Ad = newAd;
                try
                {
                    this._unitOfWork.AdRepository.Insert(newAd);
                    this._unitOfWork.Save();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public void Delete(string adId)
        {
            Ad ad = this._unitOfWork
                .AdRepository
                .GetAsQueryable()
                //.AsNoTracking()
                //.Include(a => a.Images)
                //.Include(a => a.Car)
                //.ThenInclude(c => c.Engine)
                //.Include(a => a.Car.Feature)
                .Where(ad => ad.Id == adId)
                .First();

            if (ad != null)
            {
                this._unitOfWork
                .AdRepository
                .Delete(ad);

                this._unitOfWork
                .Save();
            }
        }

        public bool Update(AdInputModel model, string adId)
        {
            Ad? ad = this._unitOfWork
            .AdRepository
            .GetAsQueryable()
            .Where(a => a.Id == adId)
            .Include(a => a.Region)
            .Include(a => a.Car)
                .ThenInclude(c => c.Feature)
            .Include(a => a.Car.Engine)
            .FirstOrDefault();


            int townId = GetTownIdByName(model.Region.TownName);

            if (ad != null)
            {
                try
                {
                    MatchFeatures(ad.Car.Feature, model.Features);

                    UpdateEngine(model.Car.Engine, ad.Car.Engine);

                    ad.Car.SeatsCount = model.Car.SeatsCount;
                    ad.Car.GearType = model.Car.GearType;
                    ad.Car.Year = model.Car.Year;
                    //TODO: Check model
                    //ad.Car.Model = updatedModel.Car.Model;
                    ad.Car.Color = model.Car.Color;
                    ad.Car.Make = model.Car.Make;
                    ad.Car.Mileage = model.Car.Mileage;


                    //TODO: Check Images
                    //ad.Images.ForEach(i=>i.ImageData=updatedModel.Car.Images[i]);
                    ad.Title = model.Title;
                    ad.Price = model.Price;
                    ad.PhoneNumber = model.PhoneNumber;
                    ad.Region.TownId = townId;
                    ad.Region.RegionName = model.Region.RegionName;
                    ad.Region.Neiborhood = model.Region.Neiborhood;


                    this._unitOfWork
                .AdRepository
                .Update(ad);
                    this._unitOfWork.Save();
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

            //string featuresType = typeof(FeaturesModel).Name;

            var propertyInfos = type
                .GetProperties()
                .Where(x => x.GetValue(model) != null &&
                       x.GetValue(model).ToString() != "Всички")
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

            var result = this._unitOfWork
                .TownRepository
                .GetAsQueryable()
                .Where(t => t.TownName == townName)
                .Select(t => t.Id)
                .FirstOrDefault();

            return result;
        }

        private Car CreateCarEntity(CarInputModel car)
        => new Car()
        {
            Color = car.Color,
            SeatsCount = car.SeatsCount,
            Mileage = car.Mileage,
            Feature = new Feature(),
            Engine = CreateEngineEntity(car.Engine),
            Model = "e46",
            Make = car.Make,
            Year = car.Year,
        };

        private Region CreateRegionEntity(RegionInputModel region, int townId)
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

        private void MatchInputFeaturesToFeatureModel(object inputData, object modelToBind)
        {
            Type inputModelType = inputData
                .GetType();

            string categoryName = inputData.GetType().Name;

            var inputDataPoperties = inputModelType
                .GetProperties()
                .Where(x => x.PropertyType == typeof(bool) && (bool)x.GetValue(inputData) == true)
                .Select(x => x.Name)
                .ToList();

            Type bindingModelType = modelToBind
               .GetType();

            var test = bindingModelType.GetProperties()
                .Where(p => inputDataPoperties.Contains(p.Name))
                .ToList();

            foreach (var item in test)
            {
                item.SetValue(modelToBind, true);
            }
        }

        private void MatchFeatures(Feature feature, FeaturesModel model)
        {
            MatchInputFeaturesToFeatureModel(model.SafetyDetails, feature.SafetyDetails);
            MatchInputFeaturesToFeatureModel(model.ComfortDetails, feature.ComfortDetails);
            MatchInputFeaturesToFeatureModel(model.InteriorDetails, feature.InteriorDetails);
            MatchInputFeaturesToFeatureModel(model.ExteriorDetails, feature.ExteriorDetails);
            MatchInputFeaturesToFeatureModel(model.OthersDetails, feature.OthersDetails);
            MatchInputFeaturesToFeatureModel(model.ProtectionDetails, feature.ProtectionDetails);
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

        private async Task<AdViewModel?> AdProjection(string adId)
            => await this._unitOfWork.AdRepository
                  .GetAsQueryable()
                  .AsNoTracking()
                  .Where(a => a.Id == adId)
                  .Include(c => c.Car.Feature.SafetyDetails)
                  .Include(c => c.Car.Feature.ProtectionDetails)
                  .Include(c => c.Car.Feature.ComfortDetails)
                  .Include(c => c.Car.Feature.ExteriorDetails)
                  .Include(c => c.Car.Feature.InteriorDetails)
                  .Include(c => c.Car.Feature.OthersDetails)
                  .Include(a => a.Car)
                        .ThenInclude(c => c.Engine)
                  .Include(a => a.Images)
                  .Select(a => new AdViewModel()
                  {
                      PhoneNumber = a.PhoneNumber,
                      Id = a.Id,
                      Title = a.Title,
                      Price = a.Price,
                      Description = a.Description,
                      Region = new RegionModel()
                      {
                          RegionName = a.Region.RegionName,
                          Neiborhood = a.Region.Neiborhood,
                          TownName = a.Region.Town.TownName,
                      },
                      Images = a.Images
                      .Select(i => new ImageDTO(i.ImageTitle, i.ImagePath + @"\"))
                      .ToList(),
                      Car = new CarModel()
                      {
                          SeatsCount = a.Car.SeatsCount,
                          Year = a.Car.Year,
                          Make = a.Car.Make,
                          //Model = a.Car.Model,
                          GearType = a.Car.GearType,
                          Color = a.Car.Color,
                          Mileage = a.Car.Mileage,
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
                          Features = a.Car.Feature
                      },
                      Owner = new OwnerModel()
                      {
                          OwnerId = a.OwnerId,
                          FirstName = a.Owner.FirstName,
                          LastName = a.Owner.LastName,
                          IsFavoriteAd = a.Owner.FavoriteAds.Any(a => a.AdId == adId),
                      },
                  })
                .FirstOrDefaultAsync();


        private void UpdateEngine(EngineModel updatedModel, Engine dbModel)
        {
            dbModel.EcoLevel = updatedModel.EcoLevel;
            dbModel.CubicCapacity = updatedModel.CubicCapacity;
            dbModel.HorsePower = updatedModel.HorsePower;
            dbModel.NewtonMeter = updatedModel.NewtonMeter;
            dbModel.FuelType = updatedModel.FuelType;
            dbModel.AutoGas = updatedModel.AutoGas;
            dbModel.Hybrid = updatedModel.Hybrid;
        }
    }
}
