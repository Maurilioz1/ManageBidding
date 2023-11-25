using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ManageBidding.Application.Interfaces.Services;
using ManageBidding.Application.ViewModels;
using ManageBidding.Domain.Models;

namespace ManageBidding.MVC.Controllers
{
    [Route("licitacoes")]
    public class BiddingsController : BaseController
    {
        private readonly IBiddingService _biddingService;
        private readonly IMapper _mapper;

        public BiddingsController(INotificationService notificationService, IBiddingService biddingService, IMapper mapper) : base(notificationService)
        {
            _biddingService = biddingService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<BiddingViewModel>>(await _biddingService.Get()));
        }

        [Route("detalhes")]
        public async Task<IActionResult> Details(Guid id)
        {
            var bidding = await GetBidding(id);

            if (bidding == null)
            {
                return NotFound();
            }

            return View(bidding);
        }

        [Route("registrar")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("registrar")]
        [HttpPost]
        public async Task<IActionResult> Create(BiddingViewModel biddingViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(biddingViewModel);
            }

            await _biddingService.Create(biddingViewModel);

            if(!ValidOperation())
            {
                return View(biddingViewModel);
            }

            return RedirectToAction("Index");
        }

        private async Task<BiddingViewModel> GetBidding(Guid id)
        {
            var bidding = _mapper.Map<BiddingViewModel>(await _biddingService.GetById(id));

            return bidding;
        }
    }
}
