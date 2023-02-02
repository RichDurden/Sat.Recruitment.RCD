using Sat.Recruitment.Common.Domain;
using Sat.Recruitment.DataAccess.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Test.Mock
{
    class UserDataAccessMock : IUserDataAccess
    {
        public Task<bool> CreateUser(User user)
        {
            return Task.FromResult(true);
        }

        public Task<IList<User>> GetUsers()
        {
            IList<User> result = new List<User>
            {
                new User
                {
                    Name = "Juan",
                    Email = "Juan@marmol.com",
                    Phone = "+5491154762312",
                    Address = "Peru 2464",
                    UserType = UserType.Normal,
                    Money = 1234M
                },
                new User
                {
                    Name = "Franco",
                    Email = "Franco.Perez@gmail.com",
                    Phone = "+534645213542",
                    Address = "Alvear y Colombres",
                    UserType = UserType.Premium,
                    Money = 112234M
                },
                new User
                {
                    Name = "Agustina",
                    Email = "Agustina@gmail.com",
                    Phone = "+534645213542",
                    Address = "Garay y Otra Calle",
                    UserType = UserType.SuperUser,
                    Money = 1234M
                },
            };

            return Task.FromResult(result);
        }
    }
}
