using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Manufacturers.Queries;

public class GetManufacturerByIdHandler : IRequestHandler<GetManufacturerByIdQuery, Manufacturer>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<GetManufacturerByIdHandler> _logger;

    public GetManufacturerByIdHandler(IRateMyWineContext context, ILogger<GetManufacturerByIdHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Manufacturer> Handle(GetManufacturerByIdQuery query, CancellationToken cancellationToken)
    {
        var manufacturer = await _context.Manufacturers.SingleOrDefaultAsync(e => query.Id == e.Id, cancellationToken);

        if (manufacturer == default)
        {
            throw new EntityNotFoundException();
        }

        return manufacturer;
    }
}
