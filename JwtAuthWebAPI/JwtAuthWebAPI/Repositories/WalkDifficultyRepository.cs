using JwtAuthWebAPI.Data;
using JwtAuthWebAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthWebAPI.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly DataDbContext dataDbContext;

        public WalkDifficultyRepository(DataDbContext dataDbContext)
        {
            this.dataDbContext = dataDbContext;
        }

        public async Task<WalkDifficulty> AddSync(WalkDifficulty walkDifficulty)
        {
            walkDifficulty.Id = Guid.NewGuid();

            await dataDbContext.WalkDifficulty.AddAsync(walkDifficulty);
            await dataDbContext.SaveChangesAsync();

            return walkDifficulty;
        }

        public async Task<WalkDifficulty> DeleteAsync(Guid id)
        {
            var existingWalkDifficulty = await dataDbContext.WalkDifficulty.FindAsync(id);

            if (existingWalkDifficulty != null)
            {
                dataDbContext.WalkDifficulty.Remove(existingWalkDifficulty);
                await dataDbContext.SaveChangesAsync();
                return existingWalkDifficulty;
            }
            return null;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await dataDbContext.WalkDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty> GetAsync(Guid id)
        {
            return await dataDbContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<WalkDifficulty> UpdateSync(Guid id, WalkDifficulty walkDifficulty)
        {
            var existingWalkDifficulty = await dataDbContext.WalkDifficulty.FindAsync(id);
            if (existingWalkDifficulty == null)
            {
                return null;
            }

            existingWalkDifficulty.Code= walkDifficulty.Code;
            await dataDbContext.SaveChangesAsync();

            return existingWalkDifficulty;

        }
    }
}
