using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefasWebAPI.Integracao.Interfaces;
using SistemaDeTarefasWebAPI.Integracao.Response;

namespace SistemaDeTarefasWebAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IViaCepIntegracao _viaCepIntegracao;

        public CepController(IViaCepIntegracao viaCepIntegracao)
        {
            _viaCepIntegracao = viaCepIntegracao;
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<ViaCepResponse>> ListarDadosEndereco(string cep)
        {
            var dadosCep = await _viaCepIntegracao.ObterDadosViaCep(cep);
            if (dadosCep == null)
            {
                return NotFound("CEP não encontrado.");
            }
            return Ok(dadosCep);
        }
    }
}
