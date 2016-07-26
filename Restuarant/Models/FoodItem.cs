using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class FoodItem
    {
        /// <summary>
        /// This is the empty constructor
        /// </summary>
        public FoodItem()
        {

        }

        /// <summary>
        /// This constructor takes one parameter - Title
        /// </summary>
        /// <param name="Title"></param>
        public FoodItem(string Name)
        {
            this.Name = Name;
        }

        public virtual int FoodID { get; set; }
        public virtual string Name { get; set; }

        public virtual string ShortDesc { get; set; }

        public virtual string LongDesc { get; set; }

        public virtual double Price { get; set; }

        public virtual string ThumbImage { get; set; }
        public virtual string LgImage { get; set; }
    }
}