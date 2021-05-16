using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaludCloudV2.Models;

namespace SaludCloudV2.Controllers
{
    public class SaludCloudController : Controller
    {
        // GET: SaludCloud
        public ActionResult Index()
        {
            ViewBag.Nombre = Global.Nombre;
            ViewBag.Apellido = Global.Apellido;
            return View();
        }
        public ActionResult Citas()
        {
            ViewBag.Nombre = Global.Nombre;
            ViewBag.Apellido = Global.Apellido;
            return View();
        }

        public ActionResult ActualizarCita()
        {
            using (Conexion.GetConexion())
            {
                string query = "";
                SqlCommand cmd = new SqlCommand(query, Conexion.GetConexion());
                SqlDataReader leer = cmd.ExecuteReader();

                while (leer.Read())
                {

                }
            }
            return View();
        }

        public ActionResult GuardarCita()
        {
            return View();
        }
    }
}