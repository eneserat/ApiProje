using Microsoft.AspNetCore.Mvc;

namespace ApiProjeWebUI.ViewComponents
{
    public class _FooterDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
