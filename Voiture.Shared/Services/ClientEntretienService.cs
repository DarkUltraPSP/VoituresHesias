using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Voitures.Shared.Entity;

namespace Voitures.Shared.Services
{
    public class ClientEntretienService : IEntretienService
    {
        private readonly HttpClient _httpClient;

        public ClientEntretienService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Entretien>> GetEntretiensByVoitureId(int id)
        {
            var response = await _httpClient.GetAsync($"api/voiture/{id}/entretien");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Entretien>>();
            }
            else
            {
                throw new Exception($"Error fetching entretiens for voiture with ID {id}. Status code: {response.StatusCode}");
            }
        }

        public async Task<Entretien> AddEntretien(int id, Entretien entretien)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/voiture/{id}/entretien", entretien);
            return await result.Content.ReadFromJsonAsync<Entretien>();
        }

        public async Task<bool> DeleteEntretien(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/entretien/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<Entretien> UpdateEntretien(int id, Entretien entretien)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/entretien/{id}", entretien);
            return await result.Content.ReadFromJsonAsync<Entretien>();
        }

        public async Task<Entretien> GetEntretien(int id)
        {
            var response = await _httpClient.GetAsync($"api/entretien/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Entretien>();
            }
            else
            {
                throw new Exception($"Error fetching entretien with ID {id}. Status code: {response.StatusCode}");
            }
        }
    }
}
