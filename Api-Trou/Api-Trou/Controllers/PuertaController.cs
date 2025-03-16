using Api_Trou.Models;
using Api_Trou.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api_Trou.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PuertaController : Controller
	{
		private IPuertaCollection db = new PuertaCollection();
		[HttpGet]
		public async Task<IActionResult> GetAllPuertas()
		{
			return Ok(await db.GetAllPuertas());
		}
		[HttpGet("{idP}")]
		public async Task<IActionResult> GetPuertaDetails(string idP)
		{
			return Ok(await db.GetPuertaById(idP));
		}
		[HttpPost]
		public async Task<IActionResult> CreateRegister([FromBody] Puerta puerta)
		{
			if (puerta == null)
				return BadRequest();
			if (puerta.Abierto == string.Empty)
			{
				ModelState.AddModelError("Abierto", "esta vacion");
			}
			await db.InsertPuerta(puerta);
			return Created("Created", true);
		}
		[HttpPut("{idP}")]
		public async Task<IActionResult> UpdatePuerta([FromBody] Puerta puerta, string idP)
		{
			if (puerta == null)
				return BadRequest();
			if (puerta.Abierto == string.Empty)
			{
				ModelState.AddModelError("Abierto", "esta vacion");
			}
			puerta.IdP = new MongoDB.Bson.ObjectId(idP);
			await db.UpdatePuerta(puerta);
			return Created("Created", true);
		}
		[HttpDelete]
		public async Task<IActionResult> DeletePuerta(string idP)
		{
			await db.DeletePuerta(idP);
			return NoContent();

		}
	}
}
