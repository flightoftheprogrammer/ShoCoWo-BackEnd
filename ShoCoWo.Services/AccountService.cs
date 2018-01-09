using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoCoWo.Data;

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
    }
}
