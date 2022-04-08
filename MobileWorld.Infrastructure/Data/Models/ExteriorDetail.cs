using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileWorld.Infrastructure.Data.Models
{
    public class ExteriorDetail
    {
        [Key]
        public int Id { get; set; }

        //[ForeignKey(nameof(Feature))]
        public int FeatureId { get; set; }

        public Feature Feature { get; set; }

        public bool Coupe { get; set; }

        public bool Sedan { get; set; }

        public bool LedHeadlights { get; set; }

        public bool XenonLights { get; set; }

        public bool AlloyWheels { get; set; }

        public bool Metallic { get; set; }

        public bool PanoramicSunroof { get; set; }

        public bool Spoilers { get; set; }

        public bool Shibedah { get; set; }

        public bool HalogenHeadlights { get; set; }
    }
}
