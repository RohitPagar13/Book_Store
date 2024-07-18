﻿using Model_Layer.RequestModel;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Commands.Interface
{
    public interface IUserDetailsCommandBL
    {
        public Task<UserDetailsEntity> addUserDetailsAsync (UserDetailsClaimsModel command);
    }
}
