using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Manufacturers.Commands.Update;

public class UpdateManufacturerCommandHandler: IRequestHandler<UpdateManufacturerCommand, Manufacturer>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<UpdateManufacturerCommandHandler> _logger;

    public UpdateManufacturerCommandHandler(IRateMyWineContext context, ILogger<UpdateManufacturerCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public async Task<Manufacturer> Handle(UpdateManufacturerCommand command, CancellationToken cancellationToken)
    {
        var manufacturer = await _context.Manufacturers.FindAsync(new object[] { command.Id }, cancellationToken);

        if (manufacturer == default)
        {
            throw new EntityNotFoundException(nameof(Manufacturer), command.Id);
        }
        
        manufacturer.Name = command.Name;

        await _context.SaveChangesAsync(cancellationToken);

        return manufacturer;
    }
}
