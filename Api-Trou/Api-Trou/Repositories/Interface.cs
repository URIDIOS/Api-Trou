using Api_Trou.Models;

namespace Api_Trou.Repositories
{
    public interface Interface
    {
        Task InsertLogin(Login login);
        Task UpdateLogin(Login login);
        Task DeleteLogin(string IdL);

        Task<List<Login>> GetAllLogin();

        Task<Login> GetLoginById(string IdL);
    }
}
