using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using ProjectInter.Models;
using System;
using ProjectInter.Data.Interfaces;

namespace ProjectInter.Controllers
{
    public class DashboardController : Controller
    {

        private ICustomersRepository repository;

        public DashboardController(ICustomersRepository repository)
        {
            this.repository = repository;
        }

        private List<Order> getOrders()
        {
            List<Order> orders = new List<Order>();

            Order order01 = new Order();
            order01.IdOrder = 1;
            order01.DateToSell = "15/10";
            order01.Situation = 3;
            order01.CodeOrder = "001282";
            order01.Observations = "Sem cebola";
            // order01.QuantityItens = 2; quantidade deve ser por itens
            order01.OrderRead = "15:15";
            order01.OrderAccepted = "15:15";
            order01.OrderDelivery = "15:20";

            Order order02 = new Order();
            order02.IdOrder = 2;
            order02.DateToSell = "15/10";
            order02.Situation = 3;
            order02.CodeOrder = "001282";
            order02.Observations = "Sem cebola";
            order02.OrderRead = "15:15";
            order02.OrderAccepted = "15:15";
            order02.OrderDelivery = "15:20";

            Order order03 = new Order();
            order03.IdOrder = 3;
            order03.DateToSell = "15/10";
            order03.Situation = 3;
            order03.CodeOrder = "001282";
            order03.Observations = "Sem cebola";
            order03.OrderRead = "15:15";
            order03.OrderAccepted = "15:15";
            order03.OrderDelivery = "15:20";

            Order order04 = new Order();
            order04.IdOrder = 4;
            order04.DateToSell = "15/10";
            order04.Situation = 3;
            order04.CodeOrder = "001282";
            order04.Observations = "Sem cebola";
            order04.OrderRead = "15:15";
            order04.OrderAccepted = "15:15";
            order04.OrderDelivery = "15:20";

            Order order05 = new Order();
            order05.IdOrder = 5;
            order05.DateToSell = "15/10";
            order05.Situation = 3;
            order05.CodeOrder = "001282";
            order05.Observations = "Sem cebola";
            order05.OrderRead = "15:15";
            order05.OrderAccepted = "15:15";
            order05.OrderDelivery = "15:20";

            orders.Add(order01);
            orders.Add(order02);
            orders.Add(order03);
            orders.Add(order04);
            orders.Add(order05);

            return orders;
        }
        [HttpGet]
        public ActionResult Order()
        {   
            return View(getOrders());
        }
        // private List<Customers> getCustomers()
        // {
            // List<Customers> customers = repository.GetAllCustomers();
            // return customers;
        // }
        public ActionResult CustomerList()
        {
            // return View(getCustomers());
            return View();
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
            return RedirectToAction("Order");
        }

        public ActionResult NewOrder()
        {
            return View();
        }
        
        public ActionResult Inventory()
        {
            return View();
        }

        public ActionResult NewProduct()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoguinAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoguinAdmin(IFormCollection LoginAdmin)
        {
            return RedirectToAction("Index", "Management");
        }
    }
}