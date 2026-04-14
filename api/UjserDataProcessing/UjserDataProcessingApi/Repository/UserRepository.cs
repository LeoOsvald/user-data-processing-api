using MongoDB.Bson;
using MongoDB.Driver;
using UserDataProcessingApi.DataModel;

public class UserRepository
{
    private readonly IMongoCollection<UserData> _collection;

    public UserRepository(MongoDbContext context)
    {
        _collection = context.Users;
    }

    public async Task InsertManyAsync(List<UserData> users)
    {
        await _collection.InsertManyAsync(users);
    }


    public async Task<UserData> GetByIdAsync(string id)
    {
        var filter = Builders<UserData>.Filter.Eq("_id", id);

        return await _collection.Find(filter).FirstOrDefaultAsync();
    }
}