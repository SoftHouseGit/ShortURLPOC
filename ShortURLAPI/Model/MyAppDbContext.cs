using Microsoft.EntityFrameworkCore;
using ShortURLAPI.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortURLAPI.Model
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions<MyAppDbContext> options)
          : base(options)
        {
        }



        public DbSet<ShortLink> ShortLinks { get; set; }
    }
}
