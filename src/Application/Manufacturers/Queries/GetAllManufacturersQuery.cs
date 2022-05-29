using Domain.Entities;
using MediatR;

namespace Application.Manufacturers.Queries;

public class GetAllManufacturersQuery : IRequest<ICollection<Manufacturer>>
{

}