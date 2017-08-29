using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Vegetais.Blog.Infrastructure.Data;

namespace Vegetais.Blog.Web.Areas.Admin.Controllers
{
    public class AssociadoController : Controller
    {
        private BlogModelContainer db = new BlogModelContainer();

        // GET: Admin/Associado
        public ActionResult Index()
        {
            return View(db.AssociadoSet.ToList());
        }

        // GET: Admin/Associado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Associado associado = db.AssociadoSet.Find(id);
            if (associado == null)
            {
                return HttpNotFound();
            }
            return View(associado);
        }

        // GET: Admin/Associado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Associado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Email,IP,HoraCadastro")] Associado associado)
        {
            if (ModelState.IsValid)
            {
                db.AssociadoSet.Add(associado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(associado);
        }

        // GET: Admin/Associado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Associado associado = db.AssociadoSet.Find(id);
            if (associado == null)
            {
                return HttpNotFound();
            }
            return View(associado);
        }

        // POST: Admin/Associado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Email,IP,HoraCadastro")] Associado associado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(associado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(associado);
        }

        // GET: Admin/Associado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Associado associado = db.AssociadoSet.Find(id);
            if (associado == null)
            {
                return HttpNotFound();
            }
            return View(associado);
        }

        // POST: Admin/Associado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Associado associado = db.AssociadoSet.Find(id);
            db.AssociadoSet.Remove(associado);
            db.SaveChanges();
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
