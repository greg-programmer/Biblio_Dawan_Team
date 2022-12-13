using Biblioteque.Models;
using Biblioteque.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Biblioteque.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LivreRepository _livreRepository;

        private readonly BiblioContext _context;

        public HomeController(ILogger<HomeController> logger, BiblioContext context)
        {
            _logger = logger;
            _livreRepository = new LivreRepository(context);
            _context = context;
        }


        public IActionResult Index()
        {
            return View(  _livreRepository.FindAllReverse4());
        }

        public IActionResult Apropos()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}