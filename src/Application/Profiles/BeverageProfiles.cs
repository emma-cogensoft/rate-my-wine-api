using Application.Beverages.Commands;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class BeverageProfile : Profile
{
    public BeverageProfile()
    {
        CreateMap<Beverage, CreateBeverageCommand>();
        CreateMap<Beverage, UpdateBeverageCommand>();
    }
}