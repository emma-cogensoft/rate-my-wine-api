using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Beverages.Queries.GetById;

public class BeverageDetailVm : IMapFrom<Beverage>
{
    public int BeverageId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ManufacturerName { get; set; } = string.Empty;
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Beverage, BeverageDetailVm>()
            .ForMember(m => m.ManufacturerName, d => d.MapFrom(b => b.Manufacturer != null ? b.Manufacturer!.Name : ""))
            .ForMember(m => m.BeverageId, d => d.MapFrom(b => b.Id));
    }
}