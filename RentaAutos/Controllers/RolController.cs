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
            return View(await db.ROL.Where(x => x.ACTIVO).ToListAsync());
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
        public async Task<ActionResult> Create([Bind(Include = "ID_ROL,NOMBRE_ROL,FECHA_CREACION,ACTIVO")] ROL rOL)
        {
            rOL.ACTIVO = true;
            rOL.FECHA_CREACION = DateTime.Now;

            db.ROL.Add(rOL);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
            var rol = await db.ROL.FindAsync(rOL.ID_ROL);
            rol.NOMBRE_ROL = rOL.NOMBRE_ROL;
            db.Entry(rol).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Rol/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(long id)
        {
            var rol = await db.ROL.FindAsync(id);
            rol.ACTIVO = false;
            db.Entry(rol).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Json(new { success = true, message = "El rol ha sido Eliminada exitosamente" }, JsonRequestBehavior.AllowGet);
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
