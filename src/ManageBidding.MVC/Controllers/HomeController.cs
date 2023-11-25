using Microsoft.AspNetCore.Mvc;
using ManageBidding.MVC.Models;
using ManageBidding.Application.Interfaces.Services;

namespace ManageBidding.MVC.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, INotificationService notificationService) : base(notificationService)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelError = new ErrorViewModel();

            if (id == 500)
            {
                modelError.ErrorCode = id;
                modelError.Title = "Ocorreu um erro!";
                modelError.Message = "Ocorreu um erro! Tente novamente mais tarde ou contate nosso suporte.";
            }

            if (id == 404)
            {
                modelError.ErrorCode = id;
                modelError.Title = "Ops! Página não encontrada.";
                modelError.Message = "A página que está procurando não existe! <br /> Em caso de dúvidas entre em contato com nosso suporte.";
            }
            else
            {
                return StatusCode(400);
            }

            return View("Error", modelError);
        }
    }
}
