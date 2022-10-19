using JwtAuthWebAPI.Models.Domain;

namespace JwtAuthWebAPI.Repositories
{
    public interface IUserRepository
    {
        Task< User> AuthenticateAsync(string username, string password);
    }
}
