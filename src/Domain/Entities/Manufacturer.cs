namespace Domain.Entities;

public class Manufacturer
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public List<Beverage> Beverages { get; set; } = new();
}