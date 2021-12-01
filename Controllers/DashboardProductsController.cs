using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using ProjectInter.Models;
using ProjectInter.Data.Interfaces;
using System;
using System.IO;
using System.Text.Json;

namespace ProjectInter.Controllers
{
    public class DashboardProductsController : Controller
    {
        private IProductsRepository repositoryProducts;
        private IPurchaseRepository repositoryPurchase;
        private IOrderRepository repositoryOrder;

        public DashboardProductsController(IProductsRepository repositoryProducts, IPurchaseRepository repositoryPurchase, IOrderRepository repositoryOrder)
        {
            this.repositoryProducts = repositoryProducts;
            this.repositoryPurchase = repositoryPurchase;
            this.repositoryOrder = repositoryOrder;
        }

        private List<Products> GetProductsFromView(){
            List<Products> products = repositoryProducts.GetAllProducts();
            return products;
        }
        [HttpGet]
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
        [HttpGet]
        public ActionResult DeleteProduct(int idProduct)
        {
            repositoryProducts.Delete(idProduct);
            return RedirectToAction("Inventory");
        }

        [HttpPost]
        public ActionResult NewOrder(CartProduct cart)
        {
            // Console.WriteLine(cart.IdPrimary);
            // foreach (var item in cart.IdAdd)
            // {
            //     Console.WriteLine(item);
            // }
            string carrinho = HttpContext.Session.GetString("carrinho");

            List<CartProduct> itens = null;

            if(carrinho == null)
            {
                itens = new List<CartProduct>();
            }
            else
            {
                itens = JsonSerializer.Deserialize<List<CartProduct>>(carrinho);
            }

            itens.Add(cart);

            string jsonString = JsonSerializer.Serialize(itens);

            HttpContext.Session.SetString("carrinho", jsonString);

            return RedirectToAction("NewOrder");
        }
        public ActionResult Cart()
        {
            string carrinho = HttpContext.Session.GetString("carrinho");

            List<CartProduct> itens = null;

            if (carrinho != null)
            {
                itens = JsonSerializer.Deserialize<List<CartProduct>>(carrinho);
            }
            else
            {
                return View(null);
            }

            Console.WriteLine(itens);
            foreach (var item in itens)
            {
                Console.WriteLine("Product");
                Console.WriteLine(item.IdPrimary);
                Console.WriteLine("Product Amount");
                Console.WriteLine(item.Amount);
                foreach (var add in item.IdAdd)
                {
                    Console.WriteLine("Product ADD");
                    Console.WriteLine(add);
                }

            }

            List<Products> allProducts = repositoryProducts.GetAllProducts();

            List<Products> retorno = new List<Products>();

            foreach (var productForCart in itens)
            {
                foreach (var productForAllProduct in allProducts)
                {
                    if(productForAllProduct.IdProducts == productForCart.IdPrimary)
                    {
                        Products cartProduct = productForAllProduct;
                        List<Products> adic = new List<Products>();
                        foreach (var aditionaisProduct in productForCart.IdAdd)
                        {
                            foreach (var productAllAditions in allProducts)
                            {
                                if(aditionaisProduct == productAllAditions.IdProducts)
                                {
                                    Products add = productAllAditions;
                                    adic.Add(add);
                                }
                            }
                        }
                        cartProduct.Adicionais = adic;
                        retorno.Add(cartProduct);
                    }

                }
            }

            return View(retorno);

        }
        [HttpGet]
        public ActionResult ToOrder(int idCustomer)
        {
            string carrinho = HttpContext.Session.GetString("carrinho");

            List<CartProduct> itens = null;

            if (carrinho != null)
            {
                itens = JsonSerializer.Deserialize<List<CartProduct>>(carrinho);
            }

            Console.WriteLine(itens);
            foreach (var item in itens)
            {
                Console.WriteLine("Product");
                Console.WriteLine(item.IdPrimary);
                Console.WriteLine("Product Amount");
                Console.WriteLine(item.Amount);
                foreach (var add in item.IdAdd)
                {
                    Console.WriteLine("Product ADD");
                    Console.WriteLine(add);
                }

            }

            List<Products> allProducts = repositoryProducts.GetAllProducts();

            List<Products> retorno = new List<Products>();

            List<int> quantidade = new List<int>();

            Order order = new Order();
            List<ProductsOrders> listaProductOrder = new List<ProductsOrders>();

            var now = DateTime.Now;


            foreach (var productForCart in itens)
            {
                
                foreach (var productForAllProduct in allProducts)
                {
                    
                    if(productForAllProduct.IdProducts == productForCart.IdPrimary)
                    {
                        Products cartProduct = productForAllProduct;
                        List<Products> adic = new List<Products>();
                        var amoutn = productForCart.Amount;


                        ProductsOrders productsOrders = new ProductsOrders();

                        foreach (var aditionaisProduct in productForCart.IdAdd)
                        {
                            foreach (var productAllAditions in allProducts)
                            {
                                if(aditionaisProduct == productAllAditions.IdProducts)
                                {
                                    Products add = productAllAditions;
                                    adic.Add(add);
                                }
                            }
                        }
                        
                        cartProduct.Adicionais = adic;
                        productsOrders.Quantify = amoutn;
                        productsOrders.Produtos = cartProduct;
                        listaProductOrder.Add(productsOrders);
                    }

                }
            }

            order.DateToSell = DateTime.Now;
            order.OrderRead = DateTime.Now;
            order.OrderAccepted = DateTime.Now;
            order.OrderDelivery = DateTime.Now;
            order.Itens = listaProductOrder;
            order.Situation = 2;
            order.Customer.IdPerson = idCustomer;



            
            repositoryOrder.Create(order);
            return RedirectToAction("Inventory");
        }
    }
}
