using Microsoft.AspNetCore.Mvc;
using ProjectInter.Models;
using ProjectInter.Data.Interfaces;
using System.Collections.Generic;

namespace ProjectInter.Controllers
{
    public class ManagementController : Controller
    {
        private IEmployeesRepository repository;

        public ManagementController(IEmployeesRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Employee()
        {
            List<Employees> employees = repository.GetListEmployees();
            return View(employees);
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
            return RedirectToAction("Index");
        }
    }
}
