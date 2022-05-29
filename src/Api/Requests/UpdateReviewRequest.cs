using Domain.Entities;
using Domain.ValueObjects;

namespace Api.Requests;

public class UpdateReviewRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public Beverage? Beverage { get; set; }
    public string ReviewText { get; set; } = string.Empty;
    public Rating Rating { get; set; }
}