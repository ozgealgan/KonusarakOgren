using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Business.Services.Interfaces
{
    public interface IAccountService
    {
        bool Login(string username, string password);
    }
}
