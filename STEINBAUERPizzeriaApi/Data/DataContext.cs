using Microsoft.EntityFrameworkCore;
using STEINBAUERPizzeriaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STEINBAUERPizzeriaApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }

        public DbSet<Pizza> Pizzas { get; set; }
    }
}
