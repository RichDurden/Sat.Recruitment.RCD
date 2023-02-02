

using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.DataAccess.Contract;
using Sat.Recruitment.Manager;
using Sat.Recruitment.Manager.Contracts;
using Sat.Recruitment.Test.Mock;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        private IUserManager _userManager;
        public UnitTest1()
        {
            IUserDataAccess dataAccess = new UserDataAccessMock();

            _userManager = new UserManager(dataAccess);
        }


        [Fact]
        public void NewUser_UserCreated()
        {
            var userController = new UsersController(_userManager);

            var result = userController.CreateUser("Mike", "mike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124").Result;


            Assert.True(result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
        }

        [Fact]
        public void NewUser_UserDuplicated()
        {
            var userController = new UsersController(_userManager);

            var result = userController.CreateUser("Agustina", "Agustina@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124").Result;


            Assert.False(result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }

        [Fact]
        public void NewUser_UserDuplicated_ByEmail()
        {
            var userController = new UsersController(_userManager);

            var result = userController.CreateUser("Martha", "Agustina@gmail.com", "Avenida Siempre viva", "+319 11223213123", "Normal", "124").Result;


            Assert.False(result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }

        [Fact]
        public void NewUser_UserDuplicated_ByPhone()
        {
            var userController = new UsersController(_userManager);

            var result = userController.CreateUser("Guillermina", "LolaBautista@gmail.com", "Sin direccion", "+534645213542", "Normal", "124").Result;


            Assert.False(result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }


        [Fact]
        public void NewUser_UserDuplicated_ByNameAndAddress()
        {
            var userController = new UsersController(_userManager);

            var result = userController.CreateUser("Agustina", "Lola@gmail.com", "Garay y Otra Calle", "+35 99999999", "Normal", "124").Result;


            Assert.False(result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }

        [Fact]
        public void NewUser_Badrequest_EmailMissing()
        {
            var userController = new UsersController(_userManager);

            var result = userController.CreateUser("Agustina", "", "Av. Juan G", "+349 1122354215", "Normal", "124").Result;


            Assert.False(result.IsSuccess);
            Assert.Contains("The email is required", result.Errors);
        }

        [Fact]
        public void NewUser_Badrequest_AddressMissing()
        {
            var userController = new UsersController(_userManager);

            var result = userController.CreateUser("Agustina", "Agustina@gmail.com", "", "+349 1122354215", "Normal", "124").Result;


            Assert.False(result.IsSuccess);
            Assert.Contains("The address is required", result.Errors);
        }


        [Fact]
        public void NewUser_Badrequest_NameMissing()
        {
            var userController = new UsersController(_userManager);

            var result = userController.CreateUser("", "", "Av. Juan G", "+349 1122354215", "Normal", "124").Result;


            Assert.False(result.IsSuccess);
            Assert.Contains("The name is required", result.Errors);
        }

        [Fact]
        public void NewUser_Badrequest_PhoneMissing()
        {
            var userController = new UsersController(_userManager);

            var result = userController.CreateUser("Agustina", "Agustina@gmail.com", "", "", "Normal", "124").Result;


            Assert.False(result.IsSuccess);
            Assert.Contains("The phone is required", result.Errors);
        }
    }
}
