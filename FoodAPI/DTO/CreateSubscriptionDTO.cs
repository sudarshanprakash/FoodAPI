namespace FoodAPI.DTO
{
    public class CreateSubscriptionDTO
    {
        public bool hasSubscription { get; set; } = false;
       // public DateTime createdat { get; set; } = DateTime.Now;
        public DateTime? subscriptionExpirationDate { get; set; }
    }
}
