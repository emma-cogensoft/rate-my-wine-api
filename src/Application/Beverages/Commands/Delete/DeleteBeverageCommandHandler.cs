using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Beverages.Commands.Delete;

public class DeleteBeverageCommandHandler : IRequestHandler<DeleteBeverageCommand>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<DeleteBeverageCommandHandler> _logger;

    public DeleteBeverageCommandHandler(IRateMyWineContext context, ILogger<DeleteBeverageCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteBeverageCommand command, CancellationToken cancellationToken)
    {
        var beverage = await _context.Beverages.SingleOrDefaultAsync(e => command.Id == e.Id, cancellationToken);

        if (beverage == default)
        {
            throw new EntityNotFoundException();
        }

        _context.Beverages.Remove(beverage);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}