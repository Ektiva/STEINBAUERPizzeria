using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using STEINBAUERPizzeriaApi.Data;
using STEINBAUERPizzeriaApi.DTOs;
using STEINBAUERPizzeriaApi.Models;
using STEINBAUERPizzeriaApi.Repositories.Interfaces;
using STEINBAUERPizzeriaApi.Repositories.Repos;

namespace STEINBAUERPizzeriaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private readonly IPizzeriaRepository _pizzeriaRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<PizzasController> _logger;
        public PizzasController(IPizzeriaRepository pizzeriaRepo, IMapper mapper, ILogger<PizzasController> logger)
        {
            _pizzeriaRepo = pizzeriaRepo;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/Pizzas
        //[HttpGet]
        //public async Task<ActionResult<IReadOnlyList<PizzaDto>>> GetPizzas()
        //{
        //    return  Ok(_mapper.Map<PizzaDto>(await _pizzeriaRepo.GetAllPizzas()));
        //}

        // GET: api/Pizzas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaDto>> GetPizza(int id)
        {
            var pizza = await _pizzeriaRepo.GetPizza(id);

            if (pizza == null)
            {
                return NotFound();
            }

            _logger.LogInformation("Hello, {Id}!", id);

            return _mapper.Map<PizzaDto>(pizza);
        }

        // PUT: api/Pizzas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizza(int id, PizzaDto pizzaDto)
        {
            if (id != pizzaDto.Id)
            {
                return BadRequest();
            }
            var pizza = _mapper.Map<Pizza>(pizzaDto);

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
        public async Task<ActionResult<Pizza>> PostPizza(PizzaDto pizzaDto)
        {
            var pizza = _mapper.Map<Pizza>(pizzaDto);
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
