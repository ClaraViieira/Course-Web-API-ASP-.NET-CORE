using CatalagoApi.Models;

namespace CatalagoApi.Services
{
    public interface ITokenService
    {
        string GerarToken(string key, string issuer, string audience, UserModel user);
    }
}
