using MongoDB.Driver;
using UserDataProcessingApi.DataModel;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration config)
    {
        var client = new MongoClient(config["MongoDbSettings:ConnectionString"]);
        _database = client.GetDatabase(config["MongoDbSettings:DatabaseName"]);
    }

    public IMongoCollection<UserData> Users =>
        _database.GetCollection<UserData>("Users");
}