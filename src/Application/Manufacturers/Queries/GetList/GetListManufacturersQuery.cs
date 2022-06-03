using Domain.Entities;
using MediatR;

namespace Application.Manufacturers.Queries.GetList;

public class GetListManufacturersQuery : IRequest<ICollection<Manufacturer>>
{

}