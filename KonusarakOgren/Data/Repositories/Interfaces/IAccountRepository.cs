﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Data.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        bool Login(string username, string password);
    }
}
