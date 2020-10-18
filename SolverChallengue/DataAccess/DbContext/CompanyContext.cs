using Microsoft.EntityFrameworkCore;
using SolverChallengue.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolverChallengue.DataAccess.DbContext
{
    public class CompanyContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) 
            : base(options)
        {
        }

        public DbSet<Record> Records { get; set; }
    }
}
