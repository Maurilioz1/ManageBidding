using AutoMapper;
using ManageBidding.Domain.Models;
using ManageBidding.Application.ViewModels;

namespace ManageBidding.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Bidding, BiddingViewModel>();
        }
    }
}
