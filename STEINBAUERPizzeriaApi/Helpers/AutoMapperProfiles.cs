using AutoMapper;
using STEINBAUERPizzeriaApi.DTOs;
using STEINBAUERPizzeriaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STEINBAUERPizzeriaApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            var ingredientsDict = new Dictionary<string, string>() 
            {
                { "HOWIE_MAUI", "Pineapple Pizza with ham, bacon, pineapple & mozzarella cheese." },
                { "BBQ_CHICKEN", "Sweet BBQ sauce, grilled chicken breast, bacon, red onions & mozzarella cheese."},
                { "HOWIE_SPECIAL", "Pepperoni, ham, mushrooms, red onions, green peppers & mozzarella cheese."},
                { "VEGGIE", "Mushrooms, red onions, green peppers, tomatoes, black olives & mozzarella cheese."},
                { "CHICKEN_BACON_RANCH", "Grilled chicken breast, bacon & mozzarella cheese with ranch dressing."},
                { "BACON_CHEDDAR_CHEESEBURGER", "Ground beef, bacon, mozzarella & cheddar cheese."},
                { "BUFFALO_CHICKEN", "Spicy buffalo sauce, grilled chicken breast, red onions, mozzarella & cheddar cheese."},
                { "ASIAN_CHICKEN", "Tangy Asian sauce, grilled chicken breast, red onions, green peppers, sesame seeds & mozzarella cheese."},
            };

            var pizzaTypeDict = new Dictionary<string, string>()
            {
                { "NewYorkStyle", "New York Style" },
                { "Neapolitan", "Neapolitan" },
                { "Sicilian", "Sicilian" },
            };

            var isCalzoneDict = new Dictionary<string, int>()
            {
                { "true", 1 },
                { "false", 0 }
            };

            CreateMap<Pizza, PizzaDto>()
                .ForMember(pizzadto => pizzadto.IngredientsList, opt =>
                {
                    opt.MapFrom(pizza => ingredientsDict[pizza.IngredientsList.ToString()]);
                })
                .ForMember(pizzadto => pizzadto.PizzaDoughType, opt =>
                {
                    opt.MapFrom(pizza => pizzaTypeDict[pizza.PizzaDoughType.ToString()]);
                });
            CreateMap<Pizza, Pizza1Dto>()
                .ForMember(pizzadto => pizzadto.IngredientsList, opt =>
                {
                    opt.MapFrom(pizza => ingredientsDict[pizza.IngredientsList.ToString()]);
                })
                .ForMember(pizzadto => pizzadto.PizzaDoughType, opt =>
                {
                    opt.MapFrom(pizza => pizzaTypeDict[pizza.PizzaDoughType.ToString()]);
                })
                .ForMember(pizzadto => pizzadto.IsCalzone, opt =>
                 {
                     opt.MapFrom(pizza => isCalzoneDict[pizza.IsCalzone.ToString()]);
                 });

            CreateMap<Pizza1Dto, Pizza>();

            CreateMap<PizzaDto, Pizza>()
                //.ForMember(pizza => pizza.IngredientsList, opt =>
                //{
                //    opt.MapFrom(pizzadto => ingredientsDict.FirstOrDefault(x => x.Value == pizzadto.IngredientsList).Key);
                //})
                //.ForMember(pizza => pizza.PizzaDoughType, opt =>
                //{
                //    opt.MapFrom(pizzadto => pizzaTypeDict.FirstOrDefault(x => x.Value == pizzadto.PizzaDoughType).Key);
                //})
                ;
        }
    }
}
