using AutoMapper;
using ManageBidding.Domain.Models;
using ManageBidding.Application.ViewModels;

namespace ManageBidding.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<BiddingViewModel, Bidding>().ConstructUsing(b => new Bidding(b.Number, b.Description, b.Status));
        }
    }
}
