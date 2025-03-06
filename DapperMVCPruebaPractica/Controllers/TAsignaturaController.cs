using DapperMVC.Data.Models.Domain;
using DapperMVC.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperMVCPruebaPractica.Controllers
{
    public class TAsignaturaController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAsignaturaRepository _repository;

        public TAsignaturaController(ILogger<HomeController> logger, IAsignaturaRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        // GET: TAsignaturaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TAsignaturaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TAsignaturaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TAsignaturaController/Create
        [HttpPost]
        public async Task<ActionResult> Create(TAsignatura asignatura)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TAsignaturaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TAsignaturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TAsignaturaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TAsignaturaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
        public async Task<ActionResult> GetById(int id)
        {
                return View();   
        }

        public async Task<ActionResult> GetAll(int pageNumber=1, int pagesize=10 )
        {
            var result = await _repository.GetAllAsync(pageNumber,pagesize);
            return View(result);
        }
    }
}
