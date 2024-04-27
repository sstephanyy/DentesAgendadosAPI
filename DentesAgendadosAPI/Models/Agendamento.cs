using DentesAgendadosAPI.Enums;
using System.Text.Json.Serialization;

namespace DentesAgendadosAPI.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateTime DataConsulta { get; set; }
        public string NomePaciente { get; set; }
        public string NomeDentista { get; set; }
        public string NumeroPaciente { get; set; }
        // Tipo de consulta (consulta de rotina, tratamento específico, limpeza, etc.)
        public string TipoConsulta { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))] // Serialize enum as string
        public StatusEnum Status { get; set; }

    }
}
