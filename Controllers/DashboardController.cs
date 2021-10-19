using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProjectInter.Models;

namespace ProjectInter.Controllers
{
    public class DashboardController : Controller
    {
        private List<Order> getOrders()
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

            Order order03 = new Order();
            order03.IdOrder = 3;
            order03.Date = "18/10";
            order03.Client = "Eduardo Junior";
            order03.Situation = "Finalizado";
            order03.OrderRead = "15:20";
            order03.OrderAccepted = "15:20";
            order03.OrderDelivery = "15:23";

            Order order04 = new Order();
            order04.IdOrder = 4;
            order04.Date = "18/10";
            order04.Client = "Fabricio Souza";
            order04.Situation = "Em andamento";
            order04.OrderRead = "15:30";
            order04.OrderAccepted = "15:30";
            order04.OrderDelivery = "--:--";

            Order order05 = new Order();
            order05.IdOrder = 5;
            order05.Date = "18/10";
            order05.Client = "Jessica Alves";
            order05.Situation = "Aguardando aprovação";
            order05.OrderRead = "15:32";
            order05.OrderAccepted = "--:--";
            order05.OrderDelivery = "--:--";

            orders.Add(order01);
            orders.Add(order02);
            orders.Add(order03);
            orders.Add(order04);
            orders.Add(order05);

            return orders;
        }
        public ActionResult Dashboard()
        {   
            return View(getOrders());
        }
    }
}