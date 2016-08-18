/***
                           *Author: Irin Avery, Morrice Pfeiffer, Marco Duarte
                           * Student Number: 200260949, 	200293988, 100006379
                           * Date	Modified: Aug 18 2016
                           * Short Version History: Scaffolded the shopping cart connection from the database
                           * Description: A model that holds the database connection of the shopping cart
 */
 namespace Restaurant.Models {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShoppingCartContext : DbContext {
        public ShoppingCartContext()
            : base("name=ShoppingCartConnection") {
        }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
        }
    }
}
