using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema ;
//using System.ComponentModel.DataAnnotations.Schema;


namespace FoodAPI.Models
{
    public class Dish
    {
        public int dishId { get; set; }
        public string name { get; set; }
        //[Column(TypeName = "decimal(10, 2)")]
        public double price {  get; set; }
        [AllowNull]
        public string? imageUrl { get; set; }
        [AllowNull]
        //public int quantity {  get; set; }
        public int ResturantID { get; set; }

        public virtual ICollection<OrderedDish> orderedDish { get; set; }  

        
    }
}
