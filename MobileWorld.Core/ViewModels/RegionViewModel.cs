﻿using MobileWorld.Core.ViewModels.Contacts;

namespace MobileWorld.Core.ViewModels
{
    public class RegionViewModel : IRegionViewModel
    {
        public string RegionName { get; set; }

        public string Neiborhood { get; set; }

        public string TownName { get; set; }
    }
}