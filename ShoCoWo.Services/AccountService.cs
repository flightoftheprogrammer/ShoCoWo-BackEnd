using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoCoWo.Data;
using ShoCoWo.Models.User;

namespace ShoCoWo.Services
{
    public class AccountService
    {
        public string GetGuid(string email)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var user =
                    ctx
                        .Users
                        .SingleOrDefault(u => u.Email == email);

                return user?.Id;
            }
        }

        public ICollection<UserListItem> GetAllUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var users =
                    ctx
                        .Users
                        .Select(
                            u => new UserListItem()
                            {
                                UserName = u.UserName,
                                Email = u.Email,
                                UserId = u.Id
                            });

                return users.ToList();
            }
        }
    }
}
