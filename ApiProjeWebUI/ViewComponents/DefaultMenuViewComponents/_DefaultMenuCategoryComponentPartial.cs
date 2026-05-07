

using ApiProjeWebUI.Dtos.CategoryDtos;
using ApiProjeWebUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeWebUI.ViewComponents.DefaultMenuViewComponents
{
    public class _DefaultMenuCategoryComponentPartial:ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultMenuCategoryComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7009/api/Categories");

            if (!responseMessage.IsSuccessStatusCode)
            {
                return View(new List<ResultTestimonialDto>());
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
            return View(values);
        }
    }
}
