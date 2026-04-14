using UserDataProcessingApi.DataModel;

namespace UserDataProcessingApi.Service
{
    public interface IDataService
    {
        Task<IEnumerable<UserData>> ProcessUserDataAsync(IFormFile file);

        Task<UserData> GetUserDataById(string id);

    }
}
