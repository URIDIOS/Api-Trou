using Api_Trou.Models;

namespace Api_Trou.Repositories
{
	public interface IProductCollection
	{
		Task InsertRegistro(Registro registro);
		Task UpdateRegistro(Registro registro);
		Task DeleteRegistro(string Id);

		Task<List<Registro>> GetAllRegistros();

		Task<Registro> GetRegistroById(string Id);	


	}
}
