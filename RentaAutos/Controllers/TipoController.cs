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
    public class TipoController : Controller
    {
        private ModeloRentaAuto db = new ModeloRentaAuto();

        // GET: Tipo
        public async Task<ActionResult> Index()
        {
            return View(await db.TIPO.Where(x=> x.ACTIVO).ToListAsync());
        }

        // GET: Tipo/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO tIPO = await db.TIPO.FindAsync(id);
            if (tIPO == null)
            {
                return HttpNotFound();
            }
            return View(tIPO);
        }

        // GET: Tipo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "ID_TIPO,NOMBRE_TIPO,FECHA_CREACION,ACTIVO")] TIPO tIPO)
        {
            tIPO.ACTIVO = true;
            tIPO.FECHA_CREACION = DateTime.Now;

            db.TIPO.Add(tIPO);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Tipo/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO tIPO = await db.TIPO.FindAsync(id);
            if (tIPO == null)
            {
                return HttpNotFound();
            }
            return View(tIPO);
        }

        // POST: Tipo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include = "ID_TIPO,NOMBRE_TIPO,FECHA_CREACION,ACTIVO")] TIPO tIPO)
        {
            var ti = await db.TIPO.FindAsync(tIPO.ID_TIPO);
            ti.NOMBRE_TIPO = tIPO.NOMBRE_TIPO;
            db.Entry(ti).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Tipo/Delete/5
        public async Task<ActionResult> Delete(long id)
        {
            TIPO tIPO = await db.TIPO.FindAsync(id);
            tIPO.ACTIVO = false;
            db.Entry(tIPO).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Json(new { success = true, message = "El tipo ha sido Eliminada exitosamente" }, JsonRequestBehavior.AllowGet);
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
