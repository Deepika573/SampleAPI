using SampleAPIs.Entities;

namespace SampleAPIs.Interfaces.Bussiness
{
    public interface IUserManager
    {
        public List<Users> GetUserByN(string name);
        public List<Users> GetUserByE(string email);
        public List<Users> GetUserByP(string pno);

        bool Add(Users entity);
        IQueryable<Users> GetUs();
        Users GetU(int id);
        bool CreateU(Users user);
        bool UpdateU(Users user);
        bool DeleteU(Users user);
        bool Save();
    }
}
