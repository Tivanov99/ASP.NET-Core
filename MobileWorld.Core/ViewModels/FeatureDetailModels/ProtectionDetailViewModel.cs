﻿using MobileWorld.Core.ViewModels.FeatureDetailModels.FeatureContracts;

namespace MobileWorld.Core.ViewModels.FeatureDetailModels
{
    public class ProtectionDetailViewModel : IProtectionDetailViewModel
    {
        public bool Alarm { get; set; }

        public bool Armored { get; set; }

        public bool Immobilizer { get; set; }

        public bool Casco { get; set; }

        public bool CentralLocking { get; set; }
    }
}
