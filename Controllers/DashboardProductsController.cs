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
        private IProductsRepository repositoryProducts;
        private IPurchaseRepository repositoryPurchase;

        public DashboardProductsController(IProductsRepository repositoryProducts, IPurchaseRepository repositoryPurchase)
        {
            this.repositoryProducts = repositoryProducts;
            this.repositoryPurchase = repositoryPurchase;
        }

        private List<Products> GetProductsFromView(){
            List<Products> products = repositoryProducts.GetAllProducts();
            return products;
        }

        public ActionResult NewOrder()
        {
            return View(GetProductsFromView());
        }

        [HttpGet]
        public ActionResult Inventory()
        {
            List<Products> products = repositoryProducts.GetAllProducts();
            return View(products);
        }
        [HttpPost]
        public ActionResult Inventory(int idProduct, string name, double amount, string price, double inventory)
        {
            if (name != null && price != null)
                repositoryProducts.UpdateProduct(idProduct, name, Convert.ToDouble(price));
            else
                repositoryPurchase.Create(amount, idProduct, inventory);
                
            return RedirectToAction("Inventory");    
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

            repositoryProducts.Create(products);
            return RedirectToAction("Inventory");
        }
    }
}
