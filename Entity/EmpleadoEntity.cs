using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EmpleadoEntity : DBEntity
    {
        public EmpleadoEntity()
        {
            Id = Id ?? new TipoIdentificacionEntity();
        }
        public int? IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int? Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int? TipoIdentificacion { get; set; }
        public virtual TipoIdentificacionEntity Id { get; set; }
        public string Identificacion => Id?.Identificacion;
    }
}
