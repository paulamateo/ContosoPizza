using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoPizza.Models {

    public class User {
        [Key]
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }

}