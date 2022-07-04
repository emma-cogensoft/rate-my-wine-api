using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Beverages.Queries.GetList;

public class GetListBeveragesQueryHandler : IRequestHandler<GetListBeveragesQuery, ICollection<Beverage>>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<GetListBeveragesQueryHandler> _logger;

    public GetListBeveragesQueryHandler(IRateMyWineContext context, ILogger<GetListBeveragesQueryHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<ICollection<Beverage>> Handle(GetListBeveragesQuery query, CancellationToken cancellationToken)
    {
        var beverages = 
            await _context
            .Beverages
            .Include(b => b.Manufacturer)
            .ToListAsync(cancellationToken);

        return beverages;
    }
}
