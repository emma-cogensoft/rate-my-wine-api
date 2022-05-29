using Domain.Entities;
using MediatR;

namespace Application.Manufacturers.Commands;

public class UpdateManufacturerCommand : IRequest<Manufacturer>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Manufacturer Manufacturer { get; set; } = new Manufacturer();
}
