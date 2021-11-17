using Microsoft.AspNetCore.Mvc;
using ProjectInter.Models;
using ProjectInter.Data.Interfaces;


namespace ProjectInter.Controllers
{
    public class DashboardCustomerController : Controller
    {
        private ICustomersRepository repository;
        public DashboardCustomerController(ICustomersRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult CustomerList()
        {
            var customers = repository.GetAllCustomers();
            return View(customers);
        }
        [HttpGet]
        public ActionResult NewCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCustomer(Customers customer)
        {
            repository.Create(customer);
            return RedirectToAction("CustomerList");
        }
    }
}
