namespace MobileWorld.Core.Contracts
{
    using MobileWorld.Core.ViewModels;
    using MobileWorld.Core.ViewModels.CarViewModels;

    public interface ICarService
    {
        List<CardAdViewModel> GetIndexCars();

        List<CardAdViewModel> GetAllCarsByCriteria(SearchCarViewModel model);

        CarViewModel GetCarById(int carId);
    }
}
