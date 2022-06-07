using MediatR;

namespace Application.Manufacturers.Commands.Delete;

public class DeleteManufacturerCommand : IRequest
{
    public int Id { get; }

    public DeleteManufacturerCommand(int id)
    {
        Id = id;
    }
}
