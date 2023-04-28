using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PizzaProject.Models;

namespace PizzaProject.Controllers
{
    public class OrdersController : Controller
    {
        private PizzaContext db = new PizzaContext();

        // GET: Orders
        [Authorize (Roles = "admin")]
        public ActionResult Index()
        {
            return View(db.Order.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create(int? id)
        {
            ViewBag.Pizzas = GetPizzaListWithMain(id);
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.UserName = User.Identity.Name;
            }
            else
            {
                ViewBag.UserName = "";
            }
            return View();
        }

        // POST: Orders/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerName,Address,PhoneNumber,PizzaId,Price")] Order order)
        {
            order.Date = DateTime.Now;
            Pizza cur = db.Pizza.Find(order.PizzaId);
            order.Price = cur.Price;
            if (ModelState.IsValid)
            {
                db.Order.Add(order);
                db.SaveChanges();
                return RedirectToAction("Completed", new { id = order.Id });
            }
            ViewBag.Pizzas = GetPizzaListWithMain(order.PizzaId);
            return View(order);
        }

        private List<Pizza> GetPizzaListWithMain(int? id)
        {
            List<Pizza> PizzaList = db.Pizza.ToList();
            if (id != null)
            {
                foreach (Pizza p in PizzaList)
                {
                    if (p.Id == id)
                    {
                        PizzaList.Remove(p);
                        PizzaList.Insert(0, p);
                        break;
                    }
                }
            }
            return PizzaList;
        }

        public ActionResult Completed(int id)
        {
            ViewBag.id = id;
            return View();
        }

        // GET: Orders/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "Id,CustomerName,Address,PhoneNumber,PizzaName,Price")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Order.Find(id);
            db.Order.Remove(order);
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
