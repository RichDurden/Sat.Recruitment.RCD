using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Contracts
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string Errors { get; set; }
    }
}
