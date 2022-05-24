using MobileWorld.Core.Models.InputModels;
using MobileWorld.Core.Models.InputModels.Contracts;
using MobileWorld.Core.ViewModels;
using MobileWorld.Infrastructure.Data.Models;
using MobileWorld.Infrastructure.Data.QueriesAndSPDtoModels;

namespace MobileWorld.Core.Services.Contracts
{
    public interface IAdService
    {
        List<AdCardSpViewModel> GetAllAds();

        AdViewModel GetAdById(string adId);

        AdInputModel GetAdForUpdate(string adId);

        List<AdCardSpViewModel> GetAdsByAdvancedCriteria(AdvancedSearchAdInputModel model);

        List<AdCardSpViewModel> GetAdsByBaseCriteria(BaseSearchAdInputModel model);

        Task<List<AdCardSpViewModel>> GetIndexAds();

        bool CreateAd(IAdInputModel model, string ownerId, List<Image> uploadedImages);

        bool Delete(string adId);

        bool Update(AdInputModel updatedModel, string adId);
    }
}
