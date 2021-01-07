using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace STS_AU_NewGen_Siemens
{
    public class UserRepository : IUserInterface
    {

        public Task<decimal> GetEstimationAsync(Gold gold)
        {
            return Task.FromResult(gold.TotalPrice);
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>
            {
                new User() {UserId = 1, UserName = "KumarKovuru", Password = "Siemens", RoleId = 1 },
                new User() { UserId = 2, UserName = "Rakesh", Password = "Siemens", RoleId = 2 }
            };
            return users;
        }
        public List<Role> GetRoles()
        {
            List<Role> roles = new List<Role>
            {
                new Role() {RoleId = 1, Name = "Regular"},
                new Role() { RoleId = 2, Name = "Privilaged"}
            };
            return roles;
        }

        public async Task<object> LoginAsync(User user)
        {
            return await Task.Run(async () =>
            {
                List<User> users = GetUsers();
                if (users.Exists(x => x.UserName == user.UserName && x.Password == user.Password))
                    return CreateToken(users.Where(x => x.UserName == user.UserName).FirstOrDefault());
                else return null;
            });
        }

        private string CreateToken(User userEntity)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("YmKcoPwab_cFFRgteb_#$RgtHYn$8BnsS_Wep");//Currently Hard coded, we can get it from Appsetting.json
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                            new Claim(ClaimTypes.Name, userEntity.UserId.ToString()),
                            new Claim(ClaimTypes.Role, userEntity.RoleId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}
