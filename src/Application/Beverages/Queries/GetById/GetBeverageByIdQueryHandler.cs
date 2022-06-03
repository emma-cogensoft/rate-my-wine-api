using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Beverages.Queries.GetById;

public class GetBeverageByIdQueryHandler : IRequestHandler<GetBeverageByIdQuery, BeverageDetailVm>
{
    private readonly IRateMyWineContext _context;
    private readonly ILogger<GetBeverageByIdQueryHandler> _logger;
    private readonly IMapper _mapper;

    public GetBeverageByIdQueryHandler(IRateMyWineContext context, ILogger<GetBeverageByIdQueryHandler> logger, IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<BeverageDetailVm> Handle(GetBeverageByIdQuery query, CancellationToken cancellationToken)
    {
        var beverage = await _context.Beverages
            .Include(e => e.Manufacturer)
            .ProjectTo<BeverageDetailVm>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(e => query.Id == e.BeverageId, cancellationToken);

        if (beverage == default)
        {
            throw new EntityNotFoundException();
        }

        return beverage;
    }
}
