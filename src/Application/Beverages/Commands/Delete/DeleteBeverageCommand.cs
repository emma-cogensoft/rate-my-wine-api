using MediatR;

namespace Application.Beverages.Commands.Delete;

public class DeleteBeverageCommand : IRequest
{
    public int Id { get; }
    
    public DeleteBeverageCommand(int id)
    {
        Id = id;
    }}
