using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileWorld.Infrastructure.Data.Models
{
    public class Image
    {
        public int Id { get; set; }

        public string ImageTitle { get; set; }

        public byte[] ImageData { get; set; }
    }
}
