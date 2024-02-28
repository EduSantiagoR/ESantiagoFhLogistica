using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result GetUsuariosSinEquipo()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ESantiagoFhLogisticaEntities context = new DL.ESantiagoFhLogisticaEntities())
                {
                    var query = context.UsuarioGetUsuariosSinEquipo();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var item in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.Area = new ML.Area();

                            usuario.IdUsuario = item.IdUsuario;
                            usuario.Nombre = item.NombreUsuario + " " + item.ApellidoPaterno + " " + item.ApellidoMaterno;
                            usuario.FechaIngreso = item.FechaIngreso;
                            usuario.Area.IdArea = item.IdArea;
                            usuario.Area.Nombre = item.NombreArea;

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "Error al recuperar los usuarios sin equipo.";
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
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ESantiagoFhLogisticaEntities context = new DL.ESantiagoFhLogisticaEntities())
                {
                    var query = context.UsuarioGetAll().ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Usuario usuario = new ML.Usuario
                            {
                                IdUsuario = item.IdUsuario,
                                Nombre = item.NombreUsuario,
                                ApellidoPaterno = item.ApellidoPaterno,
                                ApellidoMaterno = item.ApellidoMaterno,
                                FechaIngreso = item.FechaIngreso
                            };

                            usuario.Area = new ML.Area
                            {
                                IdArea = item.IdArea,
                                Nombre = item.NombreArea
                            };

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "Error al recuperar los usuarios.";
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
        public static ML.Result GetById(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ESantiagoFhLogisticaEntities context = new DL.ESantiagoFhLogisticaEntities())
                {
                    var query = context.UsuarioGetById(idUsuario).FirstOrDefault();
                    if(query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario
                        {
                            IdUsuario = query.IdUsuario,
                            Nombre = query.NombreUsuario,
                            ApellidoPaterno = query.ApellidoPaterno,
                            ApellidoMaterno = query.ApellidoMaterno,
                            FechaIngreso = query.FechaIngreso
                        };
                        usuario.Area = new ML.Area
                        {
                            IdArea = query.IdArea,
                            Nombre = query.NombreArea
                        };

                        result.Object = usuario;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "Error al recuperar el usuario.";
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
