using FoodAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodAPI.Data
{
    public class ApiDbContext:DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {


        }

        public DbSet<User> users {  get; set; }
        public DbSet<Resturant> resturants { get; set; }
        public DbSet<Dish>dishes { get; set; }
        public DbSet<Review> reviews {  get; set; }

        public DbSet<Order> orders { get; set; }
        public DbSet<OrderedDish> orderedDishes { get; set; }   
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            //modelBuilder.Entity<User>()
            //  .HasOne(r => r.resturants)
            //  .WithOne()
            //  //.HasForeignKey(r => r.UserId)
            //  .OnDelete(DeleteBehavior.NoAction);

            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                    new User { userID = 1,username= "Trung doan", email="trung@gmil.com",address="Wollongong", phoneNumber="62662622",balance=50, cardNumber="1235333",hasSubscription=false, password="trung@123", postcode="2500", role="User" },
                    new User { userID = 2, username = "Sudarshan Khadka", email = "spk@gmil.com", address = "Wollongong", phoneNumber = "071116616", balance = 50, cardNumber = "1555333", hasSubscription = false, password = "spk@123", postcode = "2500", role = "User" }
                
                );
                modelBuilder.Entity<Resturant>().HasData(
                   new Resturant { resturantId = 1, UserId=1, resturantName = "Indika", Description="indian cusine", address="Berry, NSW", averageReview=3, category= "Indian",imageUrl="image goes here",phone="08615151", postcode="2541" },
                   new Resturant { resturantId = 2, UserId=2,resturantName = "KFC", Description="fast foods", address = "Wollongong, NSW", averageReview = 3, category = "American", imageUrl = "image goes here", phone = "04156171", postcode = "2541" }


               );

                modelBuilder.Entity<Dish>().HasData(
                  new Dish { dishId = 1, name="Butter chicken", price=6, ResturantID=1, imageUrl="image url goes here" },
                  new Dish { dishId = 2, name = "Fried Chicken", price = 8, ResturantID = 2, imageUrl = "image url goes here" }




              );
                modelBuilder.Entity<Review>().HasData(
                 new Review { reviewId = 1,reviewContent="very good", star=5, ResturantID=1, UserID=1 },
                  new Review { reviewId = 2, reviewContent = "good", star = 3, ResturantID = 2, UserID = 2 }






             );
            }

    }
}
