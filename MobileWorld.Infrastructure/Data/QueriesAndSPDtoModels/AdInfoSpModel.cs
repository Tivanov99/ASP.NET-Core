﻿namespace MobileWorld.Infrastructure.Data.QueriesAndSPDtoModels
{
    public class AdInfoSpModel
    {
        //Ad
        public string Id { get; set; }

        public string Title { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreatedOn { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}