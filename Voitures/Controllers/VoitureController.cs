using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Voitures.Shared.Entity;
using Voitures.Shared.Services;

namespace Voitures.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class VoitureController : ControllerBase
	{
		private readonly IVoitureService _voitureService;

		public VoitureController(IVoitureService voitureService)
		{
			_voitureService = voitureService;
		}

		[HttpGet]
		public async Task<ActionResult<List<Voiture>>> GetVoitures()
		{
			var voitures = await _voitureService.GetVoitures();
			return Ok(voitures);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Voiture>> GetVoiture(int id)
		{
			var voiture = await _voitureService.GetVoiture(id);
			return Ok(voiture);
		}

		[HttpGet("{id}/overdue")]
		public async Task<ActionResult<Voiture>> GetOverdueVoitures(int id)
		{
            var voiture = await _voitureService.GetOverdueVoitures(id);
            return Ok(voiture);
        }

		[HttpPost]
		public async Task<ActionResult<Voiture>> AddVoiture(Voiture voiture)
		{
			var newVoiture = await _voitureService.AddVoiture(voiture);
			return Ok(newVoiture);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Voiture>> UpdateVoiture(int id, Voiture voiture)
		{
			var updatedVoiture = await _voitureService.UpdateVoiture(id, voiture);
			return Ok(updatedVoiture);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<bool>> DeleteVoiture(int id)
		{
			var deletedVoiture = await _voitureService.DeleteVoiture(id);
			return Ok(deletedVoiture);
		}
	}
}
