using Refit;
using SistemaDeTarefasWebAPI.Integracao.Response;

namespace SistemaDeTarefasWebAPI.Integracao.Refit
{
    public interface IViaCepIntegracaoRefit
    {
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ViaCepResponse>> ObterDadosViaCep(string cep);   
    }
}
// Esta interface define o contrato para a integração com a API do ViaCep usando Refit.