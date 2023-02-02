using Sat.Recruitment.Common.Domain;
using Sat.Recruitment.Manager.Contracts;
using Sat.Recruitment.DataAccess.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Sat.Recruitment.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserDataAccess _userDataAccess;

        public UserManager(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        public async Task CreateUser(User user)
        {
            GiftUser(user);

            await _userDataAccess.CreateUser(user);
        }

        public async Task<bool> GetUser(User user)
        {
            var Registereduser = await _userDataAccess.GetUsers();

            return Registereduser.Any(x => x.Equals(user));
        }

        public async Task<IList<User>> GetUsers()
        {
            return await _userDataAccess.GetUsers();
        }

        private void GiftUser(User newUser)
        {
            decimal percentage = 1;
            bool moreThan100 = newUser.Money > 100M;
            bool moreThan10 = newUser.Money > 10M;
            //
            switch (newUser.UserType)
            {
                case UserType.Normal:
                    percentage = moreThan100 ? 1.12M : moreThan10 ? 1.08M : 1.0M;
                    break;
                case UserType.SuperUser:
                    percentage = moreThan100 ? 1.2M : 1.0M;
                    break;
                case UserType.Premium:
                    percentage = moreThan100 ? 2.0M : 1.0M;
                    break;
                default:
                    break;
            }

            newUser.Money *= percentage;
        }


    }
}
