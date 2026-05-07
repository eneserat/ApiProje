using Microsoft.AspNetCore.Mvc;

namespace ApiProjeWebUI.ViewComponents.DefaultMenuViewComponents
{
    public class _DefaultMenuViewComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
