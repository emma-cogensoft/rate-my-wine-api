using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Beverages.Queries.GetById;

public class GetBeverageByIdQueryHandler : IRequestHandler<GetBeverageByIdQuery, Beverage>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<GetBeverageByIdQueryHandler> _logger;

    public GetBeverageByIdQueryHandler(IRateMyWineContext context, ILogger<GetBeverageByIdQueryHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Beverage> Handle(GetBeverageByIdQuery query, CancellationToken cancellationToken)
    {
        var beverage = await _context.Beverages.SingleOrDefaultAsync(e => query.Id == e.Id, cancellationToken);

        if (beverage == default)
        {
            throw new EntityNotFoundException();
        }

        return beverage;
    }
}
