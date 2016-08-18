/***
                           *Author: Irin Avery, Morrice Pfeiffer, Marco Duarte
                           * Student Number: 200260949, 	200293988, 100006379
                           * Date	Modified: Aug 18 2016
                           * Short Version History: Scaffolded the order details from the database
                           * Description: A model that holds the columns of the order details
 */
 namespace Restaurant.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetail
    {
        public int OrderDetailID { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public int FoodItemID { get; set; }

        public virtual FoodItem FoodItem { get; set; }

        public int OrderID { get; set; }

        public virtual Order Order { get; set; }
        
    }
}
