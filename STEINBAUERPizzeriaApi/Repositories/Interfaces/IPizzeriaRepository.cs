using STEINBAUERPizzeriaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STEINBAUERPizzeriaApi.Repositories.Interfaces
{
    public interface IPizzeriaRepository
    {
        void Add(Pizza pizza);
        Task<Pizza> GetPizza(string pizzaId);
        Task<IReadOnlyList<Pizza>> GetAllPizzas();
        void Update(Pizza pizza);
        void Delete(Pizza pizza);
        Task<int> Complete();
        bool Exist(string pizzaId);
    }
}
