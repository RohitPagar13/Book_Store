using Microsoft.EntityFrameworkCore;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Context
{
    public class Book_Store_Context:DbContext
    {
        public Book_Store_Context(DbContextOptions options): base(options) { }

        public DbSet<UserEntity>? Users { get; set; }

        public DbSet<BookEntity>? Books { get; set; }

        public DbSet<AdminEntity>? Admins { get; set; }
        public DbSet<UserDetailsEntity>? UsersDetails { get; set; }
    }
}
