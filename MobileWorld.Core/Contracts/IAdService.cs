using MobileWorld.Core.Models;
using MobileWorld.Core.Models.InputModels;
using MobileWorld.Core.ViewModels;
using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Core.Contracts
{
    public interface IAdService
    {
        List<AdCardViewModel> GetAllAds();
        AdViewModel GetAdById(string adId);

        List<AdCardViewModel> GetAdsByAdvancedCriteria(AdvancedSearchCarModel model);

        //List<AdCardViewModel> GetAdsByBaseCriteria(BaseSearchCarModel model);

        List<AdCardViewModel> GetIndexAds();

       void CreateAd(AdInputModel model, List<Image> images, string ownerId);

        void Delete(string adId);

        bool Update(AdInputModel updatedModel,string adId);
    }
}
