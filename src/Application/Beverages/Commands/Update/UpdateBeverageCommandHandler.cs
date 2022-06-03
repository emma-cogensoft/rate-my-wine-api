using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Beverages.Commands.Update;

public class UpdateBeverageCommandHandler: IRequestHandler<UpdateBeverageCommand, Beverage>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<UpdateBeverageCommandHandler> _logger;

    public UpdateBeverageCommandHandler(IRateMyWineContext context, ILogger<UpdateBeverageCommandHandler> logger)
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
        
        beverage.ManufacturerId = command.ManufacturerId;
        beverage.Name = command.Name;

        await _context.SaveChangesAsync(cancellationToken);

        return beverage;
    }
}
