using Domain.Entities;
using MediatR;

namespace Application.Reviews.Queries.GetList;

public class GetListReviewsQuery : IRequest<ICollection<Review>>
{

}