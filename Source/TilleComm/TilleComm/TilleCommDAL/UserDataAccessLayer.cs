using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilleCommModels;

namespace TilleCommDAL
{
    public class UserDataAccessLayer
    {
        public List<UserLogin> _lstUsers = new List<UserLogin>();
        public UserDataAccessLayer()
        {
            _lstUsers.Add(new UserLogin { UserId = 1, Password = "praveen", UserName = "praveen", OrgCode = "INFOSYS" });
            _lstUsers.Add(new UserLogin { UserId = 2, Password = "kumar", UserName = "kumar", OrgCode = "FACEBOOK" });
            _lstUsers.Add(new UserLogin { UserId = 3, Password = "ram", UserName = "ram", OrgCode = "AMAZON" });
            _lstUsers.Add(new UserLogin { UserId = 3, Password = "ravi", UserName = "ravi", OrgCode = "" });
        }
        public UserLogin Login(UserLogin objLogin)
        {
            List<UserLogin> obj = new List<UserLogin>();
            obj = _lstUsers.Where(x => (x.UserName == objLogin.UserName) &&  (x.Password == objLogin.Password)).ToList();
            if (obj.Count == 0)
            {
                objLogin.ErrorCode = "1";
                objLogin.ErrorMessage = "Invalid username/password";
                return objLogin;
            }
            else
            {
                obj[0].ErrorCode = "0";
                obj[0].ErrorMessage = "Login Success";
                return obj[0];
            }
            
        }
        public UserLogin GetUserById(int userId)
        {
            return _lstUsers.FirstOrDefault(x => x.UserId == userId);
        }
    }
}
