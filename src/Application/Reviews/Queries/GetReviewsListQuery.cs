using Domain.Entities;
using MediatR;

namespace Application.Reviews.Queries;

public class GetReviewsListQuery : IRequest<ICollection<Review>>
{

}