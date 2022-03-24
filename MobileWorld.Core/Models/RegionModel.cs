using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Core.Models
{
    public class RegionModel 
    {
        public TownModel Town { get; set; }

        [StringLength(70)]
        public string RegionName { get; set; }

        [StringLength(70)]
        public string Neiborhood { get; set; }
    }
}
