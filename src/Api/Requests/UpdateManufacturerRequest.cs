namespace Api.Requests;

public class UpdateManufacturerRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}