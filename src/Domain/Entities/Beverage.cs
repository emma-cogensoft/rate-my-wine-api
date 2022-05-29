namespace Domain.Entities;

public class Beverage
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Manufacturer? Manufacturer { get; set; }

    public Beverage() { }
    public Beverage(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public Beverage(int id, string name, Manufacturer? manufacturer)
    {
        Id = id;
        Name = name;
        Manufacturer = manufacturer;
    }

    public static implicit operator (int Id, string Name, Manufacturer? Manufacturer)(Beverage value)
        => (value.Id, value.Name, value.Manufacturer);

    public static implicit operator Beverage((int Id, string Name, Manufacturer? Manufacturer) value)
        => new(value.Id, value.Name, value.Manufacturer);
}
