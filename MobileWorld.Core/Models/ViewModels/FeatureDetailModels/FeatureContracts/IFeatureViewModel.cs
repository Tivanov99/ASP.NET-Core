﻿using MobileWorld.Core.ViewModels.FeatureDetailModels.FeatureContracts;

namespace MobileWorld.Core.Models.ViewModels.FeatureDetailModels.FeatureContracts
{
    public interface IFeatureViewModel
    {
        public IComfortDetailViewModel ComfortDetails { get; set; }

        public IExteriorDetailViewModel ExteriorDetails { get; set; }

        public IInteriorDetailViewModel InteriorDetails { get; set; }

        public IOthersDetailViewModel OthersDetails { get; set; }

        public IProtectionDetailViewModel ProtectionDetails { get; set; }

        public ISafetyDetailViewModel SafetyDetails { get; set; }

    }
}
