using EF.Core.Repository.Repository;
using SampleAPIs.Data;
using SampleAPIs.Entities;
using SampleAPIs.Interfaces.Repository;

namespace SampleAPIs.Repository
{
    public class UserRepository : CommonRepository<Users>, IUserRepository
    {
        private readonly SampleAPIsDbContext _dbContext;

        public UserRepository(SampleAPIsDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateUser(Users user)
        {
            _dbContext.Users.Add(user);
            return Save();
        }

        public bool DeleteUser(Users user)
        {
            _dbContext.Users.Remove(user);
            return Save();
        }

        public Users GetUser(int id)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public Users GetUserName(int id)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Users> GetUsers()
        {
            return _dbContext.Users.AsQueryable();
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }


        public bool UpdateUser(Users user)
        {
            _dbContext.Users.Update(user);
            return Save();
        }
        public List<Users> GetUserByName(string name)
        {          
            var query = (from user in _dbContext.Users
                           where user.UserName == name
                           select user).ToList();  
            return query;
        }
        public List<Users> GetUserByEmail(string email)
        {
            var query = (from user in _dbContext.Users
                         where user.UserEmail == email
                         select user).ToList();
            return query;
        }
        public List<Users> GetUserByPhoneNumber(string pno)
        {
            var query = (from user in _dbContext.Users
                         where user.PhoneNumber == pno
                         select user).ToList();
            return query;
        }
    }
}
