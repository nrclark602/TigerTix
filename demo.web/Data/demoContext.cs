using Microsoft.EntityFrameworkCore;
using demo.web.Data.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.web.Data
{
    public class demoContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public readonly IConfiguration _config;

        public demoContext (IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:DefaultConnection"]);
        }

    }
}
