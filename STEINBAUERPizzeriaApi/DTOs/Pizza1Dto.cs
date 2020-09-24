using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STEINBAUERPizzeriaApi.DTOs
{
    public class Pizza1Dto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PizzaDoughType { get; set; }
        public int IsCalzone { get; set; }
        public string IngredientsList { get; set; }
    }
}
