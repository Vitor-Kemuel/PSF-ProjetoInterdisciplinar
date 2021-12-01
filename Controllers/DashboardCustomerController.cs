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
        [HttpGet]
        public ActionResult UpdateCustomer(int idCustomer)
        {
            var customer = repository.GetSingleCustomer(idCustomer);
            return View(customer);
        }
        [HttpPost]
        public ActionResult UpdateCustomer( int idCustomer, Customers customer)
        {
            repository.Update(idCustomer, customer);
            return RedirectToAction("CustomerList");
        }
        [HttpGet]
        public ActionResult DeleteCustomer(int idCustomer)
        {
            repository.Delete(idCustomer);
            return RedirectToAction("CustomerList");
        }
        [HttpGet]
        public ActionResult CartCustomer()
        {
            var customers = repository.GetAllCustomers();
            return View(customers);
        }
    }
}
