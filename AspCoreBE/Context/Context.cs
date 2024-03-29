﻿using AspCoreBE.Models;
using Microsoft.EntityFrameworkCore;

namespace AspCoreBE.Context
{
    public class WebCoreContext : DbContext
    {
        public WebCoreContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<UserModel>? Users { get; set; }
    }
}
