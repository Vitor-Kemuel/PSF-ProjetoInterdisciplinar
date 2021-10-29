using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProjectInter.Models;
using System;
using ProjectInter.Data.Interfaces;

namespace ProjectInter.Controllers
{
    public class DashboardController : Controller
    {

        // private ICustomersRepository repository;

        // public DashboardController(ICustomersRepository repository)
        // {
            // this.repository = repository;
        // }

        private List<Order> getOrders()
        {
            List<Order> orders = new List<Order>();

            Order order01 = new Order();
            order01.IdOrder = 1;
            // order01.DateToSell = new DateTime(2021, 22, 10);
            order01.DateToSell = "15/10";
            order01.Situation = 3;
            order01.CodeOrder = "001282";
            order01.Observations = "Sem cebola";
            // order01.QuantityItens = 2; quantidade deve ser por itens
            order01.OrderRead = "15:15";
            order01.OrderAccepted = "15:15";
            order01.OrderDelivery = "15:20";
            // order01.TypeOrder = 1;

            orders.Add(order01);

            return orders;
        }
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
        public ActionResult NewCustomer()
        {
            return View();
        }

        public ActionResult NewOrder()
        {
            return View();
        }
    }
}