using FoodAPI.Data;
using FoodAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FoodAPI.Services
{
    public class DataGenerationService
    {


        private readonly ApiDbContext _db;
        private readonly Random _random = new Random();
        private readonly string[] categories = { "Indian", "Chinese", "Italian", "Mexican", "Korean", "Continental", "Others" };
        private readonly string[] restroImg = { "https://plus.unsplash.com/premium_photo-1674004585426-c6ad2adbe4c0?w=800&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NXx8cmVzdGF1cmFudHxlbnwwfHwwfHx8MA%3D%3D",
            "https://images.unsplash.com/photo-1578474846511-04ba529f0b88?w=800&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTB8fHJlc3RhdXJhbnR8ZW58MHx8MHx8fDA%3D",
            "https://images.unsplash.com/photo-1550966871-3ed3cdb5ed0c?w=800&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTV8fHJlc3RhdXJhbnR8ZW58MHx8MHx8fDA%3D"
            };












        private readonly Dictionary<string, string> dishNameToImageUrl = new Dictionary<string, string>
    {
        { "Pizza", "" },
        { "Burger", "" },
        { "Sushi", "" },
        { "Pasta", "" },
       
       
       
        
    };

        public DataGenerationService(ApiDbContext db)
        {
            _db = db;
        }

        public void GenerateRandomData()
        {
            //if (_db.resturants.Any() || _db.orders.Any())
            //{
            //    return; // Prevent re-seeding if data already exists
            //}

            List<Resturant> restaurants = GenerateRestaurants(2);
            //_db.resturants.AddRange(restaurants);
            //_db.SaveChanges();

            List<Order> orders = GenerateOrders(3, restaurants);
            _db.orders.AddRange(orders);
            _db.SaveChanges();
        }

        private List<Resturant> GenerateRestaurants(int count)
        {
            List<Resturant> restaurants = new List<Resturant>();
           // User randomUser = _db.users.Where(u => u.role.ToLower() == "owner")
               //             .OrderBy(u => Guid.NewGuid())
                     //       .FirstOrDefault();
            for (int i = 0; i < count; i++)
            {
                User randomUser = _db.users
                    .Where(u => u.role.ToLower() == "owner" && !_db.resturants.Any(r => r.UserId == u.userID))
                    .OrderBy(u => Guid.NewGuid())
                    .FirstOrDefault();
                if (randomUser == null)
                {
                    throw new Exception("There are not enough owner users available.");
                }
               
                Resturant restaurant = new Resturant
                {
                    //resturantId = i,
                    resturantName = "Restaurant " + i,
                    Description = "Description " + _random.Next(1000),
                    address = "Address " + _random.Next(1000),
                    //averageReview = _random.NextDouble() * 5,
                    category = categories[_random.Next(categories.Length)],
                    //imageUrl = restroImg[_random.Next(restroImg.Length)],
                    imageUrl = "",
                    phone = _random.Next(100000000, 999999999).ToString(),
                    postcode = _random.Next(2500, 2550).ToString(),
                    UserId = randomUser.userID
                    // Assuming there are at least 10 users
                };
                restaurant.dishes = GenerateDishesForRestaurant(restaurant.resturantId);
                restaurants.Add(restaurant);
                _db.resturants.Add (restaurant);
                _db.SaveChanges();
            }
            return restaurants;
        }

        private List<Dish> GenerateDishesForRestaurant(int restaurantId)
        {
            List<Dish> dishes = new List<Dish>();
            int numberOfDishes = _random.Next(2, 4); // Generate between 5 and 10 dishes for each restaurant

            for (int i = 1; i <= numberOfDishes; i++)
            {
                string dishName = dishNameToImageUrl.Keys.ElementAt(_random.Next(dishNameToImageUrl.Count));
                dishes.Add(new Dish
                {
                    //dishId = _db.Dishes.Count() + i,
                    name = dishName,
                    price = _random.NextDouble() * 20 + 5,
                    //imageUrl = dishNameToImageUrl[dishName],
                    imageUrl = "",
                    ResturantID = restaurantId
                });
            }
            return dishes;
        }

        private List<Order> GenerateOrders(int count, List<Resturant> restaurants)
        {
            List<Order> orders = new List<Order>();
            for (int i = 0; i < count; i++)
            {
                Resturant randomRestaurant = restaurants[_random.Next(restaurants.Count)];
                User randomUser = _db.users.Where(u => u.role.ToLower() == "user")
                            .OrderBy(u => Guid.NewGuid())
                            .FirstOrDefault();
                var orderedDishes = GenerateOrderedDishes(randomRestaurant.resturantId);
                var totalPrice = orderedDishes.Sum(d => d.price * d.quantity);

                Order order = new Order
                {
                    //orderId = i,
                    isProcessed = false,
                    isDenied =false,
                    isReady = false,
                    isDispatched = false,
                    isDelivered = false,
                    isDone = false,
                    dateTime = DateTime.Now,
                    totalPrice = (float)totalPrice,
                    UserID = randomUser.userID,
                    driverId = _random.Next(1, 11),
                    ResturantId = randomRestaurant.resturantId,
                    Dishes = GenerateOrderedDishes(randomRestaurant.resturantId)
                };
                orders.Add(order);
            }
            return orders;
        }


        private ICollection<OrderedDish> GenerateOrderedDishes(int restaurantId)
        {
            List<Dish> dishes = _db.dishes.Where(d => d.ResturantID == restaurantId).ToList();
            List<OrderedDish> orderedDishes = new List<OrderedDish>();

            int dishCount = _random.Next(1, dishes.Count);
            for (int i = 0; i < dishCount; i++)
            {
                Dish randomDish = dishes[_random.Next(dishes.Count)];

                orderedDishes.Add(new OrderedDish
                {
                    dishId = randomDish.dishId,
                    name = randomDish.name,
                    price = randomDish.price,
                    quantity = _random.Next(1, 4)
                });
            }

            return orderedDishes;
        }
    }
}
