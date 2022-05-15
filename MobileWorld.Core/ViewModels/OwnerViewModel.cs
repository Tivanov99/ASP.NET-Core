using MobileWorld.Core.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileWorld.Core.ViewModels
{
    public class OwnerViewModel : IOwnerModel
    {
        public string? OwnerId { get ; set ; }
        public string FirstName { get ; set ; }
        public string LastName { get ; set ; }
        public bool IsFavoriteAd { get ; set ; }
    }
}
