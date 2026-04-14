using System.Text.Json;
using UserDataProcessingApi.DataModel;

namespace UserDataProcessingApi.Service
{
    public class DataService : IDataService
    {
        private readonly UserRepository userRepository;

        public DataService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<IEnumerable<UserData>> ProcessUserDataAsync(IFormFile file)
        {
            using var reader = new StreamReader(file.OpenReadStream());
            var json = await reader.ReadToEndAsync();

            // aqui você pode desserializar o JSON
            var obj = JsonSerializer.Deserialize<List<UserData>>(json);


            await userRepository.InsertManyAsync(obj);

            return obj;
        }

        public async Task<UserData> GetUserDataById(string id)
        {
            var user = await userRepository.GetByIdAsync(id);

            return user;
        }
    }
}
