using JwtAuthWebAPI.Data;
using JwtAuthWebAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

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
    }
}
