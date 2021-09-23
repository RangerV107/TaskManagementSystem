using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TaskManager.API.DTO;

namespace TaskManager.Client.Services
{
    public class ProductionTaskService
    {
        public HttpClient _httpClient;

        public ProductionTaskService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<List<ProductionTaskDTO>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("api/ProductionTasks");
            response.EnsureSuccessStatusCode();
            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<List<ProductionTaskDTO>>(responseContent);
        }

        public async Task<ProductionTaskDTO> GetOnIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"api/ProductionTasks/{id}");
            response.EnsureSuccessStatusCode();
            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<ProductionTaskDTO>(responseContent);
        }

        public async Task<HttpResponseMessage> PostAsync(ProductionTaskDTO productionTaskDTO)
        {
            var json = JsonSerializer.Serialize<ProductionTaskDTO>(productionTaskDTO);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync("api/ProductionTasks", content);
        }

        public async Task<HttpResponseMessage> PutAsync(ProductionTaskDTO productionTaskDTO)
        {
            var json = JsonSerializer.Serialize<ProductionTaskDTO>(productionTaskDTO);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PutAsync($"api/ProductionTasks/{productionTaskDTO.Id}", content);
        }

        public async Task<HttpResponseMessage> DeleteAsync(Guid id)
        {
            return await _httpClient.DeleteAsync($"api/ProductionTasks/{id}");
        }
    }

}
