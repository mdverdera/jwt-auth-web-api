using JwtAuthWebAPI.Data;
using JwtAuthWebAPI.Models.Domain;

namespace JwtAuthWebAPI.Repositories
{
    public interface IWalkDifficultyRepository
    {
       
        Task<IEnumerable<WalkDifficulty>> GetAllAsync();

        Task<WalkDifficulty> GetAsync(Guid id);

        Task<WalkDifficulty> AddSync(WalkDifficulty walkDifficulty);

        Task<WalkDifficulty> UpdateSync(Guid id,WalkDifficulty walkDifficulty);

        Task<WalkDifficulty> DeleteAsync(Guid id);
    }
}
