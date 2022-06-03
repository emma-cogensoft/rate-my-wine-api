using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Beverages.Commands.Create;

public class CreateBeverageCommandHandler : IRequestHandler<CreateBeverageCommand, Beverage>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<CreateBeverageCommandHandler> _logger;

    public CreateBeverageCommandHandler(IRateMyWineContext context, ILogger<CreateBeverageCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Beverage> Handle(CreateBeverageCommand command, CancellationToken cancellationToken)
    {
        var beverage = new Beverage
        {
            ManufacturerId = command.ManufacturerId,
            Name = command.Name
        };

        _context.Beverages.Add(beverage);
        
        await _context.SaveChangesAsync(cancellationToken);
        return beverage;
    }
}