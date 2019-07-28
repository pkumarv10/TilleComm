using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilleCommModels
{
    public class UserLogin
    {
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string OrgCode { get; set; }
        public string Password { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
