using EF.Core.Repository.Repository;
using SampleAPIs.Data;
using SampleAPIs.Entities;
using SampleAPIs.Interfaces.Repository;
using SampleAPIs.Models;

namespace SampleAPIs.Repository
{
    public class SupportRepository : CommonRepository<Support>, ISupportRepository
    {
        private readonly SampleAPIsDbContext _dbContext;

        public SupportRepository(SampleAPIsDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;

        }

        public bool CreateSupport(Support support)
        {
            _dbContext.Supports.Add(support);
            return Save();
        }

        public List<Support> GetSupportById(int id)
        {
            var query = (from support in _dbContext.Supports
                         where support.TicketId == id
                         select support).ToList();
            return query;
        }

        public bool DeleteSupport(Support support)
        {
            _dbContext.Supports.Remove(support);
            return Save();
        }

        public Support GetSupport(int id)
        {
            return _dbContext.Supports.FirstOrDefault(x => x.TicketId == id);
        }

        public Support GetSupportName(int id)
        {
            return _dbContext.Supports.FirstOrDefault(x => x.TicketId == id);
        }

        public IQueryable<Support> GetSupports()
        {
            return _dbContext.Supports.AsQueryable();
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateSupport(Support support)
        {
            _dbContext.Supports.Update(support);
            return Save();
        }
        public List<FullSupport> GetFullSupport(int id)
        {
            var query = (from support in _dbContext.Supports
                         join rockstar in _dbContext.Rockstars
                                         on support.AssignedTo equals rockstar.RockId
                         where support.TicketId == id

                         select new FullSupport() 
                         {
                             TicketId = support.TicketId,
                             RockName = rockstar.RockName,
                             RockEmail= rockstar.RockEmail,
                             RockPhoneNumber = rockstar.RockPhoneNumber,
                         }).ToList();


            return query ;
        }
        public List<Support> SortSupportByCreatedDate()
        {
            var query = (from support in _dbContext.Supports
                         orderby support.CreatedDate
                         select support).ToList();
            return query;
        }
        public List<Support> SortSupportByClosedDate()
        {
            var query = (from support in _dbContext.Supports
                         orderby support.ClosedDate
                         select support).ToList();
            return query;
        }
    }
}
