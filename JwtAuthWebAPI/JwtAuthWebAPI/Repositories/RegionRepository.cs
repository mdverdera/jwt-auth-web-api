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

        public async Task<Region> AddAsync(Region region)
        {

            region.Id = Guid.NewGuid();
            await dataDbContext.AddAsync(region);
            await dataDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await dataDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region == null)
            {
                return null;
            }


            // Delete the region from database
            dataDbContext.Regions.Remove(region);
            await dataDbContext.SaveChangesAsync();

            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await dataDbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid id)
        {
            var region = await dataDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            return region;
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await dataDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;

            }

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.Area = region.Area;
            existingRegion.Lat =  region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Population = region.Population;

            await dataDbContext.SaveChangesAsync();

            return existingRegion;

        }
    }
}
