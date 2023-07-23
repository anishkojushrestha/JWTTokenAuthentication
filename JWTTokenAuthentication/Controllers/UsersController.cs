using JWTTokenAuthentication.Models;
using JWTTokenAuthentication.Repository.IJWTToken;
using JWTTokenAuthentication.Repository.IUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTTokenAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsers _users;
        private readonly IJWTTokens _jwt;
        public UsersController(IUsers _users, IJWTTokens _jwt)
        {
            this._users = _users;
            this._jwt = _jwt;
        }

        
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_users.GetAll());
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Authenticate")]
        public IActionResult Authenticate(Users users)
        {
            var token = _jwt.Authenticate(users);

            if (token == null)
            {
                return Ok(new { Message = "Unauthorized" });
            }

            return Ok(token);
        }

    }
}
