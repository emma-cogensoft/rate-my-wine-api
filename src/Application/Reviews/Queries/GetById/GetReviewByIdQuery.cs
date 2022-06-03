using Domain.Entities;
using MediatR;

namespace Application.Reviews.Queries.GetById;

public class GetReviewByIdQuery : IRequest<Review>
{
    public int Id { get; set; }
}
