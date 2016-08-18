/***
                           *Author: Irin Avery, Morrice Pfeiffer, Marco Duarte
                           * Student Number: 200260949, 	200293988, 100006379
                           * Date	Modified: Aug 18 2016
                           * Short Version History: Scaffolded the home controller from project
                           * Description: A controller that allows homepage and contact page
 */
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Restaurant.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        // GET: /Home/
        public ActionResult Contact()
        {
            return View();
        }


    }
}