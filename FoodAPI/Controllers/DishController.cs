using FoodAPI.Data;
using FoodAPI.DTO;
using FoodAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly ApiDbContext _db;
        public DishController(ApiDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        public IActionResult Get()

        {
           // var data = _db.dishes.ToList();

            var data = (from d in _db.dishes
                     select new DishDTO()
                     {
                       dishId=d.dishId,
                         ResturantID=d.ResturantID,
                        name=d.name,
                         price=d.price,
                        imageUrl=d.imageUrl


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

            var dishes = (from d in _db.dishes
                            where d.dishId == id
                            select new DishDTO()

                            {
                                dishId = d.dishId,
                                ResturantID = d.ResturantID,
                                name = d.name,
                                price = d.price,
                                imageUrl = d.imageUrl
                            }).ToList();
            if (dishes == null)
            {
                return NotFound();
            }
            return Ok(dishes);


        }


        [HttpGet("searchByRestaurant")]
        public IActionResult SearchOrdersByRestaurant(int restaurantId)
        {
            var dishes = _db.dishes.Where(o => o.ResturantID == restaurantId).ToList();

            if (dishes.Count == 0)
            {
                return NotFound($"No orders found for restaurant with ID {restaurantId}.");
            }

            return Ok(dishes);
        }

        [HttpPost]
        public IActionResult CreateDishes([FromBody] DishDTO dish)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            if (dish != null)
            {
                ModelState.Remove("dish.dishID");
                Dish newDish = new Dish()
                {
                  
                    name = dish.name,
                    price = dish.price,
                    ResturantID = dish.ResturantID,
                    imageUrl = dish.imageUrl,







                };
                _db.dishes.Add(newDish);
                _db.SaveChanges();
                //return RedirectToAction("Get");
                return Ok(newDish);
            }
            return NotFound(ModelState);
        }


        [HttpPut("Update/{id:int}", Name = "UpdateDish")]
        public IActionResult UpdateUser(int id, [FromBody] DishDTO dish)
        {
            if (dish == null || id != dish.dishId)
            {
                return BadRequest();
            }


            Dish newDish = new Dish()
            {
                dishId=dish.dishId,
                name = dish.name,
                price = dish.price,
                ResturantID = dish.ResturantID,
                imageUrl = dish.imageUrl,


            };
            _db.dishes.Update(newDish);
            _db.SaveChanges();

            return Ok(newDish);

        }

        [HttpPatch]
        public IActionResult partialUpdateResturant(int id, [FromBody] JsonPatchDocument<DishDTO> patchDish)


        {
            if (patchDish == null || id == 0)
            {
                return BadRequest();
            }
            var Dish = _db.dishes.FirstOrDefault(u => u.dishId == id);

            DishDTO dish = new()
            {
                
                dishId= Dish.dishId,
                name = Dish.name,
                price = Dish.price,
                ResturantID = Dish.ResturantID,
                imageUrl = Dish.imageUrl,





            };
            if (Dish == null)
            {
                return NotFound();
            }
            patchDish.ApplyTo(dish, ModelState);
            Dish model = new()
            {

                dishId = dish.dishId,
                name = dish.name,
                price = dish.price,
                ResturantID = dish.ResturantID,
                imageUrl = dish.imageUrl,
                


            };
            _db.dishes.Update(model);
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
            var dish = _db.dishes.FirstOrDefault(u => u.dishId == id);
            if (dish == null)
            {
                return NotFound();
            }
            _db.dishes.Remove(dish);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
