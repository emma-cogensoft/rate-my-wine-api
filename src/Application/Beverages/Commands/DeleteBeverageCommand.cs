using MediatR;

namespace Application.Beverages.Commands;

public class DeleteBeverageCommand : IRequest
{
    public int Id { get; set; }
}
