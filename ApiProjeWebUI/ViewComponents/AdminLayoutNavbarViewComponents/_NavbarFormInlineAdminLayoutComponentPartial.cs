using Microsoft.AspNetCore.Mvc;

namespace ApiProjeWebUI.ViewComponents.AdminLayoutNavbarViewComponents
{
    public class _NavbarFormInlineAdminLayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
