using Api_Trou.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Api_Trou.Repositories
{
    public class RegistroCollection : IProductCollection
    {
        internal MongoDBrepository _repository = new MongoDBrepository();
        private IMongoCollection<Registro> _collection;

        public RegistroCollection()
        {
            _collection = _repository.db.GetCollection<Registro>("Registro");
        }

        public async Task DeleteRegistro(string Id)
        {
            var filter = Builders<Registro>.Filter.Eq(s => s.Id, new ObjectId(Id));
            await _collection.DeleteManyAsync(filter);
        }

        public async Task<List<Registro>> GetAllRegistros()
        {
            return await _collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Registro> GetRegistroById(string Id)
        {
            return await _collection.FindAsync(new BsonDocument { { "_id", new ObjectId(Id) } }).Result.FirstAsync();
        }

        public async Task InsertRegistro(Registro registro)
        {
            await _collection.InsertOneAsync(registro);
        }

        public async Task UpdateRegistro(Registro registro)
        {
            var filter = Builders<Registro>.Filter.Eq(s => s.Id, registro.Id);

            await _collection.ReplaceOneAsync(filter, registro);
        }
    }
}
