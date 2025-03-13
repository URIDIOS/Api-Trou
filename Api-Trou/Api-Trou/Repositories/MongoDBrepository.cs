using MongoDB.Driver;

namespace Api_Trou.Repositories
{
	public class MongoDBrepository
	{
		public MongoClient Client;
		public IMongoDatabase db;
		public MongoDBrepository()
		{
			Client = new MongoClient("Cadena de conección");

			db = Client.GetDatabase("Base de datos");
		}
	}
}
