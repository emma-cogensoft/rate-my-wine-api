using Domain.Entities;
using MediatR;

namespace Application.Beverages.Queries;

public class GetBeveragesListQuery : IRequest<ICollection<Beverage>>
{

}