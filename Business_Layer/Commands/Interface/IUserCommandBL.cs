﻿using Model_Layer.QueryModel;
using Model_Layer.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Commands.Interface
{
    public interface IUserCommandBL
    {
        public Task<UserResponseModel> RegisterUserAsync(UserModel command);
    }
}
