﻿using MobileWorld.Core.Models;

namespace MobileWorld.Core.ViewModels
{
    public class AdViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string CreatedOn { get; set; }

        public CarModel Car { get; set; }

        public OwnerModel Owner { get; set; }

        public RegionModel Region { get; set; }

    }
}
