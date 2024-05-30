using System.ComponentModel.DataAnnotations;

namespace FoodAPI.Models
{
    public class Review
    {
        [Key]
        public int reviewId { get; set; }

        
        public string reviewContent { get; set; }
        public int star {  get; set; }
        public int ResturantID { get; set; }

        public int UserID { get; set; }
    }
}
