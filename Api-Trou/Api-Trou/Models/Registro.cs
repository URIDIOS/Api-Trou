using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Api_Trou.Models
{
	public class Registro
	{
		[BsonId]
		public ObjectId Id { get; set; }
		public string?  Nombre { get; set; }
		public string? Correo { get; set; }
		public string? Contraseña { get; set; }
	}
}
