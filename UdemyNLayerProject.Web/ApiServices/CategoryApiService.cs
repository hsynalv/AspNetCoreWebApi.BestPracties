using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UdemyNlayerProject.Web.DTOs;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Web.ApiServices
{
    public class CategoryApiService
    {
        private readonly HttpClient httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            IEnumerable<CategoryDto> categoryDtos;
            var response = await httpClient.GetAsync("categories");
            if (response.IsSuccessStatusCode)
            {
                categoryDtos = JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>
                                    (await response.Content.ReadAsStringAsync());
            }
            else
            {
                categoryDtos = null;
            }
            return categoryDtos;
        }

        public async Task<CategoryDto> AddAsync(CategoryDto categoryDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(categoryDto),Encoding.UTF8,"application/json");
            var response = await httpClient.PostAsync("categories", stringContent);
            if (response.IsSuccessStatusCode)
            {
                categoryDto = JsonConvert.DeserializeObject<CategoryDto>(await response.Content.ReadAsStringAsync());
                return categoryDto;
            }
            else
            {
                return null;
            }
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var response = await httpClient.GetAsync($"categories/{id}");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<CategoryDto>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Update(CategoryDto categoryDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject
                (categoryDto), Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync("categories", stringContent);
            if (response.IsSuccessStatusCode)
                return true;
                return false;
        }

        public async Task<bool> Remove(int id)
        {
            var response = await httpClient.DeleteAsync($"categories/{id}");
            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }
    }
}
