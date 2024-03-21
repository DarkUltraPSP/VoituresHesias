using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voitures.Shared.Data;
using Voitures.Shared.Entity;

namespace Voitures.Shared.Services
{
    public class EntretienService : IEntretienService
    {
        private readonly DataContext _context;

        public EntretienService(DataContext context)
        {
            _context = context;
        }

        public async Task<Entretien> AddEntretien(int voitureId, Entretien entretien)
        {
            var voiture = await _context.Voitures.FindAsync(voitureId);
            if (voiture == null)
            {
                throw new InvalidOperationException("Invalid Voiture ID.");
            }

            entretien.VoitureId = voitureId;
            _context.Entretiens.Add(entretien);
            await _context.SaveChangesAsync();
            return entretien;
        }

        public async Task<Entretien> UpdateEntretien(int id, Entretien entretien)
        {
            var existingEntretien = await _context.Entretiens.FindAsync(id);
            if (existingEntretien == null)
            {
                throw new InvalidOperationException("Entretien not found.");
            }

            existingEntretien.Kilometrage = entretien.Kilometrage;
            existingEntretien.DescritionEntretien = entretien.DescritionEntretien;

            await _context.SaveChangesAsync();
            return existingEntretien;
        }

        public async Task<bool> DeleteEntretien(int id)
        {
            var entretienToDelete = await _context.Entretiens.FindAsync(id);
            if (entretienToDelete == null)
            {
                throw new InvalidOperationException("Entretien not found.");
            }

            _context.Entretiens.Remove(entretienToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Entretien> GetEntretienByVoitureId(int id)
        {
            var entretien = await _context.Entretiens.FirstOrDefaultAsync(e => e.VoitureId == id);
            if (entretien == null)
            {
                throw new InvalidOperationException("Entretien not found.");
            }
            return entretien;
        }

        public async Task<List<Entretien>> GetEntretiensByVoitureId(int id)
        {
            return await _context.Entretiens.Where(e => e.VoitureId == id)
                .OrderByDescending(e => e.Kilometrage)
                .ToListAsync();
        }

        public async Task<Entretien> GetEntretien(int id)
        {
            return await _context.Entretiens.FindAsync(id);
        }
    }
}
