using EX_Quessions.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace EX_Quessions.Contexts
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> option) : base(option) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Quession> Quessions { get; set; }
        public DbSet<ResultTesting> ResultTestings { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}
