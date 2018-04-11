using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppKinesis.Models;

namespace WebAppKinesis.Controllers
{
    public class PacienteController : Controller
    {
        string mensaje;

        public ActionResult CrearHistoriaPaciente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearHistoriaPaciente(Pacientes pac)
        {
            ModelFacade facade = new ModelFacade();
            var result = facade.AddHistoria(pac);
            if (result == 1)
            {
                return View("AddExitoso", pac);
            }
            else
            {
                if (result == 2)
                {
                    mensaje = "El usuario ya se encuentra registrado en el sistema";
                    return RedirectToAction("ErrorUsuario");
                }
                else {
                    return View();
                }                
            }
        }
        public ActionResult AddExitoso()
        {
            return View();
        }

        public ActionResult ErrorUsuario()
        {
            ViewBag.error = mensaje;
            return View();
        }

 
        [HttpGet]
        public ActionResult ConsultarHistorias()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ConsultarHistorias(string NumCedula)
        {
            ModelFacade model = new ModelFacade();
            return View("HistoriaPaciente", model.BuscarPaciente(NumCedula));
        }
    }
}