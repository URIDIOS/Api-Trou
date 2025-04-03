using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Api_Trou.Models
{
    public class Login
    {
        [BsonId]
        public ObjectId IdL { get; set; }
        public string? Nombre { get; set; }
        public string? Contraseña { get; set; }
    }
}
