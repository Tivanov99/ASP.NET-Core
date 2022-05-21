using AutoMapper;
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

        public async Task<List<AdCardSpViewModel>> GetAllAds()
        {
            try
            {
                var ads = _unitOfWork
                               .AdRepository
                               .Set<AdCardSpViewModel>()
                               .FromSqlRaw(_storedProdecuresCollection.AllAds())
                               .AsNoTracking()
                               .ToListAsync();

                return await ads;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<AdViewModel> GetAdById(string adId)
        {
            try
            {
                var adSpResources = _storedProdecuresCollection
                    .GetAdById(adId);

                var dbAdModel = _unitOfWork
                    .AdRepository
                    .GetAdById(adSpResources.Item1, adSpResources.Item2);

                AdViewModel adViewModel = MapToAdViewModel(dbAdModel);

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

        public async Task<IAdInputModel> GetAdForUpdate(string adId)
        {
            try
            {
                var adSpResources = _storedProdecuresCollection
                        .GetAdById(adId);

                var dbAdModel = _unitOfWork
                    .AdRepository
                    .GetAdById(adSpResources.Item1, adSpResources.Item2);

                IAdInputModel adViewModel = MapToAdInputModel(dbAdModel);

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

            }
            return null;
        }

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
                    .ToInt32(Convert
                                    .ToString(result.Item2[1].Value)
                            );

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

        public bool Update(AdEditModel model, string adId)
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


            var result = _storedProdecuresCollection
                 .GetTownIdByTownName(model.Region.TownName);

            _unitOfWork.TownRepository.UserStoredProdecude(result.Item1, result.Item2);

            int townId = Convert
                    .ToInt32(Convert
                                    .ToString(result.Item2[1].Value)
                            );

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

        private IAdInputModel MapToAdInputModel(AdSpModel soursce)
        {
            IAdInputModel adResult = _mapper.Map<IAdInputModel>(soursce.AdInfo);
            adResult.Car = _mapper.Map<ICarViewModel>(soursce.Car);
            adResult.Car.Engine = _mapper.Map<EngineViewModel>(soursce.Engine);
            adResult.Region = _mapper.Map<RegionViewModel>(soursce.AdInfo);
            adResult.Images = soursce.Images;
            OwnerViewModel owner = _mapper.Map<OwnerViewModel>(soursce.AdInfo);
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

        private string ConfigurateSqlCommand
            (List<PropertyDto> defaultSearchCriteria, Dictionary<string, List<string>> featuresSearchCriteria)
        {
            string queryString = "Select * From";

            return queryString;
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

        private void MatchInputFeaturesToFeatureDbModel(object inputData, object modelToBind)
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
    }
}
