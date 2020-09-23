using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STEINBAUERPizzeriaApi.DTOs
{
    public class PizzaDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PizzaDoughType { get; set; }
        public bool IsCalzone { get; set; }
        public string IngredientsList { get; set; }
    }
}
