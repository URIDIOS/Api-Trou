using Api_Trou.Models;
using Api_Trou.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api_Trou.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController : Controller
    {
        private IProductCollection db = new RegistroCollection();
        [HttpGet]
        public async Task<IActionResult> GetAllRegistro()
        {
            return Ok(await db.GetAllRegistros());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistroDetails(string id)
        {
            return Ok(await db.GetRegistroById(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateRegister([FromBody] Registro registro)
        {
            if (registro == null)
                return BadRequest();
            if (registro.Nombre == string.Empty)
            {
                ModelState.AddModelError("Nombre", "esta vacion");
            }
            await db.InsertRegistro(registro);
            return Created("Created", true);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegistro([FromBody] Registro registro, string id)
        {
            if (registro == null)
                return BadRequest();
            if (registro.Nombre == string.Empty)
            {
                ModelState.AddModelError("Nombre", "esta vacio");
            }
            registro.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateRegistro(registro);
            return Created("Created", true);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRegistro(string id)
        {
            await db.DeleteRegistro(id);
            return NoContent();

        }
    }
}