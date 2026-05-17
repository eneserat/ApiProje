using Microsoft.AspNetCore.Mvc;

namespace ApiProjeWebUI.ViewComponents.AdminLayoutViewComponents
{
    public class _HeadAdminLayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
