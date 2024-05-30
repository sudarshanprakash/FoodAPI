using System.Diagnostics.CodeAnalysis;

namespace FoodAPI.DTO
{
    public class ResturantViewDTO
    {
        public int resturantId { get; set; }
        public string resturantName { get; set; }
        [AllowNull]
        public string? Description { get; set; }
        [AllowNull]
        public string? imageUrl { get; set; }
        public string category { get; set; }
        public string address { get; set; }
        public string postcode { get; set; }
        public string phone { get; set; }
        [AllowNull]
        public double? averageReview { get; set; }


        public int UserId { get; set; }  // Foreign key
    }
}
