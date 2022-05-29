using Domain.Entities;
using MediatR;

namespace Application.Manufacturers.Queries;

public class GetManufacturerByIdQuery : IRequest<Manufacturer>
{
    public int Id { get; set; }
}
