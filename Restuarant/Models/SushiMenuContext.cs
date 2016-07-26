namespace Restaurant.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SushiMenuContext : DbContext
    {
        public SushiMenuContext()
            : base("name=SushiMenuConnection")
        {
        }
            public virtual DbSet<FoodItem>FoodItems { get; set; }
        public virtual DbSet<Category> Categories{ get; set; }
    }
}
