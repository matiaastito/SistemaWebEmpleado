using System.ComponentModel.DataAnnotations;
using SistemaWebEmpleado.Validaciones;

namespace SistemaWebEmpleado.Models
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Dni { get; set; }
        [Required]
        [CheckValidLegajo]
        public string Legajo { get; set; }
        [Required]
        public string Titulo { get; set; }

    }
}
