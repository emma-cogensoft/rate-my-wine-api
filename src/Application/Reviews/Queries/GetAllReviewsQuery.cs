using Domain.Entities;
using MediatR;

namespace Application.Reviews.Queries;

public class GetAllReviewsQuery : IRequest<ICollection<Review>>
{

}