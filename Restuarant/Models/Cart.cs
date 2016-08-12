namespace Restuarant.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cart
    {
        public int CartID { get; set; }

        public string SessionID { get; set; }

        public int NumItems { get; set; }

        public DateTime DateCreated { get; set; }

        public int FoodItemID { get; set; }
    }
}
