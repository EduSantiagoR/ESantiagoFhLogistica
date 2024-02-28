using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UsuarioEquipo
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ESantiagoFhLogisticaEntities context = new DL.ESantiagoFhLogisticaEntities())
                {
                    var query = context.UsuarioEquipoGetAll();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.UsuarioEquipo usuario = new ML.UsuarioEquipo();
                            usuario.Usuario = new ML.Usuario();
                            usuario.Usuario.Area = new ML.Area();
                            usuario.Equipo = new ML.Equipo();
                            usuario.Equipo.Tipo = new ML.Tipo();
                            usuario.Equipo.Marca = new ML.Marca();

                            usuario.Usuario.IdUsuario = item.IdUsuario;
                            usuario.Usuario.Nombre = item.NombreUsuario;
                            usuario.Usuario.ApellidoPaterno = item.ApellidoPaterno;
                            usuario.Usuario.ApellidoMaterno = item.ApellidoMaterno;
                            usuario.Usuario.FechaIngreso = item.FechaIngreso;
                            usuario.Usuario.Area.IdArea = item.IdArea;
                            usuario.Usuario.Area.Nombre = item.NombreArea;
                            usuario.Equipo.IdEquipo = item.IdEquipo;
                            usuario.Equipo.Modelo = item.Modelo;
                            usuario.Equipo.ClaveInventario = item.ClaveInventario;
                            usuario.Equipo.Tipo.IdTipo = item.IdTipo;
                            usuario.Equipo.Tipo.Nombre = item.NombreTipo;
                            usuario.Equipo.Marca.IdMarca = item.IdMarca;
                            usuario.Equipo.Marca.Nombre = item.NombreMarca;
                            usuario.FechaAsignacion = item.FechaAsignacion;

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "Error al recuperar los registros.";
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
        public static ML.Result GetByIDs(int idUsuario, int idEquipo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ESantiagoFhLogisticaEntities context = new DL.ESantiagoFhLogisticaEntities())
                {

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
        public static ML.Result Add(int idUsuario, int idEquipo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ESantiagoFhLogisticaEntities context = new DL.ESantiagoFhLogisticaEntities())
                {
                    int rowsAffected = context.UsuarioEquipoAdd(idUsuario, idEquipo);
                    if(rowsAffected > 0)
                    {
                        result.Correct = true;
                        result.Message = "Asignación realizada de manera correcta.";
                    }
                    else
                    {
                        result.Message = "Error al asignar el equipo.";
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
        public static ML.Result Update(int idUsuario, int idEquipo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ESantiagoFhLogisticaEntities context = new DL.ESantiagoFhLogisticaEntities())
                {
                    int rowsAffected = context.UsuarioEquipoUpdate(idUsuario, idEquipo);
                    if(rowsAffected > 0)
                    {
                        result.Correct = true;
                        result.Message = "El equipo asignado fue actualizado correctamente.";
                    }
                    else
                    {
                        result.Message = "Error al actualizar el equipo asignado.";
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
        public static ML.Result Delete(int idUsuario, int idEquipo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ESantiagoFhLogisticaEntities context = new DL.ESantiagoFhLogisticaEntities())
                {
                    int rowsAffected = context.UsuarioEquipoDelete(idUsuario, idEquipo);
                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                        result.Message = "Registro eliminado correctamente.";
                    }
                    else
                    {
                        result.Message = "Error al eliminar el registro.";
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
