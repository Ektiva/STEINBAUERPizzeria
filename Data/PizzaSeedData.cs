using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using STEINBAUERPizzeria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STEINBAUERPizzeria.Data
{
    public class PizzaSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataContext(
                serviceProvider.GetRequiredService<DbContextOptions<DataContext>>()))
            {
                // Look for any Pizzas.
                if (context.Pizzas.Any())
                {
                    return;   // Data was already seeded
                }

                context.Pizzas.AddRange(
                    new Pizza
                    {
                        Id = 1,
                        Name = "Howie Maui New York Style Pizza",
                        PizzaDoughType = Types.NewYorkStyle,
                        IsCalzone = true,
                        IngredientsList = Ingredients.HOWIE_MAUI
                    },
                    new Pizza
                    {
                        Id = 2,
                        Name = "Howie New York Style Pizza",
                        PizzaDoughType = Types.NewYorkStyle,
                        IsCalzone = false,
                        IngredientsList = Ingredients.HOWIE_SPECIAL
                    },
                    new Pizza
                    {
                        Id = 3,
                        Name = "Veggie Neapolitan Pizza",
                        PizzaDoughType = Types.Neapolitan,
                        IsCalzone = false,
                        IngredientsList = Ingredients.VEGGIE
                    },
                    new Pizza
                    {
                        Id = 4,
                        Name = "Baccon Neapolitan Pizza",
                        PizzaDoughType = Types.Neapolitan,
                        IsCalzone = true,
                        IngredientsList = Ingredients.BACON_CHEDDAR_CHEESEBURGER
                    },
                    new Pizza
                    {
                        Id = 5,
                        Name = "Bbbq Neapolitan Chicken Pizza",
                        PizzaDoughType = Types.Neapolitan,
                        IsCalzone = false,
                        IngredientsList = Ingredients.BBQ_CHICKEN
                    },
                    new Pizza
                    {
                        Id = 6,
                        Name = "Asian Neapolitan Pizza",
                        PizzaDoughType = Types.Neapolitan,
                        IsCalzone = true,
                        IngredientsList = Ingredients.ASIAN_CHICKEN
                    },
                    new Pizza
                    {
                        Id = 7,
                        Name = "Buffalo Chicken Neapolitan Pizza",
                        PizzaDoughType = Types.Neapolitan,
                        IsCalzone = false,
                        IngredientsList = Ingredients.BUFFALO_CHICKEN
                    },
                    new Pizza
                    {
                        Id = 8,
                        Name = "Baccon Sicilian Pizza",
                        PizzaDoughType = Types.Sicilian,
                        IsCalzone = true,
                        IngredientsList = Ingredients.BACON_CHEDDAR_CHEESEBURGER
                    },
                    new Pizza
                    {
                        Id = 9,
                        Name = "Veggie Sicilian Pizza",
                        PizzaDoughType = Types.Sicilian,
                        IsCalzone = false,
                        IngredientsList = Ingredients.VEGGIE
                    },
                    new Pizza
                    {
                        Id = 10,
                        Name = "Howie Sicilian Pizza",
                        PizzaDoughType = Types.Sicilian,
                        IsCalzone = true,
                        IngredientsList = Ingredients.HOWIE_MAUI
                    });

                context.SaveChanges();
            }
        }
    }
}
