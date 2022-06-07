using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.Reviews.Commands.Create;

public class CreateReviewCommand : IRequest<Review>
{
    public int UserId { get; set; }
    public int BeverageId { get; set; }
    public string ReviewText { get; set; } = string.Empty;
    public Rating Rating { get; set; } = new(-1);
}
