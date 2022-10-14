using JwtAuthWebAPI.Data;
using JwtAuthWebAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace JwtAuthWebAPI.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly DataDbContext dataDbContext;

        public WalkRepository(DataDbContext dataDbContext)
        {
            this.dataDbContext = dataDbContext;
        }

        public async Task<Walk> AddAsync(Walk walk)
        {
            //Assign new ID
            walk.Id=Guid.NewGuid(); 
            await dataDbContext.Walks.AddAsync(walk);
            await dataDbContext.SaveChangesAsync();

            return walk;
        }

        public async Task<Walk> DeleteAsync(Guid id)
        {
            var existingWalk = await dataDbContext.Walks.FindAsync(id);

            if (existingWalk == null)
            {
                return null;
            }

            dataDbContext.Walks.Remove(existingWalk);
            await dataDbContext.SaveChangesAsync();

            return existingWalk;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await dataDbContext.Walks
                .Include(x=> x.Region)
                .Include(x=> x.WalkDifficulty)
                .ToListAsync();
        }

        public async Task<Walk> GetAsync(Guid id)
        {
            var walk = await dataDbContext.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .FirstOrDefaultAsync(x => x.Id == id);
            return walk;
        }

        public async Task<Walk> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await dataDbContext.Walks.FindAsync(id);

            if (existingWalk != null) {
                existingWalk.Length = walk.Length;
                existingWalk.Name=walk.Name;
                existingWalk.WalkDifficultyId=walk.WalkDifficultyId;
                existingWalk.RegionId=walk.RegionId;
                await dataDbContext.SaveChangesAsync();

                return existingWalk;
            }

            return null;
        }
    }
}
