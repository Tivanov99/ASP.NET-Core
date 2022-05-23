using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MobileWorld.Core.Contracts;
using MobileWorld.Core.Dto;
using MobileWorld.Core.Models;
using MobileWorld.Core.Models.InputModels;
using MobileWorld.Core.ViewModels;
using MobileWorld.Core.ViewModels.Contacts;
using MobileWorld.Core.ViewModels.FeatureDetailModels;
using MobileWorld.Infrastructure.Data.Common;
using MobileWorld.Infrastructure.Data.Models;
using MobileWorld.Infrastructure.Data.QueriesAndSP.Sp.Contracts;
using MobileWorld.Infrastructure.Data.QueriesAndSPDtoModels;
using System.Data;
using System.Text;

namespace MobileWorld.Core.Services
{
    public class AdService : IAdService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStoredProdecuresCollection _storedProdecuresCollection;
        private readonly IMapper _mapper;

        public AdService(IUnitOfWork unit,
            IStoredProdecuresCollection storedProdecuresCollection,
            IMapper mapper)
        {
            _unitOfWork = unit;
            _storedProdecuresCollection = storedProdecuresCollection;
            _mapper = mapper;
        }

        public async Task<List<AdCardSpViewModel>> GetIndexAds()
        {
            try
            {
                var ads = _unitOfWork
                                .AdRepository
                                .Set<AdCardSpViewModel>()
                                .FromSqlRaw(_storedProdecuresCollection.GetIndexAds())
                                .AsNoTracking()
                                .ToListAsync();
                return await ads;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<AdCardSpViewModel> GetAllAds()
        {
            try
            {
                var ads = _unitOfWork
                               .AdRepository
                               .Set<AdCardSpViewModel>()
                               .FromSqlRaw(_storedProdecuresCollection.AllAds())
                               .AsNoTracking()
                               .ToList();

                return ads;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public AdViewModel GetAdById(string adId)
        {
            try
            {
                var adSpResources = _storedProdecuresCollection
                    .GetAdById(adId);

                var adDbModel = _unitOfWork
                    .AdRepository
                    .GetAdById(adSpResources.Item1, adSpResources.Item2);

                AdViewModel adViewModel = MapToAdViewModel(adDbModel);

                var featuresSpResources = _storedProdecuresCollection
                    .GetAdFeatures(adId);

                var features = _unitOfWork
                    .AdRepository.Set<FeatureSpModel>()
                    .FromSqlRaw(featuresSpResources.Item1, featuresSpResources.Item2[0])
                    .ToList();

                adViewModel.Car.Features = MapToFeatureViewModel(features[0]);

                return adViewModel;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public AdInputModel GetAdForUpdate(string adId)
        {
            try
            {
                var adSpResources = _storedProdecuresCollection
                        .GetAdById(adId);

                var dbAdModel = _unitOfWork
                    .AdRepository
                    .GetAdById(adSpResources.Item1, adSpResources.Item2);

                AdInputModel inputModel = MapToAdInputModel(dbAdModel);

                var featuresSpResources = _storedProdecuresCollection
                    .GetAdFeatures(adId);

                var features = _unitOfWork
                    .AdRepository.Set<FeatureSpModel>()
                    .FromSqlRaw(featuresSpResources.Item1, featuresSpResources.Item2[0])
                    .ToList();

                inputModel.Car.Features = MapToFeatureViewModel(features[0]);

                return inputModel;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<AdCardSpViewModel> GetAdsByBaseCriteria(BaseSearchAdModel model)
        {
            Type modelType = model.GetType();

            var selected = modelType
                .GetProperties()
                .Select(x => new { Name = x.Name, Value = x.GetValue(model) })
                 .Where(x => x.Value != null)
                .ToList();

            StringBuilder sqlSb = new ();
            sqlSb.Append("SELECT A.Id AS [AdId], A.CreatedOn, A.Price, A.Title," +
                " (SELECT TOP(1) i.ImageTitle FROM [Images] AS I WHERE I.AdId = A.Id) AS [ImageTitle]," +
                " C.Mileage, C.[Year], E.HorsePower, E.FuelType" +
                " FROM [Ads] AS A " +
                "LEFT JOIN[Cars] AS C ON C.AdId = A.Id" +
                " LEFT JOIN [Engines] AS E ON E.CarId = C.Id");

            if (selected.Count == 0)
            {
                return GetAllAds();
            }

            var parameters = new object[selected.Count];

            string whereClause = " Where ";
            for (int i = 0; i < selected.Count; i++)
            {
                string paramName = selected[i].Name;


                parameters[i]
                    =new SqlParameter(paramName.ToLower(), selected[i].Value);
                if (i < selected.Count - 1 && paramName=="price")
                {
                    whereClause += $"{paramName} <= @{paramName.ToLower()}";

                    whereClause += $" and ";
                }
                else if(paramName == "year")
                {
                    whereClause += $"{paramName} > @{paramName.ToLower()}";

                    whereClause += $" and ";
                }
                else if (i < selected.Count - 1)
                {
                    whereClause += $"{paramName} = @{paramName.ToLower()}";
                }
            }
            sqlSb.Append($"{whereClause}");


            var res = _unitOfWork.AdRepository.Set<AdCardSpViewModel>()
                   .FromSqlRaw(sqlSb.ToString(), parameters)
                   .ToList();

            return null;
        }

        public List<AdCardSpViewModel> GetAdsByAdvancedCriteria(AdvancedSearchCarModel model)
        {
            List<PropertyDto> defaultSearchCriteria = GetBaseSearchCriteria(model);

            Dictionary<string, List<string>> featuresSearchCriteria = new();

            GetSelectedFeatures(model.Features.SafetyDetails, featuresSearchCriteria);
            GetSelectedFeatures(model.Features.ComfortDetails, featuresSearchCriteria);
            GetSelectedFeatures(model.Features.OthersDetails, featuresSearchCriteria);
            GetSelectedFeatures(model.Features.ExteriorDetails, featuresSearchCriteria);
            GetSelectedFeatures(model.Features.ProtectionDetails, featuresSearchCriteria);
            GetSelectedFeatures(model.Features.InteriorDetails, featuresSearchCriteria);

            //string queryString = ConfigurateSqlCommand
            //    (defaultSearchCriteria, featuresSearchCriteria);

            return null;
        }

        public bool CreateAd(IAdInputModel model, string ownerId, List<Image> images)
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
                    .ToInt32(Convert.ToString(result.Item2[1].Value));

                if (townId == 0)
                {
                    return false;
                }


                Car car = CreateCarEntity(model.Car);

                MatchFeatures(car.Feature, model.Car.Features);

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

        public bool Delete(string adId)
        {
            var result = _storedProdecuresCollection
                .DeleteAd(adId);
            try
            {
                _unitOfWork.AdRepository
                .UserStoredProdecude(result.Item1, result.Item2);

                int affectedRows = Convert
                        .ToInt32(Convert.ToString(result.Item2[1].Value));

                return affectedRows > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(AdInputModel model, string adId)
        {
            Ad? ad = this._unitOfWork
            .AdRepository
            .GetAsQueryable()
            .Where(a => a.Id == adId)
            .Include(a => a.Region)
            .Include(a => a.Owner)
            .Include(a => a.Car)
            .Include(a => a.Car.Feature)
            .Include(a => a.Car.Feature.SafetyDetails)
            .Include(a => a.Car.Feature.ComfortDetails)
            .Include(a => a.Car.Feature.ProtectionDetails)
            .Include(a => a.Car.Feature.InteriorDetails)
            .Include(a => a.Car.Feature.ExteriorDetails)
            .Include(a => a.Car.Feature.OthersDetails)
            .Include(a => a.Car.Engine)
            .FirstOrDefault();

            if (ad != null)
            {
                try
                {
                    var result = _storedProdecuresCollection
                 .GetTownIdByTownName(model.Region.TownName);

                    _unitOfWork.TownRepository.UserStoredProdecude(result.Item1, result.Item2);

                    int townId = Convert
                            .ToInt32(Convert.ToString(result.Item2[1].Value));

                    MatchFeatures(ad.Car.Feature, model.Features);
                    UpdateEngine(model.Car.Engine, ad.Car.Engine);
                    UpdateAdModel(ad, model, townId);
                    UpdateCar(ad.Car, model.Car);

                    //TODO: Check Images
                    //ad.Images.ForEach(i=>i.ImageData=updatedModel.Car.Images[i]);

                    this._unitOfWork.AdRepository.Update(ad);

                    this._unitOfWork.Save();
                    return true;
                }
                catch (Exception)
                {

                }
            }
            return false;
        }

        private AdViewModel MapToAdViewModel(AdSpModel soursce)
        {
            AdViewModel adResult = _mapper.Map<AdViewModel>(soursce.AdInfo);
            adResult.Car = _mapper.Map<CarViewModel>(soursce.Car);
            adResult.Car.Engine = _mapper.Map<EngineViewModel>(soursce.Engine);
            adResult.Region = _mapper.Map<RegionViewModel>(soursce.AdInfo);
            adResult.Images = soursce.Images;
            OwnerViewModel owner = _mapper.Map<OwnerViewModel>(soursce.AdInfo);
            adResult.Owner = owner;
            return adResult;
        }

        private AdInputModel MapToAdInputModel(AdSpModel soursce)
        {
            AdInputModel adResult = _mapper.Map<AdInputModel>(soursce.AdInfo);
            adResult.Car = _mapper.Map<CarInputModel>(soursce.Car);
            adResult.Car.Engine = _mapper.Map<EngineInputModel>(soursce.Engine);
            adResult.Region = _mapper.Map<RegionInputModel>(soursce.AdInfo);
            adResult.Images = soursce.Images;
            OwnerInputModel owner = _mapper.Map<OwnerInputModel>(soursce.AdInfo);
            adResult.Owner = owner;
            return adResult;
        }

        private FeatureViewModel MapToFeatureViewModel(FeatureSpModel source)
            => new FeatureViewModel
            {
                ComfortDetails = _mapper.Map<ComfortDetailViewModel>(source),
                ExteriorDetails = _mapper.Map<ExteriorDetailViewModel>(source),
                InteriorDetails = _mapper.Map<InteriorDetailViewModel>(source),
                OthersDetails = _mapper.Map<OthersDetailViewModel>(source),
                ProtectionDetails = _mapper.Map<ProtectionDetailViewModel>(source),
                SafetyDetails = _mapper.Map<SafetyDetailViewModel>(source),
            };

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

        private Car CreateCarEntity(ICarViewModel car)
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

        private Region CreateRegionEntity(IRegionViewModel region, int townId)
            => new Region()
            {
                TownId = townId,
                RegionName = region.RegionName,
                Neiborhood = region.Neiborhood,
            };

        private Engine CreateEngineEntity(IEngineViewModel model)
        => new Engine()
        {
            FuelConsuption = model.FuelConsuption,
            FuelType = model.FuelType,
            CubicCapacity = model.CubicCapacity,
            HorsePower = model.HorsePower,
            NewtonMeter = model.NewtonMeter,
            EcoLevel = model.EcoLevel,
        };

        private void MatchInputFeaturesToFeatureDbModel(object inputModel, object dbModel)
        {
            Type inputModelType = inputModel
                .GetType();

            string categoryName = inputModel.GetType()
                .Name;

            var inputDataPoperties = inputModelType
                .GetProperties()
                .Where(x => x.PropertyType == typeof(bool))
                .Select(x => new { Name = x.Name, Value = x.GetValue(inputModel) })
                .ToList();

            Type bindingModelType = dbModel
               .GetType();

            var dbProperties = bindingModelType.GetProperties()
                .Where(x => x.PropertyType == typeof(bool))
                .Select(x => x)
                .ToList();
            int count = 0;
            foreach (var item in dbProperties)
            {
                item.SetValue(dbModel, inputDataPoperties[count++].Value);
            }
        }

        private void MatchFeatures(Feature dbFeature, IFeatureViewModel model)
        {
            MatchInputFeaturesToFeatureDbModel(model.SafetyDetails, dbFeature.SafetyDetails);
            MatchInputFeaturesToFeatureDbModel(model.ComfortDetails, dbFeature.ComfortDetails);
            MatchInputFeaturesToFeatureDbModel(model.InteriorDetails, dbFeature.InteriorDetails);
            MatchInputFeaturesToFeatureDbModel(model.ExteriorDetails, dbFeature.ExteriorDetails);
            MatchInputFeaturesToFeatureDbModel(model.OthersDetails, dbFeature.OthersDetails);
            MatchInputFeaturesToFeatureDbModel(model.ProtectionDetails, dbFeature.ProtectionDetails);
        }

        private Ad CreaAdEntity(IAdInputModel model, List<Image> images, string ownerId, Car car, Region region)
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

        private void UpdateEngine(IEngineViewModel updatedModel, Engine dbModel)
        {
            dbModel.EcoLevel = updatedModel.EcoLevel;
            dbModel.CubicCapacity = updatedModel.CubicCapacity;
            dbModel.HorsePower = updatedModel.HorsePower;
            dbModel.NewtonMeter = updatedModel.NewtonMeter;
            dbModel.FuelType = updatedModel.FuelType;
        }

        private void UpdateAdModel(Ad ad, AdInputModel model, int townId)
        {
            ad.Title = model.Title;
            ad.Price = model.Price;
            ad.PhoneNumber = model.PhoneNumber;
            ad.Region.TownId = townId;
            ad.Region.RegionName = model.Region.RegionName;
            ad.Region.Neiborhood = model.Region.Neiborhood;
        }

        private void UpdateCar(Car car, ICarViewModel model)
        {
            car.SeatsCount = model.SeatsCount;
            car.GearType = model.GearType;
            car.Year = model.Year;
            //TODO: Check model
            //ad.Car.Model = updatedModel.Car.Model;
            car.Color = model.Color;
            car.Make = model.Make;
            car.Mileage = model.Mileage;
        }
    }
}
