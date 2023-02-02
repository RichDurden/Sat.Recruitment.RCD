using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Api.Contracts;
using Sat.Recruitment.Common.Domain;
using Sat.Recruitment.Common.Utilities;
using Sat.Recruitment.Manager;
using Sat.Recruitment.Manager.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("api/Users")]
    public partial class UsersController : ControllerBase
    {

        //private readonly List<User> _users = new List<User>();
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser(string name, string email, string address, string phone, string userType, string money)
        {
            if (ValidateErrors(name, email, address, phone, out string errors))
            {
                return new Result()
                {
                    IsSuccess = false,
                    Errors = errors
                };
            }

            var newUser = new User
            {
                Name = name,
                Email = email.NormalizeEmail(),
                Address = address,
                Phone = phone,
                UserType = userType.ParseUserType(),
                Money = money.ParseUserMoney()
            };

            if (await _userManager.GetUser(newUser))
            {
                return new Result()
                {
                    IsSuccess = false,
                    Errors = "The user is duplicated"
                };
            }

            await _userManager.CreateUser(newUser);

            Debug.WriteLine("User Created");

            return new Result()
            {
                IsSuccess = true,
                Errors = "User Created"
            };


        }

        private bool ValidateErrors(string name, string email, string address, string phone, out string errors)
        {
            var validationErrors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(name))
                //Validate if Name is null
                validationErrors.Append("The name is required");
            if (string.IsNullOrWhiteSpace(email))
                //Validate if Email is null
                validationErrors.Append(" The email is required");
            if (string.IsNullOrWhiteSpace(address))
                //Validate if Address is null
                validationErrors.Append(" The address is required");
            if (string.IsNullOrWhiteSpace(phone))
                //Validate if Phone is null
                validationErrors.Append(" The phone is required");

            errors = validationErrors.ToString();

            return errors != string.Empty;
        }

        //Validate errors

    }
}
