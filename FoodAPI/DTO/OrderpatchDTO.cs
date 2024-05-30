using FoodAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FoodAPI.DTO
{
    public class OrderpatchDTO
    {
        [Key]
        public int orderId { get; set; }
        public bool isProcessed { get; set; } = false;
        public bool isDenied { get; set; } = false;
        public bool isDone { get; set; } = false;
        public DateTime dateTime { get; set; }
        public float totalPrice { get; set; }
        public int UserID { get; set; }
        public int ResturantId { get; set; }
        public bool isReady { get; set; } = false;
        public bool isDelivered { get; set; } = false;
        [AllowNull]
        public int? driverId { get; set; }

        public string resturantName { get; set; }
        public ICollection<OrderedDish> Dishes { get; set; }
    }
}
