using Api.Requests;
using Application.Manufacturers.Commands;
using AutoMapper;

namespace Api.Profiles;

public class ManufacturerProfile : Profile
{
    public ManufacturerProfile()
    {
        CreateMap<CreateManufacturerRequest, CreateManufacturerCommand>();
        CreateMap<UpdateManufacturerRequest, UpdateManufacturerCommand>();
    }
}