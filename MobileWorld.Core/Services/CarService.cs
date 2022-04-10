﻿using MobileWorld.Core.Contracts;
using MobileWorld.Core.Dto;
using MobileWorld.Core.Models;
using MobileWorld.Core.ViewModels;
using MobileWorld.Infrastructure.Data.Common;
using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Core.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository repo;

        public CarService(ICarRepository _repo)
        {
            this.repo = _repo;
        }


        public List<AdCardViewModel> GetIndexCars()
        {
            //List<AdCardViewModel> adds = new List<AdCardViewModel>()
            //{
            //    new AdCardViewModel()
            //    {
            //        AdId ="1",
            //        Title = "BMW 330 CI",
            //        Url="data:image/jpeg;base64,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",
            //        Description="The BMW M3 is a high-performance version of the BMW 3 Series, developed by BMW's in-house motorsport division, BMW M GmbH. M3 models have been produced for every generation of 3 Series since the E30 M3 was introduced in 1986.",
            //       Price=6999
            //    },
            //    new AdCardViewModel()
            //    {
            //       AdId ="2",
            //       Title = "BMW 330 DCI",
            //       Url="https://automedia.investor.bg/media/files/resized/uploadedfiles/640x0/228/32fc3c87da2834657647bab5753ff228-03-1.jpg",
            //       Description="The BMW M3 is a high-performance version of the BMW 3 Series, developed by BMW's in-house motorsport division, BMW M GmbH. M3 models have been produced for every generation of 3 Series since the E30 M3 was introduced in 1986.",
            //       Price=7000
            //    }
            //};
            //TODO: make rquest to db and take ONLY LAST 6 CARS !

            var cars = this.repo.All<Ad>()
                .OrderByDescending(a => a.CreatedOn)
                .Select(a => new AdCardViewModel()
                {
                    AdId = a.Id,
                    Description = a.Description,
                    Price = a.Price,
                    Title = a.Title,
                    //TODO : Get images
                })
                .Take(6)
                .ToList();


            return cars;
        }

        //private List<PropertyDto> GetDefaultProperties(object model)
        //{
        //    Type type = model.GetType();

        //    string featuresType = typeof(FeaturesModel).Name;

        //    var propertyInfos = type.GetProperties()
        //        .Where(x => x.GetValue(model) != null &&
        //                x.PropertyType.Name != featuresType)
        //        .Select(x => new PropertyDto(x.Name, x.GetValue(model)))
        //        .ToList();

        //    return propertyInfos;
        //}

        //private void GetSelectedFeatures(object model, Dictionary<string, List<string>> currentCriteria)
        //{
        //    Type type = model
        //        .GetType();

        //    string categoryName = model.GetType().Name;

        //    var features = type
        //        .GetProperties()
        //        .Where(x => (bool)x.GetValue(model) == true)
        //        .Select(x => x.Name)
        //        .ToList();

        //    if (features.Any())
        //    {
        //        currentCriteria.Add(categoryName, features);
        //    }
        //}

        //private string ConfigurateSqlCommand
        //    (List<PropertyDto> defaultSearchCriteria, Dictionary<string, List<string>> featuresSearchCriteria)
        //{
        //    string queryString = "Select * From";


        //    return queryString;
        //}
    }
}