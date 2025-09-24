using Microsoft.EntityFrameworkCore;
using SistemaDeTarefasWebAPI.Data;
using SistemaDeTarefasWebAPI.Models;
using SistemaDeTarefasWebAPI.Repositorios.Interfaces;

namespace SistemaDeTarefasWebAPI.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly MeuDbContext _meuDbContext;

        public UsuarioRepositorio(MeuDbContext meuDbContext)
        {
            _meuDbContext = meuDbContext;
        }
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _meuDbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _meuDbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
             _meuDbContext.Usuarios.Add(usuario);
            await _meuDbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuarioModel, int id)
        {
           UsuarioModel usuarioNoBanco = await BuscarPorId(id);
           
            if (usuarioNoBanco == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }
            usuarioNoBanco.Id = id;
            usuarioNoBanco.Nome = usuarioModel.Nome;
            usuarioNoBanco.Email = usuarioModel.Email;

            _meuDbContext.Usuarios.Update(usuarioNoBanco);
            await _meuDbContext.SaveChangesAsync();
            return usuarioNoBanco;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            _meuDbContext.Usuarios.Remove(usuarioPorId);
            await _meuDbContext.SaveChangesAsync();
            return true;
        }
    }
}
