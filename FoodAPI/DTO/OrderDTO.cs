using FoodAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FoodAPI.DTO
{
    public class OrderDTO
    {
        [Key]
        public int orderId { get; set; }
       // public bool isProcessed { get; set; }
        //public bool isDone { get; set; }
        //public DateTime dateTime { get; set; }
        public float totalPrice { get; set; }
        public int UserID { get; set; }
        public int ResturantId { get; set; }
        public ICollection<OrderedDish> Dishes { get; set; }
    }
}
