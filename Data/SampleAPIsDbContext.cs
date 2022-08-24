using Microsoft.EntityFrameworkCore;
using SampleAPIs.Entities;

namespace SampleAPIs.Data
{
    public class SampleAPIsDbContext: DbContext
    {
        public SampleAPIsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Rockstar> Rockstars { get; set; }
        public DbSet<Support> Supports { get; set; }

        public DbSet<Users> Users { get; set; }
    }
}
