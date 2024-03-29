﻿
using MobileWorld.Core.Models.ViewModels.FeatureDetailModels.FeatureContracts;
using MobileWorld.Infrastructure.Data.Enums;

namespace MobileWorld.Core.Models.ViewModels.Contacts

{
    public interface ICarViewModel
    {
        public string Make { get; set; }

        public string Color { get; set; }

        public int SeatsCount { get; set; }

        public decimal Mileage { get; set; }

        public int Year { get; set; }

        public GearType GearType { get; set; }

        public IEngineViewModel Engine { get; set; }

        public IFeatureViewModel Features { get; set; }
    }
}
