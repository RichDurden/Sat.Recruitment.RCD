using Sat.Recruitment.Common.Domain;
using System;

namespace Sat.Recruitment.Common.Utilities
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

        public static string NormalizeEmail(this string email)
        {
            var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            return string.Join("@", new string[] { aux[0], aux[1] });
        }

    }
}
