using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilleComm.Models;
using TilleCommModels;

namespace TilleComm.BusinessServvice.Interfaces
{
    public interface ILoginBusinessService
    {
        Task<UserLogin> Login(UserLogin user);
    }
}
