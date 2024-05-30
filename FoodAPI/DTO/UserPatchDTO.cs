namespace FoodAPI.DTO
{
    public class UserPatchDTO
    {
        public int userID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }


        public string phoneNumber { get; set; }
        public string role { get; set; }
        public float balance { get; set; }
        public string address { get; set; }
        public string postcode { get; set; }
        public string cardNumber { get; set; }
        public bool hasSubscription { get; set; } = false;
        public DateTime createdat { get; set; } = DateTime.Now;
        public DateTime? subscriptionExpirationDate { get; set; }
    }
}
