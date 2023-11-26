using AutoMapper;
using ManageBidding.Application.ViewModels;
using ManageBidding.Domain.Models;

namespace ManageBidding.Application.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region ViewModelToDomain
            CreateMap<BiddingViewModel, Bidding>();
            #endregion

            #region DomainToViewModel
            CreateMap<Bidding, BiddingViewModel>();
            #endregion
        }
    }
}
