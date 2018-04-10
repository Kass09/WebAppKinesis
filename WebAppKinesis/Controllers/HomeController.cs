using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppKinesis.Models;

namespace WebAppKinesis.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username1, string password1)
        {
            ModelFacade facade = new ModelFacade();
            var result = facade.CheckLogin(username1, password1);

            if (result == 1)
            {
                ViewBag.message = "Inicio de sesion satisfactorio";
                return RedirectToAction("HomePage");
            }
            else
            {
                if (result == 2)
                {
                    ViewBag.message = "Error al iniciar sesion, el usuario o la contraseña no son correctos";
                    return RedirectToAction("ErrorLogin");
                }
                else
                {
                    ViewBag.message = "User doesn’t exist - Failed Login";
                    return RedirectToAction("ErrorLogin");
                }
            }
        }

        public ActionResult ErrorLogin()
        {
            return View();
        }

        public ActionResult HomePage()
        {
            return View();
        }
    }
}