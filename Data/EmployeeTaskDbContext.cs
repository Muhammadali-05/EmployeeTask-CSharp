using EmployeeTaskCSharp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace EmployeeTaskCSharp.Data
{
    public class EmployeeTaskDbContext : DbContext
    {
        public EmployeeTaskDbContext(DbContextOptions<EmployeeTaskDbContext> options) : base(options)
        {

        }

        public DbSet<Employ> Employ { get; set; }
        public DbSet <Userr> Userr {  get; set; }
        public DbSet <Contact> Contact { get; set;  }


        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employ>()
                .HasKey(e => e.EmployeeId);

            modelBuilder.Entity<Userr>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<Contact>()
                .HasKey(c => c.ContactId);
        }

        
    }
}
