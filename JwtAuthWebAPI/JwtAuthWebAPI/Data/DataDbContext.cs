using JwtAuthWebAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthWebAPI.Data
{
    public class DataDbContext: DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options):base(options)
        {

        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulty { get; set; }
    }
}
