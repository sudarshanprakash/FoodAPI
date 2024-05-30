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
    public class ResturantController : ControllerBase
    {

        private readonly ApiDbContext _db;
        public ResturantController(ApiDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        public IActionResult Get()

        {
            var data = (from d in _db.resturants

                        select new ResturantViewDTO()
                        {

                            resturantId=d.resturantId,
                            resturantName=d.resturantName,
                            address=d.address,
                            category=d.category,
                            averageReview=d.averageReview,
                            Description=d.Description,
                            imageUrl=d.imageUrl,
                            UserId =d.UserId,
                            phone=d.phone,
                            postcode=d.postcode,
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

            var resturants = (from d in _db.resturants
                         where d.resturantId == id
                         select new ResturantViewDTO()

                         {
                             resturantId = d.resturantId,
                             resturantName = d.resturantName,
                             address = d.address,
                             category = d.category,
                             averageReview = d.averageReview,
                             Description = d.Description,
                             imageUrl = d.imageUrl,
                             UserId = d.UserId,
                             phone = d.phone,
                             postcode = d.postcode,

                         }).ToList();
            if (resturants == null)
            {
                return NotFound();
            }
            return Ok(resturants);


        }


        [HttpGet("search")]
        public IActionResult SearchRestaurants(string keywords)
        {
            if (string.IsNullOrEmpty(keywords))
            {
                return BadRequest("Keywords are required for searching.");
            }

            keywords = keywords.ToLower();

            var matchingRestaurants = _db.resturants
                .Where(r => r.Description.ToLower().Contains(keywords) || r.resturantName.ToLower().Contains(keywords)||r.category.ToLower().Contains(keywords))
                .ToList();

            if (matchingRestaurants.Count == 0)
            {
                return NotFound("No restaurants found matching the provided keywords.");
            }

            return Ok(matchingRestaurants);
        }

        [HttpGet("searchByuserId")]

        public IActionResult GetbyUserID(int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //var users = _db.users.Find(id);

            var resturants = (from d in _db.resturants
                              where d.UserId == userId
                              select new ResturantViewDTO()

                              {
                                  resturantId = d.resturantId,
                                  resturantName = d.resturantName,
                                  address = d.address,
                                  category = d.category,
                                  averageReview = d.averageReview,
                                  Description = d.Description,
                                  imageUrl = d.imageUrl,
                                  UserId = d.UserId,
                                  phone = d.phone,
                                  postcode = d.postcode,

                              }).ToList();
            if (resturants == null)
            {
                return NotFound();
            }
            return Ok(resturants);


        }

        [HttpPost]
        public IActionResult CreateResturant([FromBody] ResturantDTO resturant)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
           
            if (resturant != null)
            {
                ModelState.Remove("resturant.resturantId");
                Resturant newResturant = new Resturant()
                {

                    //resturantId=resturant.resturantId,
                    resturantName = resturant.resturantName,
                    Description = resturant.Description,
                    address = resturant.address,
                    phone = resturant.phone,
                    postcode = resturant.postcode,
                    category = resturant.category,
                    imageUrl = resturant.imageUrl,
                    UserId=resturant.UserId




                };
                _db.resturants.Add(newResturant);
                _db.SaveChanges();
                //return RedirectToAction("Get");
                return Ok(newResturant);
            }
            return NotFound(ModelState);
        }

        [HttpPut("Update/{id:int}", Name = "UpdateResturant")]
        public IActionResult UpdateUser(int id, [FromBody] ResturantDTO resturant)
        {
            if (resturant == null || id != resturant.resturantId)
            {
                return BadRequest();
            }


            Resturant newResturant = new Resturant()
            {
                resturantId=resturant.resturantId,

                resturantName = resturant.resturantName,
                Description=resturant.Description,
                address = resturant.address,
                phone = resturant.phone,
                postcode = resturant.postcode,
                category = resturant.category,
                imageUrl = resturant.imageUrl,
                UserId=resturant.UserId


            };
            _db.resturants.Update(newResturant);
            _db.SaveChanges();

            return Ok(newResturant);

        }

        [HttpPatch]
        public IActionResult partialUpdateResturant(int id, [FromBody] JsonPatchDocument<ResturantDTO> patchResturant)


        {
            if (patchResturant == null || id == 0)
            {
                return BadRequest();
            }
            var Resturant = _db.resturants.FirstOrDefault(u => u.resturantId == id);

            ResturantDTO resturant = new()
            {
                resturantId=Resturant.resturantId,
                resturantName = Resturant.resturantName,
                Description=Resturant.Description,  
                address = Resturant.address,
                phone = Resturant.phone,
                postcode = Resturant.postcode,
                category = Resturant.category,
                imageUrl = Resturant.imageUrl,
                UserId=Resturant.UserId
               

            };
            if (Resturant == null)
            {
                return NotFound();
            }
            patchResturant.ApplyTo(resturant, ModelState);
            Resturant model = new()
            {
                resturantId = resturant.resturantId,

                resturantName = resturant.resturantName,
                Description=resturant.Description,
                address = resturant.address,
                phone = resturant.phone,
                postcode = resturant.postcode,
                category = resturant.category,
                imageUrl = resturant.imageUrl,
                UserId=resturant.UserId 



            };
            _db.resturants.Update(model);
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
            var resturant = _db.resturants.FirstOrDefault(u => u.resturantId == id);
            if (resturant == null)
            {
                return NotFound();
            }
            _db.resturants.Remove(resturant);
            _db.SaveChanges();
            return NoContent();
        }

    }
}


//find resturant search
