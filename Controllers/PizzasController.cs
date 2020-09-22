using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STEINBAUERPizzeria.Data;
using STEINBAUERPizzeria.DTOs;
using STEINBAUERPizzeria.Models;
using STEINBAUERPizzeria.Repositories.Repos;

namespace STEINBAUERPizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private readonly PizzeriaRepository _pizzeriaRepo;
        private readonly IMapper _mapper;
        public PizzasController(PizzeriaRepository pizzeriaRepo, IMapper mapper)
        {
            _pizzeriaRepo = pizzeriaRepo;
            _mapper = mapper;
        }

        // GET: api/Pizzas
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PizzaDto>>> GetPizzas()
        {
            return  Ok(_mapper.Map<PizzaDto>(await _pizzeriaRepo.GetAllPizzas()));
        }

        // GET: api/Pizzas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaDto>> GetPizza(int id)
        {
            var pizza = await _pizzeriaRepo.GetPizza(id);

            if (pizza == null)
            {
                return NotFound();
            }


            return _mapper.Map<PizzaDto>(pizza);
        }

        // PUT: api/Pizzas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizza(int id, Pizza pizza)
        {
            if (id != pizza.Id)
            {
                return BadRequest();
            }

            _pizzeriaRepo.Update(pizza);

            try
            {
                await _pizzeriaRepo.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pizzas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pizza>> PostPizza(Pizza pizza)
        {
            _pizzeriaRepo.Add(pizza);
            await _pizzeriaRepo.Complete();

            return CreatedAtAction("GetPizza", new { id = pizza.Id }, pizza);
        }

        // DELETE: api/Pizzas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pizza>> DeletePizza(int id)
        {
            var pizza = await _pizzeriaRepo.GetPizza(id);
            if (pizza == null)
            {
                return NotFound();
            }

            _pizzeriaRepo.Delete(pizza);
            await _pizzeriaRepo.Complete();

            return pizza;
        }

        private bool PizzaExists(int id)
        {
            return _pizzeriaRepo.Exist(id);
        }
    }
}
