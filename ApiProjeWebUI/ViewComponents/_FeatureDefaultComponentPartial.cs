using Microsoft.AspNetCore.Mvc;

namespace ApiProjeWebUI.ViewComponents
{
    public class _FeatureDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }   
    }
}
