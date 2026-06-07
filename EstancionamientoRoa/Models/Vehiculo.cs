using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace EstancionamientoRoa.Models;
public class Vehiculo
{
[BsonId]
[BsonRepresentation(BsonType.ObjectId)]
public string Id { get; set; }
public string Placa { get; set; }
public string Modelo { get; set; }
public string Color { get; set; }
}