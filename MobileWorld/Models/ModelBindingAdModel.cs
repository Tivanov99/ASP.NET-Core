using Microsoft.AspNetCore.Mvc;
using MobileWorld.Core.Models.InputModels;

namespace MobileWorld.Models
{
    public class ModelBindingAdModel : AdInputModel
    {
        //[BindProperty]
        public override decimal Price { get => base.Price; set => base.Price = value; }
    }
}
