using Microsoft.AspNetCore.Mvc;

namespace ApiProjeWebUI.ViewComponents
{
    public class _NavbarDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
