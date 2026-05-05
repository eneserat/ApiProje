using Microsoft.AspNetCore.Mvc;

namespace ApiProjeWebUI.ViewComponents
{
    public class _AboutDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
