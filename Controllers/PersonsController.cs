using Microsoft.AspNetCore.Mvc;

namespace ProjectInter.Controllers
{
   public class PersonsController : Controller
   {
       public ActionResult Index()
       {
           return View();
       }

       [HttpGet]
       public ActionResult Create()
       {
           return View();
       }
   }
}
