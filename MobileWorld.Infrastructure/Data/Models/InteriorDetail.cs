using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Infrastructure.Data.Models
{
    public class InteriorDetail
    {
        [Key]
        public int Id { get; set; }
        public bool SuedeSaloon { get; set; }

        public bool LeatherSalon { get; set; }

        public bool Taxi { get; set; }

        public bool Educational { get; set; }

        public bool Ruler { get; set; }
    }
}
