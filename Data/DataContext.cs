using Microsoft.EntityFrameworkCore;
using STEINBAUERPizzeria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STEINBAUERPizzeria.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }

        public DbSet<Pizza> Pizzas { get; set; }
    }
}
