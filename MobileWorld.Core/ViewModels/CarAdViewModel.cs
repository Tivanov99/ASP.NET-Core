﻿namespace MobileWorld.Core.ViewModels
{
    public class CarAdViewModel
    {
        public string Town { get; set; }

        public string Region { get; set; }

        public string Neighborhood { get; set; }

        public CarDetailsViewModel Car { get; set; } = new();

        public OwnerViewModel Owner { get; set; } = new();
    }
}
