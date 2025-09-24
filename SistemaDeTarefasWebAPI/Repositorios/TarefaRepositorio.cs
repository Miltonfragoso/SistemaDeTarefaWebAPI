using Microsoft.EntityFrameworkCore;
using SistemaDeTarefasWebAPI.Data;
using SistemaDeTarefasWebAPI.Models;
using SistemaDeTarefasWebAPI.Repositorios.Interfaces;

namespace SistemaDeTarefasWebAPI.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly MeuDbContext _meuDbContext;

        public TarefaRepositorio(MeuDbContext meuDbContext)
        {
            _meuDbContext = meuDbContext;
        }
        public async Task<TarefaModel> BuscarPorId(int id)
        {
            return await _meuDbContext.Tarefas
                                      .Include(t => t.Usuario)
                                      .FirstOrDefaultAsync(t => t.Id == id);

            
        }

        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            var result =  await _meuDbContext.Tarefas
                                      .Include(t => t.Usuario)   
                                      .ToListAsync();

            if (result == null)
                throw new Exception("A lista de tarefas está vazia");
           
            else
                return result;


        }

        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
             _meuDbContext.Tarefas.Add(tarefa);
            await _meuDbContext.SaveChangesAsync();

            return tarefa;
        }

        public async Task<TarefaModel> Atualizar(TarefaModel tarefaModel, int id)
        {
            TarefaModel tarefaNoBanco = await BuscarPorId(id);
           
            if (tarefaNoBanco == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrado no banco de dados.");
            }
            tarefaNoBanco.Nome = tarefaModel.Nome;
            tarefaNoBanco.Descricao = tarefaModel.Descricao;
            tarefaNoBanco.Status = tarefaModel.Status;
            tarefaNoBanco.UsuarioId = tarefaModel.UsuarioId;


            _meuDbContext.Tarefas.Update(tarefaNoBanco);
            await _meuDbContext.SaveChangesAsync();
            return tarefaNoBanco;
        }

        public async Task<bool> Apagar(int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);

            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrado no banco de dados.");
            }

            _meuDbContext.Tarefas.Remove(tarefaPorId);
            await _meuDbContext.SaveChangesAsync();
            return true;
        }
    }
}
