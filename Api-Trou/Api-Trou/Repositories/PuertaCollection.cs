using Api_Trou.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Api_Trou.Repositories
{
	public class PuertaCollection : IPuertaCollection
	{
		internal MongoDBrepository _repositoryp = new MongoDBrepository();
		private IMongoCollection<Puerta> _Puertacollection;

		public PuertaCollection()
		{
			_Puertacollection = _repositoryp.db.GetCollection<Puerta>("Puerta");
		}
		public async Task DeletePuerta(string IdP)
		{
			var filter = Builders<Puerta>.Filter.Eq(s => s.IdP, new ObjectId(IdP));
			await _Puertacollection.DeleteManyAsync(filter);
		}
		public async Task<List<Puerta>> GetAllPuertas()
		{
			return await _Puertacollection.FindAsync(new BsonDocument()).Result.ToListAsync();
		}
		public async Task<Puerta> GetPuertaById(string IdP)
		{
			return await _Puertacollection.FindAsync(new BsonDocument { { "_id", new ObjectId(IdP) } }).Result.FirstAsync();
		}
		public async Task InsertPuerta(Puerta puerta)
		{
			await _Puertacollection.InsertOneAsync(puerta);
		}
		public async Task UpdatePuerta(Puerta puerta)
		{
			var filter = Builders<Puerta>.Filter.Eq(s => s.IdP, puerta.IdP);

			await _Puertacollection.ReplaceOneAsync(filter, puerta);
		}
	}
}
