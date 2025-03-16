using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Api_Trou.Models
{
	public class Puerta
	{
		[BsonId]
		public ObjectId IdP { get; set; }
		public string? Abierto { get; set; }
		public string? Cerrado { get; set; }
	}
}
