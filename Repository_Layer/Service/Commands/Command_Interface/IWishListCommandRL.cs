﻿using Model_Layer.RequestModel;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Commands.Command_Interface
{
    public interface IWishListCommandRL
    {
        public Task<WishListEntity> addToWishListAsync(WishListModel wishListModel);
        public Task<WishListEntity> removeFromWishListAsync(int wishListId);
    }
}
