using FinTransact.AuthAPI.Model;

namespace FinTransact.AuthAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
