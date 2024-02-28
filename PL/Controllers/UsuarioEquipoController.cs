using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioEquipoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Usuario.GetAll();
            ML.Usuario usuario = new ML.Usuario { Usuarios = result.Objects };
            ViewBag.AvisoMessage = "Completado.";
            return View(usuario);
        }

        [HttpGet]
        public ActionResult Asignar(int idUsuario, int? idEquipo)
        {
            ML.Result resultEquipos = BL.Equipo.GetEquiposSinAsignar(0, 0);
            ML.Result tipos = BL.Tipo.GetAll();
            ML.Result marcas = BL.Marca.GetAll();
            ML.Result resultUser = BL.Usuario.GetById(idUsuario);
            
            ML.UsuarioEquipo listas = new ML.UsuarioEquipo();
            listas.Equipo = new ML.Equipo { Equipos = resultEquipos.Objects }; //Paso de lista de equipos
            listas.Equipo.Marca = new ML.Marca { Marcas = marcas.Objects }; //Paso de lista de marcas
            listas.Equipo.Tipo = new ML.Tipo { Tipos = tipos.Objects }; //Paso de lista de tipos

            Session["idEquipo"] = idEquipo != null ? idEquipo : 0;
            listas.Equipo.IdEquipo = idEquipo != null ? idEquipo.Value : 0;

            listas.Usuario = (ML.Usuario) resultUser.Object; //Paso de información de usuario

            return View(listas);
        }

        [HttpGet]
        public ActionResult GetEquipos(int idUsuario, int idMarca, int idTipo)
        {
            ML.Result resultEquipos = BL.Equipo.GetEquiposSinAsignar(idMarca, idTipo);
            ML.Result resultUser = BL.Usuario.GetById(idUsuario);
            ML.Result tipos = BL.Tipo.GetAll();
            ML.Result marcas = BL.Marca.GetAll();

            ML.UsuarioEquipo listas = new ML.UsuarioEquipo();
            listas.Equipo = new ML.Equipo { Equipos = resultEquipos.Objects };
            listas.Equipo.Marca = new ML.Marca { Marcas = marcas.Objects }; //Paso de lista de marcas
            listas.Equipo.Tipo = new ML.Tipo { Tipos = tipos.Objects }; //Paso de lista de tipos

            int? idEquipo = int.Parse(Session["idEquipo"].ToString());
            listas.Equipo.IdEquipo = idEquipo != null ? idEquipo.Value : 0;

            listas.Usuario = (ML.Usuario)resultUser.Object;

            return View("Asignar", listas);
        }
        public ActionResult SetAsignacion(string accion, int idEquipo, int idUsuario)
        {
            if(accion == "add")
            {
                ML.Result result = BL.UsuarioEquipo.Add(idUsuario, idEquipo);
            }
            else
            {
                ML.Result result = BL.UsuarioEquipo.Update(idUsuario, idEquipo);
            }
            return RedirectToAction("GetUsuariosConEquipo");
        }

        [HttpGet]
        public ActionResult GetUsuariosConEquipo()
        {
            ML.Result result = BL.UsuarioEquipo.GetAll();
            ML.UsuarioEquipo usuario = new ML.UsuarioEquipo { EquiposAsignados = result.Objects };
            return View(usuario);
        }

        [HttpGet]
        public ActionResult DeleteAsignacion(int idUsuario, int idEquipo)
        {
            ML.Result result = BL.UsuarioEquipo.Delete(idUsuario, idEquipo);
            return RedirectToAction("GetUsuariosConEquipo");
        }
    }
}