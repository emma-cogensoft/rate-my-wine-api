using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Manufacturers.Queries.GetList;

public class GetListManufacturersQueryHandler : IRequestHandler<GetListManufacturersQuery, ICollection<Manufacturer>>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<GetListManufacturersQueryHandler> _logger;

    public GetListManufacturersQueryHandler(IRateMyWineContext context, ILogger<GetListManufacturersQueryHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<ICollection<Manufacturer>> Handle(GetListManufacturersQuery query, CancellationToken cancellationToken)
    {
        return await _context.Manufacturers.ToListAsync(cancellationToken);
    }
}
