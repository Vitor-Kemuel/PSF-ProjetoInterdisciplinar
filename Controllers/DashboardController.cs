using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


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
