using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.Reviews.Commands.Update;

public class UpdateReviewCommand : IRequest<Review>
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public int BeverageId { get; init; }
    public string ReviewText { get; init; } = string.Empty;
    public Rating Rating { get; init; } = new(-1);
}
