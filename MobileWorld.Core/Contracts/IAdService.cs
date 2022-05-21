using MobileWorld.Core.Models;
using MobileWorld.Core.Models.InputModels;
using MobileWorld.Core.ViewModels;
using MobileWorld.Core.ViewModels.Contacts;
using MobileWorld.Infrastructure.Data.Models;
using MobileWorld.Infrastructure.Data.QueriesAndSPDtoModels;

namespace MobileWorld.Core.Contracts
{
    public interface IAdService
    {
        Task<List<AdCardSpViewModel>> GetAllAds();

        Task<AdViewModel> GetAdById(string adId);

        Task<AdInputModel> GetAdForUpdate(string adId);

        List<AdCardViewModel> GetAdsByAdvancedCriteria(AdvancedSearchCarModel model);

        //List<AdCardViewModel> GetAdsByBaseCriteria(BaseSearchCarModel model);

        Task<List<AdCardSpViewModel>> GetIndexAds();

        bool CreateAd(IAdInputModel model, string ownerId, List<Image> uploadedImages);

        bool Delete(string adId);

        bool Update(AdEditModel updatedModel, string adId);
    }
}
