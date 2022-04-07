﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileWorld.Infrastructure.Data.Models
{
    public class SafetyDetail
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Feature))]
        public int FeatureId { get; set; }

        public Feature Feature { get; set; }

        public bool Gps { get; set; }

        public bool AutomaticStabilityControl { get; set; }

        public bool AdaptiveFrontLights { get; set; }

        public bool Abs { get; set; }

        public bool ElBreaks { get; set; }

        public bool Esp { get; set; }

        public bool TirePressure { get; set; }

        public bool ParkPilot { get; set; }

        public bool IsoFix { get; set; }

        public bool DynamicStabilitySystem { get; set; }

        public bool SlipProtectionSystem { get; set; }

        public bool DryBrakesSystem { get; set; }

        public bool Distronic { get; set; }

        public bool HillDescentControll { get; set; }

        public bool BrakeAssist { get; set; }
    }
}
