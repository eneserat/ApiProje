using Microsoft.AspNetCore.Mvc;

namespace ApiProjeWebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
