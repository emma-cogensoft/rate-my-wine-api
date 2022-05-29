using Api.Requests;
using Application.Beverages.Commands;
using AutoMapper;

namespace Api.Profiles;

public class BeverageProfile : Profile
{
    public BeverageProfile()
    {
        CreateMap<CreateBeverageRequest, CreateBeverageCommand>();
        CreateMap<UpdateBeverageRequest, UpdateBeverageCommand>();
    }
}