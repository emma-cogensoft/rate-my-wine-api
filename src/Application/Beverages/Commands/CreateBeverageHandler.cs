using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Beverages.Commands;

public class CreateBeverageHandler : IRequestHandler<CreateBeverageCommand, Beverage>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<CreateBeverageHandler> _logger;

    public CreateBeverageHandler(IRateMyWineContext context, ILogger<CreateBeverageHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Beverage> Handle(CreateBeverageCommand command, CancellationToken cancellationToken)
    {
        var beverage = new Beverage
        {
            Name = command.Name
        };

        _context.Beverages.Add(beverage);
        
        await _context.SaveChangesAsync(cancellationToken);
        return beverage;
    }
}