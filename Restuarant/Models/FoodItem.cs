/***
                           *Author: Irin Avery, Morrice Pfeiffer, Marco Duarte
                           * Student Number: 200260949, 	200293988, 100006379
                           * Date	Modified: Aug 18 2016
                           * Short Version History: Scaffolded the food items from the database
                           * Description: A model that holds the columns of the food items
 */
 namespace Restaurant.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FoodItem")]
    public partial class FoodItem
    {
        public int ID { get; set; }

        public int CategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(300)]
        [Display(Name = "Food Description")]
        public string ShortDesc { get; set; }

        [Required]
        [Display(Name = "Detailed Description")]
        public string LongDesc { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Thumbnail Image")]
        public string ThumbURL { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Large Image")]
        public string LargeURL { get; set; }

        public virtual Category Category { get; set; }
    }
}
