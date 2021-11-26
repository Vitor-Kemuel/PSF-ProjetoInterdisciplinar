using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProjectInter.Models;
using System;


namespace ProjectInter.Controllers
{
    public class DashboardOrderController : Controller
    {
        private List<Order> getOrders()
        {
            List<Order> orders = new List<Order>();

            Order order01 = new Order();
            order01.IdOrder = 1;
            order01.DateToSell = new DateTime(2021, 11, 16, 18, 25, 00);
            order01.Situation = 3;
            order01.CodeOrder = "001282";
            order01.Observations = "Sem cebola";
            // order01.QuantityItens = 2; quantidade deve ser por itens
            order01.OrderRead = new System.DateTime(2021, 11, 26, 15, 20, 0);
            order01.OrderAccepted = new System.DateTime(2021, 11, 26, 15, 20, 0);
            order01.OrderDelivery = new System.DateTime(2021, 11, 26, 15, 20, 0);

            Order order02 = new Order();
            order02.IdOrder = 2;
            order02.DateToSell = new System.DateTime(2021, 11, 28);
            order02.Situation = 3;
            order02.CodeOrder = "001282";
            order02.Observations = "Sem cebola";
            order02.OrderRead = new System.DateTime(2021, 11, 28, 15, 20, 0);
            order02.OrderAccepted = new System.DateTime(2021, 11, 26, 15, 20, 0);
            order02.OrderDelivery = new System.DateTime(2021, 11, 26, 15, 20, 0);

            Order order03 = new Order();
            order03.IdOrder = 3;
            order03.DateToSell = new System.DateTime(2021, 11, 16);
            order03.Situation = 3;
            order03.CodeOrder = "001282";
            order03.Observations = "Sem cebola";
            order03.OrderRead = new System.DateTime(2021, 11, 26, 15, 20, 0);
            order03.OrderAccepted = new System.DateTime(2021, 11, 26, 15, 20, 0);
            order03.OrderDelivery = new System.DateTime(2021, 11, 26, 15, 20, 0);

            Order order04 = new Order();
            order04.IdOrder = 4;
            order04.DateToSell = new System.DateTime(2021, 11, 16);
            order04.Situation = 3;
            order04.CodeOrder = "001282";
            order04.Observations = "Sem cebola";
            order04.OrderRead = new System.DateTime(2021, 11, 26, 15, 20, 0);
            order04.OrderAccepted = new System.DateTime(2021, 11, 26, 15, 20, 0);
            order04.OrderDelivery = new System.DateTime(2021, 11, 26, 15, 20, 0);

            Order order05 = new Order();
            order05.IdOrder = 5;
            order05.DateToSell = new System.DateTime(2021, 11, 16);
            order05.Situation = 3;
            order05.CodeOrder = "001282";
            order05.Observations = "Sem cebola";
            order05.OrderRead = new System.DateTime(2021, 11, 26, 15, 20, 0);
            order05.OrderAccepted = new System.DateTime(2021, 11, 26, 15, 20, 0);
            order05.OrderDelivery = new System.DateTime(2021, 11, 26, 15, 20, 0);

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
    }
}
