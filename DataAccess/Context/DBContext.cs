using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class CompanyRecordsDBContext : DbContext
    {

        public CompanyRecordsDBContext(DbContextOptions<CompanyRecordsDBContext> options)
      : base(options)
        { }


        public CompanyRecordsDBContext() { }

        public virtual DbSet<Company> Company { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CompanyConfig());
        
        
        }
    }
}
