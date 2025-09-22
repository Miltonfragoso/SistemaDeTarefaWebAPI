using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefasWebAPI.Models;
using SistemaDeTarefasWebAPI.Repositorios.Interfaces;
using System.Collections.Generic;

namespace SistemaDeTarefasWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            UsuarioModel usuarios = await _usuarioRepositorio.BuscarPorId(id);
            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<ActionResult<List<UsuarioModel>>> Cadastrar([FromBody] UsuarioModel usuario)
        {
            UsuarioModel Usuario = await _usuarioRepositorio.Adicionar(usuario);
            return Ok(Usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<UsuarioModel>>> Atualizar([FromBody] UsuarioModel usuario, int id)
        {
            usuario.Id = id;
            UsuarioModel Usuario = await _usuarioRepositorio.Atualizar(usuario, id);
            return Ok(Usuario);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UsuarioModel>>> Apagar(int id)
        {
            
            bool  Usuario = await _usuarioRepositorio.Apagar(id);
            return Ok(Usuario);
        }
    }
}
