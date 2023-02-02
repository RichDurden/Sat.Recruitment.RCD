using Sat.Recruitment.Common.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Recruitment.DataAccess.Contract
{
    public interface IUserDataAccess
    {
        public Task<bool> CreateUser(User user);

        public Task<IList<User>> GetUsers();

    }
}
