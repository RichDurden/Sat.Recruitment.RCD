using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Sat.Recruitment.Common.Domain
{
    public class User : IEquatable<User>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public UserType UserType { get; set; }
        public decimal Money { get; set; }

        public bool Equals([AllowNull] User other)
        {
            if (other is null)
            {
                return false;
            }

            return this.Phone.Equals(other.Phone) || this.Email.Equals(other.Email)
                || (this.Name.Equals(other.Name) && this.Address.Equals(other.Address));
        }
    }
}
