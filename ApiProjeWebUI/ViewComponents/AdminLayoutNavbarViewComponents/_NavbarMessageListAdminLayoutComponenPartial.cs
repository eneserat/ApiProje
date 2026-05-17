using ApiProjeWebUI.Dtos.ChefDtos;
using ApiProjeWebUI.Dtos.MessageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeWebUI.ViewComponents.AdminLayoutNavbarViewComponents
{
    public class _NavbarMessageListAdminLayoutComponenPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _NavbarMessageListAdminLayoutComponenPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7009/api/Messages/MessageListByIsReadFalse");

            if (!responseMessage.IsSuccessStatusCode)
            {
                return View(new List<ResultMessageByIsReadFalseDto>());
            }
                
                
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultMessageByIsReadFalseDto>>(jsonData);
            return View(values);
        }
    }
}
