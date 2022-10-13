using JwtAuthWebAPI.Models.Domain;

namespace JwtAuthWebAPI.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();

    }
}
