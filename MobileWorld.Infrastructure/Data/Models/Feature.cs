using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileWorld.Infrastructure.Data.Models
{
    public class Feature
    {
        [Key]
        public int Id { get; set; }

        //[ForeignKey(nameof(Car))]
        public int CarId { get; set; }

        public virtual Car Car { get; set; }

        //[ForeignKey(nameof(SafetyDetails))]
        //public int SafetyDetailsId { get; set; }
        public virtual SafetyDetail SafetyDetails { get; set; } = new();


        //[ForeignKey(nameof(ComfortDetails))]
        //public int ComfortDetailsId { get; set; }
        public virtual ComfortDetail ComfortDetails { get; set; } = new();


        //[ForeignKey(nameof(OthersDetails))]
        //public int OthersDetailsId { get; set; }
        public virtual OthersDetail OthersDetails { get; set; } = new();


        //[ForeignKey(nameof(ExteriorDetails))]
        //public int ExteriorDetailsId { get; set; }
        public virtual ExteriorDetail ExteriorDetails { get; set; } = new();


        //[ForeignKey(nameof(ProtectionDetails))]
        //public int ProtectionDetailsId { get; set; }
        public virtual ProtectionDetail ProtectionDetails { get; set; } = new();


        //[ForeignKey(nameof(InteriorDetails))]
        //public int InteriorDetailsId { get; set; }
        public virtual InteriorDetail InteriorDetails { get; set; } = new();
    }
}
