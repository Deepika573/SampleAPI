using EF.Core.Repository.Repository;
using SampleAPIs.Data;
using SampleAPIs.Entities;
using SampleAPIs.Interfaces.Repository;

namespace SampleAPIs.Repository
{
    public class RockstarRepository : CommonRepository<Rockstar>, IRockstarRepository
    {
        private readonly SampleAPIsDbContext _dbContext;

        public RockstarRepository(SampleAPIsDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;

        }

        public bool CreateRockstar(Rockstar rockstar)
        {
            _dbContext.Rockstars.Add(rockstar);
            return Save();
        }

        public List<Rockstar> GetRockstarById(int id)
        {
            var query = (from rockstar in _dbContext.Rockstars
                         where rockstar.RockId == id
                         select rockstar).ToList();
            return query;
        }

        public bool DeleteRockstar(Rockstar rockstar)
        {
            _dbContext.Rockstars.Remove(rockstar);
            return Save();
        }

        public Rockstar GetRockstar(int id)
        {
            return _dbContext.Rockstars.FirstOrDefault(x => x.RockId == id);
        }

        public IQueryable<Rockstar> GetRockstars()
        {
            return _dbContext.Rockstars.AsQueryable();
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateRockstar(Rockstar rockstar)
        {
            _dbContext.Rockstars.Update(rockstar);
            return Save();
        }
    }
}
