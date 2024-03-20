using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Voitures.Shared.Entity;

namespace Voitures.Shared.Services
{

    public class ClientVoitureService : IVoitureService
    {
        private readonly HttpClient _httpClient;

        public ClientVoitureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Voiture?> AddVoiture(Voiture voiture)
        {
            var result = await _httpClient.PostAsJsonAsync("api/voiture", voiture);
            return await result.Content.ReadFromJsonAsync<Voiture>();
        }

        public async Task<bool> DeleteEntretien(int id, int entretienId)
        {
            var result = await _httpClient.DeleteAsync($"api/voiture/{id}/entretien/{entretienId}");
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteVoiture(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/voiture/{id}");
            return result.IsSuccessStatusCode;
        }

        public async Task<Voiture> GetVoiture(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Voiture>($"api/voiture/{id}");
            if (result == null)
            {
                throw new Exception("Voiture not found");
            }
            return result;
        }

        public Task<List<Voiture>> GetVoitures()
        {
            throw new NotImplementedException();
        }

        public Task<Voiture> UpdateEntretien(int id, Entretien entretien)
        {
            var result = _httpClient.PutAsJsonAsync($"api/voiture/{id}/entretien", entretien);
            return result.Result.Content.ReadFromJsonAsync<Voiture>();
        }

        public async Task<Voiture> UpdateVoiture(int id, Voiture voiture)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/voiture/{id}", voiture);
            return result.Content.ReadFromJsonAsync<Voiture>().Result;
        }
    }
}
