using FoodAPI.Data;
using FoodAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {

        private readonly ApiDbContext _db;
        public DeliveryController(ApiDbContext db)
        {
            _db = db;
        }

        
        [HttpPut]
        public IActionResult ProcessOrder(int orderId)
        {
            // Retrieve the order
            Order order = _db.orders.Find(orderId);

            if (order != null && order.isReady) // Check if the order is ready
            {
                // Retrieve the restaurant details
                Resturant restaurant = _db.resturants.Find(order.ResturantId);

                if (restaurant != null)
                {
                    // Find drivers with the same postcode as the restaurant
                    var eligibleDrivers = _db.users.Where(user => user.postcode == restaurant.postcode && user.role == "Driver").ToList();
                    eligibleDrivers = eligibleDrivers.OrderBy(d => Guid.NewGuid()).ToList();

                    if (eligibleDrivers.Any())
                    {
                        // Assign the order to the first available driver
                        var assignedDriver = eligibleDrivers.FirstOrDefault(d => !d.isEngaged);

                        if (assignedDriver != null)
                        {
                            // Update the order with the assigned driver
                            order.driverId = assignedDriver.userID;

                            order.isDispatched = true;

                            // Update the order in the database
                            _db.orders.Update(order);
                            assignedDriver.isEngaged = true;
                            _db.users.Update(assignedDriver);
                            _db.SaveChanges();

                            return Ok(order);
                        }
                        else
                        {
                            return NotFound("No available drivers found."); // Return 404 if no available drivers are found
                        }
                    }
                    else
                    {
                        return NotFound("No eligible drivers found."); // Return 404 if no eligible drivers are found
                    }
                }
            }

            return BadRequest(); // Default response if conditions are not met
        }


    }
}

