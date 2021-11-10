using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using ProjectInter.Models;
using ProjectInter.Data.Interfaces;
using ProjectInter.Data.Repositories;


namespace ProjectInter.Controllers
{
    public class ManagementController : Controller
    {
        private IEmployeesRepository repository;

        public ManagementController(IEmployeesRepository repository){
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Employee()
        {
            return View();
        }
        [HttpGet]
        public ActionResult NewEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewEmployee(Employees employees)
        {
            repository.Create(employees);
            return RedirectToAction("Order");
        }
    }
}
