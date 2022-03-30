using MobileWorld.Core.Models.Details;
using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Core.Models
{
    public class FeaturesModel : Feature
    {
        public EngineDetailsModel EngineDetails { get; set; } = new();

    }
}
