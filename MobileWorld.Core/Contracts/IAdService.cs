using MobileWorld.Core.Models;
using MobileWorld.Core.ViewModels;
using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Core.Contracts
{
    public interface IAdService
    {
        Task<AdViewModel> GetAdById(string adId);

        List<AdCardViewModel> GetAdsByAdvancedCriteria(AdvancedSearchCarModel model);

        List<AdCardViewModel> GetAdsByBaseCriteria(BaseSearchCarModel model);

        List<AdCardViewModel> GetIndexAds();

        Task<bool> CreateAd(CreateAdModel model, List<Image> images, string ownerId);
    }
}
