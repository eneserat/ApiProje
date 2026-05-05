using ApiProjeWebUI.Dtos.CategoryDtos;
using ApiProjeWebUI.Dtos.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeWebUI.Views.Shared.Components._DefaultMenuViewComponents
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
                return View(new List<ResultCategoryDto>());
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            return View(values);
        }
    }
    }

