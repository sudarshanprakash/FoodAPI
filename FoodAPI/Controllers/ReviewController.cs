using FoodAPI.Data;
using FoodAPI.DTO;
using FoodAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {

        private readonly ApiDbContext _db;
        public ReviewController(ApiDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        public IActionResult Get()

        {
            var data = (from d in _db.reviews
                        select new ReviewDTO()
                        {
                         reviewId = d.reviewId,
                        reviewContent = d.reviewContent,
                        ResturantID=d.ResturantID,
                        UserID=d.UserID,
                        star=d.star,


                        }).ToList();
            return Ok(data);

        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //var users = _db.users.Find(id);

            var reviews = (from d in _db.reviews
                          where d.reviewId == id
                          select new ReviewDTO()

                          {
                              reviewId = d.reviewId,
                              reviewContent = d.reviewContent,
                              ResturantID = d.ResturantID,
                              UserID = d.UserID,
                              star = d.star,
                          }).ToList();
            if (reviews == null)
            {
                return NotFound();
            }
            return Ok(reviews);


        }


        [HttpGet("GetReviewbyResturant")]

        public IActionResult GetReviewbyResturantId(int Resturantid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //var users = _db.users.Find(id);

            var reviews = (from d in _db.reviews
                           where d.ResturantID == Resturantid
                           select new ReviewDTO()

                           {
                               reviewId = d.reviewId,
                               reviewContent = d.reviewContent,
                               ResturantID = d.ResturantID,
                               UserID = d.UserID,
                               star = d.star,
                           }).ToList();
            if (reviews == null)
            {
                return NotFound();
            }
            return Ok(reviews);


        }

        [HttpPost]
        public IActionResult CreateReviews([FromBody] ReviewDTO review)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            if (review != null)
            {
                ModelState.Remove("review.reviewId");
                Review newReview = new Review()
                {
                    //reviewId=review.reviewId,
                    reviewContent=review.reviewContent,
                    ResturantID=review.ResturantID,
                    star = review.star,
                    UserID=review.UserID,
                   







                };
                _db.reviews.Add(newReview);
                
                _db.SaveChanges();


                var restaurant = _db.resturants.FirstOrDefault(r => r.resturantId == review.ResturantID);
                if (restaurant != null)
                {
                    // Calculate new average review
                    var reviewsForRestaurant = _db.reviews.Where(r => r.ResturantID == review.ResturantID);
                    if (reviewsForRestaurant.Any())
                    {
                        restaurant.averageReview = (double)reviewsForRestaurant.Average(r => r.star);
                        _db.resturants.Update(restaurant);
                        _db.SaveChanges();
                    }
                }
                //return RedirectToAction("Get");
                return Ok(newReview);
            }
            return NotFound(ModelState);
        }


        [HttpPut("Update/{id:int}", Name = "UpdateReview")]
        public IActionResult UpdateUser(int id, [FromBody] ReviewDTO review)
        {
            if (review == null || id != review.reviewId)
            {
                return BadRequest();
            }


            Review newReview = new Review()
            {
                reviewId=review.reviewId,
                reviewContent = review.reviewContent,
                ResturantID = review.ResturantID,
                star = review.star,
                UserID = review.UserID,

            };
            _db.reviews.Update(newReview);
            _db.SaveChanges();

            return Ok(newReview);

        }

        [HttpPatch]
        public IActionResult partialUpdateResturant(int id, [FromBody] JsonPatchDocument<ReviewDTO> patchReview)


        {
            if (patchReview == null || id == 0)
            {
                return BadRequest();
            }
            var Review = _db.reviews.FirstOrDefault(u => u.reviewId == id);

            ReviewDTO review = new()
            {
                
                reviewId=Review.reviewId,
                reviewContent=Review.reviewContent,
                star = Review.star,
                UserID = Review.UserID,
                ResturantID= Review.ResturantID




               





            };
            if (Review == null)
            {
                return NotFound();
            }
            patchReview.ApplyTo(review, ModelState);
            Review model = new()
            {
                reviewId=review.reviewId,
                reviewContent=review.reviewContent,
                star=Review.star,
                UserID=review.UserID,
                ResturantID= Review.ResturantID

                



            };
            _db.reviews.Update(model);
            _db.SaveChanges();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(model);

        }

        [HttpDelete]
        public IActionResult delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();

            }
            var review = _db.reviews.FirstOrDefault(u => u.reviewId == id);
            if (review == null)
            {
                return NotFound();
            }
            _db.reviews.Remove(review);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
