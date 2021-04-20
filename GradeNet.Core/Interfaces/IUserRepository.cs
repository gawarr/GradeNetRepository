﻿using GradeNet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Core.Interfaces
{
    public interface IUserRepository
    {
        UserModel GetUser(int userId);
    }
}
