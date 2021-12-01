using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProjectInter.Models;
using System;
using ProjectInter.Data.Interfaces;

namespace ProjectInter.Controllers
{
    public class DashboardOrderController : Controller
    {
        private IOrderRepository repositoryOrder;

        public DashboardOrderController(IOrderRepository repositoryOrder)
        {
            this.repositoryOrder = repositoryOrder;
        }
        [HttpGet]
        public ActionResult Order()
        {
            // return View(getOrders());
            return View(repositoryOrder.GetAllOrders());
        }
    }
}
