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
    public class RentaController : Controller
    {
        private ModeloRentaAuto db = new ModeloRentaAuto();

        // GET: Renta
        public async Task<ActionResult> Index()
        {
            var rENTA = db.RENTA.Include(r => r.AUTOMOVIL).Include(r => r.USUARIO);
            return View(await rENTA.ToListAsync());
        }

        // GET: Renta/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RENTA rENTA = await db.RENTA.FindAsync(id);
            if (rENTA == null)
            {
                return HttpNotFound();
            }
            return View(rENTA);
        }

        // GET: Renta/Create
        public ActionResult Create()
        {
            ViewBag.ID_AUTOMOVIL = new SelectList(db.AUTOMOVIL, "ID_AUTOMOVIL", "GAMA");
            ViewBag.ID_USUARIO = new SelectList(db.USUARIO, "ID_USUARIO", "USUARIO1");
            return View();
        }

        // POST: Renta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_RENTA,PRECIO,FECHA_ALQUILER,ID_AUTOMOVIL,ID_USUARIO")] RENTA rENTA)
        {
            if (ModelState.IsValid)
            {
                db.RENTA.Add(rENTA);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_AUTOMOVIL = new SelectList(db.AUTOMOVIL, "ID_AUTOMOVIL", "GAMA", rENTA.ID_AUTOMOVIL);
            ViewBag.ID_USUARIO = new SelectList(db.USUARIO, "ID_USUARIO", "USUARIO1", rENTA.ID_USUARIO);
            return View(rENTA);
        }

        // GET: Renta/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RENTA rENTA = await db.RENTA.FindAsync(id);
            if (rENTA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_AUTOMOVIL = new SelectList(db.AUTOMOVIL, "ID_AUTOMOVIL", "GAMA", rENTA.ID_AUTOMOVIL);
            ViewBag.ID_USUARIO = new SelectList(db.USUARIO, "ID_USUARIO", "USUARIO1", rENTA.ID_USUARIO);
            return View(rENTA);
        }

        // POST: Renta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_RENTA,PRECIO,FECHA_ALQUILER,ID_AUTOMOVIL,ID_USUARIO")] RENTA rENTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rENTA).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_AUTOMOVIL = new SelectList(db.AUTOMOVIL, "ID_AUTOMOVIL", "GAMA", rENTA.ID_AUTOMOVIL);
            ViewBag.ID_USUARIO = new SelectList(db.USUARIO, "ID_USUARIO", "USUARIO1", rENTA.ID_USUARIO);
            return View(rENTA);
        }

        // GET: Renta/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RENTA rENTA = await db.RENTA.FindAsync(id);
            if (rENTA == null)
            {
                return HttpNotFound();
            }
            return View(rENTA);
        }

        // POST: Renta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            RENTA rENTA = await db.RENTA.FindAsync(id);
            db.RENTA.Remove(rENTA);
            await db.SaveChangesAsync();
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
