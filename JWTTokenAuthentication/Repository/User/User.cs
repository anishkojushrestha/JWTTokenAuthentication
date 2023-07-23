using JWTTokenAuthentication.Data;
using JWTTokenAuthentication.Repository.IUser;

namespace JWTTokenAuthentication.Repository.User
{
    public class User : IUsers
    {
        private readonly ApplicationDbContext _context;
        public User(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Models.Users> GetAll()
        {
            return _context.users;
        }
    }
}
