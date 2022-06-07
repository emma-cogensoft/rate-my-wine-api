using Domain.Entities;
using MediatR;

namespace Application.Manufacturers.Queries.GetById;

public class GetManufacturerByIdQuery : IRequest<Manufacturer>
{
    public int Id { get; }

    public GetManufacturerByIdQuery(int id)
    {
        Id = id;
    }
}
