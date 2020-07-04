using System;
using System.Collections.Generic;
using System.Text;
using Directory.Core.Invoices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Directory.EntityFramework
{
    public class DirectoryContext : DbContext
    {
        public DirectoryContext(DbContextOptions options) : base(options)
        {}
        
        public DbSet<Invoice> Invoices { set; get; }
    }
}
