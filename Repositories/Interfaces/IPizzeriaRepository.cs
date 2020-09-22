using STEINBAUERPizzeria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STEINBAUERPizzeria.Repositories.Interfaces
{
    interface IPizzeriaRepository
    {
        void Add(Pizza pizza);
        Task<Pizza> GetPizza(int pizzaId);
        Task<IReadOnlyList<Pizza>> GetAllPizzas();
        void Update(Pizza pizza);
        void Delete(Pizza pizza);
        Task<int> Complete();
        bool Exist(int pizzaId);
    }
}
