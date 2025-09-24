using SistemaDeTarefasWebAPI.Integracao.Response;

namespace SistemaDeTarefasWebAPI.Integracao.Interfaces
{
    public interface IViaCepIntegracao
    {
        Task<ViaCepResponse?> ObterDadosViaCep(string cep);
    }
}

//Este método é responsável por buscar os dados do endereço correspondente ao CEP fornecido,
//retornando um objeto ViaCepResponse que contém as informações do endereço, ou null se o CEP não for encontrado ou ocorrer algum erro na requisição.