using JwtAuthWebAPI.Models.Domain;

namespace JwtAuthWebAPI.Repositories
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetAllAsync();

        Task<Walk> GetAsync(Guid id);

        Task<Walk> AddAsync(Walk walk);
    }
}
