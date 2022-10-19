using JwtAuthWebAPI.Models.Domain;

namespace JwtAuthWebAPI.Repositories
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(User use);

    }
}
