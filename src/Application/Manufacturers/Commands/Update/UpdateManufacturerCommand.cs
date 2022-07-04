using Domain.Entities;
using MediatR;

namespace Application.Manufacturers.Commands.Update;

public class UpdateManufacturerCommand : IRequest<Manufacturer>
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public Manufacturer Manufacturer { get; set; } = new Manufacturer();
}
