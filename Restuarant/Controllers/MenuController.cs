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
    public class MenuController : Controller
    {
        private SushiContext db = new SushiContext();

        // GET: FoodItems
        public async Task<ActionResult> Index()
        {
            var foodItems = db.FoodItems.Include(f => f.Category);
            return View(await foodItems.ToListAsync());
        }
        // GET: FoodItems/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodItem foodItem = await db.FoodItems.FindAsync(id);
            if (foodItem == null)
            {
                return HttpNotFound();
            }
            return View(foodItem);
        }
    }
}