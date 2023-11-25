using AutoMapper;
using ManageBidding.Domain.Models;
using ManageBidding.Domain.Interfaces;
using ManageBidding.Domain.Validations;
using ManageBidding.Application.ViewModels;
using ManageBidding.Application.Interfaces.Services;

namespace ManageBidding.Application.Services
{
    public class BiddingService : Service, IBiddingService
    {
        private readonly IBiddingRepository _biddingRepository;
        private readonly IMapper _mapper;

        public BiddingService(INotificationService notificationService, IBiddingRepository biddingRepository, IMapper mapper) : base(notificationService)
        {
            _biddingRepository = biddingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BiddingViewModel>> Get()
        {
            return _mapper.Map<IEnumerable<BiddingViewModel>>(await _biddingRepository.Get());
        }

        public async Task<BiddingViewModel> GetById(Guid id)
        {
            Bidding bidding = _biddingRepository.Find(b => b.Id == id && b.Active);

            if (bidding == null)
            {
                throw new Exception("Licitação não encontrada.");
            }

            return _mapper.Map<BiddingViewModel>(await _biddingRepository.GetById(id));
        }

        public async Task<Bidding> Create(BiddingViewModel biddingViewModel)
        {
            var bidding = _mapper.Map<Bidding>(biddingViewModel);

            if (!ExecuteValidation(new BiddingValidation(), bidding))
            {
                return bidding;
            }

            _biddingRepository.Create(bidding);

            await _biddingRepository.UnitOfWork.Commit();

            return bidding;
        }

        public async Task<Bidding> Update(BiddingViewModel biddingViewModel)
        {
            if (biddingViewModel.Id == Guid.Empty)
            {
                throw new Exception("Id inválido.");
            }

            Bidding bidding = _biddingRepository.Find(b => b.Id == biddingViewModel.Id && b.Active);

            if (bidding == null)
            {
                throw new Exception("Licitação não encontrada.");
            }

            bidding = _mapper.Map<Bidding>(biddingViewModel);

            if (!ExecuteValidation(new BiddingValidation(), bidding))
            {
                return bidding;
            }

            _biddingRepository.Update(bidding);

            await _biddingRepository.UnitOfWork.Commit();

            return bidding;
        }

        public async Task<bool> Delete(Guid id)
        {
            Bidding bidding = _biddingRepository.Find(x => x.Id == id && x.Active);

            if (bidding == null)
            {
                throw new Exception("Licitação não encontrada.");
            }

            bidding.Deactivate();

            _biddingRepository.Update(bidding);

            return await _biddingRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _biddingRepository?.Dispose();
        }
    }
}
