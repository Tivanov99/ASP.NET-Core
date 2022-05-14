using AutoMapper;
using MobileWorld.Core.ViewModels;
using MobileWorld.Infrastructure.Data.QueriesAndSPDtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileWorld.Core
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AdSpModel, AdViewModel>();
        }
    }
}
