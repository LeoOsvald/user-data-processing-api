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

            try
            {
                using var reader = new StreamReader(file.OpenReadStream());
                var json = await reader.ReadToEndAsync();

                var obj = JsonSerializer.Deserialize<List<UserData>>(json);


                await userRepository.InsertManyAsync(obj);

                return obj;
            }
            catch (Exception ex )
            {

                throw ex;
            }

        }

        public async Task<UserData> GetUserDataById(string id)
        {

            try
            {
                var user = await userRepository.GetByIdAsync(id);

                return user;
            }
            catch (Exception ex )
            {

                throw ex;
            }

        }
    }
}
