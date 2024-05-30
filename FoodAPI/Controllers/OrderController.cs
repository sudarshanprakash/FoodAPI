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
    public class OrderController : ControllerBase
    {

        private readonly ApiDbContext _db;
        public OrderController(ApiDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        public IActionResult Get()

        {
            var data = (from d in _db.orders
                        
                                   select new OrderpatchDTO()
                                   {
                                       orderId = d.orderId,
                                       Dishes=  d.Dishes,
                                       ResturantId = d.ResturantId,
                                       totalPrice = d.totalPrice,
                                       UserID = d.UserID,
                                       dateTime = d.dateTime,
                                       isDone =d.isDone,
                                       isProcessed=d.isProcessed,
                                       isDelivered = d.isDelivered,
                                       isReady=d.isReady,
                                       driverId=d.driverId,
                                       

                                      
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
            var order = (from d in _db.orders
                         where d.orderId == id
                         select new OrderpatchDTO()

                         {
                             orderId = d.orderId,
                             Dishes = d.Dishes,
                             ResturantId = d.ResturantId,
                             totalPrice = d.totalPrice,
                             UserID = d.UserID,
                             dateTime = d.dateTime,
                             isDone = d.isDone,
                             isProcessed = d.isProcessed,
                             isDelivered = d.isDelivered,
                             isReady = d.isReady,
                             driverId = d.driverId,

                         }).ToList();


            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);


        }

        [HttpGet("searchByRestaurant")]
        public IActionResult SearchOrdersByRestaurant(int restaurantId)
        {
            var orders = _db.orders.Where(o => o.ResturantId == restaurantId).ToList();

            if (orders.Count == 0)
            {
                return NotFound($"No orders found for restaurant with ID {restaurantId}.");
            }

            return Ok(orders);
        }




        [HttpGet("searchByUserId")]
        public IActionResult SearchOrdersByUserID(int userId)
        {
            var orders = _db.orders.Where(o => o.UserID == userId).ToList();

            if (orders.Count == 0)
            {
                return NotFound($"No orders found for restaurant with ID {userId}.");
            }

            return Ok(orders);
        }
        [HttpGet("searchByDriver")]
        public IActionResult SearchOrdersByDriverID(int driverId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var order = (from d in _db.orders
                         where d.driverId == driverId
                         select new OrderpatchDTO()

                         {
                             orderId = d.orderId,
                             Dishes = d.Dishes,
                             ResturantId = d.ResturantId,
                             totalPrice = d.totalPrice,
                             UserID = d.UserID,
                             dateTime = d.dateTime,
                             isDone = d.isDone,
                             isProcessed = d.isProcessed,
                             isDelivered = d.isDelivered,
                             isReady = d.isReady,
                             driverId = d.driverId,
                             resturantName= _db.resturants .Where(r => r.resturantId == d.ResturantId) .Select(r => r.resturantName) .FirstOrDefault()

                         }).ToList();


            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }


        [HttpGet("searchByDuration")]
        public IActionResult SearchOrdersByDuration(DateTime startDateTime, DateTime endDateTime, int resturantId)
        {
            var durationOrders = _db.orders
                 .Where(o => o.ResturantId == resturantId && o.dateTime >= startDateTime && o.dateTime <= endDateTime)
                 .ToList();

            if (durationOrders.Count == 0)
            {
                return NotFound($"No orders found within the specified duration.");
            }

            return Ok(durationOrders);
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderDTO order)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            if (order != null)
            {
                ModelState.Remove("order.orderId");
                Order newOrder = new Order()
                {
                    //orderId= order.orderId,
                    dateTime= DateTime.Now,
                     //Dishes = order.Dishes,
                     //isDone = order.isDone,
                     Dishes= order.Dishes,
                     ResturantId=order.ResturantId,
                     UserID=order.UserID,
                     totalPrice= order.totalPrice, 










                };
                _db.orders.Add(newOrder);
                _db.SaveChanges();
                //return RedirectToAction("Get");
                return Ok(newOrder);
            }
            return NotFound(ModelState);
        }



        [HttpPut("Update/{id:int}", Name = "UpdateOrder")]
        public IActionResult UpdateUser(int id, [FromBody] OrderDTO order)
        {
            if (order == null || id != order.orderId)
            {
                return BadRequest();
            }


            Order newOrder = new Order()
            {
                orderId = order.orderId,
                dateTime = DateTime.Now,
                Dishes = order.Dishes,
                ResturantId = order.ResturantId,
                UserID = order.UserID,
                totalPrice = order.totalPrice
                

            };
            _db.orders.Update(newOrder);
            _db.SaveChanges();

            return Ok(newOrder);

        }

        [HttpPatch]
        public IActionResult partialUpdateResturant(int id, [FromBody] JsonPatchDocument<OrderpatchDTO> patchOrder)


        {
            if (patchOrder == null || id == 0)
            {
                return BadRequest();
            }
            var Order = _db.orders.FirstOrDefault(u => u.orderId == id);

            OrderpatchDTO order = new()
            {
                orderId = Order.orderId,
                Dishes = Order.Dishes,
                isDone = Order.isDone,
                ResturantId = Order.ResturantId,
                UserID = Order.UserID,
                dateTime = DateTime.Now,
                isProcessed = Order.isProcessed,
                isDenied= Order.isDenied,
                isReady= Order.isReady,
                isDelivered= Order.isDelivered, 
                totalPrice =Order.totalPrice

               









            };
            if (Order == null)
            {
                return NotFound();
            }
            patchOrder.ApplyTo(order, ModelState);
            Order model = new()
            {
                orderId = order.orderId,
                dateTime=DateTime.Now,
                isProcessed = order.isProcessed,
                isDenied=order.isDenied,
                isReady = order.isReady,
                isDelivered = order.isDelivered,
                isDone =order.isDone,
                UserID = order.UserID,   
                ResturantId=order.ResturantId,
                Dishes=order.Dishes,
                totalPrice=order.totalPrice,
                

                

               




            };
            _db.orders.Update(model);
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
            var order = _db.orders.FirstOrDefault(u => u.orderId == id);
            if (order == null)
            {
                return NotFound();
            }
            _db.orders.Remove(order);
            _db.SaveChanges();
            return NoContent();
        }

    }
}
