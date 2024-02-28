using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Equipo
    {
        public int IdEquipo { get; set; }
        public string Modelo { get; set; }
        public string ClaveInventario { get; set; }
        public Tipo Tipo { get; set; }
        public Marca Marca { get; set; }
        public List<object> Equipos { get; set; }
    }
}
