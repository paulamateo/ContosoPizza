using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase {
        private readonly IPizzaService _pizzaService;
        private readonly ICustomerService _customerService;

        public PizzaController(IPizzaService pizzaService, ICustomerService customerService) {
            _pizzaService = pizzaService;
            _customerService = customerService;
        }


        //CUSTOMERS actions
        //GET all action
        [HttpGet]
        public ActionResult<List<User>> GetAllCustomers() =>
            _customerService.GetAll();








        // GET all action
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() =>
            _pizzaService.GetAll();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id) {
            var pizza = _pizzaService.Get(id);

            if (pizza == null)
                return NotFound();

            return pizza;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Pizza pizza) {
            _pizzaService.Add(pizza);
            return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza) {
            if (id != pizza.Id)
                return BadRequest();

            var existingPizza = _pizzaService.Get(id);
            if (existingPizza is null)
                return NotFound();

            _pizzaService.Update(pizza);

            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var pizza = _pizzaService.Get(id);

            if (pizza is null)
                return NotFound();

            _pizzaService.Delete(id);

            return NoContent();
        }
    }
}
