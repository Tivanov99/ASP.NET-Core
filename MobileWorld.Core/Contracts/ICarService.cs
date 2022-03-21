namespace MobileWorld.Core.Contracts
{
    using MobileWorld.Core.ViewModels;
    using MobileWorld.Core.ViewModels.CarViewModels;

    public interface ICarService
    {
        List<AdViewModel> GetIndexCars();

        List<AdViewModel> GetAllCarsByCriteria(SearchCarViewModel model);

        CarViewModel GetCarById(int carId);
    }
}
