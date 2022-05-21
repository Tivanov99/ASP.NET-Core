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

        Task<IAdViewModel> GetAdById(string adId);

        Task<IAdInputModel> GetAdForUpdate(string adId);

        List<AdCardViewModel> GetAdsByAdvancedCriteria(AdvancedSearchCarModel model);

        //List<AdCardViewModel> GetAdsByBaseCriteria(BaseSearchCarModel model);

        Task<List<AdCardSpViewModel>> GetIndexAds();

        bool CreateAd(AdInputModel model, string ownerId, List<Image> uploadedImages);

        bool Delete(string adId);

        bool Update(AdEditModel updatedModel, string adId);
    }
}
