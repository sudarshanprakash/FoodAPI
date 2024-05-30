using System.Diagnostics.CodeAnalysis;

namespace FoodAPI.Models
{
    public class OrderedDish
        
    {
        public int Id { get; set; } 
        public int dishId { get; set; }

        public string name { get; set; }

        public double price { get; set; }
       
        public int quantity { get; set; }

       

    }
}
