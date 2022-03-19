namespace MobileWorld.Core.Contracts
{
    using MobileWorld.Core.ViewModels;
    using MobileWorld.Core.ViewModels.CarViewModels;

    public interface ICarService
    {
        List<AdCardViewModel> GetIndexCars();

        List<AdCardViewModel> GetAllCarsByCriteria(SearchCarViewModel model);

        CarAdViewModel GetCarById(string carId);
    }
}
