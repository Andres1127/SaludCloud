using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;
using SaludCloudV2.Models;

namespace SaludCloudV2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult IndexLogin()
        {
            ViewBag.alert = Global.alert;
            return View();
        }

        public ActionResult Loguearse(string email, string pass)
        {
            using (Conexion.GetConexion())
            {
                string query = "select * from Usuario where Usuario = '"+email+ "' And Contrasena = '" +pass+ "'";
                SqlCommand cmd = new SqlCommand(query, Conexion.GetConexion());
                SqlDataReader leer = cmd.ExecuteReader();
                
                if (leer.Read())
                {
                    Global.Nombre = leer["Nombre"].ToString();
                    Global.Apellido = leer["Apellido"].ToString();
                    return RedirectToAction("Index", "SaludCloud");
                }
                else
                {
                    Global.alert = "Error";
                    return RedirectToAction("IndexLogin");
                }
            }
           
        }

        public ActionResult forgotPass(string email)
        {
            if(email != null)
            {
            Global.correo = email;
            EnvioCorreo ec = new EnvioCorreo();
            ec.Enviar(email);
            ViewBag.alert = "Send";
            }

            return View();
        }

        public ActionResult ressetPass()
        {
            ViewBag.alert = Global.alert;
            return View();
        }

        public ActionResult ressetPass0(string pass, string pass2)
        {
            using (Conexion.GetConexion())
            {
                if (pass == pass2)
                {
                    string query = "UPDATE Usuario SET Contrasena = '" + pass + "' WHERE Usuario = '" + Global.correo + "';";
                    SqlCommand cmd = new SqlCommand(query, Conexion.GetConexion());
                    cmd.ExecuteNonQuery();

                    return RedirectToAction("IndexLogin");
                }
                else
                {
                    Global.alert = "Error";
                    return RedirectToAction("ressetPass");
                }
            }
            
        }
    }
}