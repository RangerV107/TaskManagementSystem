using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TaskManager.API.DTO;

namespace TaskManager.Client.Services
{
    public class TaskTypeService
    {
        public HttpClient _httpClient;

        public TaskTypeService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<List<TaskTypeDTO>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("api/TaskTypes");
            response.EnsureSuccessStatusCode();
            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<List<TaskTypeDTO>>(responseContent);
        }

        public async Task<TaskTypeDTO> GetOnIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"api/TaskTypes/{id}");
            response.EnsureSuccessStatusCode();
            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<TaskTypeDTO>(responseContent);
        }

        public async Task<HttpResponseMessage> PostAsync(TaskTypeDTO taskTypesDTO)
        {
            var json = JsonSerializer.Serialize<TaskTypeDTO>(taskTypesDTO);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync("api/TaskTypes", content);
        }

        public async Task<HttpResponseMessage> PutAsync(TaskTypeDTO taskTypesDTO)
        {
            var json = JsonSerializer.Serialize<TaskTypeDTO>(taskTypesDTO);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PutAsync($"api/TaskTypes/{taskTypesDTO.Id}", content);
        }

        public async Task<HttpResponseMessage> DeleteAsync(Guid id)
        {
            return await _httpClient.DeleteAsync($"api/TaskTypes/{id}");
        }
    }

}
