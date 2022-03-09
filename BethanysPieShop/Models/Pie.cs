using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class Pie
    {
        [Key]
        [Display(Name = "Pie Id")]
        public int PieId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Display(Name = "Long Description")]
        public string LongDescription { get; set; }

        [Display(Name = "Allergy Information")]
        public string AllergyInformation { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }

        [Display(Name = "Image ThumbnailUrl")]
        public string ImageThumbnailUrl { get; set; }

        [Display(Name = "Is Pie Of TheWeek")]
        public bool IsPieOfTheWeek { get; set; }

        [Display(Name = "In Stock")]
        public bool InStock { get; set; }

        [Display(Name = "Category Id")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
 