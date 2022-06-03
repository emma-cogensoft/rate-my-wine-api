using Domain.Entities;
using MediatR;

namespace Application.Beverages.Queries.GetById;

public class GetBeverageByIdQuery : IRequest<Beverage>
{
    public int Id { get; set; }
}