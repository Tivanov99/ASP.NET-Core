using MobileWorld.Infrastructure.Data.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileWorld.Infrastructure.Data.Models
{
    public class FavoriteAd
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }


        [ForeignKey(nameof(Ad))]
        public string AdId { get; set; }
        public Ad Ad { get; set; }
    }
}
