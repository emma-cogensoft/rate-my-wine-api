using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Manufacturers.Commands;

public class UpdateManufacturerHandler: IRequestHandler<UpdateManufacturerCommand, Manufacturer>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<UpdateManufacturerHandler> _logger;

    public UpdateManufacturerHandler(IRateMyWineContext context, ILogger<UpdateManufacturerHandler> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<Manufacturer> Handle(UpdateManufacturerCommand command, CancellationToken cancellationToken)
    {
        var manufacturer = await _context.Manufacturers.SingleOrDefaultAsync(e => command.Id == e.Id, cancellationToken);

        if (manufacturer == default)
        {
            throw new EntityNotFoundException();
        }
        
        manufacturer.Name = command.Name;

        await _context.SaveChangesAsync(cancellationToken);

        return manufacturer;
    }
}
