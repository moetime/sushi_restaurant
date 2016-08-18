/***
                           *Author: Irin Avery, Morrice Pfeiffer, Marco Duarte
                           * Student Number: 200260949, 	200293988, 100006379
                           * Date	Modified: Aug 18 2016
                           * Short Version History: Scaffolded the food items connection from the database
                           * Description: A model that holds database connection of food items for our menu
 */
 namespace Restaurant.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SushiContext : DbContext
    {
        public SushiContext()
            : base("name=SushiConnection")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<FoodItem> FoodItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.FoodItems)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FoodItem>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<FoodItem>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FoodItem>()
                .Property(e => e.ShortDesc)
                .IsUnicode(false);

            modelBuilder.Entity<FoodItem>()
                .Property(e => e.LongDesc)
                .IsUnicode(false);

            modelBuilder.Entity<FoodItem>()
                .Property(e => e.ThumbURL)
                .IsUnicode(false);

            modelBuilder.Entity<FoodItem>()
                .Property(e => e.LargeURL)
                .IsUnicode(false);
        }
    }
}
