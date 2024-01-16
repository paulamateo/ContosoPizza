namespace ContosoPizza.Models;

public class User {
    public string? Name { get; set; }
    public string? Lastname { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public int? PhoneNumber { get; set; }
    public List<Order> Order { get; set; } = new List<Order>();
}