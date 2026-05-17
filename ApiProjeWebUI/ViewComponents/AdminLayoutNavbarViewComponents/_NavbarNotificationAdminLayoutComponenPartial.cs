using ApiProjeWebUI.Dtos.MessageDtos;
using ApiProjeWebUI.Dtos.NotificationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeWebUI.ViewComponents.AdminLayoutNavbarViewComponents
{
    public class _NavbarNotificationAdminLayoutComponenPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _NavbarNotificationAdminLayoutComponenPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7009/api/Notifications");

            if (!responseMessage.IsSuccessStatusCode)
            {
                return View(new List<ResultMessageByIsReadFalseDto>());
            }


            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(jsonData);
            return View(values);
        }
    }
}
