using Api.Requests;
using Application.Reviews.Commands;
using AutoMapper;

namespace Api.Profiles;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        CreateMap<CreateReviewRequest, CreateReviewCommand>();
        CreateMap<UpdateReviewRequest, UpdateReviewCommand>();
    }
}