using MediatR;

namespace Application.Manufacturers.Commands;

public class DeleteManufacturerCommand : IRequest
{
    public int Id { get; set; }
}
