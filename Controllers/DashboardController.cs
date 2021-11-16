using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using ProjectInter.Models;
using ProjectInter.Data.Interfaces;
using System.IO;
using System;


namespace ProjectInter.Controllers
{
    public class DashboardController : Controller
    {
        [HttpGet]
        public ActionResult LoguinAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoguinAdmin(IFormCollection LoginAdmin)
        {
            return RedirectToAction("Index", "Management");
        }
    }
}
