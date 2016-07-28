namespace Restuarant.Models
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
        [Display(Name = "Thumnail Image")]
        public string ThumbURL { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Large Image")]
        public string LargeURL { get; set; }

        public virtual Category Category { get; set; }
    }
}
