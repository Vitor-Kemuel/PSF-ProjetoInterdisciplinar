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

        private List<Products> GetProductsFromView(){
            List<Products> products = repository.GetAllProducts();
            return products;
        }

        public ActionResult NewOrder()
        {
            return View(GetProductsFromView());
        }

        [HttpGet]
        public ActionResult Inventory()
        {
            List<Products> products = repository.GetAllProducts();
            return View(products);
        }
        [HttpPost]
        public ActionResult Inventory(Products products)
        {
            /*
                se(products.Name != empyt && preço != null)
                   fazer lógica para alterar a quantidade e o preço
                senão
                   faz a compra
            */
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

            IFormFile file = products.ImageFile;
            if (products.ImageFile != null)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                var filePath = Path.Combine(uploads, fileName);
                using (var stream = System.IO.File.Create(filePath)){
                   products.ImageFile.CopyTo(stream);
                }
                products.Image = fileName;
            }

            repository.Create(products);
            return RedirectToAction("Inventory");
        }
    }
}
