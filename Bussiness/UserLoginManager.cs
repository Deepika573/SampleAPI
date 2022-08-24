using Microsoft.IdentityModel.Tokens;
using SampleAPIs.Interfaces.Bussiness;
using SampleAPIs.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SampleAPIs.Bussiness
{
    public class UserLoginManager: IUserLoginManager
    {
        private List<UserLogin> _users = new List<UserLogin>
        {
            new UserLogin { Id = 1, UserName = "admin", Password = "admin@123", Role = "admin"},
            new UserLogin { Id = 2, UserName = "deepika", Password = "admin@123", Role = "admin"},
            new UserLogin { Id = 3, UserName = "user", Password = "user@123", Role = "guest"},
            new UserLogin { Id = 4, UserName = "guest", Password = "guest@123", Role = "guest"}
        };

        public string Login(string userName, string password)
        {
            var user = _users.SingleOrDefault(x => x.UserName == userName && x.Password == password);

            // return null if user not found
            if (user == null)
            {
                return string.Empty;
            }

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("This is my secret key");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role)
                }),

                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user.Token;
        }
    }
}
