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
    public class RolController : Controller
    {
        private ModeloRentaAuto db = new ModeloRentaAuto();

        // GET: Rol
        public async Task<ActionResult> Index()
        {
            return View(await db.ROL.ToListAsync());
        }

        // GET: Rol/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROL rOL = await db.ROL.FindAsync(id);
            if (rOL == null)
            {
                return HttpNotFound();
            }
            return View(rOL);
        }

        // GET: Rol/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rol/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_ROL,NOMBRE_ROL,FECHA_CREACION,ACTIVO")] ROL rOL)
        {
            if (ModelState.IsValid)
            {
                db.ROL.Add(rOL);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(rOL);
        }

        // GET: Rol/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROL rOL = await db.ROL.FindAsync(id);
            if (rOL == null)
            {
                return HttpNotFound();
            }
            return View(rOL);
        }

        // POST: Rol/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_ROL,NOMBRE_ROL,FECHA_CREACION,ACTIVO")] ROL rOL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rOL).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(rOL);
        }

        // GET: Rol/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROL rOL = await db.ROL.FindAsync(id);
            if (rOL == null)
            {
                return HttpNotFound();
            }
            return View(rOL);
        }

        // POST: Rol/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            ROL rOL = await db.ROL.FindAsync(id);
            db.ROL.Remove(rOL);
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
