namespace MobileWorld.Core.Contracts
{
    using MobileWorld.Core.ViewModels;
    using MobileWorld.Core.ViewModels.CarViewModels;

    public interface ICarService
    {
        List<AdCardViewModel> GetIndexCars();

        List<AdCardViewModel> GetAllCarsByCriteria(BasicSearchCarModel model);

        CarViewModel GetCarById(int carId);
    }
}
