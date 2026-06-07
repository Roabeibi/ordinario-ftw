using MongoDB.Driver;
using EstancionamientoRoa.Models;
namespace EstancionamientoRoa.Data;
public class MongoDBContext
{
private readonly IMongoDatabase database;

public MongoDBContext()
{
var client =
new MongoClient(
"mongodb://localhost:27017");
database =
client.GetDatabase("EstancionamientoDB");
}
public IMongoCollection<Vehiculo> Vehiculos =>
database.GetCollection<Vehiculo>("Vehiculos");
}