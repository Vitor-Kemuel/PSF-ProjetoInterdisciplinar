using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProjectInter.Models;

namespace ProjectInter.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            List<Order> orders = new List<Order>();

            Order order01 = new Order();
            order01.IdOrder = 1;
            order01.Date = "18/10";
            order01.Client = "Julio Cesar";
            order01.Situation = "Finalizado";
            order01.OrderRead = "15:15";
            order01.OrderAccepted = "15:15";
            order01.OrderDelivery = "15:20";

            Order order02 = new Order();
            order02.IdOrder = 2;
            order02.Date = "18/10";
            order02.Client = "Jaqueline Ster";
            order02.Situation = "Finalizado";
            order02.OrderRead = "15:17";
            order02.OrderAccepted = "15:17";
            order02.OrderDelivery = "15:21";

            orders.Add(order01);
            orders.Add(order02);
            
            return View(orders);
        }
    }
}