using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FoodAPI.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userID {  get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        
        
        public string phoneNumber { get; set; } 
        public string role { get; set; }
        [AllowNull]
        public float balance { get; set; } 
        public string address { get; set; }
        public string postcode { get; set; }

        [AllowNull]
        public string? cardNumber { get; set; }
        public bool hasSubscription { get; set; }  =false;
        [AllowNull]
        
        public bool isEngaged { get; set; } = false;
        [AllowNull]
        public DateTime subscreatedat { get; set; }   
        [AllowNull]
        public DateTime subscriptionExpirationDate { get; set; } 

        public Resturant resturants { get; set; }   
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
