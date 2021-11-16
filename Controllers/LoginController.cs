using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ProjectInter.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(IFormCollection Login)
        {
            return RedirectToAction("Order", "DashboardOrder");
        }
    }
}
