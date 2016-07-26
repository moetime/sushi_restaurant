using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class Category
    {
        /// <summary>
        /// This is the empty constructor
        /// </summary>
        public Category()
        {

        }

        /// <summary>
        /// This constructor takes one paramter - Name
        /// </summary>
        /// <param name="Name"></param>
        public Category(string Name)
        {
            this.Name = Name;
        }

        public virtual int CategoryID { get; set; }
        public virtual string Name { get; set; }
        public virtual List<FoodItem> FoodItems { get; set; }

    }
}