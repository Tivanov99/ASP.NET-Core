using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.ControllerHelper.Contracts
{
    public interface IImageBinding
    {
         List<Image> BindImages(IFormFileCollection formFiles);
    }
}
