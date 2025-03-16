using Api_Trou.Models;

namespace Api_Trou.Repositories
{
	public interface IPuertaCollection
	{
		Task InsertPuerta(Puerta puerta);
		Task UpdatePuerta(Puerta puerta);
		Task DeletePuerta(string IdP);

		Task<List<Puerta>> GetAllPuertas();

		Task<Puerta> GetPuertaById(string IdP);
	}
}
