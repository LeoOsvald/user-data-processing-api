using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UserDataProcessingApi.DataModel;
using UserDataProcessingApi.Service;

namespace UJserDataProcessingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class JsonDataController : ControllerBase
    {
     
        private readonly IDataService _dataService;
        private readonly ILogger<JsonDataController> _logger;

        public JsonDataController(IDataService dataService, ILogger<JsonDataController> logger)
        {
            _dataService = dataService;
            _logger = logger;
        }
        /// <summary>
        /// Importa um arquivo JSON contendo uma lista de usuários e persiste os dados no MongoDB.
        /// </summary>
        /// <param name="file">Arquivo JSON enviado via form-data.</param>
        /// <returns>Retorna status 200 caso o processamento seja concluído com sucesso.</returns>
        /// <response code="200">Arquivo processado com sucesso</response>
        /// <response code="400">Arquivo inválido ou não enviado</response>
        [HttpPost]
        public async Task<IActionResult> ImportJsonData(IFormFile file)
        {
            await _dataService.ProcessUserDataAsync(file);

            return Ok();
        }

        /// <summary>
        /// Retorna um usuário específico com base no identificador informado.
        /// </summary>
        /// <param name="id">Identificador único do usuário.</param>
        /// <returns>Objeto do usuário correspondente ao ID.</returns>
        /// <response code="200">Usuário encontrado</response>
        /// <response code="404">Usuário não encontrado</response>
        [HttpGet]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _dataService.GetUserDataById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
