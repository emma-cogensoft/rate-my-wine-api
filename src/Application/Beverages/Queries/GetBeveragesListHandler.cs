using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Beverages.Queries;

public class GetBeveragesListHandler : IRequestHandler<GetBeveragesListQuery, ICollection<Beverage>>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<GetBeveragesListHandler> _logger;

    public GetBeveragesListHandler(IRateMyWineContext context, ILogger<GetBeveragesListHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<ICollection<Beverage>> Handle(GetBeveragesListQuery query, CancellationToken cancellationToken)
    {
        var beverages = await _context.Beverages.ToListAsync(cancellationToken);

        return beverages;
    }
}
