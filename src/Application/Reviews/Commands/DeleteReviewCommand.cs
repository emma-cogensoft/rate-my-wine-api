using MediatR;

namespace Application.Reviews.Commands;

public class DeleteReviewCommand : IRequest
{
    public int Id { get; set; }
}
