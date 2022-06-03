using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Reviews.Queries.GetList;

public class GetListReviewsQueryHandler : IRequestHandler<GetListReviewsQuery, ICollection<Review>>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<GetListReviewsQueryHandler> _logger;

    public GetListReviewsQueryHandler(IRateMyWineContext context, ILogger<GetListReviewsQueryHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<ICollection<Review>> Handle(GetListReviewsQuery query, CancellationToken cancellationToken)
    {
        var reviews = await _context.Reviews.ToListAsync(cancellationToken);

        return reviews;
    }
}
