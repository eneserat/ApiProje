using Microsoft.AspNetCore.Mvc;

namespace ApiProjeWebUI.ViewComponents.DefaultMenuViewComponents
{
    public class _DefaultMenuViewComponents: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
