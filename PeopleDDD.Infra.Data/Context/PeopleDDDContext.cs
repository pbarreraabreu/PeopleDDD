using Microsoft.EntityFrameworkCore;
using PeopleDDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDDD.Infra.Data.Context
{
    public class PeopleDDDContext : DbContext
    {
        public PeopleDDDContext(DbContextOptions<PeopleDDDContext> options) : base(options)
        {
        }
        public DbSet<People> Peoples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
