using DentesAgendadosAPI.Core.IRepositories;
using DentesAgendadosAPI.Data;
using DentesAgendadosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DentesAgendadosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {

        private readonly IUnitOfWork _unityOfWork;

        public AgendamentoController(IUnitOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;   
        }


        [HttpGet]
        public async Task<IActionResult> PegarTodasConsultas()
        {
            return Ok(await _unityOfWork.Agendamentos.PegarTodos());

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> PegarConsulta(int id)
        {
            var consulta = await _unityOfWork.Agendamentos.PegarPorId(id);

            if (consulta == null)
            {
                return NotFound("Desculpa, mas essa consulta ainda não existe!!");
            }
            return Ok(consulta);

        }

        [HttpPost]
        public async Task<IActionResult> CriarConsulta(Agendamento consulta)
        {
            await _unityOfWork.Agendamentos.Adicionar(consulta);
            await _unityOfWork.CompleteAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarConsulta(int id, Agendamento request)
        {
            var consulta = await _unityOfWork.Agendamentos.PegarPorId(id);
            if (consulta == null)
            {
                return NotFound("Desculpa, mas essa consulta ainda não existe!!");
            }

            await _unityOfWork.Agendamentos.Atualizar(request);
            await _unityOfWork.CompleteAsync();

            return Ok(consulta);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarConsulta(int id)
        {
            var consulta = await _unityOfWork.Agendamentos.PegarPorId(id);

            if (consulta == null)
            {
                return NotFound("Desculpa, mas essa consulta ainda não existe!!");
            }

            await _unityOfWork.Agendamentos.Deletar(id);
            await _unityOfWork.CompleteAsync();

            return NoContent();

        }

    }
}
