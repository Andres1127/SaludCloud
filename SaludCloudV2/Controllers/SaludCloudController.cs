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

            using (Conexion.GetConexion())
            {
                string query = "Select Count(Nombre_Paciente) as Cantidad from cita where Fecha = '"+System.DateTime.Now+"'";
                SqlCommand cmd = new SqlCommand(query, Conexion.GetConexion());
                SqlDataReader leer = cmd.ExecuteReader();

                if (leer.Read())
                {
                    Global.CantCitas = leer["Cantidad"].ToString();
                    ViewBag.cant = Global.CantCitas;
                    return View();
                }
            }

            return View();
        }
        public ActionResult Citas()
        {
            ViewBag.Nombre = Global.Nombre;
            ViewBag.Apellido = Global.Apellido;
            ViewBag.alert = Global.alert;
            using (dbCitas db = new dbCitas())
            {
                //var list = (from b in db.cita
                //            select new cita
                //            {
                //               // Id = b.Id,
                //                Nombre_Paciente = b.Nombre_Paciente,
                //                Apellido_Paciente = b.Apellido_Paciente,
                //                Motivo = b.Motivo,
                //                Nota = b.Nota,
                //                Fecha = b.Fecha,
                //                Hora = b.Hora,
                //                Medico = b.Medico,
                //                Centro_Salud = b.Centro_Salud,
                //                Estatus = b.Estatus

                //            }).ToList();

                var list = (from d in db.cita
                            select d).ToList();

                return View(list);
            }

           // return View();
        }

        public ActionResult ActualizarCita()
        {
            return View();
        }

        public ActionResult GuardarCita(string nombres, string apellidos, string Motivo, string Nota, string date, string hora, string medico, string clinica, string Correo )
        {
            using (Conexion.GetConexion())
            {
                string query = " insert into cita(Nombre_Paciente, Apellido_Paciente, Motivo, Nota, Fecha, Hora, Medico, Centro_Salud, Estatus, Estatus_Correo, Correo) values ('"+nombres+ "','"+apellidos+"','"+Motivo+"','"+Nota+ "', '"+date+"','"+hora+ "', '"+medico+"', '"+clinica+ "', 'Pendiente', 'No', '"+Correo+"')";
                SqlCommand cmd = new SqlCommand(query, Conexion.GetConexion());
                if (cmd.ExecuteNonQuery()>=1){
                    Global.alert = "Send";
                }
            }
            return RedirectToAction("Citas");
        }
    }
}