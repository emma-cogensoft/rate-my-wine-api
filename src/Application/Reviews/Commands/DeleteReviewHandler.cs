using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Reviews.Commands;

public class DeleteReviewHandler : IRequestHandler<DeleteReviewCommand>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<DeleteReviewHandler> _logger;

    public DeleteReviewHandler(IRateMyWineContext context, ILogger<DeleteReviewHandler> logger)
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