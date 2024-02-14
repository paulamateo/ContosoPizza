using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Data {

    public class UserEFRepository : IUserRepository {
        private readonly DataContext _context;

        public UserEFRepository(DataContext context) {
            _context = context;
        }

        

    }

}