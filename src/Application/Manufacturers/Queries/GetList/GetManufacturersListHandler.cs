using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Manufacturers.Queries.GetList;

public class GetManufacturersListHandler : IRequestHandler<GetManufacturersListQuery, ICollection<Manufacturer>>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<GetManufacturersListHandler> _logger;

    public GetManufacturersListHandler(IRateMyWineContext context, ILogger<GetManufacturersListHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<ICollection<Manufacturer>> Handle(GetManufacturersListQuery query, CancellationToken cancellationToken)
    {
        return await _context.Manufacturers.ToListAsync(cancellationToken);
    }
}
