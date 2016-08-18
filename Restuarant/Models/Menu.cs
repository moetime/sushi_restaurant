/***
                           *Author: Irin Avery, Morrice Pfeiffer, Marco Duarte
                           * Student Number: 200260949, 	200293988, 100006379
                           * Date	Modified: Aug 18 2016
                           * Short Version History: Created the parent model to connect 
                           * categories and food items
                           * Description: A model that holds both categories and food items
 */
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