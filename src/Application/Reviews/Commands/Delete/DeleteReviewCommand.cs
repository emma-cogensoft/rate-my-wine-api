using MediatR;

namespace Application.Reviews.Commands.Delete;

public class DeleteReviewCommand : IRequest
{
    public int Id { get; }

    public DeleteReviewCommand(int id)
    {
        Id = id;
    }
}
