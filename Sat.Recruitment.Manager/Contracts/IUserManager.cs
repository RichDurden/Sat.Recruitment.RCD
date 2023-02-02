using Sat.Recruitment.Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Manager.Contracts
{
    public interface IUserManager
    {
        public Task CreateUser(User user);

        public Task<IList<User>> GetUsers();

        public Task<bool> GetUser(User user); 
    }
}
