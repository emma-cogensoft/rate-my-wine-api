using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Manufacturers.Commands.Create;

public class CreateManufacturerCommandHandler : IRequestHandler<CreateManufacturerCommand, int>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<CreateManufacturerCommandHandler> _logger;

    public CreateManufacturerCommandHandler(IRateMyWineContext context, ILogger<CreateManufacturerCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<int> Handle(CreateManufacturerCommand command, CancellationToken cancellationToken)
    {
        var manufacturer = new Manufacturer
        {
            Name = command.Name
        };

        _context.Manufacturers.Add(manufacturer);
        
        await _context.SaveChangesAsync(cancellationToken);
        return manufacturer.Id;
    }
}