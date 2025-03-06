using DapperMVC.Data.Repository;
using DapperMVCPruebaPractica.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Diagnostics;

namespace DapperMVCPruebaPractica.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAsignaturaRepository _repository;

        public HomeController(ILogger<HomeController> logger, IAsignaturaRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<IActionResult> Index(int pageNumber = 1, int pagesize = 10)
        {
            var result = await _repository.GetAllAsync(pageNumber, pagesize);
            return View(result);
        }


        public IActionResult Privacy()
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
