﻿using MobileWorld.Core.Models.ViewModels.FeatureDetailModels.FeatureContracts;

namespace MobileWorld.Core.Models.ViewModels.FeatureDetailModels
{
    public class OthersDetailViewModel : IOthersDetailViewModel
    {
        public bool AllDrive { get; set; }

        public bool SevenSeats { get; set; }

        public bool BuyBack { get; set; }

        public bool Exchange { get; set; }

        public bool AutoGas { get; set; }

        public bool Long { get; set; }

        public bool Catastrophic { get; set; }

        public bool Leasing { get; set; }

        public bool MethaneSystem { get; set; }

        public bool InPieces { get; set; }

        public bool FullyServed { get; set; }

        public bool Registration { get; set; }

        public bool Tuning { get; set; }
    }
}
