﻿using MongoDB.Driver;

namespace Api_Trou.Repositories
{
	public class MongoDBrepository
	{
		public MongoClient Client;
		public IMongoDatabase db;
		public MongoDBrepository()
		{
			Client = new MongoClient("mongodb+srv://taniaportillo158:portillo@trou.uvcvb.mongodb.net/");

			db = Client.GetDatabase("TROU");
		}
	}
}
