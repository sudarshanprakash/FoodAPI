using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FoodAPI.Models
{
    public class Order
    {
        [Key]
        public int orderId { get; set; }
        public bool isProcessed { get; set; }=false;
        public bool isDenied { get; set; } = false;
        public bool isReady { get; set; } = false;
        public bool isDispatched { get; set; } = false;
        public bool isDelivered {  get; set; } = false; 
        public bool isDone { get; set; } = false;
        public DateTime dateTime { get; set; }
        public float totalPrice { get; set; }
        public int UserID { get; set; }
        [AllowNull]
        public int? driverId {  get; set; }  
        public int ResturantId { get; set; }
        public ICollection<OrderedDish> Dishes { get; set; }

    }
}
