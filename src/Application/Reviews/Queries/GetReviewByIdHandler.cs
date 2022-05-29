using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Reviews.Queries;

public class GetReviewByIdHandler : IRequestHandler<GetReviewByIdQuery, Review>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<GetReviewByIdHandler> _logger;

    public GetReviewByIdHandler(IRateMyWineContext context, ILogger<GetReviewByIdHandler> logger)
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
