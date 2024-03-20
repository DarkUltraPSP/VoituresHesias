using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voitures.Shared.Entity;

namespace Voitures.Shared.Services
{
    public interface IEntretienService
    {
        Task<List<Entretien>> GetEntretiensByVoitureId(int id);
        Task<Entretien> GetEntretien(int id);
        Task<Entretien> AddEntretien(int id, Entretien entretien);
        Task<Entretien> UpdateEntretien(int id, Entretien entretien);
        Task<bool> DeleteEntretien(int id);
    }
}
