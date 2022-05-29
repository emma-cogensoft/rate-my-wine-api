using Domain.ValueObjects;

namespace Domain.Entities;

public class Review
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public Beverage? Beverage { get; set; }
    public string ReviewText { get; set; } = string.Empty;
    public Rating? Rating { get; set; }
}
