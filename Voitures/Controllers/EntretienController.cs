using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Voitures.Shared.Entity;
using Voitures.Shared.Services;

namespace Voitures.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntretienController : ControllerBase
    {
        private readonly IEntretienService _entretienService;

        public EntretienController(IEntretienService entretienService)
        {
            _entretienService = entretienService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Entretien>>> GetEntretiensByVoitureId(int id)
        {
            var entretiens = await _entretienService.GetEntretiensByVoitureId(id);
            return Ok(entretiens);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<Entretien>> AddEntretien(int id, Entretien entretien)
        {
            var newEntretien = await _entretienService.AddEntretien(id, entretien);
            return Ok(newEntretien);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Entretien>> UpdateEntretien(int id, Entretien entretien)
        {
            var updatedEntretien = await _entretienService.UpdateEntretien(id, entretien);
            return Ok(updatedEntretien);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteEntretien(int id)
        {
            var result = await _entretienService.DeleteEntretien(id);
            return Ok(result);
        }

        [HttpGet("{id}/entretien/{entretienId}")]
        public async Task<ActionResult<Entretien>> GetEntretien(int id)
        {
            var entretien = await _entretienService.GetEntretien(id);
            return Ok(entretien);
        }
    }
}
