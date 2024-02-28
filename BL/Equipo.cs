using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Equipo
    {
        public static ML.Result GetEquiposSinAsignar(int idMarca, int idTipo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ESantiagoFhLogisticaEntities context = new DL.ESantiagoFhLogisticaEntities())
                {
                    var query = context.EquipoGetEquiposSinAsignarByIdMarcaAndIdTipo(idMarca, idTipo).ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Equipo equipo = new ML.Equipo();
                            equipo.Marca = new ML.Marca();
                            equipo.Tipo = new ML.Tipo();

                            equipo.IdEquipo = item.IdEquipo;
                            equipo.Modelo = item.Modelo;
                            equipo.ClaveInventario = item.ClaveInventario;
                            equipo.Marca.IdMarca = item.IdMarca;
                            equipo.Marca.Nombre = item.NombreMarca;
                            equipo.Tipo.IdTipo = item.IdTipo;
                            equipo.Tipo.Nombre = item.NombreTipo;

                            result.Objects.Add(equipo);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "Error al recuperar los equipos sin asignar.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = true;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
