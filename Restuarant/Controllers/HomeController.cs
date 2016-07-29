﻿using System;
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

       
    }
}