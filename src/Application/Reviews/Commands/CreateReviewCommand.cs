using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.Reviews.Commands;

public class CreateReviewCommand : IRequest<Review>
{
    public int UserId { get; set; }
    public Beverage? Beverage { get; set; }
    public string ReviewText { get; set; } = string.Empty;
    public Rating Rating { get; set; }
}
