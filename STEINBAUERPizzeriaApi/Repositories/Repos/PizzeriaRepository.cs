using Microsoft.EntityFrameworkCore;
using STEINBAUERPizzeriaApi.Data;
using STEINBAUERPizzeriaApi.Models;
using STEINBAUERPizzeriaApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STEINBAUERPizzeriaApi.Repositories.Repos
{
    public class PizzeriaRepository : IPizzeriaRepository
    {
        private readonly DataContext _context;
        public PizzeriaRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Pizza pizza)
        {
            _context.Set<Pizza>().Add(pizza);
        }

        public void Delete(Pizza pizza)
        {
            _context.Set<Pizza>().Remove(pizza);
        }

        public async Task<IReadOnlyList<Pizza>> GetAllPizzas()
        {
            return await _context.Set<Pizza>().ToListAsync();
        }

        public async Task<Pizza> GetPizza(string pizzaId)
        {
            return await _context.Set<Pizza>().FindAsync(pizzaId);
        }

        public void Update(Pizza pizza)
        {
            _context.Attach(pizza);
            _context.Entry(pizza).State = EntityState.Modified;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public bool Exist(string pizzaId)
        {
            return _context.Pizzas.Any(e => e.Id == pizzaId);
        }
    }
}
