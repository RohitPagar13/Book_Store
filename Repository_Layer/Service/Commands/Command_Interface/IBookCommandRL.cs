﻿using Model_Layer.RequestModel;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Commands.Command_Interface
{
    public interface IBookCommandRL
    {
        public Task<BookEntity> AddBookAsync(BookEntity book);
        public Task<BookEntity> UpdateBookAsync(BookEntity book);

        public Task<BookEntity> DeleteBookAsync(int bookId);
    }
}
