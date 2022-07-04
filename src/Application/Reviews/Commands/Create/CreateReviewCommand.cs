using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.Reviews.Commands.Create;

public class CreateReviewCommand : IRequest<Review>
{
    public int UserId { get; init; }
    public int BeverageId { get; init; }
    public string ReviewText { get; init; } = string.Empty;
    public Rating Rating { get; init; } = new(-1);
}
