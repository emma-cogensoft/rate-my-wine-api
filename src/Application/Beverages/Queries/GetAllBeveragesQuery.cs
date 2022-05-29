using Domain.Entities;
using MediatR;

namespace Application.Beverages.Queries;

public class GetAllBeveragesQuery : IRequest<ICollection<Beverage>>
{

}