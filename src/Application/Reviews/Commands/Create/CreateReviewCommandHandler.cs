using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Reviews.Commands.Create;

public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, Review>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<CreateReviewCommandHandler> _logger;

    public CreateReviewCommandHandler(IRateMyWineContext context, ILogger<CreateReviewCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Review> Handle(CreateReviewCommand command, CancellationToken cancellationToken)
    {
        var review = new Review
        {
            BeverageId = command.BeverageId,
            Rating = command.Rating,
            ReviewText = command.ReviewText,
            UserId = command.UserId
        };

        _context.Reviews.Add(review);
        
        await _context.SaveChangesAsync(cancellationToken);
        return review;
    }
}