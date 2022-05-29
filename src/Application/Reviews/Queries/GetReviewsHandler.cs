using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Reviews.Queries;

public class GetReviewsHandler : IRequestHandler<GetAllReviewsQuery, ICollection<Review>>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<GetReviewsHandler> _logger;

    public GetReviewsHandler(IRateMyWineContext context, ILogger<GetReviewsHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<ICollection<Review>> Handle(GetAllReviewsQuery query, CancellationToken cancellationToken)
    {
        var reviews = await _context.Reviews.ToListAsync(cancellationToken);

        return reviews;
    }
}
