using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Data {

    public class PizzaEFRepository : DbContext {
        private readonly DataContext _context;

        public PizzaEFRepository(DataContext context) {
            _context = context;
        }

    }

}