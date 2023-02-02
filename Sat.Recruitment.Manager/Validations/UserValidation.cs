using Sat.Recruitment.Common.Domain;
using System;

namespace Sat.Recruitment.Manager.Validations
{
    public static class UserExtensionParser
    {
        public static UserType ParseUserType(this string userType)
        {
            if (Enum.TryParse(userType, out UserType newUserType))
            {
                return newUserType;
            }
            return UserType.Normal;
        }

        public static decimal ParseUserMoney(this string userMoney)
        {
            if (decimal.TryParse(userMoney, out decimal result))
            {
                return result;
            }
            return 0M;
        }

    }
}
