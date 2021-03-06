﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace STEINBAUERPizzeriaApi.Models
{

    public class Pizza
    {
        public string Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Pizza Dough Type")]
        public Types PizzaDoughType { get; set; }
        public bool IsCalzone { get; set; }
        public Ingredients IngredientsList { get; set; }      
    }
}
