using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using ProjectInter.Models;
using ProjectInter.Data.Interfaces;
using System.IO;
using System;


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
        public ActionResult NewCustomer(Customers customer, Address address)
        {
            repository.Create(customer, address);
            return RedirectToAction("CustomerList");
        }
    }
}
