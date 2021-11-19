using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using ProjectInter.Models;
using ProjectInter.Data.Interfaces;
using System.IO;
using System;


namespace ProjectInter.Controllers
{
    public class DashboardProductsController : Controller
    {
        private IProductsRepository repository;

        public DashboardProductsController(IProductsRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult NewOrder()
        {
            return View();
        }

        public ActionResult Inventory()
        {
            return View();
        }
        [HttpGet]
        public ActionResult NewProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewProduct(Products products)
        {

            if (products.Image != null)
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
                var filePath = Path.Combine(uploads, new Guid().ToString());
                using (var stream = System.IO.File.Create(filePath)){
                   products.Image.CopyTo(stream);
                }
            }

            repository.Create(products);
            return RedirectToAction("Inventory");
        }
    }
}
