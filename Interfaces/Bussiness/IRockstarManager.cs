using SampleAPIs.Entities;

namespace SampleAPIs.Interfaces.Bussiness
{
    public interface IRockstarManager
    {
        bool Add(Rockstar entity);
        IQueryable<Rockstar> GetRocks();
        Rockstar GetRock(int id);
        bool CreateRock(Rockstar rockstar);
        bool UpdateRock(Rockstar rockstar);
        bool DeleteRock(Rockstar rockstar);
        bool Save();
        public List<Rockstar> GetRockstarByI(int id);
    }
}
