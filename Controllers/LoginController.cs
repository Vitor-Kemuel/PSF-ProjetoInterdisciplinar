using Microsoft.AspNetCore.Mvc;
using ProjectInter.Data.Interfaces;
using ProjectInter.Models;

namespace ProjectInter.Controllers
{
    public class LoginController : Controller
    {
        private IEmployeesRepository repository;

        public LoginController(IEmployeesRepository repository){
            this.repository = repository;
        }


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Employees model)
        {

            if(!ModelState.IsValid)
                return View(model);

            Employees employees = repository.Login(model);

            if(employees == null){
                ViewBag.Title = "Usuário não encontrado";
                return View(model);
            }

            return RedirectToAction("Order", "DashboardOrder");
        }
    }
}
