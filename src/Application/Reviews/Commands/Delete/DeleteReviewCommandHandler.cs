using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Reviews.Commands.Delete;

public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<DeleteReviewCommandHandler> _logger;

    public DeleteReviewCommandHandler(IRateMyWineContext context, ILogger<DeleteReviewCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteReviewCommand command, CancellationToken cancellationToken)
    {
        var review = await _context.Reviews.SingleOrDefaultAsync(e => command.Id == e.Id, cancellationToken);

        if (review == default)
        {
            throw new EntityNotFoundException();
        }

        _context.Reviews.Remove(review);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}