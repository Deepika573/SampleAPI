using SampleAPIs.Entities;
using SampleAPIs.Interfaces.Bussiness;
using SampleAPIs.Interfaces.Repository;

namespace SampleAPIs.Bussiness
{
    public class RockstarManager : IRockstarManager
    {
        private readonly IRockstarRepository _rockstarRepository;
        public RockstarManager(IRockstarRepository rockstarRepository)
        {
            _rockstarRepository = rockstarRepository;

        }
        public bool Add(Rockstar rockstar)
        {
            return _rockstarRepository.Add(rockstar);
        }
        public List<Rockstar> GetRockstarByI(int id)
        {
            return _rockstarRepository.GetRockstarById(id);
        }

        public bool CreateRock(Rockstar rockstar)
        {
            return _rockstarRepository.CreateRockstar(rockstar);
        }

        public bool DeleteRock(Rockstar rockstar)
        {
            return _rockstarRepository.DeleteRockstar(rockstar);
        }

        public Rockstar GetRock(int id)
        {
            return _rockstarRepository.GetRockstar(id);
        }

        public IQueryable<Rockstar> GetRocks()
        {
            return _rockstarRepository.GetRockstars();
        }

        public bool Save()
        {
            return _rockstarRepository.Save();
        }

        public bool UpdateRock(Rockstar rockstar)
        {
            return _rockstarRepository.UpdateRockstar(rockstar);
        }
    }
}
