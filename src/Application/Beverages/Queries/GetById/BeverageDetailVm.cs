using Application.Mappings;
using Domain.Entities;

namespace Application.Beverages.Queries.GetById;

public class BeverageDetailVm : IMapFrom<Beverage>
{
    public int BeverageId { get; set; }
    public string BeverageName { get; set; } = string.Empty;
    public string ManufacturerName { get; set; } = string.Empty;
}