﻿using MobileWorld.Infrastructure.Data.Enums;

namespace MobileWorld.Infrastructure.Data.QueriesAndSPDtoModels
{
    public class CarSpModel
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public GearType GearType { get; set; }

        public string Color { get; set; }

        public int SeatsCount { get; set; }

        public decimal Mileage { get; set; }
    }
}
