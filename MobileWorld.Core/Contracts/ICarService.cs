namespace MobileWorld.Core.Contracts
{
    using MobileWorld.Core.ViewModels.CarViewModels;

    public interface ICarService
    {
        List<CarCardViewModel> GetIndexCars();

        List<CarCardViewModel> GetAllCarsByCriteria(SearchCarViewModel model);

        CarAdViewModel GetCarById(string carId);
    }
}
