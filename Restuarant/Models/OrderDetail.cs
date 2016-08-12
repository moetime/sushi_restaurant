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

        public int OrderID { get; set; }

        public virtual Order Order { get; set; }
    }
}
