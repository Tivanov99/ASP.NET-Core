using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Infrastructure.Data.Models
{
    public class OthersDetail
    {
        [Key]
        public int Id { get; set; }

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
