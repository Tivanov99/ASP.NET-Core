﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MobileWorld.Infrastructure.Data.QueriesAndSPDtoModels
{
    public class AdCardSpViewModel
    {
        public string AdId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageTitle { get; set; }

        public DateTime CreatedOn { get; set; }
        //public string ImagePath { get; set; }
    }
}
