using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Manufacturers.Queries;

public class GetManufacturersHandler : IRequestHandler<GetAllManufacturersQuery, ICollection<Manufacturer>>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<GetManufacturersHandler> _logger;

    public GetManufacturersHandler(IRateMyWineContext context, ILogger<GetManufacturersHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<ICollection<Manufacturer>> Handle(GetAllManufacturersQuery query, CancellationToken cancellationToken)
    {
        var manufacturers = await _context.Manufacturers.ToListAsync(cancellationToken);

        return manufacturers;
    }
}
