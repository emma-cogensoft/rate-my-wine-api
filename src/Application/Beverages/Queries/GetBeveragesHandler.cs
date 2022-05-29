using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Beverages.Queries;

public class GetBeveragesHandler : IRequestHandler<GetAllBeveragesQuery, ICollection<Beverage>>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<GetBeveragesHandler> _logger;

    public GetBeveragesHandler(IRateMyWineContext context, ILogger<GetBeveragesHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<ICollection<Beverage>> Handle(GetAllBeveragesQuery query, CancellationToken cancellationToken)
    {
        var beverages = await _context.Beverages.ToListAsync(cancellationToken);

        return beverages;
    }
}
