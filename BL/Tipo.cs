using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Tipo
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ESantiagoFhLogisticaEntities context = new DL.ESantiagoFhLogisticaEntities())
                {
                    var query = context.TipoGetAll().ToList();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var item in query)
                        {
                            ML.Tipo tipo = new ML.Tipo { IdTipo = item.IdTipo, Nombre = item.Nombre };
                            
                            result.Objects.Add(tipo);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "Error al recuperar los tipos de equipos.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
