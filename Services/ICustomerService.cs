using ContosoPizza.Models;
using ContosoPizza.Data;

namespace ContosoPizza.Services {

    public interface ICustomerService {
        List<User> GetAll();
    }

}