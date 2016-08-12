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
