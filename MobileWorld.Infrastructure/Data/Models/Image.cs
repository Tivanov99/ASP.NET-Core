using System.ComponentModel.DataAnnotations.Schema;

namespace MobileWorld.Infrastructure.Data.Models
{
    public class Image
    {
        public int Id { get; set; }

        public string ImageTitle { get; set; }

        public string ImagePath { get; set; }

        [ForeignKey(nameof(Ad))]
        public string AdId { get; set; }
        public Ad Ad { get; set; }
    }
}
