using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactListData.Context
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Contact> Contacts { get; set; }
    }
}
