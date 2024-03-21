using Voitures.Shared.Entity;

namespace Voitures.Shared.Services
{
    public interface IVoitureService
    {
        Task<List<Voiture>> GetVoitures();
        Task<Voiture> GetVoiture(int id);
        Task<List<Voiture>> GetOverdueVoitures(int id);
        Task<Voiture> AddVoiture(Voiture voiture);
        Task<Voiture> UpdateVoiture(int id, Voiture voiture);
        Task<bool> DeleteVoiture(int id);
    }
}
