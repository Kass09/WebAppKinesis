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
        public ActionResult CrearHistoriaPaciente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearHistoriaPaciente(Pacientes pac)
        {
            return View();
        }
    }
}