using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FoodAPI.Models
{
    public class Resturant
    {
        public int resturantId { get; set; }
        public string resturantName { get; set; }
        [AllowNull]
        public string? Description {  get; set; }
        [AllowNull]
        public string? imageUrl {  get; set; }
        public string category {  get; set; }
        public string address {  get; set; }
        public string postcode { get; set; }
       public string phone {  get; set; }
       [AllowNull]
        public double? averageReview { get; set; }

        
        public int UserId { get; set; }  // Foreign key
       //public  virtual User user { get; set; }
        public virtual ICollection<Dish> dishes { get; set; }
        public virtual ICollection<Review> reviews { get; set; }
        public virtual ICollection<Order> Orders { get; set; }



    }
}
