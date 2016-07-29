using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class Menu
    {
        public virtual List<Category> categories { get; set; }
        public virtual List<FoodItem> foodItems { get; set; }
    }
}