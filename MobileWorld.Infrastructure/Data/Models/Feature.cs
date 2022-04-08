using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileWorld.Infrastructure.Data.Models
{
    public class Feature
    {
        [Key]
        public int Id { get; set; }

        public int CarId { get; set; }

        public virtual Car Car { get; set; }
        
        public virtual SafetyDetail SafetyDetails { get; set; } 

        public virtual ComfortDetail ComfortDetails { get; set; } 

        public virtual OthersDetail OthersDetails { get; set; } 

        public virtual ExteriorDetail ExteriorDetails { get; set; }

        public virtual ProtectionDetail ProtectionDetails { get; set; } 

        public virtual InteriorDetail InteriorDetails { get; set; } 
    }
}
