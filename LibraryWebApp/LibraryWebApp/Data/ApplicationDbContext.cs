using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using LibraryWebApp.Models;

namespace LibraryWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<LibraryWebApp.Models.BookCategory> BookCategory { get; set; }
        public DbSet<LibraryWebApp.Models.Book> Book { get; set; }
        public DbSet<LibraryWebApp.Models.Address> Address { get; set; }
        public DbSet<LibraryWebApp.Models.Employee> Employee { get; set; }

    }
}
