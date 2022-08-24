using EF.Core.Repository.Interface.Repository;
using SampleAPIs.Entities;

namespace SampleAPIs.Interfaces.Repository
{
    public interface IUserRepository : ICommonRepository<Users>
    {
        IQueryable<Users> GetUsers();
        Users GetUser(int id);

        public List<Users> GetUserByName(string name);
        public List<Users> GetUserByEmail(string email);
        public List<Users> GetUserByPhoneNumber(string pno);

        bool CreateUser(Users user);
        bool UpdateUser(Users user);
        bool DeleteUser(Users user);
        bool Save();
    }
}
