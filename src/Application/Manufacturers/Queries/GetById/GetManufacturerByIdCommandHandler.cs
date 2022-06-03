using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Manufacturers.Queries.GetById;

public class GetManufacturerByIdCommandHandler : IRequestHandler<GetManufacturerByIdQuery, Manufacturer>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<GetManufacturerByIdCommandHandler> _logger;

    public GetManufacturerByIdCommandHandler(IRateMyWineContext context, ILogger<GetManufacturerByIdCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Manufacturer> Handle(GetManufacturerByIdQuery query, CancellationToken cancellationToken)
    {
        var manufacturer = await _context.Manufacturers.FindAsync(new object[] { query.Id }, cancellationToken);

        if (manufacturer == default)
        {
            throw new EntityNotFoundException(nameof(Manufacturer), query.Id);
        }

        return manufacturer;
    }
}
