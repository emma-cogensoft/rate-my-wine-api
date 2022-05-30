using Domain.Entities;
using MediatR;

namespace Application.Manufacturers.Queries.GetList;

public class GetManufacturersListQuery : IRequest<ICollection<Manufacturer>>
{

}