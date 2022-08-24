using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CAPA_DATOS;
using CAPA_NEGOCIO;

namespace CAPA_PRESENTACION.Controllers
{
    public class ClIENTESController : Controller
    {
        private CLAROEntities1 db = new CLAROEntities1();

        // GET: ClIENTES
        public ActionResult Index()
        {
            var clIENTES = db.ClIENTES.Include(c => c.TIPO_IDENTIFICACION);
            return View(clIENTES.ToList());
        }

       

        // GET: ClIENTES/Create
        public ActionResult Create()
        {
            ViewBag.Id_Tipo_Identificacion = new SelectList(db.TIPO_IDENTIFICACION, "Id_Tipo_Identificacion", "Nombre");
            return View();
        }

        // POST: ClIENTES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( ClIENTES clIENTES)
        {
            if (ModelState.IsValid)
            {
                ClIENTES cli = new ClIENTES();

                cli.Nombre = clIENTES.Nombre;
                cli.Numero_Identificacion = clIENTES.Numero_Identificacion;
                cli.Correo = clIENTES.Correo;
                cli.Telefono = clIENTES.Telefono;
                cli.Direccion = clIENTES.Direccion;
                cli.Direccion_Instalacion = clIENTES.Direccion_Instalacion;
                cli.Id_Tipo_Identificacion = clIENTES.Id_Tipo_Identificacion;
                cli.estado = clIENTES.estado;

                if (Clientes_BL.ValidarDocument(cli))
                {
                    //return RedirectToAction("Index");
                    ViewBag.Mensaje = "Cliente ya existente";
                }
                else
                {
                    cli = Clientes_BL.RegistrarClientes(cli);
                    return RedirectToAction("Index");
                }

               
            }

            ViewBag.Id_Tipo_Identificacion = new SelectList(db.TIPO_IDENTIFICACION, "Id_Tipo_Identificacion", "Nombre", clIENTES.Id_Tipo_Identificacion);
            return View(clIENTES);
        }

        // GET: ClIENTES/Edit/5
        public ActionResult Edit(int id = 0)
        {
            ClIENTES clientes = new Clientes_BL().ObtenerId(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Tipo_Identificacion = new SelectList(db.TIPO_IDENTIFICACION, "Id_Tipo_Identificacion", "Nombre", clientes.Id_Tipo_Identificacion);
            return View(clientes);
        }

        // POST: ClIENTES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClIENTES clIENTES)
        {
            if (ModelState.IsValid)
            {
                ClIENTES cli = new ClIENTES();
                cli.Id_Cliente = clIENTES.Id_Cliente;
                cli.Nombre = clIENTES.Nombre;
                cli.Numero_Identificacion = clIENTES.Numero_Identificacion;
                cli.Correo = clIENTES.Correo;
                cli.Telefono = clIENTES.Telefono;
                cli.Direccion = clIENTES.Direccion;
                cli.Direccion_Instalacion = clIENTES.Direccion_Instalacion;
                cli.Id_Tipo_Identificacion = clIENTES.Id_Tipo_Identificacion;
                cli.estado = clIENTES.estado;
                cli = Clientes_BL.ModificarClientes(cli);
                return RedirectToAction("Index");
            }
            ViewBag.Id_Tipo_Identificacion = new SelectList(db.TIPO_IDENTIFICACION, "Id_Tipo_Identificacion", "Nombre", clIENTES.Id_Tipo_Identificacion);
            return View(clIENTES);
        }

        public ActionResult Delete(int id)
        {
            ClIENTES cli = new ClIENTES();
            cli.Id_Cliente = id;
            cli = Clientes_BL.EliminarClientes(cli);
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
