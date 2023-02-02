using Sat.Recruitment.Common.Domain;
using Sat.Recruitment.Common.Utilities;
using Sat.Recruitment.DataAccess.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.DataAccess
{
    public class UserDataAccess : IUserDataAccess
    {
        private string _filepath;
        private IList<User> users;
        public UserDataAccess()
        {
            _filepath = Directory.GetCurrentDirectory() + "/Files/Users.txt";
            users = new List<User>();
        }

        public Task<bool> CreateUser(User user)
        {
            lock (_filepath)
            {
                using var reader = StreamFileHelper.GetStrimWriterFromFile(_filepath);
                reader.WriteLineAsync(reader.NewLine + string.Join(",", new string[] { user.Name, user.Email, user.Phone, user.Address, user.UserType.ToString(), user.Money.ToString() })).Wait();
                users.Add(user);
            }
            return Task.FromResult(true);
        }

        public Task<IList<User>> GetUsers()
        {
            lock (_filepath)
            {
                if (users.Count == 0)
                {
                    ReadUsers();
                }
            }
            return Task.FromResult(users);
        }

        private void ReadUsers()
        {
                using var reader = StreamFileHelper.GetStrimReaderFromFile(_filepath);
                while (reader.Peek() >= 0)
                {
                    var line = reader.ReadLineAsync().Result;
                    var user = new User
                    {
                        Name = line.Split(',')[0].ToString(),
                        Email = line.Split(',')[1].ToString(),
                        Phone = line.Split(',')[2].ToString(),
                        Address = line.Split(',')[3].ToString(),
                        UserType = line.Split(',')[4].ToString().ParseUserType(),
                        Money = line.Split(',')[5].ToString().ParseUserMoney(),
                    };

                    users.Add(user);
                }

        }
    }
}
