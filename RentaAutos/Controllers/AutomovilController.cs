using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RentaAutos.Models;

namespace RentaAutos.Controllers
{
    public class AutomovilController : Controller
    {
        private ModeloRentaAuto db = new ModeloRentaAuto();

        // GET: Automovil
        public async Task<ActionResult> Index()
        {
            var aUTOMOVIL = db.AUTOMOVIL.Include(a => a.MARCA).Include(a => a.TIPO);
            return View(await aUTOMOVIL.Where(X=> X.ACTIVO).ToListAsync());
        }

        // GET: Automovil/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AUTOMOVIL aUTOMOVIL = await db.AUTOMOVIL.FindAsync(id);
            if (aUTOMOVIL == null)
            {
                return HttpNotFound();
            }
            return View(aUTOMOVIL);
        }

        // GET: Automovil/Create
        public ActionResult Create()
        {
            ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID_MARCA", "NOMBRE_MARCA");
            ViewBag.ID_TIPO = new SelectList(db.TIPO, "ID_TIPO", "NOMBRE_TIPO");
            return View();
        }

        // POST: Automovil/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_AUTOMOVIL,GAMA,FECHA_CREACION,PRECIO,OCUPADO,ACTIVO,ID_MARCA,ID_TIPO")] AUTOMOVIL aUTOMOVIL)
        {
            if (ModelState.IsValid)
            {
                aUTOMOVIL.ACTIVO = true;
                aUTOMOVIL.OCUPADO = false;
                db.AUTOMOVIL.Add(aUTOMOVIL);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID_MARCA", "NOMBRE_MARCA", aUTOMOVIL.ID_MARCA);
            ViewBag.ID_TIPO = new SelectList(db.TIPO, "ID_TIPO", "NOMBRE_TIPO", aUTOMOVIL.ID_TIPO);
            return View(aUTOMOVIL);
        }

        // GET: Automovil/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AUTOMOVIL aUTOMOVIL = await db.AUTOMOVIL.FindAsync(id);
            if (aUTOMOVIL == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID_MARCA", "NOMBRE_MARCA", aUTOMOVIL.ID_MARCA);
            ViewBag.ID_TIPO = new SelectList(db.TIPO, "ID_TIPO", "NOMBRE_TIPO", aUTOMOVIL.ID_TIPO);
            return View(aUTOMOVIL);
        }

        // POST: Automovil/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_AUTOMOVIL,GAMA,FECHA_CREACION,PRECIO,OCUPADO,ACTIVO,ID_MARCA,ID_TIPO")] AUTOMOVIL aUTOMOVIL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aUTOMOVIL).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID_MARCA", "NOMBRE_MARCA", aUTOMOVIL.ID_MARCA);
            ViewBag.ID_TIPO = new SelectList(db.TIPO, "ID_TIPO", "NOMBRE_TIPO", aUTOMOVIL.ID_TIPO);
            return View(aUTOMOVIL);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                AUTOMOVIL aUTOMOVIL = await db.AUTOMOVIL.FindAsync(id);
                aUTOMOVIL.ACTIVO = false;
                db.Entry(aUTOMOVIL).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Json(new { success = true, message = "El automovil ha sido Eliminada exitosamente" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                String msj = ex.Message;
                throw;
            }
            
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
