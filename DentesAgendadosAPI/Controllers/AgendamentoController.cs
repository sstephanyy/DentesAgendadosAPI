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

        private readonly DataContext _context;

        public AgendamentoController(DataContext context)
        {
            _context = context;  
        }


        [HttpGet]
        public async Task<IActionResult> PegarTodasConsultas()
        {
            return Ok(await _context.Agendamentos.ToListAsync());

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> PegarConsulta(int id)
        {
            var consulta = await _context.Agendamentos.FirstOrDefaultAsync(x => x.Id == id);

            if (consulta == null)
            {
                return NotFound("Desculpa, mas essa consulta ainda não existe!!");
            }
            return Ok(consulta);

        }

        [HttpPost]
        public async Task<IActionResult> CriarConsulta(Agendamento consulta)
        {
            _context.Agendamentos.Add(consulta);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarConsulta(int id, Agendamento request)
        {
            var consulta = await _context.Agendamentos.FindAsync(id);
            if (consulta == null)
            {
                return NotFound("Desculpa, mas essa consulta ainda não existe!!");
            }

            consulta.NomeDentista = request.NomeDentista;
            consulta.NomePaciente = request.NomePaciente;
            consulta.TipoConsulta = request.TipoConsulta;
            consulta.Status = request.Status;
            consulta.DataConsulta = request.DataConsulta;

            await _context.SaveChangesAsync();

            return Ok(consulta);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarConsulta(int id)
        {
            var consulta = await _context.Agendamentos.FirstOrDefaultAsync(x => x.Id == id);

            if (consulta == null)
            {
                return NotFound("Desculpa, mas essa consulta ainda não existe!!");
            }

            _context.Agendamentos.Remove(consulta);
            await _context.SaveChangesAsync();

            return NoContent();

        }

    }
}
