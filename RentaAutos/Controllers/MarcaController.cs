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
    public class MarcaController : Controller
    {
        private ModeloRentaAuto db = new ModeloRentaAuto();

        // GET: Marca
        public async Task<ActionResult> Index()
        {
            return View(await db.MARCA.Where(x=> x.ACTIVO).ToListAsync());
        }

        // GET: Marca/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MARCA mARCA = await db.MARCA.FindAsync(id);
            if (mARCA == null)
            {
                return HttpNotFound();
            }
            return View(mARCA);
        }

        // GET: Marca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marca/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_MARCA,NOMBRE_MARCA,FECHA_CREACION,ACTIVO")] MARCA mARCA)
        {
            if (ModelState.IsValid)
            {
                MARCA m = new MARCA
                {
                    FECHA_CREACION = DateTime.Now,
                    ACTIVO = true,
                    NOMBRE_MARCA = mARCA.NOMBRE_MARCA
                };
                db.MARCA.Add(m);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mARCA);
        }

        // GET: Marca/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MARCA mARCA = await db.MARCA.FindAsync(id);
            if (mARCA == null)
            {
                return HttpNotFound();
            }
            return View(mARCA);
        }

        // POST: Marca/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_MARCA,NOMBRE_MARCA,FECHA_CREACION,ACTIVO")] MARCA mARCA)
        {
            if (ModelState.IsValid)
            {
                var marca = await db.MARCA.FindAsync(mARCA.ID_MARCA);


                marca.NOMBRE_MARCA = mARCA.NOMBRE_MARCA;
                db.Entry(marca).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mARCA);
        }

        // GET: Marca/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var marca = await db.MARCA.FindAsync(id.Value);
                marca.ACTIVO = false;
                db.Entry(marca).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Json(new { success = true, message = "Marca Eliminada exitosamente" }, JsonRequestBehavior.AllowGet);
            }
        }

        //// POST: Marca/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(long id)
        //{
        //    MARCA mARCA = await db.MARCA.FindAsync(id);
        //    db.MARCA.Remove(mARCA);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

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
