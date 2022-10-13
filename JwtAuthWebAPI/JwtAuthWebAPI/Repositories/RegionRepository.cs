using JwtAuthWebAPI.Data;
using JwtAuthWebAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthWebAPI.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly DataDbContext dataDbContext;
        public RegionRepository(DataDbContext dataDbContext)
        {
            this.dataDbContext = dataDbContext;
        }
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await dataDbContext.Regions.ToListAsync();
        }
    }
}
