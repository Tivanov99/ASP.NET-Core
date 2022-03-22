using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileWorld.Core.ViewModels
{
    public class AdCardViewModel
    {
        public int CarId { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
