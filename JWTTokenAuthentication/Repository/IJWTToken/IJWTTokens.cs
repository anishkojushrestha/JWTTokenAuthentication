using JWTTokenAuthentication.Models;

namespace JWTTokenAuthentication.Repository.IJWTToken
{
    public interface IJWTTokens
    {
        JWTTokens Authenticate(Users users);
    }
}
