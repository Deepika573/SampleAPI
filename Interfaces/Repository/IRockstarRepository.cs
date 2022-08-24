using EF.Core.Repository.Interface.Repository;
using SampleAPIs.Entities;

namespace SampleAPIs.Interfaces.Repository
{
    public interface IRockstarRepository : ICommonRepository<Rockstar>
    {
        IQueryable<Rockstar> GetRockstars();
        Rockstar GetRockstar(int id);
        bool CreateRockstar(Rockstar rockstar);
        bool UpdateRockstar(Rockstar rockstar);
        bool DeleteRockstar(Rockstar rockstar);
        bool Save();
        public List<Rockstar> GetRockstarById(int id);
    }
}
