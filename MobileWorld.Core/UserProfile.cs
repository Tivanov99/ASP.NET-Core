using AutoMapper;
using MobileWorld.Core.ViewModels;
using MobileWorld.Infrastructure.Data.QueriesAndSPDtoModels;

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
