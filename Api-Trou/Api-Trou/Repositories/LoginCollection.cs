using Api_Trou.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Api_Trou.Repositories
{
    public class LoginCollection : Interface
    {
        internal MongoDBrepository _repositoryp = new MongoDBrepository();
        private IMongoCollection<Login> _Logincollection;

        public LoginCollection()
        {
            _Logincollection = _repositoryp.db.GetCollection<Login>("Login");
        }
        public async Task DeleteLogin(string IdL)
        {
            var filter = Builders<Login>.Filter.Eq(s => s.IdL, new ObjectId(IdL));
            await _Logincollection.DeleteManyAsync(filter);
        }
        public async Task<List<Login>> GetAllLogin()
        {
            return await _Logincollection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }
        public async Task<Login> GetLoginById(string IdL)
        {
            return await _Logincollection.FindAsync(new BsonDocument { { "_id", new ObjectId(IdL) } }).Result.FirstAsync();
        }
        public async Task InsertLogin(Login login)
        {
            await _Logincollection.InsertOneAsync(login);
        }
        public async Task UpdateLogin(Login login)
        {
            var filter = Builders<Login>.Filter.Eq(s => s.IdL, login.IdL);

            await _Logincollection.ReplaceOneAsync(filter, login);
        }
    }
}
