﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCore.web.Services
{
    public interface IUserService:IServiceTag
    {
        int GetUserCount();
    }
}
