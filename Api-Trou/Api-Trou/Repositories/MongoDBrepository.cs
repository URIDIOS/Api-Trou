using MongoDB.Driver;

namespace Api_Trou.Repositories
{
	public class MongoDBrepository
	{
		public MongoClient Client;
		public IMongoDatabase db;
		public MongoDBrepository()
		{
			//mongodb+srv://taniaportillo158:portillo@trou.uvcvb.mongodb.net/
			//mongodb+srv://areneflores10:angel123@database.gld6ooz.mongodb.net/

			Client = new MongoClient("mongodb+srv://taniaportillo158:portillo@trou.uvcvb.mongodb.net/?retryWrites=true&w=majority&appName=TROU");

			db = Client.GetDatabase("TROU");
		}
	}
}
