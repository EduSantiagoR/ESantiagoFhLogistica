using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class UsuarioEquipo
    {
        public Usuario Usuario { get; set; }
        public Equipo Equipo { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public List<object> EquiposAsignados { get; set; }
    }
}
