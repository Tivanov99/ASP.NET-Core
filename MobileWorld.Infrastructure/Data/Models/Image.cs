using System.ComponentModel.DataAnnotations.Schema;

namespace MobileWorld.Infrastructure.Data.Models
{
    public class Image
    {
        public int Id { get; set; }

        public string ImageTitle { get; set; }

        public byte[] ImageData { get; set; }

        [ForeignKey(nameof(Ad))]
        public string AdId { get; set; }
        public Ad Ad { get; set; }
    }
}
