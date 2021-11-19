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
        public ActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAdmin(IFormCollection LoginAdmin)
        {
            return RedirectToAction("Index", "Management");
        }
    }
}
