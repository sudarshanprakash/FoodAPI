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
    public class UserController : ControllerBase
    {
        private readonly ApiDbContext _db;

        public UserController(ApiDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()

        {
            var data = _db.users.ToList();
            return Ok(data);
        }

        // [HttpGet("{id}")]

        [HttpGet("Login")]
        public IActionResult Login(string email, string password )

        {
            var user= _db.users.FirstOrDefault(x => x.email.Equals(email));
            if (user == null)
            {
               return NotFound("the user does not exist");
            }
            if (user.password!=password) {
                return BadRequest("wrong password. Try valid password");


            }
            return Ok(user);

        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var users = _db.users.Find(id);
                        
            // var Menu = _db.Menus.FirstOrDefault(u => u.ItemId == id);
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);


        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDTO user)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            var existinguser = _db.users.FirstOrDefault(u=>u.email==user.email);
            if (existinguser!= null) {
                return BadRequest("The email user has been already resigstered.Please login or create try with a new emal user! ");

            }
            if (user != null)
            {
                ModelState.Remove("user.userId");
                User newUser = new User()
                {
                    //userID=user.userID,
                    username=user.username,
                    email=user.email,
                    password=user.password,
                    address=user.address,
                    phoneNumber=user.phoneNumber,
                    postcode=user.postcode,
                    role=user.role,
                    //balance=user.balance,
                    //cardNumber =user.cardNumber,
                    //createdat= DateTime.Now,


                    

                };
                _db.users.Add(newUser);
                _db.SaveChanges();
                //return RedirectToAction("Get");
                return Ok(newUser);
            }
            return NotFound(ModelState);
        }


        [HttpPut("Update/{id:int}", Name = "UpdateUser")]
        public IActionResult UpdateUser(int id, [FromBody] UserDTO user)
        {
            if (user == null || id != user.userID)
            {
                return BadRequest();
            }
           

            User newUser = new User()
            {

                userID = user.userID,
                username=user.username,
                email=user.email,
                password=user.password,
                address=user.address,
                phoneNumber=user.phoneNumber,
                postcode=user.postcode,
                //balance=user.balance,
                role=user.role,

            };
            _db.users.Update(newUser);
            _db.SaveChanges();

            return Ok(newUser);

        }

        [HttpPut("Subscription/{id:int}", Name = "Subscription")]
        public IActionResult CreateSubscription(int id, [FromBody] CreateSubscriptionDTO user)
        {
            if (user == null )
            {
                return BadRequest();
            }
            var User = _db.users.FirstOrDefault(u => u.userID == id);
            if (User == null)
            {
                return NotFound(ModelState);
            }
            User.hasSubscription=user.hasSubscription;
            User.subscriptionExpirationDate = user.subscriptionExpirationDate.Value;  

            
            _db.users.Update(User);
            _db.SaveChanges();

            return Ok(User);

        }

        [HttpPatch]
        public IActionResult partialUpdateUser(int id, [FromBody]JsonPatchDocument<UserPatchDTO> patchUser)


        {
            if (patchUser == null || id == 0)
            {
                return BadRequest();
            }
            var User = _db.users.FirstOrDefault(u => u.userID == id);

            UserPatchDTO user = new()
            {
                userID=User.userID,
                username=User.username,
                address=User.address,
                phoneNumber=User.phoneNumber,
                postcode=User.postcode,
                role=User.role, 
                balance= User.balance,
                cardNumber=User.cardNumber,
                email=User.email,

                hasSubscription= User.hasSubscription,
                password=User.password,
                subscriptionExpirationDate=User.subscriptionExpirationDate,
                
            };
            if (User == null)
            {
                return NotFound();
            }
            patchUser.ApplyTo(user, ModelState);
            User model = new()
            {
                userID=user.userID,
                username=user.username,
                address=user.address,
                phoneNumber=user.phoneNumber,
                postcode=user.postcode,
                role=user.role,
                balance=user.balance,
                cardNumber=user.cardNumber,
                email=user.email,
                hasSubscription= user.hasSubscription,
                password=user.password,
                subscriptionExpirationDate=user.subscriptionExpirationDate.Value    ,
                
                

            };
            _db.users.Update(model);
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
            var User = _db.users.FirstOrDefault(u => u.userID == id);
            if (User == null)
            {
                return NotFound();
            }
            _db.users.Remove(User);
            _db.SaveChanges();
            return NoContent();
        }


    }
}
