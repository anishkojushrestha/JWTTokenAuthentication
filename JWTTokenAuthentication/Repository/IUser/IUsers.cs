using JWTTokenAuthentication.Models;

namespace JWTTokenAuthentication.Repository.IUser
{
    public interface IUsers
    {
        IEnumerable<Users> GetAll();
        
    }
}
