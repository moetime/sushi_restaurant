/***
                           *Author: Irin Avery, Morrice Pfeiffer, Marco Duarte
                           * Student Number: 200260949, 	200293988, 100006379
                           * Date	Modified: Aug 18 2016
                           * Short Version History: Scaffolded the menu controller from the database
                           * Description: A controller that allows our menu items to be viewed and detailed
 */
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
    [Authorize]
    public class MenuController : Controller
    {
        private SushiContext db = new SushiContext();

        [AllowAnonymous]
        // GET: FoodItems
        public async Task<ActionResult> Index()
        {

            var menuItems = new Restaurant.Models.Menu {

                foodItems = db.FoodItems.Include(f => f.Category).ToList(),
                categories = db.Categories.Include(f => f.FoodItems).ToList()
                
            };

            return View(menuItems);


            //var foodItems = db.FoodItems.Include(f => f.Category);
            //return View(await foodItems.ToListAsync());
        }
        [AllowAnonymous]
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