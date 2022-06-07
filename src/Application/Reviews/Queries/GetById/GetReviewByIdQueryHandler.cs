using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Reviews.Queries.GetById;

public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, Review>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<GetReviewByIdQueryHandler> _logger;

    public GetReviewByIdQueryHandler(IRateMyWineContext context, ILogger<GetReviewByIdQueryHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Review> Handle(GetReviewByIdQuery query, CancellationToken cancellationToken)
    {
        var review = await _context.Reviews.SingleOrDefaultAsync(e => query.Id == e.Id, cancellationToken);

        if (review == default)
        {
            throw new EntityNotFoundException();
        }

        return review;
    }
}