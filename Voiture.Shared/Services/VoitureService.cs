using Voitures.Shared.Entity;
using Voitures.Shared.Data;
using Microsoft.EntityFrameworkCore;

namespace Voitures.Shared.Services
{
    public class VoitureService : IVoitureService
    {
        private readonly DataContext _context;

        public VoitureService(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteVoiture(int id)
        {
            var voiture = await _context.Voitures.FindAsync(id);
            if (voiture != null)
            {
                _context.Voitures.Remove(voiture);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Voiture> GetVoiture(int id)
        {
            return await _context.Voitures.FindAsync(id);
        }

        public async Task<List<Voiture>> GetVoitures()
        {
            var voitures = await _context.Voitures.ToListAsync();
            return voitures;
        }

        public async Task<Voiture> UpdateVoiture(int id, Voiture voiture)
        {
            var existingVoiture = await _context.Voitures.FindAsync(id);
            if (existingVoiture != null)
            {
                existingVoiture.Marque = voiture.Marque;
                existingVoiture.Modele = voiture.Modele;
                existingVoiture.Annee = voiture.Annee;
                existingVoiture.Energie = voiture.Energie;
                existingVoiture.Immatriculation = voiture.Immatriculation;
                existingVoiture.Kilometrage = voiture.Kilometrage;
                await _context.SaveChangesAsync();
                return existingVoiture;
            }
            throw new Exception("Voiture not found");
        }

        async Task<Voiture> IVoitureService.AddVoiture(Voiture voiture)
        {
            _context.Voitures.Add(voiture);
            await _context.SaveChangesAsync();

            return voiture;
        }
    }
}
