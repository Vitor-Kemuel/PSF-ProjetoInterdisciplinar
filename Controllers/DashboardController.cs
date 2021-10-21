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
        public ActionResult Order()
        {   
            return View(getOrders());
        }
        private List<Customer> getCustomers()
        {
            List<Customer> customers = new List<Customer>();

            Customer customer01 = new Customer();
            customer01.IdCustomer = 1;
            customer01.Name = "José Aparecido da Silva Filho";
            customer01.Adress = "Rua. Antonio José, 654";
            customer01.Complemento = "Ap. 15";
            customer01.Telefone = "(17) 91234-5678";

            Customer customer02 = new Customer();
            customer02.IdCustomer = 2;
            customer02.Name = "José da Silva";
            customer02.Adress = "Rua. Antonio José, 654";
            customer02.Complemento = "Ap. 15";
            customer02.Telefone = "(17) 91234-5678";

            Customer customer03 = new Customer();
            customer03.IdCustomer = 3;
            customer03.Name = "José da Silva";
            customer03.Adress = "Rua. Antonio José, 654";
            customer03.Complemento = "Ap. 15";
            customer03.Telefone = "(17) 91234-5678";

            Customer customer04 = new Customer();
            customer04.IdCustomer = 4;
            customer04.Name = "José da Silva";
            customer04.Adress = "Rua. Antonio José, 654";
            customer04.Complemento = "Ap. 15";
            customer04.Telefone = "(17) 91234-5678";

            Customer customer05 = new Customer();
            customer05.IdCustomer = 5;
            customer05.Name = "José da Silva";
            customer05.Adress = "Rua. Antonio José, 654";
            customer05.Complemento = "Ap. 15";
            customer05.Telefone = "(17) 91234-5678";

            Customer customer06 = new Customer();
            customer06.IdCustomer = 6;
            customer06.Name = "José da Silva";
            customer06.Adress = "Rua. Antonio José, 654";
            customer06.Complemento = "Ap. 15";
            customer06.Telefone = "(17) 91234-5678";

            customers.Add(customer01);
            customers.Add(customer02);
            customers.Add(customer03);
            customers.Add(customer04);
            customers.Add(customer05);
            customers.Add(customer06);

            return customers;
        }
        public ActionResult CustomerList()
        {
            return View(getCustomers());
        }
        public ActionResult NewCustomer()
        {
            return View();
        }
    }
}