using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Reviews.Queries;

public class GetReviewsListQueryHandler : IRequestHandler<GetReviewsListQuery, ICollection<Review>>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<GetReviewsListQueryHandler> _logger;

    public GetReviewsListQueryHandler(IRateMyWineContext context, ILogger<GetReviewsListQueryHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<ICollection<Review>> Handle(GetReviewsListQuery query, CancellationToken cancellationToken)
    {
        var reviews = await _context.Reviews.ToListAsync(cancellationToken);

        return reviews;
    }
}
