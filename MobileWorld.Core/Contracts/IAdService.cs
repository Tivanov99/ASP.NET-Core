using MobileWorld.Core.Models;
using MobileWorld.Core.Models.InputModels;
using MobileWorld.Core.ViewModels;
using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Core.Contracts
{
    public interface IAdService
    {
        Task<List<AdCardViewModel>> GetAllAds();

        Task<AdViewModel> GetAdById(string adId);

        Task<AdInputModel> GetAdForUpdate(string adId);

        List<AdCardViewModel> GetAdsByAdvancedCriteria(AdvancedSearchCarModel model);

        //List<AdCardViewModel> GetAdsByBaseCriteria(BaseSearchCarModel model);

        Task<List<AdCardViewModel>> GetIndexAds();

       bool CreateAd(AdInputModel model, string ownerId, List<Image> uploadedImages);

        bool Delete(string adId);

        bool Update(AdInputModel updatedModel,string adId);
    }
}
