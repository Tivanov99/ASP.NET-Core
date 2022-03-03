namespace MobileWorld.Core.Contracts
{
    using MobileWorld.Core.ViewModels;

    public interface ICarService
    {
        List<CarCardViewModel> GetIndexCars();

        List<CarCardViewModel> GetAllCarsByCriteria(SearchCarModel model);


    }
}
