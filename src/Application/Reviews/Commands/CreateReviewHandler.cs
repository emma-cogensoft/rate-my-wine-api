using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Reviews.Commands;

public class CreateReviewHandler : IRequestHandler<CreateReviewCommand, Review>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<CreateReviewHandler> _logger;

    public CreateReviewHandler(IRateMyWineContext context, ILogger<CreateReviewHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Review> Handle(CreateReviewCommand command, CancellationToken cancellationToken)
    {
        var review = new Review
        {
          
            Rating = command.Rating,
            ReviewText = command.ReviewText,
            Beverage = command.Beverage,
            UserId = command.UserId
        };

        _context.Reviews.Add(review);
        
        await _context.SaveChangesAsync(cancellationToken);
        return review;
    }
}