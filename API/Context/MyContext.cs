using API.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("myConnection") { }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}