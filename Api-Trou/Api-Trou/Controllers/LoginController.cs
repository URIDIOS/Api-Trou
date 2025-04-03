using Api_Trou.Models;
using Api_Trou.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api_Trou.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private Interface db = new LoginCollection();
        [HttpGet]
        public async Task<IActionResult> GetAllLogin()
        {
            return Ok(await db.GetAllLogin());
        }
        [HttpGet("{idL}")]
        public async Task<IActionResult> GetLoginDetails(string idL)
        {
            return Ok(await db.GetLoginById(idL));
        }
        [HttpPost]
        public async Task<IActionResult> CreateRegister([FromBody] Login login)
        {
            if (login == null)
                return BadRequest();
            if (login.Nombre == string.Empty)
            {
                ModelState.AddModelError("Nombre", "esta vacion");
            }
            await db.InsertLogin(login);
            return Created("Created", true);
        }
        [HttpPut("{idL}")]
        public async Task<IActionResult> UpdateLogin([FromBody] Login login, string idL)
        {
            if (login == null)
                return BadRequest();
            if (login.Nombre == string.Empty)
            {
                ModelState.AddModelError("Nombre", "esta vacion");
            }
            login.IdL = new MongoDB.Bson.ObjectId(idL);
            await db.UpdateLogin(login);
            return Created("Created", true);
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePuerta(string idL)
        {
            await db.DeleteLogin(idL);
            return NoContent();

        }
    }
}
