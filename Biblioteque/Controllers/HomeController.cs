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
<<<<<<< HEAD
        protected readonly BiblioContext _context;
        protected readonly LivreRepository _livreRepository;
        protected readonly AuteurRepository _auteurRepository;
        protected readonly GenreRepository _genreRepository;
        
        public HomeController(ILogger<HomeController> logger, BiblioContext context)
        {
            _logger = logger;
            _context = context;
            _livreRepository = new LivreRepository(context);
            _auteurRepository = new AuteurRepository(context);
            _genreRepository = new GenreRepository(context);
=======
        private readonly LivreRepository _livreRepository;

        private readonly BiblioContext _context;

        public HomeController(ILogger<HomeController> logger, BiblioContext context)
        {
            _logger = logger;
            _livreRepository = new LivreRepository(context);
            _context = context;
>>>>>>> c9e229e602811744bac6ab818b33cfafad51d15e
        }


        public IActionResult Index()
        {
<<<<<<< HEAD
            var livre = _livreRepository.FindAll();
            var auteur = _auteurRepository.FindAll();
            var genre = _genreRepository.FindAll();

            var id = _context.Livres
                   .OrderByDescending(l => l.Id)
                   .FirstOrDefault();


            ViewModel viewModel = new ViewModel()
            {
                LivreViewM = livre,
                GenreViewM = genre, 
                AuteurViewM = auteur,
                LivreViewM_Nolist = _livreRepository.FindById(id.Id),
                GenreViewM_Nolist = _genreRepository.FindById(id.Id),
                AuteurViewM_Nolist = _auteurRepository.FindById(id.Id), 
        };    
             return View(viewModel);
=======
            return View(  _livreRepository.FindAllReverse4());
>>>>>>> c9e229e602811744bac6ab818b33cfafad51d15e
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