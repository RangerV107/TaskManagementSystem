using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TaskManager.API.DTO;

namespace TaskManager.Client.Services
{
    public class InDocumentService
    {
        public HttpClient _httpClient;

        public InDocumentService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<List<InDocumentDTO>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("api/InDocuments");
            response.EnsureSuccessStatusCode();
            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<List<InDocumentDTO>>(responseContent);
        }

        public async Task<InDocumentDTO> GetOnIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"api/InDocuments/{id}");
            response.EnsureSuccessStatusCode();
            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<InDocumentDTO>(responseContent);
        }

        public async Task<HttpResponseMessage> PostAsync(InDocumentDTO inDocumentsDTO)
        {
            var json = JsonSerializer.Serialize<InDocumentDTO>(inDocumentsDTO);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync("api/InDocuments", content);
        }

        public async Task<HttpResponseMessage> PutAsync(InDocumentDTO inDocumentsDTO)
        {
            var json = JsonSerializer.Serialize<InDocumentDTO>(inDocumentsDTO);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PutAsync($"api/InDocuments/{inDocumentsDTO.Id}", content);
        }

        public async Task<HttpResponseMessage> DeleteAsync(Guid id)
        {
            return await _httpClient.DeleteAsync($"api/InDocuments/{id}");
        }
    }

}
