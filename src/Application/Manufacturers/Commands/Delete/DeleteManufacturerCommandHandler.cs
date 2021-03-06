using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Manufacturers.Commands.Delete;

public class DeleteManufacturerCommandHandler : IRequestHandler<DeleteManufacturerCommand>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<DeleteManufacturerCommandHandler> _logger;

    public DeleteManufacturerCommandHandler(IRateMyWineContext context, ILogger<DeleteManufacturerCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteManufacturerCommand command, CancellationToken cancellationToken)
    {
        var manufacturer = await _context.Manufacturers.SingleOrDefaultAsync(e => command.Id == e.Id, cancellationToken);

        if (manufacturer == default)
        {
            throw new EntityNotFoundException();
        }

        _context.Manufacturers.Remove(manufacturer);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}