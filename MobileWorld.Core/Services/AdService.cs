using MobileWorld.Core.Models;
using MobileWorld.Core.ViewModels;
using MobileWorld.Infrastructure.Data.Common;
using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Core.Services
{
    public class AdService
    {
        private readonly IRepository repo;
        public AdService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public AdViewModel GetAdById(string adId)
        {
            var car = this.repo.All<Ad>()
                .Where(a => a.Id == adId)
                .Select(a => new AdViewModel()
                {
                    Title = a.Title,
                    Price = a.Price,
                    Description = a.Description,
                    //Town = a.Region.Town.Name,
                    //Region = a.Region.RegionName,
                    Car = new CarModel()
                    {
                        SeatsCount = a.Car.SeatsCount,
                        Year = a.Car.Year,
                        Make = a.Car.Make,
                        Model = a.Car.Model,
                        GearType = a.Car.GearType,
                        Color = a.Car.Color,
                        Mileage = a.Car.Mileage,
                    },
                    Owner = new OwnerModel()
                    {
                        PhoneNumber = a.PhoneNumber
                    }
                })
                .FirstOrDefault();

            //TODO: Make request to db with car Id
            //CarViewModel carAd = new CarViewModel();
            //carAd.Car.Description = "ВЪЗМОЖЕН ЛИЗИНГ БЕЗ ДОКАЗВАНЕ НА ДОХОДИ, ПРИ МИНИМАЛНА ПЪРВОНАЧАЛНА ВНОСКА СТАРТИРАЩА ОТ 10% ОДОБРЕНИЕ И РЕГИСТРАЦИЯ В РАМКИТЕ НА ДЕНЯ. Автомобила е от шоурум на BMW в Южна Швейцария (Мендризо). Само един собственик който го връща в представителството и взима нов. Пълна подръжка и документация за всяко обслужване на 15 хиляди километра изцяло, и единствено в сервиз на BMW.";
            //carAd.Owner.PhoneNumber = 0893668829;
            //carAd.Owner.Name = "АУТО КЛАСИК - ДИРЕКТЕН";
            //carAd.Region = "Бургас";
            //carAd.Town = "Сарафово";
            //carAd.Neighborhood = "Сарафово";

            return car;
        }
    }
}
