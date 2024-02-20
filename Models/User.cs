using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.Models;

public class User {
    [Key]
    public int UserId { get; set; }
    public string? UserName { get; set; }
    public string? UserLastname { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public List<Order> Orders { get; set; } = new List<Order>();
}