using System.Collections.ObjectModel;

namespace Domain.Entities;

public class Manufacturer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IReadOnlyCollection<Beverage> Beverages { get; set; } = new Collection<Beverage>();
}