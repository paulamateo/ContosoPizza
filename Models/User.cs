namespace ContosoPizza.Models;

public class User {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Lastname { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public int? PhoneNumber { get; set; }
    public List<Order> Orders { get; set; } = new List<Order>();
    
}