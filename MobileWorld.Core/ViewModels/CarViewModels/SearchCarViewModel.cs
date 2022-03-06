﻿namespace MobileWorld.Core.ViewModels.CarViewModels
{
    public class SearchCarViewModel
    {
        public string Make { get; set; }

        public string Location { get; set; }

        public decimal MaxPrice { get; set; }

        public int AfterYear { get; set; }

        public string Transmission { get; set; }

        public string EngineType { get; set; }

        public bool Asc { get; set; }
    }
}
