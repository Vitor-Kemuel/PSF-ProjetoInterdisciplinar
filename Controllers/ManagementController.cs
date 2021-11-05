using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using ProjectInter.Models;

namespace ProjectInter.Controllers
{
    public class ManagementController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Employee()
        {
            return View();
        }
        public ActionResult NewEmployee()
        {
            return View();
        }
    }
}