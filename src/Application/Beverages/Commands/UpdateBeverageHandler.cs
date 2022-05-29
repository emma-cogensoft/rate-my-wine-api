using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Beverages.Commands;

public class UpdateBeverageHandler: IRequestHandler<UpdateBeverageCommand, Beverage>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<UpdateBeverageHandler> _logger;

    public UpdateBeverageHandler(IRateMyWineContext context, ILogger<UpdateBeverageHandler> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<Beverage> Handle(UpdateBeverageCommand command, CancellationToken cancellationToken)
    {
        var beverage = await _context.Beverages.SingleOrDefaultAsync(e => command.Id == e.Id, cancellationToken);

        if (beverage == default)
        {
            throw new EntityNotFoundException();
        }
        
        beverage.Name = command.Name;

        await _context.SaveChangesAsync(cancellationToken);

        return beverage;
    }
}
