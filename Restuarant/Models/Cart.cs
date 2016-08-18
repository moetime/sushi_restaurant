/***
                           *Author: Irin Avery, Morrice Pfeiffer, Marco Duarte
                           * Student Number: 200260949, 	200293988, 100006379
                           * Date	Modified: Aug 18 2016
                           * Short Version History: Scaffolded the cart from the database
                           * Description: A model that holds the columns of the cart
 */

namespace Restaurant.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;


    public partial class Cart
    {
        public virtual int CartID { get; set; }

        public virtual string SessionID { get; set; }

        public virtual int NumItems { get; set; }

        public virtual DateTime DateCreated { get; set; }

        public virtual int FoodItemID { get; set; }

        public virtual FoodItem FoodItem { get; set; }

        
    }
}
