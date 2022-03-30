using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileWorld.Infrastructure.Data.Models
{
    public class Feature
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }

        public Car Car { get; set; }

        [ForeignKey(nameof(SafetyDetails))]
        public int SafetyDetailsId { get; set; }
        public SafetyDetail SafetyDetails { get; set; } = new();


        [ForeignKey(nameof(ComfortDetails))]
        public int ComfortDetailsId { get; set; }
        public ComfortDetail ComfortDetails { get; set; } = new();


        [ForeignKey(nameof(OthersDetails))]
        public int OthersDetailsId { get; set; }
        public OthersDetail OthersDetails { get; set; } = new();


        [ForeignKey(nameof(ExteriorDetails))]
        public int ExteriorDetailsId { get; set; }
        public ExteriorDetail ExteriorDetails { get; set; } = new();


        [ForeignKey(nameof(ProtectionDetails))]
        public int ProtectionDetailsId { get; set; }
        public ProtectionDetail ProtectionDetails { get; set; } = new();


        [ForeignKey(nameof(InteriorDetails))]
        public int InteriorDetailsId { get; set; }
        public InteriorDetail InteriorDetails { get; set; } = new();
    }
}
