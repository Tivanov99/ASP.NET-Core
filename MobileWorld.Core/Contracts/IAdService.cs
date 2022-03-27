using MobileWorld.Core.Models;
using MobileWorld.Core.ViewModels;
using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Core.Contracts
{
    public interface IAdService
    {
        AdViewModel GetAdById(string adId);

        List<AdCardViewModel> GetAdsByCriteria(AdvancedSearchCarModel model);

        List<AdCardViewModel> GetIndexAds();

        public bool CreateAd(CreateAdModel model, List<Image> images, string ownerId);
    }
}
