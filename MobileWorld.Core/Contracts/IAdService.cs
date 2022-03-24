using MobileWorld.Core.ViewModels;

namespace MobileWorld.Core.Contracts
{
    public interface IAdService
    {
        AdViewModel GetAdById(string adId);
    }
}
