using MobileWorld.Core.Models;
using MobileWorld.Core.ViewModels;

namespace MobileWorld.Core.Contracts
{
    public interface ICarService
    {
        List<AdCardViewModel> GetIndexCars();

        List<AdCardViewModel> GetAllCarsWithCriteria(AdvancedSearchCarModel model);

    }
}
