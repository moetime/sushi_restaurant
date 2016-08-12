using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class OrderDetailsController : Controller
    {
        private ShoppingCartContext db = new ShoppingCartContext();

        // GET: OrderDetails
        public async Task<ActionResult> Index()
        {
            var orderDetails = db.OrderDetails.Include(o => o.Order);
            return View(await orderDetails.ToListAsync());
        }

        // GET: OrderDetails/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = await db.OrderDetails.FindAsync(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // GET: OrderDetails/Create
        public ActionResult Create()
        {
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "Username");
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "OrderDetailID,Quantity,UnitPrice,FoodItemID,OrderID")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                db.OrderDetails.Add(orderDetail);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "Username", orderDetail.OrderID);
            return View(orderDetail);
        }

        // GET: OrderDetails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = await db.OrderDetails.FindAsync(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "Username", orderDetail.OrderID);
            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "OrderDetailID,Quantity,UnitPrice,FoodItemID,OrderID")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderDetail).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "Username", orderDetail.OrderID);
            return View(orderDetail);
        }

        // GET: OrderDetails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = await db.OrderDetails.FindAsync(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OrderDetail orderDetail = await db.OrderDetails.FindAsync(id);
            db.OrderDetails.Remove(orderDetail);
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
