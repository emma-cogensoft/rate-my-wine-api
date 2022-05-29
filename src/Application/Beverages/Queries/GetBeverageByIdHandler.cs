using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Beverages.Queries;

public class GetBeverageByIdHandler : IRequestHandler<GetBeverageByIdQuery, Beverage>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<GetBeverageByIdHandler> _logger;

    public GetBeverageByIdHandler(IRateMyWineContext context, ILogger<GetBeverageByIdHandler> logger)
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
