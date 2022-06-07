using MediatR;

namespace Application.Beverages.Queries.GetById;

public class GetBeverageByIdQuery : IRequest<BeverageDetailVm>
{
    public int Id { get; }

    public GetBeverageByIdQuery(int id)
    {
        Id = id;
    }
}