using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Marca
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ESantiagoFhLogisticaEntities context = new DL.ESantiagoFhLogisticaEntities())
                {
                    var query = context.MarcaGetAll().ToList();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var item in query)
                        {
                            ML.Marca marca = new ML.Marca { IdMarca = item.IdMarca, Nombre = item.Nombre };

                            result.Objects.Add(marca);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "Error al recuperar las marcas.";
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
