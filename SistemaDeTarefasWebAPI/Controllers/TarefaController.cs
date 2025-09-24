using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefasWebAPI.Models;
using SistemaDeTarefasWebAPI.Repositorios;
using SistemaDeTarefasWebAPI.Repositorios.Interfaces;
using System.Collections.Generic;

namespace SistemaDeTarefasWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : Controller
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;

        public TarefaController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> ListarTodas()
        {
            List<TarefaModel> tarefas = await _tarefaRepositorio.BuscarTodasTarefas();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> BuscarPorId(int id)
        {
            TarefaModel tarefas = await _tarefaRepositorio.BuscarPorId(id);
            return Ok(tarefas);
        }

        [HttpPost]
        public async Task<ActionResult<List<TarefaModel>>> Cadastrar([FromBody] TarefaModel tarefaModel)
        {
            TarefaModel tarefa = await _tarefaRepositorio.Adicionar(tarefaModel);
            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<TarefaModel>>> Atualizar([FromBody] TarefaModel tarefaModel, int id)
        {
            tarefaModel.Id = id;
            TarefaModel tarefa = await _tarefaRepositorio.Atualizar(tarefaModel, id);
            return Ok(tarefa);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TarefaModel>>> Apagar(int id)
        {
            
            bool  tarefa = await _tarefaRepositorio.Apagar(id);
            return Ok(tarefa);
        }
    }
}
