using SampleAPIs.Entities;
using SampleAPIs.Interfaces.Bussiness;
using SampleAPIs.Interfaces.Repository;

namespace SampleAPIs.Bussiness
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }
        public bool Add(Users user)
        {
            return _userRepository.Add(user);
        }

        public bool CreateU(Users user)
        {
            return _userRepository.CreateUser(user);
        }

        public bool DeleteU(Users user)
        {
            return _userRepository.DeleteUser(user);
        }

        public Users GetU(int id)
        {
            return _userRepository.GetUser(id);
        }

        public IQueryable<Users> GetUs()
        {
            return _userRepository.GetUsers();
        }

        public bool Save()
        {
            return _userRepository.Save();
        }

        public bool UpdateU(Users user)
        {
            return _userRepository.UpdateUser(user);
        }

        public List<Users> GetUserByN(string name)
        {
            return _userRepository.GetUserByName(name);
        }
        public List<Users> GetUserByE(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }
        public List<Users> GetUserByP(string pno)
        {
            return _userRepository.GetUserByPhoneNumber(pno);
        }
    }
}
