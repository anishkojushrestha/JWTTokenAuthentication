using JWTTokenAuthentication.Data;
using JWTTokenAuthentication.Models;
using JWTTokenAuthentication.Repository.IJWTToken;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTTokenAuthentication.Repository.JWTToken
{
    public class JWTToken : IJWTTokens
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public JWTToken(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public Models.JWTTokens Authenticate(Users users)
        {
            if(!_context.users.Any(x=>x.UserName == users.UserName && x.Password == users.Password))
            {
                return null;
            }
            var tokenhandler = new JwtSecurityTokenHandler();
            var tkey = Encoding.UTF8.GetBytes(_configuration["JWTToken:key"]);
            var ToeknDescp = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, users.UserName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tkey), SecurityAlgorithms.HmacSha256Signature)
            };
            var toekn = tokenhandler.CreateToken(ToeknDescp);

            return new JWTTokens { Token = tokenhandler.WriteToken(toekn) };
        }
    }
}
