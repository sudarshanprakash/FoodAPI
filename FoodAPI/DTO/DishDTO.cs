using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodAPI.DTO
{
    public class DishDTO
    {

        public int dishId { get; set; }
        public string name { get; set; }

        //[Column(TypeName = "decimal(10, 2)")]
        public double price { get; set; }
        public string imageUrl { get; set; }
        [AllowNull]
        //public int quantity { get; set; }
        public int ResturantID { get; set; }
    }


}
