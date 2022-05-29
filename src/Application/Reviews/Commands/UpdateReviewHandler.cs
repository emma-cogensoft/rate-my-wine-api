using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Reviews.Commands;

public class UpdateReviewHandler: IRequestHandler<UpdateReviewCommand, Review>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<UpdateReviewHandler> _logger;

    public UpdateReviewHandler(IRateMyWineContext context, ILogger<UpdateReviewHandler> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<Review> Handle(UpdateReviewCommand command, CancellationToken cancellationToken)
    {
        var review = await _context.Reviews.SingleOrDefaultAsync(e => command.Id == e.Id, cancellationToken);

        if (review == default)
        {
            throw new EntityNotFoundException();
        }
        
        review.Rating = command.Rating;
        review.ReviewText = command.ReviewText;
        review.Beverage = command.Beverage;
        review.UserId = command.UserId;

        await _context.SaveChangesAsync(cancellationToken);

        return review;
    }
}
