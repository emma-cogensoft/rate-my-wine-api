using Domain.Entities;
using MediatR;

namespace Application.Beverages.Queries.GetList;

public class GetListBeveragesQuery : IRequest<ICollection<Beverage>>
{

}